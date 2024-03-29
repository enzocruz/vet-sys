using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vet.Web.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
namespace Vet.DBContext
{
    public class VetDBContext : IdentityDbContext
    {
        public VetDBContext (DbContextOptions<VetDBContext> options)
            : base(options)
        {
                
        }
         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var user=new IdentityUser("admin"){
                Email="test@gmail.com"
                ,UserName="admin"
              
            };
            /*PasswordHasher<IdentityUser> ph =new PasswordHasher<IdentityUser>();
           
            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "cdd3dc99-b409-45b0-a682-c3441d677a0d",
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "test@gmail.com",
                NormalizedEmail = "test@gmail.com",
                EmailConfirmed = true,
                PasswordHash ="p@$$w0rd",
                SecurityStamp = string.Empty
            });*/
            modelBuilder.Entity<Animal>().HasData(
                new Animal(){Id=1,Name="Dog"}
                ,new Animal(){Id=2,Name="Cat"}
            );
            modelBuilder.Entity<ItemType>().HasData(
                new ItemType(){Id=1,Name="Vaccine"}
                ,new ItemType(){Id=2,Name="Tablet"}
                ,new ItemType(){Id=3,Name="Capsules"}
                ,new ItemType(){Id=4,Name="Injections"}
            );      
        }
        public DbSet<Breeds> Breeds { get; set; }
        public DbSet<Animal> Animals { get; set; }

        public DbSet<Pets> Pets { get; set; }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<History> History { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<Items> Items { get; set; }
        public DbSet<Owners> Owners { get; set; }

        public DbSet<ItemType> Types{get;set;}
        
        public DbSet<Prescription> Prescriptions{get;set;}

        public DbSet<Vacination> Vacinations{get;set;}
        






    }
}