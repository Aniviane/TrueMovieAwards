using WebApplication1.Controllers.Services.Interfaces;
using WebApplication1.Data;
using WebApplication1.Data.DTO;
using WebApplication1.Data.Models;

namespace WebApplication1.Controllers.Services
{
    public class ActorService : IActor
    {
        private DataContext context;
        private string serverPath = "https://localhost:7133";

        public ActorService(DataContext dataContext)
        {
            context = dataContext;
        }
        public ActorDTO AddActor(ActorCreateDTO actor)
        {
            if (actor != null && actor.APhoto != null && actor.APhoto.Length > 0)
            {


                var folderName = DateTime.Now.ToString("yyyyMMddHHmmssfff");

                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Pictures", "Actors", folderName);

                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                var imageExtension = Path.GetExtension(actor.APhoto.FileName);

                var imageName = "image" + imageExtension;

                var imagePath = Path.Combine(folderPath, imageName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    actor.APhoto.CopyTo(stream);
                }


                var a = new Actor(actor);

                a.APhoto = serverPath + "/Pictures/Actors/" + folderName + "/" + imageName;

                Console.WriteLine("actor created");

                context.Actors.Add(a);

                context.SaveChanges();

                return new ActorDTO(a);

            }
            return null;
        }


        public void UpdatePhoto(PhotoUpdateDTO photoUpdateDTO)
        {
            long id = long.Parse(photoUpdateDTO.ID);

            var actor = context.Actors.Find(id);

            if (actor == null) return;
            if (actor.APhoto != "")
            {

                var photoPath = actor.APhoto;

                var relativePath = photoPath.Replace(serverPath, "");

                var absolutePath = Directory.GetCurrentDirectory() + relativePath;

                absolutePath = absolutePath.Replace("/", "\\");

                if (photoUpdateDTO.Photo != null && photoUpdateDTO.Photo.Length > 0)
                {
                    if (File.Exists(absolutePath))
                        File.Delete(absolutePath);


                    var folderName = DateTime.Now.ToString("yyyyMMddHHmmssfff");

                    var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Pictures", "Actors", folderName);

                    if (!Directory.Exists(folderPath))
                        Directory.CreateDirectory(folderPath);

                    var imageExtension = Path.GetExtension(photoUpdateDTO.Photo.FileName);

                    var imageName = "image" + imageExtension;

                    var imagePath = Path.Combine(folderPath, imageName);



                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {

                        photoUpdateDTO.Photo.CopyTo(stream);
                    }


                    actor.APhoto = serverPath + "/Pictures/Actors/" + folderName + "/" + imageName;

                    context.SaveChanges();
                }


            }
            else
            {

                var folderName = DateTime.Now.ToString("yyyyMMddHHmmssfff");

                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Pictures", "Actors", folderName);

                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                var imageExtension = Path.GetExtension(photoUpdateDTO.Photo.FileName);

                var imageName = "image" + imageExtension;

                var imagePath = Path.Combine(folderPath, imageName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    photoUpdateDTO.Photo.CopyTo(stream);
                }


               

                actor.APhoto = serverPath + "/Pictures/Actors/" + folderName + "/" + imageName;

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

        public void DeleteActor(long id)
        {
            var a = context.Actors.Find(id);
            if (a != null)
            {
                context.Actors.Remove(a);
                context.SaveChanges();
            }

        }

        public ActorDTO GetActor(long id)
        {
            var a = context.Actors.Find(id);
            if(a != null)
            return new ActorDTO(a);
            else 
                return null;
        }

        public List<ActorDTO> GetActors()
        {
            var actors = context.Actors.ToList<Actor>();
            var ret = new List<ActorDTO>();
            if(actors != null)
            foreach(var a in actors)
                {
                    ret.Add(new ActorDTO(a));
                }

            return ret;
        }

        public ActorDTO UpdateActor(ActorDTO actor)
        {
            var ac = context.Actors.Find(actor.ID);
            if(ac != null)
            {
                ac.FName = actor.FName;
                ac.LName = actor.LName;
                ac.Bio = actor.Bio;


                context.SaveChanges();

                return new ActorDTO(ac);
            }

            return null;

        }
    }
}
