using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace crudweb.Models
{
    public partial class DSFEBABR2022Context : DbContext
    {
        public DSFEBABR2022Context()
        {
        }

        public DSFEBABR2022Context(DbContextOptions<DSFEBABR2022Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Ciudadano> Ciudadanos { get; set; } = null!;
        public virtual DbSet<CiudadanoEstado> CiudadanoEstados { get; set; } = null!;
        public virtual DbSet<ColegioElectoral> ColegioElectorals { get; set; } = null!;
        public virtual DbSet<EstadoCivil> EstadoCivils { get; set; } = null!;
        public virtual DbSet<Municipio> Municipios { get; set; } = null!;
        public virtual DbSet<Nacionalidad> Nacionalidads { get; set; } = null!;
        public virtual DbSet<Ocupacion> Ocupacions { get; set; } = null!;
        public virtual DbSet<Provincium> Provincia { get; set; } = null!;
        public virtual DbSet<Sector> Sectors { get; set; } = null!;
        public virtual DbSet<TipoDeSangre> TipoDeSangres { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=sql.fvtech.net;Database=DSFEBABR2022;user id=dsfebapr2022;password=dsfebapr2022;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ciudadano>(entity =>
            {
                entity.ToTable("Ciudadano");

                entity.Property(e => e.Apellido1)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.Apellido2)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoPostal)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaDeExpiracion).HasColumnType("date");

                entity.Property(e => e.FechaDeNacimiento).HasColumnType("date");

                entity.Property(e => e.Firma).IsUnicode(false);

                entity.Property(e => e.Foto).IsUnicode(false);

                entity.Property(e => e.NoCedula)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.RegistroDeNacimiento)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Secuencia).ValueGeneratedOnAdd();

                entity.Property(e => e.Sexo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UsuarioCreacionId).HasMaxLength(450);

                entity.HasOne(d => d.ColegioElectoral)
                    .WithMany(p => p.Ciudadanos)
                    .HasForeignKey(d => d.ColegioElectoralId)
                    .HasConstraintName("FK_Ciudadano_ColegioElectoral");

                entity.HasOne(d => d.EstadoCivil)
                    .WithMany(p => p.Ciudadanos)
                    .HasForeignKey(d => d.EstadoCivilId)
                    .HasConstraintName("FK_Ciudadano_EstadoCivil");

                entity.HasOne(d => d.Estado)
                    .WithMany(p => p.Ciudadanos)
                    .HasForeignKey(d => d.EstadoId)
                    .HasConstraintName("FK_Ciudadano_CiudadanoEstado");

                entity.HasOne(d => d.LugarDeNacimiento)
                    .WithMany(p => p.Ciudadanos)
                    .HasForeignKey(d => d.LugarDeNacimientoId)
                    .HasConstraintName("FK_Ciudadano_Provincia");

                entity.HasOne(d => d.Nacionalidad)
                    .WithMany(p => p.Ciudadanos)
                    .HasForeignKey(d => d.NacionalidadId)
                    .HasConstraintName("FK_Ciudadano_Nacionalidad");

                entity.HasOne(d => d.Ocupacion)
                    .WithMany(p => p.Ciudadanos)
                    .HasForeignKey(d => d.OcupacionId)
                    .HasConstraintName("FK_Ciudadano_Ocupacion");

                entity.HasOne(d => d.TipoDeSangre)
                    .WithMany(p => p.Ciudadanos)
                    .HasForeignKey(d => d.TipoDeSangreId)
                    .HasConstraintName("FK_Ciudadano_TipoDeSangre");

                entity.HasOne(d => d.UsuarioCreacion)
                    .WithMany(p => p.Ciudadanos)
                    .HasForeignKey(d => d.UsuarioCreacionId)
                    .HasConstraintName("FK_Ciudadano_Usuario");
            });

            modelBuilder.Entity<CiudadanoEstado>(entity =>
            {
                entity.ToTable("CiudadanoEstado");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ColegioElectoral>(entity =>
            {
                entity.ToTable("ColegioElectoral");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MunicipioId)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.SectorId)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Telefono)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EstadoCivil>(entity =>
            {
                entity.ToTable("EstadoCivil");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Municipio>(entity =>
            {
                entity.ToTable("Municipio");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.HasOne(d => d.Provincia)
                    .WithMany(p => p.Municipios)
                    .HasForeignKey(d => d.ProvinciaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Municipio_Provincia");
            });

            modelBuilder.Entity<Nacionalidad>(entity =>
            {
                entity.ToTable("Nacionalidad");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ocupacion>(entity =>
            {
                entity.ToTable("Ocupacion");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Provincium>(entity =>
            {
                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sector>(entity =>
            {
                entity.ToTable("Sector");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.HasOne(d => d.Municipio)
                    .WithMany(p => p.Sectors)
                    .HasForeignKey(d => d.MunicipioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sector_Municipio");
            });

            modelBuilder.Entity<TipoDeSangre>(entity =>
            {
                entity.ToTable("TipoDeSangre");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuario");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Clave)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CorreoElectronico)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Usuario1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Usuario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
