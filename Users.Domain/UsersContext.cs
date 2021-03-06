﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Users.Domain.Models;

namespace Users.Domain
{
    public sealed class UsersContext : IdentityDbContext<User>
    {
        

        public DbSet<Technology> Technologies { get; set; }
        public DbSet<UserTechnology> UserTechnologies { get; set; }


        public UsersContext(DbContextOptions<UsersContext> options) : base(options)
        {

        }

        public UsersContext()
        {
            Database.EnsureCreated();
            //Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=(localdb)\\ProjectsV13;Initial Catalog=UsersDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserTechnology>().HasKey(t => new { t.UserId, t.TechnologyId });

            modelBuilder.Entity<Technology>().HasData(
                Technology.CreateTechnology("Java"),
                Technology.CreateTechnology("JavaScript"),
                Technology.CreateTechnology(".Net"),
                Technology.CreateTechnology("C#"),
                Technology.CreateTechnology("Unity"),
                Technology.CreateTechnology("Node.js"),
                Technology.CreateTechnology("Angular"),
                Technology.CreateTechnology("React"),
                Technology.CreateTechnology("Vue"),
                Technology.CreateTechnology("Express"),
                Technology.CreateTechnology("Swift"),
                Technology.CreateTechnology("MongoDb"),
                Technology.CreateTechnology("C++"),
                Technology.CreateTechnology("Python"),
                Technology.CreateTechnology("C")

            );
        }
    }
}
