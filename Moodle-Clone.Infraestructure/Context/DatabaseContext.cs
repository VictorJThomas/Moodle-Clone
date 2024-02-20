using Microsoft.EntityFrameworkCore;
using Moodle_Clone.Domain.Models;

namespace Moodle_Clone.Infraestructure.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) 
        {
        }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Role> Role { get; set; } 
        public DbSet<Resources> Resources { get; set; } 
        public DbSet<Forum> Forums { get; set; } 
        public DbSet<Courses> Courses { get; set; } 
        public DbSet<Assignments> Assignments { get; set; } 
        public DbSet<Answers> Answers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>().Property(p => p.TeacherId).ValueGeneratedOnAdd();

            modelBuilder.Entity<Users>().Property(p => p.UserId).IsRequired().ValueGeneratedOnAdd();

            modelBuilder.Entity<Student>().Property(p => p.StudentId).ValueGeneratedOnAdd();

            modelBuilder.Entity<Role>().Property(p => p.RolId).ValueGeneratedOnAdd();

            modelBuilder.Entity<Resources>().Property(p => p.ResourcesId).ValueGeneratedOnAdd();

            modelBuilder.Entity<Forum>().Property(p => p.ForumId).ValueGeneratedOnAdd();

            modelBuilder.Entity<Courses>().Property(p => p.CourseId).ValueGeneratedOnAdd();

            modelBuilder.Entity<Assignments>().Property(p => p.AssignmentsId).ValueGeneratedOnAdd();

            modelBuilder.Entity<Answers>().Property(p => p.AnswerId).ValueGeneratedOnAdd();

            base.OnModelCreating(modelBuilder);
        }
    }
}
