using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MSU_Case_LostAndFound.Models
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
            modelBuilder.Entity<AnimalsLost>(entity =>
            {
                entity.HasKey(e => e.AnimalId);

                entity.Property(e => e.Animal)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.FurLenght)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.FurPattern)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(8);

                entity.Property(e => e.History).HasColumnType("ntext");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.LostDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(20);

                entity.Property(e => e.NearArea)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Updated).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
