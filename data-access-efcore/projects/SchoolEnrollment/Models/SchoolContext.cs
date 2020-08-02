using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace SchoolEnrollment
{
    public partial class SchoolContext : DbContext
    {
        public SchoolContext()
        {

        }

        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("server=localhost;Database=SchoolEnrollment;Trusted_Connection=True;");
                // optionsBuilder.UseSqlite("Data Source=school.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enrollment>(entity =>
            {
                entity.HasKey(e => e.EnrollmentID);
                entity.ToTable("enrollments");
                entity.Property(e => e.EnrollmentID).ValueGeneratedOnAdd();

            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.StudentID);
                entity.ToTable("students");
                entity.Property(e => e.StudentID).ValueGeneratedOnAdd();

            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.CourseID);
                entity.ToTable("courses");
                entity.Property(e => e.CourseID).ValueGeneratedOnAdd();


            });


        }
    }
}