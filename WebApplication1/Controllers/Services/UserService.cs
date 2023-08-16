using Microsoft.Extensions.Configuration.UserSecrets;
using WebApplication1.Controllers.Services.Interfaces;
using WebApplication1.Data;
using WebApplication1.Data.DTO;
using WebApplication1.Data.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebApplication1.Controllers.Services
{
    public class UserService : IUser
    {

        private DataContext context;


        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(DataContext dataContext, IHttpContextAccessor httpContextAccessor)
        {
            context = dataContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public void DeleteUser(long id)
        {
            var user = context.Users.Find(id);
            if(user != null)
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
            if(favoriseDTO.Mode == "Movie") {

                var movie = context.Movies.Find(favoriseDTO.ID);
                if (movie == null) return;
                if (user.FavMovies.Contains(movie)) return;

                user.FavMovies.Add(movie);


                context.SaveChanges();
                return;
            
            }
            if(favoriseDTO.Mode == "Producer") {

                var producer = context.Producers.Find(favoriseDTO.ID);
                if (producer == null) return;


                if (user.FavProducers.Contains(producer)) return;
                user.FavProducers.Add(producer);


                context.SaveChanges();
                return;
            }
            if(favoriseDTO.Mode == "Actor") {

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
            var rets = context.Users.Where(o => o.Username == userDTO.Username);
            if (rets == null) return null;

            var ret = rets.First();
            if (ret == null)
                return null;
            if (ret.Username != userDTO.Username || ret.Password != userDTO.Password) return null;

            


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

        public UserDTO Register(UserDTO user)
        {
            var userTemp = new User(user);

            context.Users.Add(userTemp);

            context.SaveChanges();

            var ret = new UserDTO(userTemp);

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






            return  ret;


        }


        public UpReviewDTO LeaveReview(UpReviewDTO reviewDTO)
        {
            //long userId = 3; //untill JWT
            if (_httpContextAccessor == null) return null;
            long userId = long.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.SerialNumber));
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
                          
            if (_httpContextAccessor == null) return null;

            long userId = long.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.SerialNumber));
            var user = context.Users.Find(userId);
            if (user == null) return null;
            user.Username = User.Username;
            user.FName = User.FName;
            user.LName = User.LName;
            user.Bio = User.Bio;
            user.EMail = User.EMail;
            user.UPhoto = User.UPhoto;

            context.SaveChanges();

            return new UserDTO(user);

        }
    }
}
