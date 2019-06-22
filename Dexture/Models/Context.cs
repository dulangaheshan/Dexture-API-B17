using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dexture.Models
{
    public class Context : DbContext
    {
      public Context(DbContextOptions options): base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<AgricultureOfficer> AgricultureOfficers { get; set; }

        public DbSet<Farmer> Farmers { get; set; }

        public DbSet<Buyer> Buyers { get; set; }

        public DbSet<Land> Lands { get; set; }


    }
}
