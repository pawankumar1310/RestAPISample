using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RestAPISample.Models;

public partial class StudentDbContext : DbContext
{
    public StudentDbContext()
    {
    }

    public StudentDbContext(DbContextOptions<StudentDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //     => optionsBuilder.UseSqlServer("Server=DESKTOP-RUJ2TUO;Database=StudentDbDemo;Trusted_Connection=true;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable("Student");

            entity.Property(e => e.StudentId)
                .HasMaxLength(50)
                .HasColumnName("Student_ID");
            entity.Property(e => e.Class)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("gender");
            entity.Property(e => e.GradeId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("GradeID");
            entity.Property(e => e.NationalIty)
                .HasMaxLength(50)
                .HasColumnName("NationalITy");
            entity.Property(e => e.ParentAnsweringSurvey)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ParentschoolSatisfaction).HasMaxLength(50);
            entity.Property(e => e.PlaceofBirth).HasMaxLength(50);
            entity.Property(e => e.Raisedhands).HasColumnName("raisedhands");
            entity.Property(e => e.Relation).HasMaxLength(50);
            entity.Property(e => e.SectionId)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SectionID");
            entity.Property(e => e.Semester)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.StageId)
                .HasMaxLength(50)
                .HasColumnName("StageID");
            entity.Property(e => e.StudentAbsenceDays).HasMaxLength(50);
            entity.Property(e => e.StudentMarks).HasColumnName("Student_Marks");
            entity.Property(e => e.Topic).HasMaxLength(50);
            entity.Property(e => e.VisItedResources).HasColumnName("VisITedResources");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
