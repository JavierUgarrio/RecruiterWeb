using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RecruiterWeb.Modelos
{
    public partial class RecruiterContext : DbContext
    {
        public RecruiterContext()
        {
        }

        public RecruiterContext(DbContextOptions<RecruiterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Candidatura> Candidaturas { get; set; } = null!;
        public virtual DbSet<DetallesCandidatura> DetallesCandidaturas { get; set; } = null!;
        public virtual DbSet<Proceso> Procesos { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //Configuro para que no este hardcodeado la conexion a la bbdd
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("SQL"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidatura>(entity =>
            {
                entity.HasKey(e => e.IdCandidatura);

                entity.Property(e => e.Empresa)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.FechaAlta).HasColumnType("date");

                entity.Property(e => e.FechaBaja).HasColumnType("date");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Candidaturas)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Candidaturas_Usuario");
            });

            modelBuilder.Entity<DetallesCandidatura>(entity =>
            {
                entity.HasKey(e => e.IdDetalleCandidatura);

                entity.HasOne(d => d.IdCandidaturasNavigation)
                    .WithMany(p => p.DetallesCandidaturas)
                    .HasForeignKey(d => d.IdCandidaturas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetallesCandidaturas_Candidaturas");

                entity.HasOne(d => d.IdProcesosNavigation)
                    .WithMany(p => p.DetallesCandidaturas)
                    .HasForeignKey(d => d.IdProcesos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetallesCandidaturas_Proceso");
            });

            modelBuilder.Entity<Proceso>(entity =>
            {
                entity.HasKey(e => e.IdProceso);

                entity.ToTable("Proceso");

                entity.Property(e => e.IdProceso).ValueGeneratedNever();

                entity.Property(e => e.Cliente)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(1000)
                    .IsFixedLength();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.ToTable("Usuario");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.FechaAlta).HasColumnType("date");

                entity.Property(e => e.FechaBaja).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.Password).HasMaxLength(500);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
