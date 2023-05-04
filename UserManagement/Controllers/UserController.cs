using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Interface.Manager;
using UserManagement.Manager;
using UserManagement.Models;

namespace UserManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserManager userManager;
        public UserController(IUserManager _userManager)
        {
            this.userManager = _userManager;
        }
        [HttpGet]
        public IEnumerable<User> UserList()
        {
            var userList = userManager.GetUser();
            return userList;
        }
        [HttpGet("{id}")]
        public User GetUserById(int id)
        {
            return userManager.GetUserById(id);
        }
        [HttpPost]
        public User AddUser(User user )
        {
            return userManager.AddUser(user);
        }
        [HttpPut]
        public User UpdateUser(User user)
        {
            return userManager.UpdateUser(user);
        }
        [HttpDelete("{id}")]
        public bool DeleteUser(int id)
        {
            return userManager.DeleteUser(id);
        }
    }
}
