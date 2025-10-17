using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Student_Database.Models;

public partial class CollegeContext : DbContext
{
    public CollegeContext()
    {
    }

    public CollegeContext(DbContextOptions<CollegeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.ToTable("Course");

            entity.Property(e => e.Rank).HasColumnName("rank");
            entity.Property(e => e.CourseName).HasColumnName("CourseName");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable("Student");

            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.Name).HasColumnName("Name").HasMaxLength(50);
            entity.Property(e => e.Email).HasColumnName("Email");
            entity.Property(e => e.Age).HasColumnName("Age");
            entity.Property(e => e.City).HasColumnName("City");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
