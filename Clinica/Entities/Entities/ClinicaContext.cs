using System;
using System.Collections.Generic;
using Entities.Utilities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Entities.Entities
{
    public partial class ClinicaContext : IdentityDbContext<ApplicationUser>
    {
        public ClinicaContext()
        {
            var optionBuilder = new DbContextOptionsBuilder<ClinicaContext>();
            optionBuilder.UseSqlServer(Util.ConnectionString);
        }

        public ClinicaContext(DbContextOptions<ClinicaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cita> Cita { get; set; } = null!;
        public virtual DbSet<Clinica> Clinicas { get; set; } = null!;
        public virtual DbSet<Diagnostico> Diagnosticos { get; set; } = null!;
        public virtual DbSet<Doctor> Doctors { get; set; } = null!;
        public virtual DbSet<Especialidad> Especialidads { get; set; } = null!;
        public virtual DbSet<Factura> Facturas { get; set; } = null!;
        public virtual DbSet<Horario> Horarios { get; set; } = null!;
        public virtual DbSet<Precio> Precios { get; set; } = null!;
        public virtual DbSet<Reserva> Reservas { get; set; } = null!;
        public virtual DbSet<Role> Rols { get; set; } = null!;
        public virtual DbSet<StatusReserva> StatusReservas { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        public virtual DbSet<SpObtenerInfoCitasResult> SpObtenerInfoCitasResults { get; set; } = null!;
        public virtual DbSet<SpObtenerInfoDiagnosticosResult> SpObtenerInfoDiagnosticosResults { get; set; } = null!;
        public virtual DbSet<SpObtenerInfoEspecialidadesResult> SpObtenerInfoEspecialidadesResult { get; set; } = null!;
        public virtual DbSet<SpObtenerInfoReservasResult> SpObtenerInfoReservasResults { get; set; } = null!;
        public virtual DbSet<SpObtenerInfoUsuariosConRolResult> SpObtenerInfoUsuariosConRolResults { get; set; } = null!;
        public virtual DbSet<SpObtenerInfoFacturasConUsuario> SpObtenerInfoFacturasConUsuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Util.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Cita>(entity =>
            {
                entity.HasKey(e => e.IdCita)
                    .HasName("PK__Cita__394B020239CAEC53");

                entity.HasOne(d => d.IdClinicaNavigation)
                    .WithMany(p => p.Cita)
                    .HasForeignKey(d => d.IdClinica)
                    .HasConstraintName("FK__Cita__IdClinica__49C3F6B7");

                entity.HasOne(d => d.IdDoctorNavigation)
                    .WithMany(p => p.Cita)
                    .HasForeignKey(d => d.IdDoctor)
                    .HasConstraintName("FK__Cita__IdDoctor__47DBAE45");

                entity.HasOne(d => d.IdEspecialidadNavigation)
                    .WithMany(p => p.Cita)
                    .HasForeignKey(d => d.IdEspecialidad)
                    .HasConstraintName("FK__Cita__IdEspecial__48CFD27E");

                entity.HasOne(d => d.IdHorarioNavigation)
                    .WithMany(p => p.Cita)
                    .HasForeignKey(d => d.IdHorario)
                    .HasConstraintName("FK__Cita__IdHorario__4AB81AF0");
            });

            modelBuilder.Entity<Clinica>(entity =>
            {
                entity.HasKey(e => e.IdClinica)
                    .HasName("PK__Clinica__52A90951867BBDD8");

                entity.ToTable("Clinica");

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Diagnostico>(entity =>
            {
                entity.HasKey(e => e.IdDiagnostico)
                    .HasName("PK__Diagnost__BD16DB69AFA90FA6");

                entity.ToTable("Diagnostico");

                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.HasOne(d => d.IdReservaNavigation)
                    .WithMany(p => p.Diagnosticos)
                    .HasForeignKey(d => d.IdReserva)
                    .HasConstraintName("FK__Diagnosti__IdRes__59063A47");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.IdDoctor)
                    .HasName("PK__Doctor__F838DB3ED520D352");

                entity.ToTable("Doctor");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Especialidad>(entity =>
            {
                entity.HasKey(e => e.IdEspecialidad)
                    .HasName("PK__Especial__693FA0AF4E7B6A5F");

                entity.ToTable("Especialidad");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPrecioNavigation)
                    .WithMany(p => p.Especialidads)
                    .HasForeignKey(d => d.IdPrecio)
                    .HasConstraintName("FK__Especiali__IdPre__3F466844");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => e.IdFactura)
                    .HasName("PK__Facturas__50E7BAF174427AED");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdReservaNavigation)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.IdReserva)
                    .HasConstraintName("FK__Facturas__IdRese__5535A963");
            });

            modelBuilder.Entity<Horario>(entity =>
            {
                entity.HasKey(e => e.IdHorario)
                    .HasName("PK__Horario__1539229BDB4BBAA8");

                entity.ToTable("Horario");

                entity.Property(e => e.Dia)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Hora)
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Precio>(entity =>
            {
                entity.HasKey(e => e.IdPrecio)
                    .HasName("PK__Precio__2450584BF82D9FD8");

                entity.ToTable("Precio");
            });

            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.HasKey(e => e.IdReserva)
                    .HasName("PK__Reserva__0E49C69DB47220C3");

                entity.ToTable("Reserva");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdCitaNavigation)
                    .WithMany(p => p.Reservas)
                    .HasForeignKey(d => d.IdCita)
                    .HasConstraintName("FK__Reserva__IdCita__4F7CD00D");

                entity.HasOne(d => d.IdStatusReservaNavigation)
                    .WithMany(p => p.Reservas)
                    .HasForeignKey(d => d.IdStatusReserva)
                    .HasConstraintName("FK__Reserva__IdStatu__5165187F");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Reservas)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Reserva__IdUsuar__5070F446");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PK__Rol__2A49584C830E78C0");

                entity.ToTable("Rol");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StatusReserva>(entity =>
            {
                entity.HasKey(e => e.IdStatusReserva)
                    .HasName("PK__StatusRe__89FBDF160EDACB14");

                entity.ToTable("StatusReserva");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__5B65BF97B5BCAC4B");

                entity.ToTable("Usuario");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Clave)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdRol)
                    .HasConstraintName("FK__Usuario__IdRol__3A81B327");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
