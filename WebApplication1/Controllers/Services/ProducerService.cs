using WebApplication1.Data.DTO;
using WebApplication1.Data.Models;
using WebApplication1.Data;
using WebApplication1.Controllers.Services.Interfaces;

namespace WebApplication1.Controllers.Services
{
    public class ProducerService : IProducer
    {

        private DataContext context;

        private string serverPath = "https://localhost:7133";
        public ProducerService(DataContext dataContext)
        {
            context = dataContext;
        }
        public ProducerDTO AddProducer(ProducerCreateDTO Producer)
        {
            if (Producer != null && Producer.Photo != null && Producer.Photo.Length > 0)
            {


                var folderName = DateTime.Now.ToString("yyyyMMddHHmmssfff");

                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Pictures", "Producers", folderName);

                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                var imageExtension = Path.GetExtension(Producer.Photo.FileName);

                var imageName = "image" + imageExtension;

                var imagePath = Path.Combine(folderPath, imageName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    Producer.Photo.CopyToAsync(stream);
                }


                var pr = new Producer(Producer);

                pr.Photo = serverPath + "/Pictures/Producers/" + folderName + "/" + imageName;


                context.Producers.Add(pr);

                context.SaveChanges();

                return new ProducerDTO(pr);

            }
            return null;
        }


        public void UpdatePhoto(PhotoUpdateDTO photoUpdateDTO)
        {
            long id = long.Parse(photoUpdateDTO.ID);

            var producer = context.Producers.Find(id);

            if (producer == null) return;
            if (producer.Photo != "")
            {

                var photoPath = producer.Photo;

                var relativePath = photoPath.Replace(serverPath, "");

                var absolutePath = Directory.GetCurrentDirectory() + relativePath;

                absolutePath = absolutePath.Replace("/", "\\");

                if (photoUpdateDTO.Photo != null && photoUpdateDTO.Photo.Length > 0)
                {
                    if (File.Exists(absolutePath))
                        File.Delete(absolutePath);

                    var folderName = DateTime.Now.ToString("yyyyMMddHHmmssfff");

                    var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Pictures", "Producers", folderName);

                    if (!Directory.Exists(folderPath))
                        Directory.CreateDirectory(folderPath);

                    var imageExtension = Path.GetExtension(photoUpdateDTO.Photo.FileName);

                    var imageName = "image" + imageExtension;

                    var imagePath = Path.Combine(folderPath, imageName);



                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {

                        photoUpdateDTO.Photo.CopyTo(stream);
                    }


                    producer.Photo = serverPath + "/Pictures/Producers/" + folderName + "/" + imageName;

                    context.SaveChanges();
                }


            }
            else
            {

                var folderName = DateTime.Now.ToString("yyyyMMddHHmmssfff");

                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Pictures", "Producers", folderName);

                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                var imageExtension = Path.GetExtension(photoUpdateDTO.Photo.FileName);

                var imageName = "image" + imageExtension;

                var imagePath = Path.Combine(folderPath, imageName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    photoUpdateDTO.Photo.CopyTo(stream);
                }




                producer.Photo = serverPath + "/Pictures/Producers/" + folderName + "/" + imageName;

                context.SaveChanges();

            }
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
                


                context.SaveChanges();

                return new ProducerDTO(ac);
            }

            return null;

        }
    }
}
