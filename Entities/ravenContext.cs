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
                optionsBuilder.UseNpgsql("Host=localhost;Database=raven;Username=postgres;Password=password");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Highpuritymaterial>(entity =>
            {
                entity.HasKey(e => e.Materialnumber)
                    .HasName("highpuritymaterial_pkey");

                entity.ToTable("highpuritymaterial", "materials");

                entity.Property(e => e.Materialnumber)
                    .ValueGeneratedNever()
                    .HasColumnName("materialnumber");

                entity.Property(e => e.Batchmanaged)
                    .HasColumnType("bit(1)")
                    .HasColumnName("batchmanaged")
                    .HasDefaultValueSql("(0)::bit(1)");

                entity.Property(e => e.Binomial)
                    .HasMaxLength(6)
                    .HasColumnName("binomial");

                entity.Property(e => e.Materialcode)
                    .HasMaxLength(3)
                    .HasColumnName("materialcode");

                entity.Property(e => e.Materialname)
                    .HasMaxLength(25)
                    .HasColumnName("materialname");

                entity.Property(e => e.Permitnumber)
                    .HasMaxLength(25)
                    .HasColumnName("permitnumber");

                entity.Property(e => e.Sequenceid).HasColumnName("sequenceid");

                entity.Property(e => e.Totalrecords).HasColumnName("totalrecords");

                entity.Property(e => e.Unitofissue)
                    .HasMaxLength(3)
                    .HasColumnName("unitofissue");
            });

            modelBuilder.Entity<Rawmateriallog>(entity =>
            {
                entity.HasKey(e => e.Productlotnumber)
                    .HasName("rawmateriallog_pkey");

                entity.ToTable("rawmateriallog", "distillation");

                entity.Property(e => e.Productlotnumber)
                    .HasMaxLength(10)
                    .HasColumnName("productlotnumber");

                entity.Property(e => e.Containernumber)
                    .HasMaxLength(7)
                    .HasColumnName("containernumber");

                entity.Property(e => e.Inspectionlotnumber).HasColumnName("inspectionlotnumber");

                entity.Property(e => e.Issuedate).HasColumnName("issuedate");

                entity.Property(e => e.Materialnumber).HasColumnName("materialnumber");

                entity.Property(e => e.Netweight)
                    .HasColumnName("netweight")
                    .HasDefaultValueSql("180");

                entity.Property(e => e.Productbatchnumber).HasColumnName("productbatchnumber");

                entity.Property(e => e.Sampleid).HasColumnName("sampleid");

                entity.Property(e => e.Vendorlotnumber)
                    .HasMaxLength(25)
                    .HasColumnName("vendorlotnumber");

                entity.Property(e => e.Vendorname)
                    .HasMaxLength(25)
                    .HasColumnName("vendorname");

                entity.HasOne(d => d.MaterialnumberNavigation)
                    .WithMany(p => p.Rawmateriallogs)
                    .HasForeignKey(d => d.Materialnumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("rawmateriallog_materialnumber_fkey");
            });

            modelBuilder.Entity<Rawmaterialvendor>(entity =>
            {
                entity.HasKey(e => e.Materialnumber)
                    .HasName("rawmaterialvendor_pkey");

                entity.ToTable("rawmaterialvendor", "materials");

                entity.Property(e => e.Materialnumber)
                    .ValueGeneratedNever()
                    .HasColumnName("materialnumber");

                entity.Property(e => e.Batchmanaged)
                    .HasColumnType("bit(1)")
                    .HasColumnName("batchmanaged")
                    .HasDefaultValueSql("(0)::bit(1)");

                entity.Property(e => e.Containernumberrequired)
                    .HasColumnType("bit(1)")
                    .HasColumnName("containernumberrequired")
                    .HasDefaultValueSql("(0)::bit(1)");

                entity.Property(e => e.Materialcode)
                    .HasMaxLength(3)
                    .HasColumnName("materialcode");

                entity.Property(e => e.Parentmaterialnumber).HasColumnName("parentmaterialnumber");

                entity.Property(e => e.Sequenceid).HasColumnName("sequenceid");

                entity.Property(e => e.Totalrecords).HasColumnName("totalrecords");

                entity.Property(e => e.Unitofissue)
                    .HasMaxLength(3)
                    .HasColumnName("unitofissue");

                entity.Property(e => e.Vendorname)
                    .HasMaxLength(25)
                    .HasColumnName("vendorname");

                entity.HasOne(d => d.ParentmaterialnumberNavigation)
                    .WithMany(p => p.Rawmaterialvendors)
                    .HasForeignKey(d => d.Parentmaterialnumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("rawmaterialvendor_parentmaterialnumber_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
