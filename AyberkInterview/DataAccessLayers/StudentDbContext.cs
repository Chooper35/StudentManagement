using AyberkInterview.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AyberkInterview.DataAccessLayers
{
    public class StudentDbContext : DbContext
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasIndex(e=>e.Id);
            base.OnModelCreating(modelBuilder);     
        }
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {
            
        }


        public DbSet<Student> Students { get; set; }
    }
}
