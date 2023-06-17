using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DrugManagement.Data.Entities;

public partial class DmsContext : DbContext
{
    public DmsContext()
    {
    }

    public DmsContext(DbContextOptions<DmsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblDrug> TblDrugs { get; set; }

    public virtual DbSet<TblSupplier> TblSuppliers { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=KEERTHIK;Database=DMS;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblDrug>(entity =>
        {
            entity.ToTable("tblDrug");

            entity.Property(e => e.ExpiryDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SerialNumber).HasMaxLength(50);

            entity.HasOne(d => d.Supplier).WithMany(p => p.TblDrugs)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("FK_tblDrug_tblSupplier");
        });

        modelBuilder.Entity<TblSupplier>(entity =>
        {
            entity.ToTable("tblSupplier");

            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tblUser");

            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
