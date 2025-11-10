using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebServer.Models;

public partial class BlazorTutorialContext : DbContext
{
    public BlazorTutorialContext()
    {
    }

    public BlazorTutorialContext(DbContextOptions<BlazorTutorialContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Student__3214EC07EA259DA4");

            entity.ToTable("Student");

            entity.Property(e => e.Birthday).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
