using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Net.Mime;
using WebApplication1.Controllers.Services.Interfaces;
using WebApplication1.Data;
using WebApplication1.Data.DTO;
using WebApplication1.Data.Models;

namespace WebApplication1.Controllers.Services
{
    public class MovieService : IMovie
    {
        private DataContext context;

        private string serverPath = "https://localhost:7133";

        public MovieService(DataContext dataContext)
        {
            context = dataContext;
        }
        public MovieDTO AddMovie(MovieCreateDTO movie)
        {
            

            if (movie != null && movie.Photo != null && movie.Photo.Length > 0)
            {
                var folderName = DateTime.Now.ToString("yyyyMMddHHmmssfff");

                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Pictures", "Movies", folderName);

                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                var imageExtension = Path.GetExtension(movie.Photo.FileName);

                var imageName = "image" + imageExtension;

                var imagePath = Path.Combine(folderPath, imageName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    movie.Photo.CopyTo(stream);
                }




                var mov = new Movie(movie);
                mov.Photo = serverPath + "/Pictures/Movies/" + folderName + "/" + imageName;

                mov.RevCount = 0;
                mov.RevGrade = 0;
                if(movie.Genres != null)
                foreach(var genre in movie.Genres)
                {
                        if (genre == null) continue;
                   long id = long.Parse(genre);

                   var Genre = context.Genres.Find(id);

                   if (Genre != null)
                   mov.Genres.Add(Genre);
                        
                }
                if(movie.Roles!=null)
                foreach(var role in movie.Roles)
                {
                        if (role == null) continue;
                    var actor = context.Actors.Find(long.Parse(role.ActorID));

                    if (actor == null) continue;
                    

                      var Role = new Role();

                      Role.Actor = actor;
                      Role.Movie = mov;
                      Role.FName = role.FName;
                      Role.LName = role.LName;

                      mov.Roles.Add(Role);
                    
                }
                if(movie.Producings != null)
                foreach(var producing in movie.Producings)
                {
                        if (producing == null) continue;
                    var id = long.Parse(producing);

                    var producer = context.Producers.Find(id);

                    if (producer == null) continue;

                    var Producing = new ProducingMovie();
                    Producing.Movie = mov;
                    Producing.Producer = producer;

                    mov.Producings.Add(Producing);

                }

               
                
                long seriesId = long.Parse(movie.SeriesId);
                if (seriesId != 0)
                {
                    var series = context.Series.Find(seriesId);
                    if (series == null) mov.Series = null;
                    else
                    mov.Series = series;


                }
                else mov.Series = null;

                long studioId = long.Parse(movie.StudioId);
                if (studioId != 0)
                {
                    var studio = context.Studios.Find(studioId);
                    if (studio == null) mov.Series = null;
                    else
                    mov.Studio = studio;


                }
                else mov.Studio = null;

                Console.WriteLine("Movie created with Path " + mov.Photo);

                context.Movies.Add(mov);

                context.SaveChanges();

                return new MovieDTO(mov);

            }


            return null;
        }




        public void DeleteMovie(long id)
        {
            var mov = context.Movies.Find(id);
            if (mov != null)
            {
                context.Movies.Remove(mov);
                context.SaveChanges();
            }

        }

        public MovieDTO GetMovie(long id)
        {
            var mov = context.Movies.Find(id);
            if (mov != null)
                return new MovieDTO(mov);
            else
                return null;
        }

        public List<DownProducingMovieDTO> GetProducings()
        {
            var producings = context.Producings.ToList();
            if (producings == null) return null;
            var ret = new List<DownProducingMovieDTO>();
            foreach (var pr in producings)
                ret.Add(new DownProducingMovieDTO(pr));

            return ret;

        }


        public void UpdatePhoto(PhotoUpdateDTO photoUpdateDTO)
        {
            long id = long.Parse(photoUpdateDTO.ID);

            var movie = context.Movies.Find(id);

            if (movie == null) return;
            if (movie.Photo != "")
            {

                var photoPath = movie.Photo;

                var relativePath = photoPath.Replace(serverPath, "");

                var absolutePath = Directory.GetCurrentDirectory() + relativePath;

                absolutePath = absolutePath.Replace("/", "\\");

                if (photoUpdateDTO.Photo != null && photoUpdateDTO.Photo.Length > 0)
                {
                    if (File.Exists(absolutePath))
                        File.Delete(absolutePath);


                    var folderName = DateTime.Now.ToString("yyyyMMddHHmmssfff");

                    var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Pictures", "Movies", folderName);

                    if (!Directory.Exists(folderPath))
                        Directory.CreateDirectory(folderPath);

                    var imageExtension = Path.GetExtension(photoUpdateDTO.Photo.FileName);

                    var imageName = "image" + imageExtension;

                    var imagePath = Path.Combine(folderPath, imageName);



                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {

                        photoUpdateDTO.Photo.CopyTo(stream);
                    }


                    movie.Photo = serverPath + "/Pictures/Movies/" + folderName + "/" + imageName;

                    context.SaveChanges();
                }


            }
            else
            {

                var folderName = DateTime.Now.ToString("yyyyMMddHHmmssfff");

                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Pictures", "Movies", folderName);

                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                var imageExtension = Path.GetExtension(photoUpdateDTO.Photo.FileName);

                var imageName = "image" + imageExtension;

                var imagePath = Path.Combine(folderPath, imageName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    photoUpdateDTO.Photo.CopyTo(stream);
                }




                movie.Photo = serverPath + "/Pictures/Movies/" + folderName + "/" + imageName;

                context.SaveChanges();

            }
        }

        public List<MovieDTO> GetMovies()
        {
            var Movies = context.Movies.ToList();
            var ret = new List<MovieDTO>();
            if (Movies != null)
                foreach (var a in Movies)
                {
                    ret.Add(new MovieDTO(a));
                }

            return ret;
        }


        public List<DownRoleDTO> GetRoles()
        {
            var roles = context.Roles.ToList();
            var ret = new List<DownRoleDTO>();
            if (roles != null)
                foreach (var role in roles)
                    ret.Add(new DownRoleDTO(role));
            return ret;
        }

        public MovieDTO UpdateMovie(MovieDTO Movie)
        {
            var mov = context.Movies.Find(Movie.ID);
            if (mov != null)
            {
                mov.Description = Movie.Description;
                mov.Title = Movie.Title;
                mov.DateOfRelease = Movie.DateOfRelease;
                 
                

                context.SaveChanges();

                return new MovieDTO(mov);
            }

            return null;

        }

        public void DeleteRole(long id)
        {
            var role = context.Roles.Find(id);

            if (role == null) return;

            context.Roles.Remove(role);

            context.SaveChanges();
        }

        public void DeleteProducing(DownProducingMovieDTO dto)
        {
            var producing = context.Producings.Find(dto.Movie.ID, dto.Producer.ID);

            if (producing == null) return;

            context.Producings.Remove(producing);

            context.SaveChanges();
        }

        public RightRoleDTO UpdateRole(RightRoleDTO dto)
        {
            var role = context.Roles.Find(dto.ID);

            if (role == null) return null;

            role.FName = dto.FName;
            role.LName = dto.LName;

            context.SaveChanges();

            return new RightRoleDTO(role);
        }
    }
}
