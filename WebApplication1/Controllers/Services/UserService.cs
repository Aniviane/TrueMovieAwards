using Microsoft.Extensions.Configuration.UserSecrets;
using WebApplication1.Controllers.Services.Interfaces;
using WebApplication1.Data;
using WebApplication1.Data.DTO;
using WebApplication1.Data.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Castle.Core.Internal;
using BCrypt.Net;

namespace WebApplication1.Controllers.Services
{
    public class UserService : IUser
    {

        private DataContext context;


        private readonly IHttpContextAccessor _httpContextAccessor;

        private string serverPath = "https://localhost:7133";

        public UserService(DataContext dataContext, IHttpContextAccessor httpContextAccessor)
        {
            context = dataContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public void DeleteUser(long id)
        {
            var user = context.Users.Find(id);
            if (user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
            }
        }

        public void FavSomething(FavoriseDTO favoriseDTO)
        {
            // long userId = 3; //temp untill JWT is implemented

            if (_httpContextAccessor == null) return;
            long userId = long.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.SerialNumber));
            var user = context.Users.Find(userId);
            if (user == null) return;
            if (favoriseDTO.Mode == "Movie") {

                var movie = context.Movies.Find(favoriseDTO.ID);
                if (movie == null) return;
                if (user.FavMovies.Contains(movie)) return;

                user.FavMovies.Add(movie);


                context.SaveChanges();
                return;

            }
            if (favoriseDTO.Mode == "Producer") {

                var producer = context.Producers.Find(favoriseDTO.ID);
                if (producer == null) return;


                if (user.FavProducers.Contains(producer)) return;
                user.FavProducers.Add(producer);


                context.SaveChanges();
                return;
            }
            if (favoriseDTO.Mode == "Actor") {

                var actor = context.Actors.Find(favoriseDTO.ID);
                if (actor == null) return;

                if (user.FavActors.Contains(actor)) return;
                user.FavActors.Add(actor);


                context.SaveChanges();
                return;

            }
        }

        public UserDTO GetUser(long id)
        {
            var ret = context.Users.Find(id);
            if (ret != null)
                return new UserDTO(ret);
            return null;
        }


