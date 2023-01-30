using AlIInOne.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AlIInOne.Context
{
    public class AllInOneDbContext : IdentityUserContext<IdentityUser>
    {
        public AllInOneDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Build Lesson - Student Many-to-Many Relationship
            modelBuilder
                .Entity<LessonStudent>()
                .HasKey(ls => new { ls.StudentId, ls.LessonId });
            modelBuilder
                .Entity<LessonStudent>()
                .HasOne(ls => ls.Student)
                .WithMany(s => s.LessonStudents)
                .HasForeignKey(ls => ls.StudentId);
            modelBuilder
                .Entity<LessonStudent>()
                .HasOne(ls => ls.Lesson)
                .WithMany(l => l.LessonStudents)
                .HasForeignKey(ls => ls.LessonId);

            // Build Lesson Lecturer One-to-Many relationship
            modelBuilder
                .Entity<Lecturer>()
                .HasMany(l => l.Lessons)
                .WithOne(lesson => lesson.Lecturer)
                .HasForeignKey(l => l.LecturerId);
            modelBuilder
                .Entity<Lesson>()
                .HasOne(l => l.Lecturer)
                .WithMany(l2 => l2.Lessons)
                .HasForeignKey(l => l.LecturerId);
        }

        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<LessonStudent> LessonStudents { get; set; }
        //public DbSet<User> Users { get; set; }
    }
}
