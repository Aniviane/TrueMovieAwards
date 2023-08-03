using WebApplication1.Data.DTO;
using WebApplication1.Data.Models;
using WebApplication1.Data;
using WebApplication1.Controllers.Services.Interfaces;

namespace WebApplication1.Controllers.Services
{
    public class AwardService : IAward
    {
        private DataContext context;

        public AwardService(DataContext dataContext)
        {
            context = dataContext;
        }
        public AwardDTO AddAward(AwardDTO Award)
        {



            if (Award.AwardType == "Movie")
            {
                var helper = new MovieAward((MovieAwardDTO)Award);
                var rev = new MovieAward((MovieAwardDTO)Award);
                rev.Movies = new List<Movie>();
                foreach (var m in helper.Movies)
                {
                    var mov = context.Movies.Find(m.ID);
                    if (mov == null)
                        return null;
                    rev.Movies.Add(mov);
                }


                    var hol = context.Holdings.Find(rev.HoldingId);
                    if (hol == null)
                        return null;

                    rev.Holding = hol;

                    context.Awards.Add(rev);

                    context.SaveChanges();

                    CreateNotification(rev);
                    return new MovieAwardDTO(rev);


                
            }
           
            if(Award.AwardType == "Producer") {

                var rev = new ProducerAward((ProducerAwardDTO)Award);

                foreach (var pr in rev.Producings.ToList())
                {
                    var prod = context.Producers.Find(pr.ProducerId);
                    var m = context.Movies.Find(pr.MovieId);

                    if (prod == null)
                        return null;
                    if (m == null)
                        return null;
                    pr.Movie = m;
                    pr.Producer = prod;

                    var hol = context.Holdings.Find(rev.HoldingId);
                    if (hol == null)
                        return null;

                    rev.Holding = hol;

                    context.Awards.Add(rev);

                    context.SaveChanges();

                    CreateNotification(rev);

                    return new ProducerAwardDTO(rev);


                }


            }
            if(Award.AwardType == "Role") {

                var rev = new RoleAward((RoleAwardDTO)Award);
            
                foreach(var r in rev.Roles.ToList())
                {
                    var ac =context.Actors.Find(r.ActorId);
                    var m = context.Movies.Find(r.MovieId);

                    if (ac == null)
                        return null;
                    if (m == null)
                        return null;
                    r.Movie = m;
                    r.Actor = ac;


                }

                var hol = context.Holdings.Find(rev.HoldingId);
                if (hol == null)
                    return null;
                
                rev.Holding = hol;

                context.Awards.Add(rev);

                context.SaveChanges();
                CreateNotification(rev);
                return new RoleAwardDTO(rev);
                

            }

            



            return null ;


        }

        public void DeleteAward(long id)
        {
            var a = context.Awards.Find(id);
            if (a != null)
            {
                context.Awards.Remove(a);
                context.SaveChanges();
            }

        }

        public AwardDTO GetAward(long id)
        {
            var a = context.Awards.Find(id);
            if (a != null)
                return new AwardDTO(a);
            else
                return null;
        }

        public List<AwardWrapperDTO> GetAwards()
        {
            var Awards = context.Awards.ToList<Award>();
            var ret = new List<AwardWrapperDTO>();
            if (Awards != null)
                foreach (var a in Awards)
                {
                    ret.Add(new AwardWrapperDTO(a));
                }

            return ret;
        }

        public AwardDTO UpdateAward(AwardDTO Award)
        {
            var ac = context.Awards.Find(Award.ID);
            if (ac != null)
            {
             

                context.Entry(ac).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                context.SaveChanges();

                return new AwardDTO(ac);
            }

            return null;

        }


        public void CreateNotification(Award award)
        {
            var not = new Notification();
            not.Award = award;
            not.DateOfNotification = DateTime.Now;
            not.AwardId = award.ID;
            not.Notifies = new List<Notify>();

            if (award.AwardType == "Movie") {
                not.Description = "Your favorite Movie got an award!";
                var help = ((MovieAward)award).Movies;
                foreach (var m in help) {
                        foreach(var user in m.Favorites)
                            {
                            var n = new Notify();
                            n.User = user;
                            n.Seen = false;
                            n.UserId = user.ID;

                            not.Notifies.Add(n);
                            }
                        }

                context.Notifications.Add(not);
                context.SaveChanges();
                return;

                    }
            if(award.AwardType == "Producer") {
                not.Description = "Your favorite Producer got an award!";

                var help = ((ProducerAward)award).Producings;
                foreach (var m in help)
                {
                    foreach (var user in m.Producer.Favorites)
                    {
                        var n = new Notify();
                        n.User = user;
                        n.Seen = false;
                        n.UserId = user.ID;

                        not.Notifies.Add(n);
                    }
                }

                context.Notifications.Add(not);
                context.SaveChanges();
                return;


            }
            if(award.AwardType == "Role") {
                not.Description = "Your favorite Actor got an award!";

                var help = ((RoleAward)award).Roles;
                foreach (var m in help)
                {
                    foreach (var user in m.Actor.Favorites)
                    {
                        var n = new Notify();
                        n.User = user;
                        n.Seen = false;
                        n.UserId = user.ID;

                        not.Notifies.Add(n);
                    }
                }

                context.Notifications.Add(not);
                context.SaveChanges();
                return;
            }


        }

    }
}
