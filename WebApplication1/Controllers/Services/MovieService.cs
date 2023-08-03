using Microsoft.CodeAnalysis.CSharp.Syntax;
using WebApplication1.Controllers.Services.Interfaces;
using WebApplication1.Data;
using WebApplication1.Data.DTO;
using WebApplication1.Data.Models;

namespace WebApplication1.Controllers.Services
{
    public class MovieService : IMovie
    {
        private DataContext context;

        public MovieService(DataContext dataContext)
        {
            context = dataContext;
        }
        public MovieDTO AddMovie(MovieDTO movie)
        {
            var mov = new Movie(movie);

            if (movie.Genres != null)
            {
                foreach(var genre in movie.Genres)
                {
                    var g = context.Genres.Find(genre.ID);
                    if (g == null) continue;
                    mov.Genres.Add(g);

                }
            }

            if (movie.Roles != null)
            {
                foreach (var role in movie.Roles)
                {
                    var actor = context.Actors.Find(role.Actor.ID);
                    if (actor == null) continue;
                    var movieRole = new Role();
                    movieRole.FName = role.FName;
                    movieRole.LName = role.LName;
                    movieRole.Actor = actor;
                    movieRole.Movie = mov;
                    
                    mov.Roles.Add(movieRole);

                }
            }

            if(movie.Producings != null)
            {
                foreach(var producing in movie.Producings)
                {
                    var producer = context.Producers.Find(producing.Producer.ID);
                    if (producer == null) continue;
                    var producingMovie = new ProducingMovie();
                    producingMovie.Movie = mov;
                    producingMovie.Producer = producer;
                    mov.Producings.Add(producingMovie);
                }
            }

            if(movie.Series != null)
            {
                var series = context.Series.Find(movie.Series.ID);
                if (series != null)
                    mov.Series = series;
                else
                    mov.Series = null;
            }

            if (movie.Studio != null)
            {
                var studio = context.Studios.Find(movie.Studio.ID);
                if (studio != null)
                    mov.Studio = studio;
                else
                    mov.Studio = null;
            }


            context.Movies.Add(mov);

            context.SaveChanges();

            return new MovieDTO(mov);


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
                mov.Photo = Movie.Photo;    
                

                context.SaveChanges();

                return new MovieDTO(mov);
            }

            return null;

        }
    }
}
