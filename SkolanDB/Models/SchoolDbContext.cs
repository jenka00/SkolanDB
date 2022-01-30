﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SkolanDB.Models
{
    public partial class SchoolDbContext : DbContext
    {
        public SchoolDbContext()
        {
        }

        public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Grades> Grades { get; set; }
        public virtual DbSet<HeadMaster> HeadMaster { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<StudentCourse> StudentCourse { get; set; }
        public virtual DbSet<StudentGrade> StudentGrade { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }
        public virtual DbSet<VWgradesBiology1> VWgradesBiology1 { get; set; }
        public virtual DbSet<VWgradesChemistry1> VWgradesChemistry1 { get; set; }
        public virtual DbSet<VWgradesEnglish1> VWgradesEnglish1 { get; set; }
        public virtual DbSet<VWgradesEnglish2> VWgradesEnglish2 { get; set; }
        public virtual DbSet<VWgradesMathematics1> VWgradesMathematics1 { get; set; }
        public virtual DbSet<VWgradesOneMonth> VWgradesOneMonth { get; set; }
        public virtual DbSet<VWgradesSwedish1> VWgradesSwedish1 { get; set; }
        public virtual DbSet<VWshowAllAdmin> VWshowAllAdmin { get; set; }
        public virtual DbSet<VWshowAllHeadMasters> VWshowAllHeadMasters { get; set; }
        public virtual DbSet<VWshowAllStaff> VWshowAllStaff { get; set; }
        public virtual DbSet<VWshowAllTeachers> VWshowAllTeachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source = DESKTOP-I9VU7M4;Initial Catalog=School;Integrated Security = True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.Property(e => e.AdminId)
                    .HasColumnName("AdminID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasColumnName("FName")
                    .HasMaxLength(50);

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasColumnName("LName")
                    .HasMaxLength(50);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.Property(e => e.ClassId)
                    .HasColumnName("ClassID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ClassName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("date");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.CourseId)
                    .HasColumnName("CourseID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CourseName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("date");
            });

            modelBuilder.Entity<Grades>(entity =>
            {
                entity.HasKey(e => e.GradeId)
                    .HasName("PK_Grade");

                entity.Property(e => e.GradeId)
                    .HasColumnName("GradeID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<HeadMaster>(entity =>
            {
                entity.Property(e => e.HeadMasterId)
                    .HasColumnName("HeadMasterID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasColumnName("FName")
                    .HasMaxLength(50);

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasColumnName("LName")
                    .HasMaxLength(50);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.StudentId)
                    .HasColumnName("StudentID")
                    .ValueGeneratedNever();

                entity.Property(e => e.FkclassId).HasColumnName("FKClassID");

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasColumnName("FName")
                    .HasMaxLength(50);

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasColumnName("LName")
                    .HasMaxLength(50);

                entity.Property(e => e.PersonalNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Fkclass)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.FkclassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_Class");
            });

            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity.Property(e => e.StudentCourseId)
                    .HasColumnName("StudentCourseID")
                    .ValueGeneratedNever();

                entity.Property(e => e.FkcourseId).HasColumnName("FKCourseID");

                entity.Property(e => e.FkstudentId).HasColumnName("FKStudentID");

                entity.Property(e => e.FkteacherId).HasColumnName("FKTeacherID");

                entity.HasOne(d => d.Fkcourse)
                    .WithMany(p => p.StudentCourse)
                    .HasForeignKey(d => d.FkcourseId)
                    .HasConstraintName("FK_StudentCourse_Course");

                entity.HasOne(d => d.Fkstudent)
                    .WithMany(p => p.StudentCourse)
                    .HasForeignKey(d => d.FkstudentId)
                    .HasConstraintName("FK_StudentCourse_Student");

                entity.HasOne(d => d.Fkteacher)
                    .WithMany(p => p.StudentCourse)
                    .HasForeignKey(d => d.FkteacherId)
                    .HasConstraintName("FK_StudentCourse_Teacher");
            });

            modelBuilder.Entity<StudentGrade>(entity =>
            {
                entity.Property(e => e.StudentGradeId)
                    .HasColumnName("StudentGradeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.FkcourseId).HasColumnName("FKCourseID");

                entity.Property(e => e.FkgradeId).HasColumnName("FKGradeID");

                entity.Property(e => e.FkstudentId).HasColumnName("FKStudentID");

                entity.Property(e => e.FkteacherId).HasColumnName("FKTeacherID");

                entity.Property(e => e.GradeDate).HasColumnType("date");

                entity.HasOne(d => d.Fkcourse)
                    .WithMany(p => p.StudentGrade)
                    .HasForeignKey(d => d.FkcourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentGrade_Course");

                entity.HasOne(d => d.Fkgrade)
                    .WithMany(p => p.StudentGrade)
                    .HasForeignKey(d => d.FkgradeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentGrade_Grades");

                entity.HasOne(d => d.Fkstudent)
                    .WithMany(p => p.StudentGrade)
                    .HasForeignKey(d => d.FkstudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentGrade_Student");

                entity.HasOne(d => d.Fkteacher)
                    .WithMany(p => p.StudentGrade)
                    .HasForeignKey(d => d.FkteacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentGrade_Teacher");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.Property(e => e.TeacherId)
                    .HasColumnName("TeacherID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasColumnName("FName")
                    .HasMaxLength(50);

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasColumnName("LName")
                    .HasMaxLength(50);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<VWgradesBiology1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vWGradesBiology1");

                entity.Property(e => e.AverageGradeBiology1).HasColumnName("Average grade Biology 1");

                entity.Property(e => e.HighestGradeBiology1).HasColumnName("Highest grade Biology 1");

                entity.Property(e => e.LowestGradeBiology1).HasColumnName("Lowest grade Biology 1");
            });

            modelBuilder.Entity<VWgradesChemistry1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vWGradesChemistry1");

                entity.Property(e => e.AverageGradeChemistry1).HasColumnName("Average grade Chemistry 1");

                entity.Property(e => e.HighestGradeChemistry1).HasColumnName("Highest grade Chemistry 1");

                entity.Property(e => e.LowestGradeChemistry1).HasColumnName("Lowest grade Chemistry 1");
            });

            modelBuilder.Entity<VWgradesEnglish1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vWGradesEnglish1");

                entity.Property(e => e.AverageGradeEnglish1).HasColumnName("Average grade English 1");

                entity.Property(e => e.HighestGradeEnglish1).HasColumnName("Highest grade English 1");

                entity.Property(e => e.LowestGradeEnglish1).HasColumnName("Lowest grade English 1");
            });

            modelBuilder.Entity<VWgradesEnglish2>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vWGradesEnglish2");

                entity.Property(e => e.AverageGradeEnglish2).HasColumnName("Average grade English 2");

                entity.Property(e => e.HighestGradeEnglish2).HasColumnName("Highest grade English 2");

                entity.Property(e => e.LowestGradeEnglish2).HasColumnName("Lowest grade English 2");
            });

            modelBuilder.Entity<VWgradesMathematics1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vWGradesMathematics1");

                entity.Property(e => e.AverageGradeMathematics1).HasColumnName("Average grade Mathematics 1");

                entity.Property(e => e.HighestGradeMathematics1).HasColumnName("Highest grade Mathematics 1");

                entity.Property(e => e.LowestGradeMathematics1).HasColumnName("Lowest grade Mathematics 1");
            });

            modelBuilder.Entity<VWgradesOneMonth>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vWGradesOneMonth");

                entity.Property(e => e.CourseName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasColumnName("FName")
                    .HasMaxLength(50);

                entity.Property(e => e.Grade)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GradeDate).HasColumnType("date");

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasColumnName("LName")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<VWgradesSwedish1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vWGradesSwedish1");

                entity.Property(e => e.AverageGradeSwedish1).HasColumnName("Average grade Swedish 1");

                entity.Property(e => e.HighestGradeSwedish1).HasColumnName("Highest grade Swedish 1");

                entity.Property(e => e.LowestGradeSwedish1).HasColumnName("Lowest grade Swedish 1");
            });

            modelBuilder.Entity<VWshowAllAdmin>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vWShowAllAdmin");

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasColumnName("FName")
                    .HasMaxLength(50);

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasColumnName("LName")
                    .HasMaxLength(50);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<VWshowAllHeadMasters>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vWShowAllHeadMasters");

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasColumnName("FName")
                    .HasMaxLength(50);

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasColumnName("LName")
                    .HasMaxLength(50);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<VWshowAllStaff>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vWShowAllStaff");

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasColumnName("FName")
                    .HasMaxLength(50);

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasColumnName("LName")
                    .HasMaxLength(50);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<VWshowAllTeachers>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vWShowAllTeachers");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.CourseName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasColumnName("FName")
                    .HasMaxLength(50);

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasColumnName("LName")
                    .HasMaxLength(50);

                entity.Property(e => e.TeacherId).HasColumnName("TeacherID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}