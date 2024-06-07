using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Entities
{
    public partial class ravenContext : DbContext
    {
        public ravenContext()
        {
        }

        public ravenContext(DbContextOptions<ravenContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DateCode> DateCodes { get; set; } = null!;
        public virtual DbSet<HighPurityMaterial> HighPurityMaterials { get; set; } = null!;
        public virtual DbSet<RawMaterialLog> RawMaterialLogs { get; set; } = null!;
        public virtual DbSet<RawMaterialVendor> RawMaterialVendors { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=raven; Username=postgres;Password=password");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DateCode>(entity =>
            {
                entity.HasKey(e => e.DateId)
                    .HasName("date_code_pkey");

                entity.ToTable("date_code", "distillation");

                entity.Property(e => e.DateId)
                    .ValueGeneratedNever()
                    .HasColumnName("date_id");

                entity.Property(e => e.DateCode1)
                    .HasMaxLength(1)
                    .HasColumnName("date_code");
            });

            modelBuilder.Entity<HighPurityMaterial>(entity =>
            {
                entity.HasKey(e => e.MaterialNumber)
                    .HasName("high_purity_material_pkey");

                entity.ToTable("high_purity_material", "materials");

                entity.Property(e => e.MaterialNumber)
                    .ValueGeneratedNever()
                    .HasColumnName("material_number");

                entity.Property(e => e.BatchManaged).HasColumnName("batch_managed");

                entity.Property(e => e.Binomial)
                    .HasMaxLength(6)
                    .HasColumnName("binomial");

                entity.Property(e => e.MaterialCode)
                    .HasMaxLength(3)
                    .HasColumnName("material_code");

                entity.Property(e => e.MaterialName)
                    .HasMaxLength(25)
                    .HasColumnName("material_name");

                entity.Property(e => e.PermitNumber)
                    .HasMaxLength(25)
                    .HasColumnName("permit_number");

                entity.Property(e => e.SequenceId).HasColumnName("sequence_id");

                entity.Property(e => e.TotalRecords).HasColumnName("total_records");

                entity.Property(e => e.UnitOfIssue)
                    .HasMaxLength(3)
                    .HasColumnName("unit_of_issue");
            });

            modelBuilder.Entity<RawMaterialLog>(entity =>
            {
                entity.HasKey(e => e.ProductLotNumber)
                    .HasName("raw_material_log_pkey");

                entity.ToTable("raw_material_log", "distillation");

                entity.Property(e => e.ProductLotNumber)
                    .HasMaxLength(10)
                    .HasColumnName("product_lot_number");

                entity.Property(e => e.ContainerNumber)
                    .HasMaxLength(7)
                    .HasColumnName("container_number");

                entity.Property(e => e.InspectionLotNumber).HasColumnName("inspection_lot_number");

                entity.Property(e => e.IssueDate).HasColumnName("issue_date");

                entity.Property(e => e.MaterialNumber).HasColumnName("material_number");

                entity.Property(e => e.NetWeight)
                    .HasColumnName("net_weight")
                    .HasDefaultValueSql("180");

                entity.Property(e => e.ProductBatchNumber).HasColumnName("product_batch_number");

                entity.Property(e => e.SampleId).HasColumnName("sample_id");

                entity.Property(e => e.VendorLotNumber)
                    .HasMaxLength(25)
                    .HasColumnName("vendor_lot_number");

                entity.Property(e => e.VendorName)
                    .HasMaxLength(25)
                    .HasColumnName("vendor_name");

                entity.HasOne(d => d.MaterialNumberNavigation)
                    .WithMany(p => p.RawMaterialLogs)
                    .HasForeignKey(d => d.MaterialNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("raw_material_log_material_number_fkey");
            });

            modelBuilder.Entity<RawMaterialVendor>(entity =>
            {
                entity.HasKey(e => e.MaterialNumber)
                    .HasName("raw_material_vendor_pkey");

                entity.ToTable("raw_material_vendor", "materials");

                entity.Property(e => e.MaterialNumber)
                    .ValueGeneratedNever()
                    .HasColumnName("material_number");

                entity.Property(e => e.BatchManaged).HasColumnName("batch_managed");

                entity.Property(e => e.ContainerNumberRequired).HasColumnName("container_number_required");

                entity.Property(e => e.MaterialCode)
                    .HasMaxLength(3)
                    .HasColumnName("material_code");

                entity.Property(e => e.ParentMaterialNumber).HasColumnName("parent_material_number");

                entity.Property(e => e.SequenceId).HasColumnName("sequence_id");

                entity.Property(e => e.TotalRecords).HasColumnName("total_records");

                entity.Property(e => e.UnitOfIssue)
                    .HasMaxLength(3)
                    .HasColumnName("unit_of_issue");

                entity.Property(e => e.VendorName)
                    .HasMaxLength(25)
                    .HasColumnName("vendor_name");

                entity.HasOne(d => d.ParentMaterialNumberNavigation)
                    .WithMany(p => p.RawMaterialVendors)
                    .HasForeignKey(d => d.ParentMaterialNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("raw_material_vendor_parent_material_number_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
