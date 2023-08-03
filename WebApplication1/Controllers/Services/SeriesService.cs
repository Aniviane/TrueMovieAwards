using WebApplication1.Controllers.Services.Interfaces;
using WebApplication1.Data.DTO;
using WebApplication1.Data.Models;
using WebApplication1.Data;

namespace WebApplication1.Controllers.Services
{
    public class SeriesService : ISeries
    {
        private DataContext context;

        public SeriesService(DataContext dataContext)
        {
            context = dataContext;
        }
        public SeriesDTO AddSeries(SeriesDTO series)
        {
            var a = new Series(series);

            context.Series.Add(a);

            context.SaveChanges();

            return new SeriesDTO(a);


        }

        public SeriesDTO AddMovie(SeriesDTO series)
        {
            var Series = context.Series.Find(series.ID);
            if (Series == null) return null;
            if (series.Movies == null) return null;
            foreach(var mov in series.Movies)
            {
                var movie = context.Movies.Find(mov.ID);
                if (movie == null) continue;
                if (movie.Series != null) continue;
                if (Series.Movies.Contains(movie)) continue;
                Series.Movies.Add(movie);
            }

            context.SaveChanges();

            return new SeriesDTO(Series);

        }



        public void DeleteSeries(long id)
        {
            var a = context.Series.Find(id);
            if (a != null)
            {
                context.Series.Remove(a);
                context.SaveChanges();
            }

        }

        public SeriesDTO GetSeries(long id)
        {
            var a = context.Series.Find(id);
            if (a != null)
                return new SeriesDTO(a);
            else
                return null;
        }

        public List<SeriesDTO> GetSeries()
        {
            var Series = context.Series.ToList();
            var ret = new List<SeriesDTO>();
            if (Series != null)
                foreach (var a in Series)
                {
                    ret.Add(new SeriesDTO(a));
                }

            return ret;
        }

        public SeriesDTO UpdateSeries(SeriesDTO series)
        {
            var Series = context.Series.Find(series.ID);
            if (Series != null)
            {

                Series.FName = series.FName;
               

                context.SaveChanges();

                return new SeriesDTO(Series);
            }

            return null;

        }
    }
}
