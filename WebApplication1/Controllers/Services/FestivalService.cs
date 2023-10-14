using WebApplication1.Data.DTO;
using WebApplication1.Data.Models;
using WebApplication1.Data;
using WebApplication1.Controllers.Services.Interfaces;

namespace WebApplication1.Controllers.Services
{
    public class FestivalService : IFestival
    {

        private DataContext context;

        private string serverPath = "https://localhost:7133";

        public FestivalService(DataContext dataContext)
        {
            context = dataContext;
        }
        public FestivalDTO AddFestival(FestivalCreateDTO Festival)
        {
            if (Festival != null && Festival.Photo != null && Festival.Photo.Length > 0)
            {
                var folderName = DateTime.Now.ToString("yyyyMMddHHmmssfff");

                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Pictures", "Festivals", folderName);

                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                var imageExtension = Path.GetExtension(Festival.Photo.FileName);

                var imageName = "image" + imageExtension;

                var imagePath = Path.Combine(folderPath, imageName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    Festival.Photo.CopyTo(stream);
                }




                var fes = new Festival(Festival);
                fes.Photo = serverPath + "/Pictures/Festivals/" + folderName + "/" + imageName;

                Console.WriteLine("Festival created with Path " + fes.Photo);


                context.Festivals.Add(fes);

                context.SaveChanges();

                return new FestivalDTO(fes);

            }
            return null;
        }


        public void UpdatePhoto(PhotoUpdateDTO photoUpdateDTO)
        {
            long id = long.Parse(photoUpdateDTO.ID);

            var Festival = context.Festivals.Find(id);

            if (Festival == null) return;
            if (Festival.Photo != "")
            {

                var photoPath = Festival.Photo;

                var relativePath = photoPath.Replace(serverPath, "");

                var absolutePath = Directory.GetCurrentDirectory() + relativePath;

                absolutePath = absolutePath.Replace("/", "\\");

                if (photoUpdateDTO.Photo != null && photoUpdateDTO.Photo.Length > 0)
                {
                    if (File.Exists(absolutePath))
                        File.Delete(absolutePath);


                    var folderName = DateTime.Now.ToString("yyyyMMddHHmmssfff");

                    var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Pictures", "Festivals", folderName);

                    if (!Directory.Exists(folderPath))
                        Directory.CreateDirectory(folderPath);

                    var imageExtension = Path.GetExtension(photoUpdateDTO.Photo.FileName);

                    var imageName = "image" + imageExtension;

                    var imagePath = Path.Combine(folderPath, imageName);



                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {

                        photoUpdateDTO.Photo.CopyTo(stream);
                    }


                    Festival.Photo = serverPath + "/Pictures/Festivals/" + folderName + "/" + imageName;

                    context.SaveChanges();
                }


            }
            else
            {

                var folderName = DateTime.Now.ToString("yyyyMMddHHmmssfff");

                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Pictures", "Festivals", folderName);

                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                var imageExtension = Path.GetExtension(photoUpdateDTO.Photo.FileName);

                var imageName = "image" + imageExtension;

                var imagePath = Path.Combine(folderPath, imageName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    photoUpdateDTO.Photo.CopyTo(stream);
                }




                Festival.Photo = serverPath + "/Pictures/Festivals/" + folderName + "/" + imageName;

                context.SaveChanges();

            }
        }





        /*
        * if (Studio != null && Studio.photo != null && Studio.photo.Length >0 )
           {
               var folderName = DateTime.Now.ToString("yyyyMMddHHmmssfff");

               var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Pictures","Studios", folderName);

               if (!Directory.Exists(folderPath))
                   Directory.CreateDirectory(folderPath);

               var imageExtension = Path.GetExtension(Studio.photo.FileName);

               var imageName = "image" + imageExtension;

               var imagePath = Path.Combine(folderPath, imageName);

               using (var stream = new FileStream(imagePath, FileMode.Create))
               {
                    Studio.photo.CopyToAsync(stream);
               }

               var st = new Studio();
               st.Name = Studio.name;
               st.Description = Studio.description;
               st.Photo = serverPath + "/Pictures/Studios/" + folderName +"/"+ imageName;

               st.Movies = new List<Movie>();
               context.Studios.Add(st);

               context.SaveChanges();

               return new StudioDTO(st);

           }
        * 
     */







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

                


                context.SaveChanges();

                return new FestivalDTO(fes);
            }

            return null;

        }

    }
}
