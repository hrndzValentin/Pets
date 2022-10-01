using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Domain.Entities.Models
{
    public partial class VeterinariaContext : DbContext
    {
        public VeterinariaContext()
        {
        }

        public VeterinariaContext(DbContextOptions<VeterinariaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Mascotum> Mascota { get; set; } = null!;
        public virtual DbSet<Numero> Numeros { get; set; } = null!;
        public virtual DbSet<Persona> Personas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=Veterinaria;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mascotum>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Edad).HasColumnName("edad");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Veterinario)
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Numero>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("numero");

                entity.Property(e => e.Numero1).HasColumnName("numero");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.ToTable("Persona");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(70)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
