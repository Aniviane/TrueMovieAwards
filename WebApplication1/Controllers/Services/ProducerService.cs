using WebApplication1.Data.DTO;
using WebApplication1.Data.Models;
using WebApplication1.Data;
using WebApplication1.Controllers.Services.Interfaces;

namespace WebApplication1.Controllers.Services
{
    public class ProducerService : IProducer
    {

        private DataContext context;

        public ProducerService(DataContext dataContext)
        {
            context = dataContext;
        }
        public ProducerDTO AddProducer(ProducerDTO Producer)
        {
            var a = new Producer(Producer);

            context.Producers.Add(a);

            context.SaveChanges();

            return new ProducerDTO(a);


        }

        public void DeleteProducer(long id)
        {
            var a = context.Producers.Find(id);
            if (a != null)
            {
                context.Producers.Remove(a);
                context.SaveChanges();
            }

        }

        public ProducerDTO GetProducer(long id)
        {
            var a = context.Producers.Find(id);
            if (a != null)
                return new ProducerDTO(a);
            else
                return null;
        }

        public List<ProducerDTO> GetProducers()
        {
            var Producers = context.Producers.ToList<Producer>();
            var ret = new List<ProducerDTO>();
            if (Producers != null)
                foreach (var a in Producers)
                {
                    ret.Add(new ProducerDTO(a));
                }

            return ret;
        }

        public ProducerDTO UpdateProducer(ProducerDTO Producer)
        {
            var ac = context.Producers.Find(Producer.ID);
            if (ac != null)
            {
                ac.FName = Producer.FName;
                ac.LName = Producer.LName;
                ac.Bio = Producer.Bio;
                ac.Photo = Producer.Photo;
                

                context.Entry(ac).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                context.SaveChanges();

                return new ProducerDTO(ac);
            }

            return null;

        }
    }
}
