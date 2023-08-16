using Microsoft.AspNetCore.Mvc;
using WebApplication1.Controllers.Services.Interfaces;
using WebApplication1.Data;
using WebApplication1.Data.DTO;
using WebApplication1.Data.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase

    {


        public IActor actorService;

        public ActorController(IActor _actorService)
        {
            actorService = _actorService;
        }


        // GET: api/<ActorController>
        [HttpGet]
        public  ActionResult<IEnumerable<ActorDTO>> Get()
        {

            var ret = actorService.GetActors();

            
          
            return Ok(ret);
        }

       


        // GET api/<ActorController>/5
        [HttpGet("{id}")]
        public ActorDTO Get(int id)
        {


            return actorService.GetActor(id);
        }

        // POST api/<ActorController>
        [HttpPost]
        public async Task<ActionResult<ActorDTO>>  Post(ActorDTO actorDTO)
        {
            /*
            var u = context.Users.First();

            var n = context.Notifications.ToList<Notification>();

            var n1 = new Notify();
            n1.Notification = n[0];
            n1.Seen = false;
            n1.User = u;

            var n2 = new Notify();
            n2.Notification = n[1];
            n2.Seen = false;
            n2.User = u;
            var n3 = new Notify();
            n3.Notification = n[2];
            n3.Seen = false;
            n3.User = u;
            */

            /*

            var m = new Movie();
            m.DateOfRelease = DateTime.Now;
            m.Title = "Star Wars";
            m.Photo = "";
            m.RevCount = 0;
            m.RevGrade = 0;
            m.Description = "The Best Movie ever!";

            var g = new Genre();
            g.FName = "Sci Fi";
            
            m.Genres = new List<Genre> { g };


            var a = new Actor();
            a.FName = "Bob";
            a.LName = "Loblaw";
            a.DoB = DateTime.Now.Subtract(new TimeSpan(25*365,0,0,0));
            a.Bio = "Bob Loblaw from Bob Loblaws Law Blog";
            a.APhoto = "";
           


            var r = new Role();
            r.FName = "Luke";
            r.LName = "Skywalker";
            r.Actor = a;
            r.Movie = m;

            m.Roles = new List<Role> { r };

            var p = new Producer();
            p.FName = "George";
            p.LName = "Lucas";
            p.DoB = DateTime.Now.Subtract(new TimeSpan(25 * 365, 0, 0, 0));
            p.Photo = "";
            p.Bio = "He produces stuff";
            

            var pr = new ProducingMovie();
            pr.Producer = p;
            pr.Movie = m;

            m.Producings = new List<ProducingMovie> { pr };

            var mAward = new MovieAward();
            var pAward = new ProducerAward();
            var rAward = new RoleAward();

            var f = new Festival();
            f.Description = "The Bestest Festival Ever!";
            f.Name = "The Besties";
            f.Photo = "";

            var h = new Holding();
            h.Festival = f;
            h.City = "Best Town";
            h.Year = 2023;
            h.Name = "The bestest Holding";

            mAward.Name = "Best Movie Ever";
            mAward.Movies = new List<Movie> { m };
            pAward.Name = "Best Producer Ever!";
            pAward.Producings = new List<ProducingMovie> { pr };
            rAward.Name = "Best Role Ever!";
            rAward.Roles = new List<Role> { r };


            mAward.Holding = h;
            pAward.Holding = h;
            rAward.Holding = h;

            var n1 = new Notification();
            n1.DateOfNotification = DateTime.Now;
            n1.Award = mAward;
            n1.Description = "Your Favourite Movie got an award";

            var n2 = new Notification();
            n2.DateOfNotification = DateTime.Now;
            n2.Award = pAward;
            n2.Description = "Your Favourite Producer got an award";

            var n3 = new Notification();
            n3.DateOfNotification = DateTime.Now;
            n3.Award = rAward;
            n3.Description = "Your Favourite Role got an award";

            mAward.Notification = n1;
            pAward.Notification = n2;
            rAward.Notification = n3;

            */
            /*
            var m = context.Movies.FirstOrDefault();
            //var r = context.Roles.First();
            var p = context.Producers.First();
            var a = context.Actors.First();
            
            var u = new User();
            u.FName = "Bob";
            u.LName = "Loblaw";
            u.Username = "Bob Loblaw";
            u.Bio = "Bob Loblaw, from Bob Loblaws Law Blogs";
            u.UPhoto = "";
            u.Password = "BobLoblaw";
            u.UType = "General";
            u.Notifies = new List<Notify>();
            

            var r = new Review();
            r.Reviewer = u;
            r.Description = "The best Movie ever";
            r.Grade = 5;
            r.Movie = m;
            r.RevTime = DateTime.Now;

            u.Reviews = new List<Review> { r };
            u.EMail = "bobloblawslawblogs@gmail.com";
            u.FavActors = new List<Actor> { a };
            u.FavProducers = new List<Producer> { p };
            u.FavMovies = new List<Movie> { m };

            var wl = new WatchList();
            wl.User = u;
            wl.Movies = new List<Movie> { m };

            u.WatchList = wl;

            m.RevGrade = 5;
            */
            /*
            var mAward = new MovieAward();
            var pAward = new ProducerAward();
            var rAward = new RoleAward();


            var f = new Festival();
            f.Description = "The Bestest Festival Ever!";
            f.Name = "The Besties";
            f.Photo = "";

            var h = new Holding();
            h.Festival = f;
            h.City = "Best Town";
            h.Year = 2023;
            h.Name = "The bestest Holding";
            



            mAward.Name = "Best Movie Ever";
            mAward.Movies = new List<Movie> { m };
            pAward.Name = "Best Producer Ever!";
            pAward.Producings = new List<ProducingMovie> { p };
            rAward.Name = "Best Role Ever!";
            rAward.Roles = new List<Role> { r };


            mAward.Holding = h;
            pAward.Holding = h;
            rAward.Holding = h;

            var n1 = new Notification();
            n1.DateOfNotification = DateTime.Now;
            n1.Award = mAward;
            n1.Description = "Your Favourite Movie got an award";

            var n2 = new Notification();
            n2.DateOfNotification = DateTime.Now;
            n2.Award = pAward;
            n2.Description = "Your Favourite Producer got an award";

            var n3 = new Notification();
            n3.DateOfNotification = DateTime.Now;
            n3.Award = rAward;
            n3.Description = "Your Favourite Role got an award";

            mAward.Notification = n1;
            pAward.Notification = n2;
            rAward.Notification = n3;

            */
            //var r = new Role();
            //r.Actor = actor;

            //r.Movie = m;
            //r.LName = "Skywalker";
            //r.FName = "Anakin";


            //context.Series.Add(s);
            //context.Studios.Add(st);
            //context.Producers.Add(p);
            //context.Actors.Add(a);
            //context.Producers.Add(p);
            //context.Movies.Add(m);
            //context.Producings.Add(pr);
            //context.Roles.Add(r);
            //context.Festivals.Add(f);
            //context.Holdings.Add(h);
            //context.Awards.Add(mAward);
            //context.Awards.Add(pAward);
            //context.Awards.Add(rAward);
            //context.Users.Add(u);
            //context.Notifies.Add(n1);
            //context.Notifies.Add(n2);
            //context.Notifies.Add(n3);
            //context.SaveChanges();

            var newActor = actorService.AddActor(actorDTO);


            return newActor;
        }

        // PUT api/<ActorController>/5
        [HttpPut("{id}")]
        public ActorDTO Put(ActorDTO actor)
        {
            return actorService.UpdateActor(actor);
        }

        // DELETE api/<ActorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            actorService.DeleteActor(id);
        }
    }
}
