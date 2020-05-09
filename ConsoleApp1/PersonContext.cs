using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ConsoleApp1
{
    public partial class PersonContext : DbContext
    {
        public PersonContext()
        {
        }

        public PersonContext(DbContextOptions<PersonContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PersonTable> PersonTable { get; set; }
        public virtual DbSet<Students> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=Amirbek;Database=Person;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonTable>(entity =>
            {
                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.MiddleName).HasMaxLength(200);
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Faculty)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.MiddleName).HasMaxLength(200);

                entity.Property(e => e.Nation)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PlaceOfBirth)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.PlaceOfResidence)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Specialty)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.University)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
