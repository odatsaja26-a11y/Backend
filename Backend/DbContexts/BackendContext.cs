using Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace Backend.DbContexts
{
    public class BackendContext : DbContext  {

        public BackendContext(DbContextOptions<BackendContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            

            modelBuilder.Entity<User>()
                .HasIndex(x => x.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(x => x.PhoneNumber)
                .IsUnique();
        }

        public DbSet<User> Users { get; set; }
    }
}
