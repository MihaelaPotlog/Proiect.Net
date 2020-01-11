using Microsoft.EntityFrameworkCore;
using Projects.Domain.Models;

namespace Projects.Domain
{
    public sealed class ProjectsContext:DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<ProjectTechnology> ProjectTechnologies { get; set; }
        public DbSet<ProjectUser> ProjectUsers { get; set; }
        public DbSet<Invitation> Invitations { get; set; }



        public ProjectsContext(DbContextOptions<ProjectsContext> options):base(options)
        {
        }
        public ProjectsContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source = (localdb)\\ProjectsV13; Initial Catalog = ProjectsDatabase; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<ProjectUser>().HasKey(t => new { t.ProjectId, t.UserId });
            modelBuilder.Entity<ProjectTechnology>().HasKey(t => new { t.ProjectId, t.TechnologieId });
            modelBuilder.Entity<Invitation>().HasKey(invitation => new { invitation.ProjectId, invitation.CollaboratorId, invitation.OwnerId});

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
