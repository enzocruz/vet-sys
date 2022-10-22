using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vet.Web.Models;

namespace DBContext
{
    public class VetDBContext : DbContext
    {
        public VetDBContext (DbContextOptions<VetDBContext> options)
            : base(options)
        {
        }

        public DbSet<Breeds> Breed { get; set; }
        public DbSet<Animal> Animal { get; set; }

        public DbSet<Pets> Pet { get; set; }

    }
}