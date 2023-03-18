using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.DataAccessLayer
{
    public class Context :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=LAPTOP-T2JD2JRE\\EMRE;database=NetCoreBlogApi1; integrated security=true");

        }

        public DbSet<Employee> Employees { get; set; }
    }
}
