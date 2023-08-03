using Microsoft.EntityFrameworkCore;

namespace AuthAPI.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                    new User { Id = 1, Email = "studnikita@gmail.com", Password = "string12" },
                    new User { Id = 2, Email = "Bobik164", Password = "string13" },
                    new User { Id = 3, Email = "Smer4ik228", Password = "string14" }
            );
        }
    }
}
