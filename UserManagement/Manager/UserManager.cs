using System.Collections.Generic;
using UserManagement.Interface.Manager;
using UserManagement.Models;

//using UserManagement.Interface.Manager;
//using UserManagement.Models;
using UserManagement.Repository;
using Microsoft.EntityFrameworkCore;
using UserManagement.Data;

namespace UserManagement.Manager
{
    public class UserManager : BaseManager<User>, IUserManager
    {
        //public UserManager(DbContextClass db) : base(new BaseRepository<User>(db))
        //{
        //}


        //public ICollection<User> GetUser()
        //{
        //    return Get(x => true);
        //}

        //IEnumerable<User> IUserManager.GetUser()
        //{
        //    throw new NotImplementedException();
        //}
        private readonly DbContextClass _dbContext;

        public UserManager(DbContextClass dbContext) : base(new BaseRepository<User>(dbContext))
        {
            _dbContext = dbContext;
        }
        public IEnumerable<User> GetUser()
        {
            return _dbContext.Users.ToList();
        }
        public User GetUserById(int id)
        {
            return _dbContext.Users.Where(x => x.Id == id).FirstOrDefault();
        }

        public User AddUser(User user)
        {
            var result = _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return result.Entity;
        }

        public User UpdateUser(User user)
        {
            var result = _dbContext.Users.Update(user);
            _dbContext.SaveChanges();
            return result.Entity;
        }
        public bool DeleteUser(int Id)
        {
            var filteredData = _dbContext.Users.Where(x => x.Id == Id).FirstOrDefault();
            var result = _dbContext.Remove(filteredData);
            _dbContext.SaveChanges();
            return result != null ? true : false;
        }
    }
}

