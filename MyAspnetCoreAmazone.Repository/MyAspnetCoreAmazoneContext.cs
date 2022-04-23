using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MyAspnetCoreAmazone
{
    public partial class MyAspnetCoreAmazoneContext : DbContext
    {
        public MyAspnetCoreAmazoneContext()
        {
        }

        public MyAspnetCoreAmazoneContext(DbContextOptions<MyAspnetCoreAmazoneContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Price> Prices { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=MyAspnetCoreAmazone;Persist Security Info=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Price>(entity =>
            {
                entity.ToTable("Price");

                entity.Property(e => e.PriceId).HasColumnName("PriceID");

                entity.Property(e => e.Discount).HasColumnType("smallmoney");

                entity.Property(e => e.Rrp)
                    .HasColumnType("smallmoney")
                    .HasColumnName("RRP");

                entity.Property(e => e.SellingPrice).HasColumnType("smallmoney");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.PriceId).HasColumnName("PriceID");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RRP)
                    .HasColumnType("smallmoney")
                    .HasColumnName("RRP");

                entity.Property(e => e.SellingPrice).HasColumnType("smallmoney");

                entity.HasOne(d => d.Price)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.PriceId)
                    .HasConstraintName("FK__Products__PriceI__25869641");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
