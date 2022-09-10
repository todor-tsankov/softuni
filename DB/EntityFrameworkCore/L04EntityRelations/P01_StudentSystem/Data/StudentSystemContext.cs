using System.ComponentModel.Design.Serialization;

using P01_StudentSystem.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        private const string ConnectionString = "Server=.;Database=StudentSystem;Integrated Security=true;";

        public StudentSystemContext()
            : base()
        {
        }

        public StudentSystemContext(DbContextOptions<StudentSystemContext> dbContextOptions)
            : base(dbContextOptions)
        {
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<Homework> HomeworkSubmissions { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>()
                        .HasKey(x => new { x.CourseId, x.StudentId });

            modelBuilder.Entity<Homework>()
                        .ToTable("HomeworkSubmissions");

            modelBuilder.Entity<Homework>()
                        .Property(x => x.Content)
                        .IsUnicode(false);

            modelBuilder.Entity<Student>()
                        .Property(x => x.PhoneNumber)
                        .HasColumnType("char(10)");

            modelBuilder.Entity<Student>()
                        .Property(x => x.Birthday)
                        .IsRequired(false);

            modelBuilder.Entity<Resource>()
                        .Property(x => x.Url)
                        .IsUnicode(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
