using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AMIProjectAPI.Models;

public partial class AmiprojectContext : DbContext
{
    public AmiprojectContext()
    {
    }

    public AmiprojectContext(DbContextOptions<AmiprojectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bill> Bills { get; set; }

    public virtual DbSet<Consumer> Consumers { get; set; }

    public virtual DbSet<ConsumerLogin> ConsumerLogins { get; set; }

    public virtual DbSet<DailyConsumption> DailyConsumptions { get; set; }

    public virtual DbSet<Meter> Meters { get; set; }

    public virtual DbSet<MonthlyConsumption> MonthlyConsumptions { get; set; }

    public virtual DbSet<OrgUnit> OrgUnits { get; set; }

    public virtual DbSet<Tariff> Tariffs { get; set; }

    public virtual DbSet<TariffSlab> TariffSlabs { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bill>(entity =>
        {
            entity.HasKey(e => e.BillId).HasName("PK__Bill__11F2FC4A01285CBF");

            entity.ToTable("Bill");

            entity.Property(e => e.BillId).HasColumnName("BillID");
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.BaseRate).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Category).HasMaxLength(50);
            entity.Property(e => e.GeneratedAt)
                .HasPrecision(3)
                .HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.MeterId)
                .HasMaxLength(50)
                .HasColumnName("MeterID");
            entity.Property(e => e.MonthlyConsumptionkWh).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.SlabRate).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("Pending");
            entity.Property(e => e.TaxRate).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Meter).WithMany(p => p.Bills)
                .HasForeignKey(d => d.MeterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Bill__MeterID__4C6B5938");
        });

        modelBuilder.Entity<Consumer>(entity =>
        {
            entity.HasKey(e => e.ConsumerId).HasName("PK__Consumer__63BBE99A68520A2C");

            entity.ToTable("Consumer", tb => tb.HasTrigger("trg_Update_ConsumerTimestamp"));

            entity.Property(e => e.ConsumerId).HasColumnName("ConsumerID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.CreatedAt)
                .HasPrecision(3)
                .HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("admin");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Active");
            entity.Property(e => e.UpdatedAt).HasPrecision(3);
            entity.Property(e => e.UpdatedBy).HasMaxLength(100);

            entity.HasOne(d => d.Tariff).WithMany(p => p.Consumers)
                .HasForeignKey(d => d.TariffId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Consumer__Tariff__3864608B");
        });

        modelBuilder.Entity<ConsumerLogin>(entity =>
        {
            entity.HasKey(e => e.ConsumerLoginId).HasName("PK__Consumer__E6D708D7971BF8D5");

            entity.ToTable("ConsumerLogin");

            entity.HasIndex(e => e.Username, "UQ__Consumer__536C85E4CE88D471").IsUnique();

            entity.HasIndex(e => e.ConsumerId, "UQ__Consumer__63BBE99B15E0A00D").IsUnique();

            entity.Property(e => e.ConsumerLoginId).HasColumnName("ConsumerLoginID");
            entity.Property(e => e.ConsumerId).HasColumnName("ConsumerID");
            entity.Property(e => e.IsVerified).HasDefaultValue(false);
            entity.Property(e => e.LastLogin).HasPrecision(3);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("Active");
            entity.Property(e => e.Username).HasMaxLength(50);

            entity.HasOne(d => d.Consumer).WithOne(p => p.ConsumerLogin)
                .HasForeignKey<ConsumerLogin>(d => d.ConsumerId)
                .HasConstraintName("FK__ConsumerL__Consu__5D95E53A");
        });

        modelBuilder.Entity<DailyConsumption>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DailyConsumption", tb => tb.HasTrigger("trg_UpdateMonthlyConsumption"));

            entity.Property(e => e.ConsumptionkWh).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.MeterId)
                .HasMaxLength(50)
                .HasColumnName("MeterID");

            entity.HasOne(d => d.Meter).WithMany()
                .HasForeignKey(d => d.MeterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DailyCons__Meter__45BE5BA9");
        });

        modelBuilder.Entity<Meter>(entity =>
        {
            entity.HasKey(e => e.MeterSerialNo).HasName("PK__Meter__5C498B0F61327F6F");

            entity.ToTable("Meter");

            entity.Property(e => e.MeterSerialNo).HasMaxLength(50);
            entity.Property(e => e.Category).HasMaxLength(50);
            entity.Property(e => e.ConsumerId).HasColumnName("ConsumerID");
            entity.Property(e => e.Firmware).HasMaxLength(20);
            entity.Property(e => e.Iccid)
                .HasMaxLength(50)
                .HasColumnName("ICCID");
            entity.Property(e => e.Imsi)
                .HasMaxLength(50)
                .HasColumnName("IMSI");
            entity.Property(e => e.InstallDate).HasPrecision(3);
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(50)
                .HasColumnName("IPAddress");
            entity.Property(e => e.Manufacturer).HasMaxLength(100);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Active");

            entity.HasOne(d => d.Consumer).WithMany(p => p.Meters)
                .HasForeignKey(d => d.ConsumerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Meter__ConsumerI__40058253");

            entity.HasOne(d => d.OrgUnit).WithMany(p => p.Meters)
                .HasForeignKey(d => d.OrgUnitId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Meter__OrgUnitId__41EDCAC5");
        });

        modelBuilder.Entity<MonthlyConsumption>(entity =>
        {
            entity.HasKey(e => new { e.MeterId, e.MonthStartDate });

            entity.ToTable("MonthlyConsumption", tb => tb.HasTrigger("trg_AutoGenerateBill"));

            entity.Property(e => e.MeterId)
                .HasMaxLength(50)
                .HasColumnName("MeterID");
            entity.Property(e => e.ConsumptionkWh).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Meter).WithMany(p => p.MonthlyConsumptions)
                .HasForeignKey(d => d.MeterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MonthlyCo__Meter__489AC854");
        });

        modelBuilder.Entity<OrgUnit>(entity =>
        {
            entity.HasKey(e => e.OrgUnitId).HasName("PK__OrgUnit__4A793B8E52AAD40D");

            entity.ToTable("OrgUnit");

            entity.Property(e => e.OrgUnitId).HasColumnName("OrgUnitID");
            entity.Property(e => e.Dtr)
                .HasMaxLength(100)
                .HasColumnName("DTR");
            entity.Property(e => e.Feeder).HasMaxLength(100);
            entity.Property(e => e.Substation).HasMaxLength(100);
            entity.Property(e => e.Zone).HasMaxLength(100);
        });

        modelBuilder.Entity<Tariff>(entity =>
        {
            entity.HasKey(e => e.TariffId).HasName("PK__Tariff__EBAF9D9318D8DF06");

            entity.ToTable("Tariff");

            entity.Property(e => e.TariffId).HasColumnName("TariffID");
            entity.Property(e => e.BaseRate).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TariffName).HasMaxLength(100);
            entity.Property(e => e.TaxRate).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<TariffSlab>(entity =>
        {
            entity.HasKey(e => e.SlabId).HasName("PK__TariffSl__D6169921146B4B55");

            entity.ToTable("TariffSlab");

            entity.Property(e => e.FromKwh).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.RatePerKwh).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.TariffId).HasColumnName("TariffID");
            entity.Property(e => e.ToKwh).HasColumnType("decimal(18, 6)");

            entity.HasOne(d => d.Tariff).WithMany(p => p.TariffSlabs)
                .HasForeignKey(d => d.TariffId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TariffSla__Tarif__3493CFA7");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC216BFCFA");

            entity.HasIndex(e => e.Username, "UQ__Users__536C85E42780D375").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.DisplayName).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.LastLogin).HasColumnType("datetime");
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("Active");
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
