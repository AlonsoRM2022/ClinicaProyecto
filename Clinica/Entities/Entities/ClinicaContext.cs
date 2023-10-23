using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Entities.Entities
{
    public partial class ClinicaContext : DbContext
    {
        public ClinicaContext()
        {
        }

        public ClinicaContext(DbContextOptions<ClinicaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cita> Citas { get; set; } = null!;
        public virtual DbSet<Clinica> Clinicas { get; set; } = null!;
        public virtual DbSet<Diagnostico> Diagnosticos { get; set; } = null!;
        public virtual DbSet<Doctore> Doctores { get; set; } = null!;
        public virtual DbSet<Especialidade> Especialidades { get; set; } = null!;
        public virtual DbSet<Factura> Facturas { get; set; } = null!;
        public virtual DbSet<Horario> Horarios { get; set; } = null!;
        public virtual DbSet<Precio> Precios { get; set; } = null!;
        public virtual DbSet<Reserva> Reservas { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<StatusReserva> StatusReservas { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-DJD7T3K;Database=Clinica;Integrated Security=True;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cita>(entity =>
            {
                entity.HasKey(e => e.IdCita)
                    .HasName("PK__Citas__394B0202FA08D694");

                entity.HasOne(d => d.IdClinicaNavigation)
                    .WithMany(p => p.Cita)
                    .HasForeignKey(d => d.IdClinica)
                    .HasConstraintName("FK__Citas__IdClinica__36B12243");

                entity.HasOne(d => d.IdDoctorNavigation)
                    .WithMany(p => p.Cita)
                    .HasForeignKey(d => d.IdDoctor)
                    .HasConstraintName("FK__Citas__IdDoctor__34C8D9D1");

                entity.HasOne(d => d.IdEspecialidadNavigation)
                    .WithMany(p => p.Cita)
                    .HasForeignKey(d => d.IdEspecialidad)
                    .HasConstraintName("FK__Citas__IdEspecia__35BCFE0A");

                entity.HasOne(d => d.IdHorarioNavigation)
                    .WithMany(p => p.Cita)
                    .HasForeignKey(d => d.IdHorario)
                    .HasConstraintName("FK__Citas__IdHorario__37A5467C");
            });

            modelBuilder.Entity<Clinica>(entity =>
            {
                entity.HasKey(e => e.IdClinica)
                    .HasName("PK__Clinicas__52A90951714C55C3");

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
                    .HasName("PK__Diagnost__BD16DB69DA1B42BB");

                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.HasOne(d => d.IdReservaNavigation)
                    .WithMany(p => p.Diagnosticos)
                    .HasForeignKey(d => d.IdReserva)
                    .HasConstraintName("FK__Diagnosti__IdRes__45F365D3");
            });

            modelBuilder.Entity<Doctore>(entity =>
            {
                entity.HasKey(e => e.IdDoctor)
                    .HasName("PK__Doctores__F838DB3EA2FB3455");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Especialidade>(entity =>
            {
                entity.HasKey(e => e.IdEspecialidad)
                    .HasName("PK__Especial__693FA0AF21B14629");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPrecioNavigation)
                    .WithMany(p => p.Especialidades)
                    .HasForeignKey(d => d.IdPrecio)
                    .HasConstraintName("FK__Especiali__IdPre__2C3393D0");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => e.IdFactura)
                    .HasName("PK__Facturas__50E7BAF19DBFEE75");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdReservaNavigation)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.IdReserva)
                    .HasConstraintName("FK__Facturas__IdRese__4222D4EF");
            });

            modelBuilder.Entity<Horario>(entity =>
            {
                entity.HasKey(e => e.IdHorario)
                    .HasName("PK__Horarios__1539229BB0FD0E3A");

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
                    .HasName("PK__Precios__2450584B02AAD287");
            });

            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.HasKey(e => e.IdReserva)
                    .HasName("PK__Reservas__0E49C69D55029B9B");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdCitaNavigation)
                    .WithMany(p => p.Reservas)
                    .HasForeignKey(d => d.IdCita)
                    .HasConstraintName("FK__Reservas__IdCita__3C69FB99");

                entity.HasOne(d => d.IdStatusReservaNavigation)
                    .WithMany(p => p.Reservas)
                    .HasForeignKey(d => d.IdStatusReserva)
                    .HasConstraintName("FK__Reservas__IdStat__3E52440B");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Reservas)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Reservas__IdUsua__3D5E1FD2");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PK__Roles__2A49584CDEFE75B5");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StatusReserva>(entity =>
            {
                entity.HasKey(e => e.IdStatusReserva)
                    .HasName("PK__StatusRe__89FBDF1622DEB700");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuarios__5B65BF97B6884545");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Contraseña)
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
                    .HasConstraintName("FK__Usuarios__IdRol__276EDEB3");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
