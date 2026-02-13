using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MVCWithEFCore.Models;

public partial class SmsContext : DbContext
{
    public SmsContext()
    {
    }

    public SmsContext(DbContextOptions<SmsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdminDatum> AdminData { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<EmployeeDatum> EmployeeData { get; set; }

    public virtual DbSet<Invenotry> Invenotries { get; set; }

    public virtual DbSet<SubCategory> SubCategories { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

        modelBuilder.Entity<AdminDatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__adminDat__3213E83F1D6A5EC6");

            entity.ToTable("adminData");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AEmail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("aEmail");
            entity.Property(e => e.AImage).HasColumnName("aImage");
            entity.Property(e => e.AName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("aName");
            entity.Property(e => e.APassword)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("aPassword");
            entity.Property(e => e.AUsername)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("aUsername");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryName).HasName("PK__Categori__8517B2E15655D4B5");

            entity.Property(e => e.CategoryName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
        });

        modelBuilder.Entity<EmployeeDatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__employee__3213E83F1A94C43C");

            entity.ToTable("employeeData");

            entity.HasIndex(e => e.EEmail, "UQ__employee__47688921F0022025").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AImage).HasColumnName("aImage");
            entity.Property(e => e.EEmail)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("eEmail");
            entity.Property(e => e.EJobTitle)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("eJobTitle");
            entity.Property(e => e.EJoinDate).HasColumnName("eJoinDate");
            entity.Property(e => e.EName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("eName");
            entity.Property(e => e.EPhone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("ePhone");
            entity.Property(e => e.ESalary)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("eSalary");
            entity.Property(e => e.EShift)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("eShift");
        });

        modelBuilder.Entity<Invenotry>(entity =>
        {
            entity.HasKey(e => e.ProId).HasName("PK__Invenotr__620295F03D45BF9B");

            entity.ToTable("Invenotry");

            entity.Property(e => e.ProId).HasColumnName("ProID");
            entity.Property(e => e.ProCategory)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ProName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ProOrderPrice).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ProPricePerItem).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ProSubCat)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ProSupplier)
                .HasMaxLength(45)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SubCategory>(entity =>
        {
            entity.HasKey(e => e.SubCategoryName).HasName("PK__SubCateg__0BBDA28A244835AC");

            entity.Property(e => e.SubCategoryName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CategoryName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");

            entity.HasOne(d => d.CategoryNameNavigation).WithMany(p => p.SubCategories)
                .HasForeignKey(d => d.CategoryName)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SubCatego__Categ__74AE54BC");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.SupId).HasName("PK__Supplier__B4F22192D5F36210");

            entity.ToTable("Supplier");

            entity.Property(e => e.SupId).HasColumnName("supID");
            entity.Property(e => e.SupAddress)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("supAddress");
            entity.Property(e => e.SupEmail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("supEmail");
            entity.Property(e => e.SupName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("supName");
            entity.Property(e => e.SupPhone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("supPhone");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
