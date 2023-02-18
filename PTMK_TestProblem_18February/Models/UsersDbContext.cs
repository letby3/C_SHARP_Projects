using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTMK_TestProblem_18February.Models
{
    internal class UsersDbContext : DbContext
    {

        public DbSet<Users> users => Set<Users>();

        public UsersDbContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=UsersDB.db");
            
        }

    }
}
