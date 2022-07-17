using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace final_proyect.Models2
{
    public partial class defvo8ctbb198bContext : DbContext
    {
        public defvo8ctbb198bContext()
        {
        }

        public defvo8ctbb198bContext(DbContextOptions<defvo8ctbb198bContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Carro> Carros { get; set; } = null!;
        public virtual DbSet<Cita> Citas { get; set; } = null!;
        public virtual DbSet<Consultorio> Consultorios { get; set; } = null!;
        public virtual DbSet<Piso> Pisos { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("host=ec2-23-23-151-191.compute-1.amazonaws.com;port=5432;database=defvo8ctbb198b;username=vwzclzbgwgfama;password=3f94fdace6e49cf530af4c6149109755babec582c848e7e56bef2c89b9dd0604");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Carro>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('\"Vehiculex_id_seq\"'::regclass)");
            });

            modelBuilder.Entity<Cita>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ConsultorioId).HasColumnName("consultorio_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.Fecha).HasColumnName("fecha");

                entity.Property(e => e.Paciente)
                    .HasMaxLength(255)
                    .HasColumnName("paciente");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Consultorio)
                    .WithMany(p => p.Cita)
                    .HasForeignKey(d => d.ConsultorioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Citas_relation_1");
            });

            modelBuilder.Entity<Consultorio>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.Encargado)
                    .HasMaxLength(255)
                    .HasColumnName("encargado");

                entity.Property(e => e.NombreConsultorio)
                    .HasMaxLength(255)
                    .HasColumnName("nombre_consultorio");

                entity.Property(e => e.PisoId).HasColumnName("piso_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Piso)
                    .WithMany(p => p.Consultorios)
                    .HasForeignKey(d => d.PisoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Consultorios_relation_1");
            });

            modelBuilder.Entity<Piso>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .HasColumnName("nombre")
                    .HasComment("unique");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Usuario1).HasColumnName("Usuario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
