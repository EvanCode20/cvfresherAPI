using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace cv_fresher_api.Models;

public partial class CvGenerateContext : DbContext
{
    public CvGenerateContext()
    {
    }

    public CvGenerateContext(DbContextOptions<CvGenerateContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Education> Educations { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<Reference> References { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server='lab000000\\SQLEXPRESS';Database='CV_GENERATE';Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Education>(entity =>
        {
            entity.HasKey(e => e.EducationId).HasName("PK__EDUCATIO__DA1AD9B177C25462");

            entity.ToTable("EDUCATION");

            entity.Property(e => e.EducationId).HasColumnName("EDUCATION_ID");
            entity.Property(e => e.NameOfInstitution)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NAME_OF_INSTITUTION");
            entity.Property(e => e.Qualification)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("QUALIFICATION");
            entity.Property(e => e.QualificationDuration).HasColumnName("QUALIFICATION_DURATION");
            entity.Property(e => e.UserId)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("USER_ID");

            entity.HasOne(d => d.User).WithMany(p => p.Educations)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__EDUCATION__USER___5165187F");
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.JobId).HasName("PK__JOB__2AC9D60AFFC89FF9");

            entity.ToTable("JOB");

            entity.Property(e => e.JobId).HasColumnName("JOB_ID");
            entity.Property(e => e.JobDescription)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("JOB_DESCRIPTION");
            entity.Property(e => e.JobDuration)
                .HasColumnType("date")
                .HasColumnName("JOB_DURATION");
            entity.Property(e => e.JobName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("JOB_NAME");
            entity.Property(e => e.UserId)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("USER_ID");

            entity.HasOne(d => d.User).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__JOB__USER_ID__4E88ABD4");
        });

        modelBuilder.Entity<Reference>(entity =>
        {
            entity.HasKey(e => e.ReferenceId).HasName("PK__REFERENC__E5F4B1D02783523B");

            entity.ToTable("REFERENCE");

            entity.Property(e => e.ReferenceId).HasColumnName("REFERENCE_ID");
            entity.Property(e => e.EmployerCellNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("EMPLOYER_CELL_NUMBER");
            entity.Property(e => e.EmployerCompany)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EMPLOYER_COMPANY");
            entity.Property(e => e.EmployerJobTitle)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EMPLOYER_JOB_TITLE");
            entity.Property(e => e.EmployerName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EMPLOYER_NAME");
            entity.Property(e => e.UserId)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("USER_ID");

            entity.HasOne(d => d.User).WithMany(p => p.References)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__REFERENCE__USER___5441852A");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.SkillsId).HasName("PK__SKILLS__8C9A9B7F3CCBA8E1");

            entity.ToTable("SKILLS");

            entity.Property(e => e.SkillsId).HasColumnName("SKILLS_ID");
            entity.Property(e => e.SkillsDescription)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SKILLS_DESCRIPTION");
            entity.Property(e => e.SkillsType)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SKILLS_TYPE");
            entity.Property(e => e.UserId)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("USER_ID");

            entity.HasOne(d => d.User).WithMany(p => p.Skills)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__SKILLS__USER_ID__4BAC3F29");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__USERS__F3BEEBFF4250FDD5");

            entity.ToTable("USERS");

            entity.Property(e => e.UserId)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("USER_ID");
            entity.Property(e => e.CellNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CELL_NUMBER");
            entity.Property(e => e.Dob)
                .HasColumnType("date")
                .HasColumnName("DOB");
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EMAIL_ADDRESS");
            entity.Property(e => e.Ethinicity)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ETHINICITY");
            entity.Property(e => e.Firstname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("FIRSTNAME");
            entity.Property(e => e.ResidentialAddress)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("RESIDENTIAL_ADDRESS");
            entity.Property(e => e.Surname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SURNAME");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
