﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MSU_Case_LostAndFound.Model
{
    public partial class RescuteDBContext : DbContext
    {
        public RescuteDBContext()
        {
        }

        public RescuteDBContext(DbContextOptions<RescuteDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AnimalsFound> AnimalsFound { get; set; }
        public virtual DbSet<AnimalsLost> AnimalsLost { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:rescutesqlserver.database.windows.net,1433;Initial Catalog=RescuteDB;Persist Security Info=False;User ID=rescuteadmin;Password=erikito123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnimalsFound>(entity =>
            {
                entity.HasKey(e => e.AnimalId);

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Animal)
                    .HasConversion<string>()
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.FoundDate).HasColumnType("date");

                entity.Property(e => e.FurLenght)
                    .HasConversion<string>()
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.FurPattern)
                    .HasConversion<string>()
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Gender)
                    .HasConversion<string>()
                    .IsRequired()
                    .HasMaxLength(8);

                entity.Property(e => e.History).HasColumnType("ntext");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(20);

                entity.Property(e => e.NearArea)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Updated).HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasMaxLength(450);
            });

            modelBuilder.Entity<AnimalsLost>(entity =>
            {
                entity.HasKey(e => e.AnimalId);

                entity.Property(e => e.Animal)
                    .HasConversion<string>()
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.FurLenght)
                    .HasConversion<string>()
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.FurPattern)
                    .HasConversion<string>()
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Gender)
                    .HasConversion<string>()
                    .IsRequired()
                    .HasMaxLength(8);

                entity.Property(e => e.History).HasColumnType("ntext");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.LostDate).HasColumnType("date");

                entity.Property(e => e.Name).HasMaxLength(20);

                entity.Property(e => e.NearArea)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Updated).HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasMaxLength(450);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
