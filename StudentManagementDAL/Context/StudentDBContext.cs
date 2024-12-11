using Microsoft.EntityFrameworkCore;
using StudentManagementDAL.Models;

namespace StudentManagementDAL.Data
{
    public class StudentDBContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasIndex(e => e.Id);
            modelBuilder.Entity<Student>()
               .HasOne(s => s.University)
               .WithMany(u => u.Students)
               .HasForeignKey(s => s.UniversityId);
            //base.OnModelCreating(modelBuilder);
        }
        public StudentDBContext(DbContextOptions<StudentDBContext> options) : base(options)
        {

        }


        public DbSet<Student> Students { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<University> Universities { get; set; }
    }
}
