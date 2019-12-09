using System;
using Microsoft.EntityFrameworkCore;
using Users.Domain.Models;

namespace Users.Domain
{
    public class UsersContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Technologie> Technologies { get; set; }
        public DbSet<UserTechnologie> UserTechnologies { get; set; }


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

            modelBuilder.Entity<UserTechnologie>().HasKey(t => new { t.UserId, t.TechnologieId });
            modelBuilder.Entity<Technologie>().HasData(
                Technologie.CreateTechnologie("Java"),
                Technologie.CreateTechnologie("JavaScript")
            );
        }
    }
}
