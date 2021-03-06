﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ASPNETCoreWithVueJs.Models
{
    public partial class CoreDbContext : DbContext
    {
        public CoreDbContext()
        {
        }

        public CoreDbContext(DbContextOptions<CoreDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<StudentStatus> StudentStatus { get; set; }
        public virtual DbSet<Course> Course { get; set; }

        public virtual DbSet<CoursesStudents> CoursesStudents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=Students;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.PkstudentId)
                    .HasName("PK__Student__2DF65722AEE6E7C7");

                entity.HasOne(d => d.StudentStatus)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.StudentStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKStudentStatus");
            });

            modelBuilder.Entity<StudentStatus>(entity =>
            {
                entity.HasKey(e => e.PkstudentStatusId)
                    .HasName("PK__StudentS__5BEEBD4FB5D5165A");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.PkcourseId)
                    .HasName("PK__Course__5655AD102DDA3DE8");
            });

            modelBuilder.Entity<CoursesStudents>(entity =>
            {
                entity.HasKey(cs => new { cs.CourseID, cs.StudentID });

                entity.HasOne(cs => cs.Course)
                .WithMany(c => c.CoursesStudents)
                .HasForeignKey(cs => cs.CourseID);

                entity.HasOne(cs => cs.Student)
                .WithMany(s => s.CoursesStudents)
                .HasForeignKey(cs => cs.StudentID);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
