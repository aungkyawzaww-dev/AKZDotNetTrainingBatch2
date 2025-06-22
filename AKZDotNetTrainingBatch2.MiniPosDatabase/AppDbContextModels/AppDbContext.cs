using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AKZDotNetTrainingBatch2.MiniPosDatabase.AppDbContextModels;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblProduct> TblProducts { get; set; }

    public virtual DbSet<TblSaleDetail> TblSaleDetails { get; set; }

    public virtual DbSet<TblSaleSummary> TblSaleSummaries { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=DotNetTrainingBatch2MiniPos;User ID=sa;Password=sasa@123;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblProduct>(entity =>
        {
            entity.HasKey(e => e.ProductId);

            entity.ToTable("Tbl_Product");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Price)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblSaleDetail>(entity =>
        {
            entity.HasKey(e => e.SaleDetailId);

            entity.ToTable("Tbl_SaleDetail");

            entity.Property(e => e.Price)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ProductId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Quantity)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SaleId)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblSaleSummary>(entity =>
        {
            entity.HasKey(e => e.SaleId).HasName("PK_Tbl_Sale_Summary");

            entity.ToTable("Tbl_SaleSummary");

            entity.Property(e => e.SaleDate)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TotalAmount)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.VoucherNo)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