        public void UpdateNotify(long id)
        {
            if (_httpContextAccessor == null || _httpContextAccessor.HttpContext == null) return;
            long userId = long.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.SerialNumber));

            var notify = context.Notifies.Find(userId, id);

            if (notify == null) return;
            notify.Seen = true;

            context.SaveChanges();


        }


        public List<UserDTO> GetUsers()
        {
            var users = context.Users.ToList();

            var ret = new List<UserDTO>();
            if (users != null)
            {
                foreach (var u in users)
                {
                    ret.Add(new UserDTO(u));
                }
                return ret;
            }
            return null;
        }


        public UserDTO Login(UserLoginDTO userDTO)
        {
            var ret = context.Users.Where(o => o.Username == userDTO.Username).FirstOrDefault();
            if (ret == null) return null;

            

            

            if (!BCrypt.Net.BCrypt.Verify(userDTO.Password,ret.Password)) return null;




            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Role, ret.UType));
            claims.Add(new Claim(ClaimTypes.SerialNumber, ret.ID.ToString()));
            SymmetricSecurityKey secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("TrueMovieAwardsTrueMovieAwardsTrueMovieAwardsTrueMovieAwards"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokenOptions = new JwtSecurityToken(
                issuer: "https://localhost:7133/",
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: signinCredentials
                ); ;
            string token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);


            var user = new UserDTO(ret);
            user.Token = token;

            return user;





        }

        public UserDTO Register(UserCreateDTO user)
        {
            
         
            if (user != null && user.UPhoto != null && user.UPhoto.Length > 0)
            {

                var folderName = DateTime.Now.ToString("yyyyMMddHHmmssfff");

                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Pictures", "Users", folderName);

                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                var imageExtension = Path.GetExtension(user.UPhoto.FileName);

                var imageName = "image" + imageExtension;

                var imagePath = Path.Combine(folderPath, imageName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    user.UPhoto.CopyTo(stream);
                }




                var u = new User(user);
                u.UPhoto = serverPath + "/Pictures/Users/" + folderName + "/" + imageName;
                var passHash = BCrypt.Net.BCrypt.HashPassword(user.Password);
                u.Password = passHash;

                context.Users.Add(u);

                context.SaveChanges();



                var ret = new UserDTO(u);

                List<Claim> claims = new List<Claim>();

                claims.Add(new Claim(ClaimTypes.Role, ret.UType));
                claims.Add(new Claim(ClaimTypes.SerialNumber, ret.ID.ToString()));
                SymmetricSecurityKey secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("TrueMovieAwardsTrueMovieAwardsTrueMovieAwardsTrueMovieAwards"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokenOptions = new JwtSecurityToken(
                    issuer: "https://localhost:7133/",
                    claims: claims,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: signinCredentials
                    ); ;
                string token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);



                ret.Token = token;






                return ret;


            }


            return null;






        }

        public UserDTO RegisterModerator(UserLoginDTO dto)
        {
            var user = new User();

            user.Username = dto.Username;
            user.Password = dto.Password.GetHashCode().ToString();
            user.FName = "";
            user.LName = "";
            user.EMail = "";
            user.UType = "Moderator";
            user.Bio = "";
            user.UPhoto = "";

            if (_httpContextAccessor == null || _httpContextAccessor.HttpContext == null) return null;
            long adminId = long.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.SerialNumber));

            var admin = context.Users.Find(adminId);

            user.Admin = admin;

            context.Users.Add(user);
            context.SaveChanges();
            return new UserDTO(user);
        }
        public void UpdatePhoto(PhotoUpdateDTO photoUpdateDTO)
        {
            long id = long.Parse(photoUpdateDTO.ID);

            var user = context.Users.Find(id);

            if (user == null) return;
            if (user.UPhoto != "")
            {

                var photoPath = user.UPhoto;

                var relativePath = photoPath.Replace(serverPath, "");

                var absolutePath = Directory.GetCurrentDirectory() + relativePath;

                absolutePath = absolutePath.Replace("/", "\\");

                if (photoUpdateDTO.Photo != null && photoUpdateDTO.Photo.Length > 0)
                {
                    if (File.Exists(absolutePath))
                        File.Delete(absolutePath);


                    var folderName = DateTime.Now.ToString("yyyyMMddHHmmssfff");

                    var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Pictures", "Users", folderName);

                    if (!Directory.Exists(folderPath))
                        Directory.CreateDirectory(folderPath);

                    var imageExtension = Path.GetExtension(photoUpdateDTO.Photo.FileName);

                    var imageName = "image" + imageExtension;

                    var imagePath = Path.Combine(folderPath, imageName);



                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {

                        photoUpdateDTO.Photo.CopyTo(stream);
                    }


                    user.UPhoto = serverPath + "/Pictures/Users/" + folderName + "/" + imageName;

                    context.SaveChanges();

                }


            }
            else
            {

                var folderName = DateTime.Now.ToString("yyyyMMddHHmmssfff");

                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Pictures", "Users", folderName);

                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                var imageExtension = Path.GetExtension(photoUpdateDTO.Photo.FileName);

                var imageName = "image" + imageExtension;

                var imagePath = Path.Combine(folderPath, imageName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    photoUpdateDTO.Photo.CopyTo(stream);
                }




                user.UPhoto = serverPath + "/Pictures/Users/" + folderName + "/" + imageName;

                context.SaveChanges();

            }
        }




        public UpReviewDTO LeaveReview(UpReviewDTO reviewDTO)
        {
            //long userId = 3; //untill JWT
            if (_httpContextAccessor == null || _httpContextAccessor.HttpContext== null) return null;
            long userId = long.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.SerialNumber));

            var revs = context.Reviews.Any(r => r.UserId == userId && r.MovieId == reviewDTO.Movie.ID);
            if (revs) return null;

            var user = context.Users.Find(userId);

            var movie = context.Movies.Find(reviewDTO.Movie.ID);

            var rev = new Review(reviewDTO);

            rev.Reviewer = user;
            rev.Movie = movie;


            var temp = movie.RevGrade * movie.RevCount;

            var grade = (temp + reviewDTO.Grade) / (movie.RevCount + 1);
            movie.RevGrade = grade;
            movie.RevCount++;
            context.Reviews.Add(rev);
            context.SaveChanges();

            return new UpReviewDTO(rev);




        }

        public UserDTO UpdateUser(UserDTO User)
        {
            //long userId = 3; // untill JWT

            if (_httpContextAccessor == null || _httpContextAccessor.HttpContext == null) return null;

            long userId = long.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.SerialNumber));
            var user = context.Users.Find(userId);
            if (user == null) return null;
            user.Username = User.Username;
            user.FName = User.FName;
            user.LName = User.LName;
            user.Bio = User.Bio;
            user.EMail = User.EMail;

            context.SaveChanges();

            return new UserDTO(user);

        }



        public void DeleteReview(long id)
        {
            var rev = context.Reviews.Find(id);

            if (rev == null) return;

            var movie = context.Movies.Find(rev.MovieId);

            if (movie == null) return;

            var oldRevGrade = movie.RevGrade * movie.RevCount;
            if (movie.RevCount <= 1)
            {
                movie.RevCount = 0;
                movie.RevGrade = 0;
            }
            else
            {
                movie.RevCount = movie.RevCount - 1;

                movie.RevGrade = (oldRevGrade - rev.Grade) / movie.RevCount;
            }

            context.Reviews.Remove(rev);

            context.SaveChanges();
        }

        public UpReviewDTO UpdateReview(UpReviewDTO reviewDTO) {

            var rev = context.Reviews.Find(reviewDTO.ID);

            if (rev == null) return null;

           

            if (reviewDTO.Grade != rev.Grade)
            {

                var movie = context.Movies.Find(rev.MovieId);

                var oldRevGrade = movie.RevGrade * movie.RevCount;

                var newRevGrade = oldRevGrade - rev.Grade + reviewDTO.Grade;

                movie.RevGrade = newRevGrade / movie.RevCount;


            }

            rev.Description = reviewDTO.Description;

            rev.Grade = reviewDTO.Grade;

            context.SaveChanges();

            return new UpReviewDTO(rev);



        }

        public WatchListDTO AddToWatchlist(long movieId)
        {
            if (_httpContextAccessor == null || _httpContextAccessor.HttpContext == null) return null;

            long userId = long.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.SerialNumber));
            var user = context.Users.Find(userId);
            if (user == null) return null;

            var wl = context.WatchLists.Find(user.WatchList.ID);

            if (wl == null) return null;

            var movie = context.Movies.Find(movieId);

            if (movie == null) return null;

            wl.Movies.Add(movie);

            context.SaveChanges();

            return new WatchListDTO(wl);

        }

    }
}
