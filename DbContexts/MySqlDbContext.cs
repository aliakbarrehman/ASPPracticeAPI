using ASPPracticeAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPPracticeAPI.DbContexts
{
    public class MySqlDbContext : DbContext
    {
        public MySqlDbContext(DbContextOptions<MySqlDbContext> options)
           : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
