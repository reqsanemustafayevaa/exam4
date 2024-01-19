using boxer.core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boxer.data.DAL
{
    public class AppDbContext:IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options) 
        {
                
        }
        public DbSet<Students>Students { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Setting> Settings { get; set; }
    }
}
