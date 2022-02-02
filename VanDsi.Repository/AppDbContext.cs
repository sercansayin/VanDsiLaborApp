using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanDsi.Core;

namespace VanDsi.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Labor> Labors { get; set; }
        public DbSet<Personnel> Personnels { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
