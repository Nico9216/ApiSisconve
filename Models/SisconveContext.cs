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

        public virtual DbSet<Empresa> Empresas { get; set; }
        public virtual DbSet<Funcionario> Funcionarios { get; set; }
        public virtual DbSet<Orden> Ordens { get; set; }
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

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.ToTable("Empresa");

                entity.Property(e => e.EmpresaId).HasColumnName("empresaId");

                entity.Property(e => e.EmpresaCantServDiario).HasColumnName("empresaCantServDiario");

                entity.Property(e => e.EmpresaNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("empresaNombre");
            });

            modelBuilder.Entity<Funcionario>(entity =>
            {
                entity.ToTable("Funcionario");

                entity.Property(e => e.FuncionarioId).HasColumnName("funcionarioId");

                entity.Property(e => e.FuncionarioApellido)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("funcionarioApellido");

                entity.Property(e => e.FuncionarioCargo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("funcionarioCargo");

                entity.Property(e => e.FuncionarioEmpresaId).HasColumnName("funcionarioEmpresaId");

                entity.Property(e => e.FuncionarioEstado)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("funcionarioEstado");

                entity.Property(e => e.FuncionarioNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("funcionarioNombre");

                entity.HasOne(d => d.FuncionarioEmpresa)
                    .WithMany(p => p.Funcionarios)
                    .HasForeignKey(d => d.FuncionarioEmpresaId)
                    .HasConstraintName("FK__Funcionar__funci__0AD2A005");
            });

            modelBuilder.Entity<Orden>(entity =>
            {
                entity.ToTable("Orden");

                entity.HasIndex(e => e.OrdenNumero, "UQ__Orden__A0C06A80108B795B")
                    .IsUnique();

                entity.Property(e => e.OrdenId).HasColumnName("ordenId");

                entity.Property(e => e.OrdenComentario)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("ordenComentario");

                entity.Property(e => e.OrdenEmpresaId).HasColumnName("ordenEmpresaId");

                entity.Property(e => e.OrdenEmpresaNombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ordenEmpresaNombre");

                entity.Property(e => e.OrdenEstado)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ordenEstado");

                entity.Property(e => e.OrdenFechaFinCoordinacion)
                    .HasColumnType("date")
                    .HasColumnName("ordenFechaFinCoordinacion");

                entity.Property(e => e.OrdenFechaFinalizacion)
                    .HasColumnType("date")
                    .HasColumnName("ordenFechaFinalizacion");

                entity.Property(e => e.OrdenFechaIngreso)
                    .HasColumnType("datetime")
                    .HasColumnName("ordenFechaIngreso");

                entity.Property(e => e.OrdenFechaInicioCoordinacion)
                    .HasColumnType("date")
                    .HasColumnName("ordenFechaInicioCoordinacion");

                entity.Property(e => e.OrdenFuncionarioId).HasColumnName("ordenFuncionarioId");

                entity.Property(e => e.OrdenFuncionarioApellido)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ordenFuncionarioApellido");

                entity.Property(e => e.OrdenFuncionarioNombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ordenFuncionarioNombre");

                entity.Property(e => e.OrdenLugar)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ordenLugar");

                entity.Property(e => e.OrdenMovil)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ordenMovil");

                entity.Property(e => e.OrdenNumero).HasColumnName("ordenNumero");

                entity.Property(e => e.OrdenUsuarioNombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ordenUsuarioNombre");

                entity.HasOne(d => d.OrdenEmpresa)
                    .WithMany(p => p.Ordens)
                    .HasForeignKey(d => d.OrdenEmpresaId)
                    .HasConstraintName("FK__Orden__ordenEmpr__1273C1CD");

                entity.HasOne(d => d.OrdenFuncionarioNavigation)
                    .WithMany(p => p.Ordens)
                    .HasForeignKey(d => d.OrdenFuncionarioId)
                    .HasConstraintName("FK__Orden__ordenFunc__1367E606");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Usuario");

                entity.HasIndex(e => e.UsuarioEmail, "UQ__Usuario__B8D449BD7F60ED59")
                    .IsUnique();

                entity.Property(e => e.UsuarioApellidos)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("usuarioApellidos");

                entity.Property(e => e.UsuarioCi)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("usuarioCi");

                entity.Property(e => e.UsuarioEmail)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("usuarioEmail");

                entity.Property(e => e.UsuarioEstado).HasColumnName("usuarioEstado");

                entity.Property(e => e.UsuarioId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("usuarioId");

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
