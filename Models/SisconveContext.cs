using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Sisconve.Persistencia;

#nullable disable

namespace Sisconve.Models
{
    public partial class SisconveContext : DbContext
    {
        public SisconveContext()
        {
        }

        public SisconveContext(DbContextOptions<SisconveContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer(Conexion.getConexion);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.UsuarioCi)
                    .HasName("PK__Usuario__A5B254467F60ED59");

                entity.ToTable("Usuario");

                entity.HasIndex(e => e.UsuarioEmail, "UQ__Usuario__B8D449BD023D5A04")
                    .IsUnique();

                entity.Property(e => e.UsuarioCi)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("usuarioCi");

                entity.Property(e => e.UsuarioApellidos)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("usuarioApellidos");

                entity.Property(e => e.UsuarioEmail)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("usuarioEmail");

                entity.Property(e => e.UsuarioEstado).HasColumnName("usuarioEstado");

                entity.Property(e => e.UsuarioNombres)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("usuarioNombres");

                entity.Property(e => e.UsuarioPassword)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("usuarioPassword");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
