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

                entity.Property(e => e.EmpresaCantEmpleados).HasColumnName("empresaCantEmpleados");

                entity.Property(e => e.EmpresaHorarioFin).HasColumnName("empresaHorarioFin");

                entity.Property(e => e.EmpresaHorarioInicio).HasColumnName("empresaHorarioInicio");

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

                entity.Property(e => e.OrdenBobina)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ordenBobina");

                entity.Property(e => e.OrdenCapacidadTanqueMim)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ordenCapacidadTanqueMIM");

                entity.Property(e => e.OrdenCapacidadTanqueMimtec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ordenCapacidadTanqueMIMTec");

                entity.Property(e => e.OrdenCardId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ordenCardId");

                entity.Property(e => e.OrdenChip)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ordenChip");

                entity.Property(e => e.OrdenComentarioFinales)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("ordenComentarioFinales");

                entity.Property(e => e.OrdenComentarioInicial)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("ordenComentarioInicial");

                entity.Property(e => e.OrdenDeviceIdDpl)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ordenDeviceIdDPL");

                entity.Property(e => e.OrdenDivision)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ordenDivision");

                entity.Property(e => e.OrdenEncendidoPorMotor).HasColumnName("ordenEncendidoPorMotor");

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

                entity.Property(e => e.OrdenFechaInicioCoordinacion)
                    .HasColumnType("date")
                    .HasColumnName("ordenFechaInicioCoordinacion");

                entity.Property(e => e.OrdenFechaPrimeraCarga)
                    .HasColumnType("date")
                    .HasColumnName("ordenFechaPrimeraCarga");

                entity.Property(e => e.OrdenFlota)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ordenFlota");

                entity.Property(e => e.OrdenInstalaCa).HasColumnName("ordenInstalaCA");

                entity.Property(e => e.OrdenInstalaDataPass).HasColumnName("ordenInstalaDataPass");

                entity.Property(e => e.OrdenInstalaDpl).HasColumnName("ordenInstalaDPL");

                entity.Property(e => e.OrdenInstalaInmovilizador).HasColumnName("ordenInstalaInmovilizador");

                entity.Property(e => e.OrdenInstalaMebiclick).HasColumnName("ordenInstalaMebiclick");

                entity.Property(e => e.OrdenInstalaTagreader).HasColumnName("ordenInstalaTAGReader");

                entity.Property(e => e.OrdenLugar)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ordenLugar");

                entity.Property(e => e.OrdenMacdataPass)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ordenMACDataPass");

                entity.Property(e => e.OrdenMatricula)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ordenMatricula");

                entity.Property(e => e.OrdenMovil)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ordenMovil");

                entity.Property(e => e.OrdenNombreOrganizacion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ordenNombreOrganizacion");

                entity.Property(e => e.OrdenNroParte)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ordenNroParte");

                entity.Property(e => e.OrdenNroTagreader)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ordenNroTAGReader");

                entity.Property(e => e.OrdenNumero).HasColumnName("ordenNumero");

                entity.Property(e => e.OrdenPudoInstalarCs).HasColumnName("ordenPudoInstalarCS");

                entity.Property(e => e.OrdenSerieDataPass)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ordenSerieDataPass");

                entity.Property(e => e.OrdenSerieDpl)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ordenSerieDPL");

                entity.Property(e => e.OrdenSerieTagreader)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ordenSerieTAGReader");

                entity.Property(e => e.OrdenTmpoTrabajoEnInterior)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ordenTmpoTrabajoEnInterior");

                entity.Property(e => e.OrdenTmpoTrabajoEnMdeo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ordenTmpoTrabajoEnMdeo");

                entity.Property(e => e.OrdenTrazaOrden)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ordenTrazaOrden");

                entity.Property(e => e.OrdenUsuarioNombreFinalizo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ordenUsuarioNombreFinalizo");

                entity.Property(e => e.OrdenZonaGira)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ordenZonaGira");
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
