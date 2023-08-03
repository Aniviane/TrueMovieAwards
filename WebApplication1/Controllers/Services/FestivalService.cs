using WebApplication1.Data.DTO;
using WebApplication1.Data.Models;
using WebApplication1.Data;
using WebApplication1.Controllers.Services.Interfaces;

namespace WebApplication1.Controllers.Services
{
    public class FestivalService : IFestival
    {

        private DataContext context;

        public FestivalService(DataContext dataContext)
        {
            context = dataContext;
        }
        public FestivalDTO AddFestival(FestivalDTO Festival)
        {
            var fes = new Festival(Festival);

            context.Festivals.Add(fes);

            context.SaveChanges();

            return new FestivalDTO(fes);


        }

        public void DeleteFestival(long id)
        {
            var fes = context.Festivals.Find(id);
            if (fes != null)
            {
                context.Festivals.Remove(fes);
                context.SaveChanges();
            }

        }

        public FestivalDTO GetFestival(long id)
        {
            var fes = context.Festivals.Find(id);
            if (fes != null)
                return new FestivalDTO(fes);
            else
                return null;
        }

        public List<FestivalDTO> GetFestivals()
        {
            var Festivals = context.Festivals.ToList<Festival>();
            var ret = new List<FestivalDTO>();
            if (Festivals != null)
                foreach (var a in Festivals)
                {
                    ret.Add(new FestivalDTO(a));
                }

            return ret;
        }




        public FestivalDTO UpdateFestival(FestivalDTO Festival)
        {
            var fes = context.Festivals.Find(Festival.ID);
            if (fes != null)
            {
                fes.Description = Festival.Description;
                fes.Name = Festival.Name;
                fes.Photo = Festival.Photo;

                

                context.Entry(fes).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                context.SaveChanges();

                return new FestivalDTO(fes);
            }

            return null;

        }

    }
}
