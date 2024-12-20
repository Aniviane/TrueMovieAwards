﻿using WebApplication1.Controllers.Services.Interfaces;
using WebApplication1.Data.DTO;
using WebApplication1.Data.Models;
using WebApplication1.Data;

namespace WebApplication1.Controllers.Services
{
    public class StudioService : IStudio
    {
        private DataContext context;


        private string serverPath = "https://localhost:7133";

        public StudioService(DataContext dataContext)
        {
            context = dataContext;
        }
        public  StudioDTO AddStudio(StudioCreateDTO Studio)
        {
            

            if (Studio != null && Studio.photo != null && Studio.photo.Length >0 )
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
                     Studio.photo.CopyTo(stream);
                }

                var st = new Studio();
                st.Name = Studio.name;
                st.Description = Studio.description;
                st.Photo = serverPath + "/Pictures/Studios/" + folderName +"/"+ imageName;

                st.Movies = new List<Movie>();

                Console.WriteLine("Studio created with Path " + st.Photo);


                context.Studios.Add(st);

                context.SaveChanges();

                return new StudioDTO(st);

            }


            return null;


        }

        public void UpdatePhoto(PhotoUpdateDTO photoUpdateDTO)
        {
            long id = long.Parse(photoUpdateDTO.ID);

            var studio = context.Studios.Find(id);

            if (studio == null) return;
            if (studio.Photo != "")
            {

                var photoPath = studio.Photo;

                var relativePath = photoPath.Replace(serverPath, "");

                var absolutePath = Directory.GetCurrentDirectory() + relativePath;

                absolutePath = absolutePath.Replace("/", "\\");

                if (photoUpdateDTO.Photo != null && photoUpdateDTO.Photo.Length > 0)
                {
                    if (File.Exists(absolutePath))
                        File.Delete(absolutePath);

                  

                    var folderName = DateTime.Now.ToString("yyyyMMddHHmmssfff");

                    var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Pictures", "Studios", folderName);

                    if (!Directory.Exists(folderPath))
                        Directory.CreateDirectory(folderPath);

                    var imageExtension = Path.GetExtension(photoUpdateDTO.Photo.FileName);

                    var imageName = "image" + imageExtension;

                    var imagePath = Path.Combine(folderPath, imageName);



                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {

                        photoUpdateDTO.Photo.CopyTo(stream);
                    }


                    studio.Photo = serverPath + "/Pictures/Studios/" + folderName + "/" + imageName;

                    context.SaveChanges();
                }


            }
            else
            {

                var folderName = DateTime.Now.ToString("yyyyMMddHHmmssfff");

                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Pictures", "Studios", folderName);

                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                var imageExtension = Path.GetExtension(photoUpdateDTO.Photo.FileName);

                var imageName = "image" + imageExtension;

                var imagePath = Path.Combine(folderPath, imageName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    photoUpdateDTO.Photo.CopyTo(stream);
                }




                studio.Photo = serverPath + "/Pictures/Studios/" + folderName + "/" + imageName;

                context.SaveChanges();

            }
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
                


                context.SaveChanges();

                return new StudioDTO(Studio);
            }

            return null;

        }
    }
}
