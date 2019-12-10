using System;
using Microsoft.EntityFrameworkCore;
using Users.Domain.Models;

namespace Users.Domain
{
    public sealed class UsersContext : DbContext
    {
        public DbSet<User> Users { get; set; }

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

            modelBuilder.Entity<UserTechnology>().HasKey(t => new { t.UserId, t.TechnologyId });
            modelBuilder.Entity<Technology>().HasData(
                Technology.CreateTechnology("Java"),
                Technology.CreateTechnology("JavaScript")
            );
        }
    }
}
