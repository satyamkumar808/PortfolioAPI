using DAL.DB_Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class ProtfolioDBContext : DbContext
    {
        public ProtfolioDBContext(DbContextOptions options): base(options)
        {
           
        }
        public virtual DbSet<Project> Project {  get; set; }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Project>(x =>
            {
                x.HasKey(k => k.Id);
                x.HasData(
                    new Project
                    {
                        Id = 1,
                        Description = "Project 1 Description",
                        Name = "Dotnet web API",
                        GitLink = "gitLink"
                    },
                    new Project
                    {
                        Id = 2,
                        Description = "Project 2 Description",
                        Name = "Angular web API",
                        GitLink = "gitlink"
                    }
                );
                x.Property(p => p.Name).IsRequired();
            });
            modelBuilder.Entity<User>(x =>
            {
                x.HasKey(k => k.Id);
                x.HasData(
                    new User
                    {
                        Id = 1,
                        UserEmail = "satyam808@gmail.com",
                        UserName = "Satyam",
                        Password = "Satyam808@"
                    }
                  );
            });
        }

    }
}
