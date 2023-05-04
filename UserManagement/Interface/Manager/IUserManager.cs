using System.Collections.Generic;
using UserManagement.Interface.Manager;
using UserManagement.Models;

namespace UserManagement.Interface.Manager
{
  public interface IUserManager : IBaseManager<User>
   {
        public IEnumerable<User> GetUser();
        public User GetUserById(int id);
        public User AddUser(User user);
        public User UpdateUser(User user);
        public bool DeleteUser(int Id);
    }
}
