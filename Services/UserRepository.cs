using ASPPracticeAPI.DbContexts;
using ASPPracticeAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ASPPracticeAPI.Helpers;

namespace ASPPracticeAPI.Services
{
    public class UserRepository : IDisposable
    {
        private MySqlDbContext _dbContext { get; set; }

        public UserRepository(MySqlDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddUser(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }
        public PagedResponse<User> GetUsers(UserQueryParameters userQuery)
        {
            var x = _dbContext.Users as IQueryable<User>;
            var result = new PagedResponse<User>
            {
                TotalItems = x.Count(),
                Items = x.Skip(userQuery.PageSize * (userQuery.PageNumber - 1)).Take(userQuery.PageSize).Include(x => x.Tasks).ToList<User>()
            };
            return result;
        }
        public User GetUser(int userId)
        {
            return _dbContext.Users.Where(x => x.Id == userId).FirstOrDefault();
        }
        public void UpdateUser(int userId, User user)
        {

        }
        public void DeleteUser(User user)
        {
            _dbContext.Users.Remove(user);
        }
        public void Dispose()
        {
            // Dispose here
        }
    }
}
