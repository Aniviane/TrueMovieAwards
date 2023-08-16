using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Controllers.Services.Interfaces;
using WebApplication1.Data.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IUser UserService;

        public UserController(IUser User)
        {
            UserService = User;
        }
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<UserDTO> Get()
        {
            var ret = UserService.GetUsers();
            return ret;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public UserDTO Get(int id)
        {
            return UserService.GetUser(id);
        }

        [HttpPost("Login")]
        public UserDTO Post([FromBody]UserLoginDTO userLoginDTO)
        {
            return UserService.Login(userLoginDTO);
        }


        // POST api/<UserController>
        [HttpPost]
        public UserDTO Post(UserDTO User)
        {
            return UserService.Register(User);
        }

        // PUT api/<UserController>/
        [HttpPut]
        public UserDTO Put(UserDTO User)
        {
            return UserService.UpdateUser(User);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            UserService.DeleteUser(id);
        }


        [HttpPut("UpdateNotify")]
        [Authorize]
        public void UpdateNotify(long id)
        {
            UserService.UpdateNotify(id);
        }

        [HttpPost("LeaveReview")]
        public UpReviewDTO LeaveReview(UpReviewDTO upReviewDTO)
        {
            return UserService.LeaveReview(upReviewDTO);
        }

        [HttpPut("Favorise")]
        [Authorize]
        public void Favorize(FavoriseDTO favoriseDTO)
        {
            
             UserService.FavSomething(favoriseDTO);
            
        }
    }
}
