using WebApplication1.Controllers.Services.Interfaces;
using WebApplication1.Data.DTO;
using WebApplication1.Data.Models;
using WebApplication1.Data;

namespace WebApplication1.Controllers.Services
{
    public class HoldingService : IHolding
    {


        private DataContext context;

        public HoldingService(DataContext dataContext)
        {
            context = dataContext;
        }
        public HoldingDTO AddHolding(HoldingDTO Holding)
        {
            var Hol = new Holding(Holding);

            var fes = context.Festivals.Find(Holding.FestivalId);

            if (fes != null)
            {
                Hol.Festival = fes;


                context.Holdings.Add(Hol);

                context.SaveChanges();

                return new HoldingDTO(Hol);
            }
            return null;


        }

        public void DeleteHolding(long id)
        {
            var Hol = context.Holdings.Find(id);
            if (Hol != null)
            {
                context.Holdings.Remove(Hol);
                context.SaveChanges();
            }

        }

        public HoldingDTO GetHolding(long id)
        {
            var Hol = context.Holdings.Find(id);
            if (Hol != null)
                return new HoldingDTO(Hol);
            else
                return null;
        }

        public List<HoldingDTO> GetHoldings()
        {
            var Holdings = context.Holdings.ToList<Holding>();
            var ret = new List<HoldingDTO>();
            if (Holdings != null)
                foreach (var a in Holdings)
                {
                    ret.Add(new HoldingDTO(a));
                }

            return ret;
        }

        public HoldingDTO UpdateHolding(HoldingDTO Holding)
        {
            var hol = context.Holdings.Find(Holding.ID);
            if (hol != null)
            {
                hol.City = Holding.City;
                hol.Name = Holding.Name;
                hol.Year = Holding.Year;


                context.Entry(hol).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                context.SaveChanges();

                return new HoldingDTO(hol);
            }

            return null;

        }
    }
}
