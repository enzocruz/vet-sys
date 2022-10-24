using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vet.Web.Models;

namespace Vet.DBContext
{
    public class VetDBContext : DbContext
    {
        public VetDBContext (DbContextOptions<VetDBContext> options)
            : base(options)
        {
                
        }
         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Breeds>()
                .HasOne(p => p.Animal)
                .WithMany(b => b.Breeds);
        }
        public DbSet<Breeds> Breeds { get; set; }
        public DbSet<Animal> Animals { get; set; }

        public DbSet<Pets> Pets { get; set; }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<History> History { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<Items> Items { get; set; }
        public DbSet<Owners> Owners { get; set; }

        public DbSet<Transactions> Transactions{get;set;}

        






    }
}