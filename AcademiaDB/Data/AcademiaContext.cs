using System;
using System.Collections.Generic;
using AcademiaDB.Models;
using Microsoft.EntityFrameworkCore;

namespace AcademiaDB.Data;

public partial class AcademiaContext : DbContext
{
    public AcademiaContext()
    {
    }

    public AcademiaContext(DbContextOptions<AcademiaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<CourseAssignment> CourseAssignments { get; set; }

    public virtual DbSet<CourseEnrolment> CourseEnrolments { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<TopGrade> TopGrades { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("YourConnectionString");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.ClassId).HasName("PK__Classes__CB1927A062ADE826");

            entity.Property(e => e.ClassId).HasColumnName("ClassID");
            entity.Property(e => e.ClassName).HasMaxLength(35);
            entity.Property(e => e.EmployeeIdFk).HasColumnName("EmployeeID_FK");

            entity.HasOne(d => d.EmployeeIdFkNavigation).WithMany(p => p.Classes)
                .HasForeignKey(d => d.EmployeeIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Classes__Employe__2D27B809");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK__Courses__C92D718724BF5B27");

            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.Active).HasDefaultValue(true);
            entity.Property(e => e.CourseName).HasMaxLength(35);
        });

        modelBuilder.Entity<CourseAssignment>(entity =>
        {
            entity.HasKey(e => e.AssignmentId).HasName("PK__CourseAs__32499E57F6BC71B4");

            entity.Property(e => e.AssignmentId).HasColumnName("AssignmentID");
            entity.Property(e => e.CourseIdFk).HasColumnName("CourseID_FK");
            entity.Property(e => e.EmployeeIdFk).HasColumnName("EmployeeID_FK");

            entity.HasOne(d => d.CourseIdFkNavigation).WithMany(p => p.CourseAssignments)
                .HasForeignKey(d => d.CourseIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CourseAss__Cours__3B75D760");

            entity.HasOne(d => d.EmployeeIdFkNavigation).WithMany(p => p.CourseAssignments)
                .HasForeignKey(d => d.EmployeeIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CourseAss__Emplo__3A81B327");
        });

        modelBuilder.Entity<CourseEnrolment>(entity =>
        {
            entity.HasKey(e => e.EnrolmentId).HasName("PK__CourseEn__5C0E5FEF3B22BD9F");

            entity.ToTable(tb => tb.HasTrigger("trg_PreventInvalidGradeSetter"));

            entity.Property(e => e.EnrolmentId).HasColumnName("EnrolmentID");
            entity.Property(e => e.CourseIdFk).HasColumnName("CourseID_FK");
            entity.Property(e => e.Grade)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.GradeSetterFk).HasColumnName("GradeSetter_FK");
            entity.Property(e => e.StudentIdFk).HasColumnName("StudentID_FK");

            entity.HasOne(d => d.CourseIdFkNavigation).WithMany(p => p.CourseEnrolments)
                .HasForeignKey(d => d.CourseIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CourseEnr__Cours__36B12243");

            entity.HasOne(d => d.GradeSetterFkNavigation).WithMany(p => p.CourseEnrolments)
                .HasForeignKey(d => d.GradeSetterFk)
                .HasConstraintName("FK__CourseEnr__Grade__37A5467C");

            entity.HasOne(d => d.StudentIdFkNavigation).WithMany(p => p.CourseEnrolments)
                .HasForeignKey(d => d.StudentIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CourseEnr__Gradi__35BCFE0A");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__B2079BCD65F30F76");

            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.DepartmentName).HasMaxLength(35);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04FF1F9A331FA");

            entity.ToTable(tb => tb.HasTrigger("trg_ValidateEmployeeRole"));

            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.DepartmentIdFk).HasColumnName("DepartmentID_FK");
            entity.Property(e => e.EmployeeFirstName).HasMaxLength(35);
            entity.Property(e => e.EmployeeLastName).HasMaxLength(35);
            entity.Property(e => e.EmployeeSalary).HasColumnType("money");
            entity.Property(e => e.EmployeeSsn)
                .HasMaxLength(13)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("EmployeeSSN");
            entity.Property(e => e.RoleIdFk).HasColumnName("RoleID_FK");

            entity.HasOne(d => d.DepartmentIdFkNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DepartmentIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Employees__Depar__29572725");

            entity.HasOne(d => d.RoleIdFkNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.RoleIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Employees__RoleI__2A4B4B5E");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE3A367B7819");

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.DepartmentIdFk).HasColumnName("DepartmentID_FK");
            entity.Property(e => e.RoleName).HasMaxLength(35);

            entity.HasOne(d => d.DepartmentIdFkNavigation).WithMany(p => p.Roles)
                .HasForeignKey(d => d.DepartmentIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Roles__Departmen__267ABA7A");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Students__32C52A79434FC887");

            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.ClassIdFk).HasColumnName("ClassID_FK");
            entity.Property(e => e.StudentFirstName).HasMaxLength(35);
            entity.Property(e => e.StudentLastName).HasMaxLength(35);
            entity.Property(e => e.StudentSsn)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("StudentSSN");

            entity.HasOne(d => d.ClassIdFkNavigation).WithMany(p => p.Students)
                .HasForeignKey(d => d.ClassIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Students__ClassI__300424B4");
        });

        modelBuilder.Entity<TopGrade>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("TopGrades");

            entity.Property(e => e.Grade)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Name).HasMaxLength(71);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
