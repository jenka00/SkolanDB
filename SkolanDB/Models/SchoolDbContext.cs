using System;
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

        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeeDepartment> EmployeeDepartment { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<StudentCourse> StudentCourse { get; set; }
        public virtual DbSet<VWallCoursesAllGrades> VWallCoursesAllGrades { get; set; }
        public virtual DbSet<VWgradesBiology1> VWgradesBiology1 { get; set; }
        public virtual DbSet<VWgradesChemistry1> VWgradesChemistry1 { get; set; }
        public virtual DbSet<VWgradesEnglish1> VWgradesEnglish1 { get; set; }
        public virtual DbSet<VWgradesEnglish2> VWgradesEnglish2 { get; set; }
        public virtual DbSet<VWgradesEnglish3> VWgradesEnglish3 { get; set; }
        public virtual DbSet<VWgradesHistory1> VWgradesHistory1 { get; set; }
        public virtual DbSet<VWgradesHistory2> VWgradesHistory2 { get; set; }
        public virtual DbSet<VWgradesMathematics1> VWgradesMathematics1 { get; set; }
        public virtual DbSet<VWgradesMathematics2> VWgradesMathematics2 { get; set; }
        public virtual DbSet<VWgradesMathematics3> VWgradesMathematics3 { get; set; }
        public virtual DbSet<VWgradesOneMonth> VWgradesOneMonth { get; set; }
        public virtual DbSet<VWgradesSwedish1> VWgradesSwedish1 { get; set; }
        public virtual DbSet<VWgradesSwedish2> VWgradesSwedish2 { get; set; }
        public virtual DbSet<VWsalaryInDepartments> VWsalaryInDepartments { get; set; }
        public virtual DbSet<VWshowActiveCourses> VWshowActiveCourses { get; set; }
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
            modelBuilder.Entity<Class>(entity =>
            {
                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.ClassName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("date");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.CourseName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FkdepartmentId).HasColumnName("FKDepartmentID");

                entity.HasOne(d => d.Fkdepartment)
                    .WithMany(p => p.Course)
                    .HasForeignKey(d => d.FkdepartmentId)
                    .HasConstraintName("FK_Course_Department");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmploymentId);

                entity.Property(e => e.EmploymentId).HasColumnName("EmploymentID");

                entity.Property(e => e.FkroleId).HasColumnName("FKRoleID");

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasColumnName("FName")
                    .HasMaxLength(50);

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasColumnName("LName")
                    .HasMaxLength(50);

                entity.Property(e => e.Salary).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Fkrole)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.FkroleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_Role");
            });

            modelBuilder.Entity<EmployeeDepartment>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.FkdepartmentId).HasColumnName("FKDepartmentID");

                entity.Property(e => e.FkemploymentId).HasColumnName("FKEmploymentID");

                entity.HasOne(d => d.Fkdepartment)
                    .WithMany()
                    .HasForeignKey(d => d.FkdepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeDepartment_Department");

                entity.HasOne(d => d.Fkemployment)
                    .WithMany()
                    .HasForeignKey(d => d.FkemploymentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeDepartment_Employee");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.StudentId).HasColumnName("StudentID");

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
                entity.Property(e => e.StudentCourseId).HasColumnName("StudentCourseID");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.FkcourseId).HasColumnName("FKCourseID");

                entity.Property(e => e.FkemploymentId).HasColumnName("FKEmploymentID");

                entity.Property(e => e.FkstudentId).HasColumnName("FKStudentID");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Fkcourse)
                    .WithMany(p => p.StudentCourse)
                    .HasForeignKey(d => d.FkcourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentCourse_Course");

                entity.HasOne(d => d.Fkemployment)
                    .WithMany(p => p.StudentCourse)
                    .HasForeignKey(d => d.FkemploymentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentCourse_Employee");

                entity.HasOne(d => d.Fkstudent)
                    .WithMany(p => p.StudentCourse)
                    .HasForeignKey(d => d.FkstudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentCourse_Student");
            });

            modelBuilder.Entity<VWallCoursesAllGrades>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vWAllCoursesAllGrades");

                entity.Property(e => e.CourseName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<VWgradesBiology1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vWGradesBiology1");

                entity.Property(e => e.CourseName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<VWgradesChemistry1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vWGradesChemistry1");

                entity.Property(e => e.CourseName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<VWgradesEnglish1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vWGradesEnglish1");

                entity.Property(e => e.CourseName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<VWgradesEnglish2>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vWGradesEnglish2");

                entity.Property(e => e.CourseName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<VWgradesEnglish3>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vWGradesEnglish3");

                entity.Property(e => e.CourseName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<VWgradesHistory1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vWGradesHistory1");

                entity.Property(e => e.CourseName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<VWgradesHistory2>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vWGradesHistory2");

                entity.Property(e => e.CourseName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<VWgradesMathematics1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vWGradesMathematics1");

                entity.Property(e => e.CourseName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<VWgradesMathematics2>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vWGradesMathematics2");

                entity.Property(e => e.CourseName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<VWgradesMathematics3>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vWGradesMathematics3");

                entity.Property(e => e.CourseName)
                    .IsRequired()
                    .HasMaxLength(50);
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

                entity.Property(e => e.CourseName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<VWgradesSwedish2>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vWGradesSwedish2");

                entity.Property(e => e.CourseName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<VWsalaryInDepartments>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vWSalaryInDepartments");

                entity.Property(e => e.AverageSalary).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SumSalaryMonth)
                    .HasColumnName("SumSalary/Month")
                    .HasColumnType("decimal(38, 0)");
            });

            modelBuilder.Entity<VWshowActiveCourses>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vWShowActiveCourses");

                entity.Property(e => e.ActiveCourses)
                    .IsRequired()
                    .HasColumnName("Active Courses")
                    .HasMaxLength(50);

                entity.Property(e => e.CourseId).HasColumnName("CourseID");
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

                entity.Property(e => e.RoleName)
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

                entity.Property(e => e.RoleName)
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

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<VWshowAllTeachers>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vWShowAllTeachers");

                entity.Property(e => e.EmploymentId).HasColumnName("EmploymentID");

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasColumnName("FName")
                    .HasMaxLength(50);

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasColumnName("LName")
                    .HasMaxLength(50);

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
