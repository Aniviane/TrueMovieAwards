using WebApplication1.Controllers.Services.Interfaces;
using WebApplication1.Data.DTO;
using WebApplication1.Data.Models;
using WebApplication1.Data;

namespace WebApplication1.Controllers.Services
{
    public class StudioService : IStudio
    {
        private DataContext context;

        public StudioService(DataContext dataContext)
        {
            context = dataContext;
        }
        public StudioDTO AddStudio(StudioDTO Studio)
        {
            var st = new Studio(Studio);

            context.Studios.Add(st);

            context.SaveChanges();

            return new StudioDTO(st);


        }




        public void DeleteStudio(long id)
        {
            var st = context.Studios.Find(id);
            if (st != null)
            {
                context.Studios.Remove(st);
                context.SaveChanges();
            }

        }

        public StudioDTO GetStudio(long id)
        {
            var st = context.Studios.Find(id);
            if (st != null)
                return new StudioDTO(st);
            else
                return null;
        }

        public List<StudioDTO> GetStudios()
        {
            var Studio = context.Studios.ToList();
            var ret = new List<StudioDTO>();
            if (Studio != null)
                foreach (var a in Studio)
                {
                    ret.Add(new StudioDTO(a));
                }

            return ret;
        }

        public StudioDTO AddMovie(StudioDTO studio)
        {
            var Studio = context.Studios.Find(studio.ID);
            if (Studio == null) return null;
            if (Studio.Movies == null) return null;
            foreach (var mov in studio.Movies)
            {
                var movie = context.Movies.Find(mov.ID);
                if (movie == null) continue;
                if (movie.Studio != null) continue;
                if (Studio.Movies.Contains(movie)) continue;
                Studio.Movies.Add(movie);
            }

            context.SaveChanges();

            return new StudioDTO(Studio);

        }



        public StudioDTO UpdateStudio(StudioDTO studio)
        {
            var Studio = context.Studios.Find(studio.ID);
            if (Studio != null)
            {

                Studio.Name = studio.Name;
                Studio.Description = studio.Description;
                Studio.Photo = studio.Photo;
                


                context.SaveChanges();

                return new StudioDTO(Studio);
            }

            return null;

        }
    }
}
