﻿using WebApplication1.Data.DTO;
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
                var producings = new List<ProducingMovie>();
                foreach (var pr in rev.Producings.ToList())
                {
                    var producing = context.Producings.Find(pr.MovieId, pr.ProducerId );
                    if (producing == null) return null;
                    producings.Add(producing);


                }

                rev.Producings = producings;

                var hol = context.Holdings.Find(rev.HoldingId);
                if (hol == null)
                    return null;

                rev.Holding = hol;

                context.Awards.Add(rev);

                context.SaveChanges();

                CreateNotification(rev);

                return new ProducerAwardDTO(rev);


                


            }
            if(Award.AwardType == "Role") {

                var rev = new RoleAward((RoleAwardDTO)Award);
                var rewards = new List<Role>();

                foreach(var r in rev.Roles.ToList())
                {
                    var role = context.Roles.Find(r.ID);
                    if (role == null) return null;

                    rewards.Add(role);


                }

                rev.Roles = rewards;


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

        public AwardWrapperDTO GetAward(long id)
        {
            var a = context.Awards.Find(id);
            if (a != null)
                return new AwardWrapperDTO(a);
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
                ac.Name = Award.Name;
                

              

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
                    List<User> users = new List<User>();
                        foreach(var user in m.Favorites)
                            {
                                if (!users.Contains(user))
                                 users.Add(user);
                            }

                        foreach(var user in users)
                        {
                        var notify = new Notify();
                        notify.User = user;
                        notify.UserId = user.ID;
                        notify.Seen = false;

                        not.Notifies.Add(notify);
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
                    List<User> users = new List<User>();
                    foreach (var user in m.Producer.Favorites)
                    {
                        if (!users.Contains(user))
                            users.Add(user);
                    }

                    foreach (var user in users)
                    {
                        var notify = new Notify();
                        notify.User = user;
                        notify.UserId = user.ID;
                        notify.Seen = false;

                        not.Notifies.Add(notify);
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
                    List<User> users = new List<User>();
                    foreach (var user in m.Actor.Favorites)
                    {
                        if (!users.Contains(user))
                            users.Add(user);
                    }

                    foreach (var user in users)
                    {
                        var notify = new Notify();
                        notify.User = user;
                        notify.UserId = user.ID;
                        notify.Seen = false;

                        not.Notifies.Add(notify);
                    }
                }

                context.Notifications.Add(not);
                context.SaveChanges();
                return;
            }


        }

    }
}
