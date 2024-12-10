using Microsoft.EntityFrameworkCore;
using StudentManagementMODELS.Models;

namespace StudentManagementDAL.Data
{
    public class StudentDBContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasIndex(e => e.Id);
            base.OnModelCreating(modelBuilder);
        }
        public StudentDBContext(DbContextOptions<StudentDBContext> options) : base(options)
        {

        }


        public DbSet<Student> Students { get; set; }
    }
}
