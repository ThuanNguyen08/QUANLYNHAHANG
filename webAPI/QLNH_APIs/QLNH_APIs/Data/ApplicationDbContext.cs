using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using QLNH_APIs.Models;

namespace QLNH_APIs.Data
{
 
    public class ApplicationDbContext: DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<Category> Category { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
