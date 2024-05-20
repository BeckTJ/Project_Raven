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

        public virtual DbSet<Highpuritymaterial> Highpuritymaterials { get; set; } = null!;
        public virtual DbSet<Rawmateriallog> Rawmateriallogs { get; set; } = null!;
        public virtual DbSet<Rawmaterialvendor> Rawmaterialvendors { get; set; } = null!;

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
            modelBuilder.Entity<Highpuritymaterial>(entity =>
            {

                entity.HasKey(e => e.MaterialNumber)

                    .HasName("highpuritymaterial_pkey");

                entity.ToTable("highpuritymaterial", "materials");

                entity.Property(e => e.MaterialNumber)
                    .ValueGeneratedNever()
                    .HasColumnName("materialnumber");

                entity.Property(e => e.BatchManaged).HasColumnName("batchmanaged");


                entity.Property(e => e.Binomial)
                    .HasMaxLength(6)
                    .HasColumnName("binomial");

                entity.Property(e => e.MaterialCode)
                    .HasMaxLength(3)
                    .HasColumnName("materialcode");

                entity.Property(e => e.MaterialName)
                    .HasMaxLength(25)
                    .HasColumnName("materialname");

                entity.Property(e => e.PermitNumber)
                    .HasMaxLength(25)
                    .HasColumnName("permitnumber");

                entity.Property(e => e.SequenceId).HasColumnName("sequenceid");

                entity.Property(e => e.TotalRecords).HasColumnName("totalrecords");

                entity.Property(e => e.UnitOfIssue)
                    .HasMaxLength(3)
                    .HasColumnName("unitofissue");
            });

            modelBuilder.Entity<Rawmateriallog>(entity =>
            {
                entity.HasKey(e => e.ProductLotNumber)
                    .HasName("rawmateriallog_pkey");

                entity.ToTable("rawmateriallog", "distillation");

                entity.Property(e => e.ProductLotNumber)
                    .HasMaxLength(10)
                    .HasColumnName("productlotnumber");

                entity.Property(e => e.ContainerNumber)
                    .HasMaxLength(7)
                    .HasColumnName("containernumber");

                entity.Property(e => e.InspectionLotNumber).HasColumnName("inspectionlotnumber");

                entity.Property(e => e.IssueDate).HasColumnName("issuedate");

                entity.Property(e => e.MaterialNumber).HasColumnName("materialnumber");

                entity.Property(e => e.NetWeight)
                    .HasColumnName("netweight")
                    .HasDefaultValueSql("180");

                entity.Property(e => e.ProductBatchNumber).HasColumnName("productbatchnumber");

                entity.Property(e => e.SampleId).HasColumnName("sampleid");

                entity.Property(e => e.VendorLotNumber)
                    .HasMaxLength(25)
                    .HasColumnName("vendorlotnumber");

                entity.Property(e => e.VendorName)
                    .HasMaxLength(25)
                    .HasColumnName("vendorname");

                entity.HasOne(d => d.MaterialNumberNavigation)
                    .WithMany(p => p.RawMaterialLogs)
                    .HasForeignKey(d => d.MaterialNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("rawmateriallog_materialnumber_fkey");
            });

            modelBuilder.Entity<Rawmaterialvendor>(entity =>
            {
                entity.HasKey(e => e.MaterialNumber)
                    .HasName("rawmaterialvendor_pkey");

                entity.ToTable("rawmaterialvendor", "materials");

                entity.Property(e => e.MaterialNumber)
                    .ValueGeneratedNever()
                    .HasColumnName("materialnumber");

                entity.Property(e => e.BatchManaged).HasColumnName("batchmanaged");

                entity.Property(e => e.ContainerNumberRequired).HasColumnName("containernumberrequired");

                entity.Property(e => e.MaterialCode)
                    .HasMaxLength(3)
                    .HasColumnName("materialcode");

                entity.Property(e => e.ParentMaterialNumber).HasColumnName("parentmaterialnumber");

                entity.Property(e => e.SequenceId).HasColumnName("sequenceid");

                entity.Property(e => e.TotalRecords).HasColumnName("totalrecords");

                entity.Property(e => e.UnitOfIssue)
                    .HasMaxLength(3)
                    .HasColumnName("unitofissue");

                entity.Property(e => e.VendorName)
                    .HasMaxLength(25)
                    .HasColumnName("vendorname");

                entity.HasOne(d => d.ParentMaterialNumberNavigation)
                    .WithMany(p => p.RawMaterialVendors)
                    .HasForeignKey(d => d.ParentMaterialNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("rawmaterialvendor_parentmaterialnumber_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
