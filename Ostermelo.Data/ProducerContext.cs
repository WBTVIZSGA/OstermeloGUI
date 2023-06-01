using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Ostermelo.Data.Models;

namespace Ostermelo.Data
{
    public partial class ProducerContext : DbContext
    {
        public ProducerContext()
        {
        }

        public ProducerContext(DbContextOptions<ProducerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DeliveryModel> Deliveries { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;database=ostermelo;uid=root", ServerVersion.Parse("10.4.24-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8_hungarian_ci")
                .HasCharSet("utf8");

            modelBuilder.Entity<JuiceModel>(entity =>
            {
                entity.ToTable("gyumolcslevek");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(16)
                    .HasColumnName("gynev");
            });

            modelBuilder.Entity<DeliveryModel>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PRIMARY");

                entity.ToTable("kiszallitasok");

                entity.HasIndex(e => e.JuiceId, "fk_gyumleszall");

                entity.HasIndex(e => e.PartnerId, "fk_partnerszall");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("sorsz");

                entity.Property(e => e.Date).HasColumnName("datum");

                entity.Property(e => e.JuiceId)
                    .HasColumnType("int(11)")
                    .HasColumnName("gyumleid");

                entity.Property(e => e.Pack)
                    .HasColumnType("int(11)")
                    .HasColumnName("karton");

                entity.Property(e => e.PartnerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("partnerid");

                entity.HasOne(d => d.Juice)
                    .WithMany(p => p.Deliveries)
                    .HasForeignKey(d => d.JuiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_gyumleszall");

                entity.HasOne(d => d.Partner)
                    .WithMany(p => p.Deliveries)
                    .HasForeignKey(d => d.PartnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_partnerszall");
            });

            modelBuilder.Entity<PartnerModel>(entity =>
            {
                entity.ToTable("partnerek");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Contact)
                    .HasMaxLength(20)
                    .HasColumnName("kontakt");

                entity.Property(e => e.City)
                    .HasMaxLength(20)
                    .HasColumnName("telepules");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
