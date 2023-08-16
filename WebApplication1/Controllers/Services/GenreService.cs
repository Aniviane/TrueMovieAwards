using WebApplication1.Controllers.Services.Interfaces;
using WebApplication1.Data;
using WebApplication1.Data.DTO;
using WebApplication1.Data.Models;

namespace WebApplication1.Controllers.Services
{
    public class GenreService : IGenre
    {
        private DataContext context;

        public GenreService(DataContext dataContext)
        {
            context = dataContext;
        }
        public GenreDTO AddGenre(GenreDTO genre)
        {
            var a = new Genre(genre);

            context.Genres.Add(a);

            context.SaveChanges();

            return new GenreDTO(a);


        }




        public void DeleteGenre(long id)
        {
            var a = context.Genres.Find(id);
            if (a != null)
            {
                context.Genres.Remove(a);
                context.SaveChanges();
            }

        }

        public GenreDTO GetGenre(long id)
        {
            var a = context.Genres.Find(id);
            if (a != null)
                return new GenreDTO(a);
            else
                return null;
        }

        public List<GenreDTO> GetGenres()
        {
            var Genres = context.Genres.ToList<Genre>();
            var ret = new List<GenreDTO>();
            if (Genres != null)
                foreach (var a in Genres)
                {
                    ret.Add(new GenreDTO(a));
                }

            return ret;
        }

        public GenreDTO AddMovie(GenreMovieDTO genreMovieDTO)
        {
            var genre = context.Genres.Find(genreMovieDTO.GenreId);

            var movie = context.Movies.Find(genreMovieDTO.MovieId);

            if (genre == null || movie == null) return null;

            if (genre.Movies.Contains(movie)) return null;
            genre.Movies.Add(movie);

            context.SaveChanges();

            return new GenreDTO(genre);

        }

        public GenreDTO UpdateGenre(GenreDTO Genre)
        {
            var ac = context.Genres.Find(Genre.ID);
            if (ac != null)
            {
                ac.FName = Genre.FName;
               

                context.SaveChanges();

                return new GenreDTO(ac);
            }

            return null;

        }
    }
}
