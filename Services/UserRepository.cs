using ASPPracticeAPI.DbContexts;
using ASPPracticeAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPPracticeAPI.Services
{
    public class UserRepository : IDisposable
    {
        private MySqlDbContext _dbContext { get; set; }

        public UserRepository(MySqlDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool AddUser(User user)
        {
            try
            {
                var x = _dbContext.Users.Add(user);
                _dbContext.SaveChanges();
                return true;
            }
            catch(Exception _)
            {
                // Log if exception here
                return false;
            }
        }
        public IEnumerable<User> GetUsers()
        {
            var x = _dbContext.Users.ToList<User>();
            return x;
        }
        public void Dispose()
        {
            // Dispose here
        }
    }
}
