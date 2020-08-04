using Microsoft.EntityFrameworkCore;

namespace EFCore.Entities
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           base.OnModelCreating(modelBuilder);
        }
    }
}
