using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProyectoAPI.Models;

public partial class HotelDbContext : DbContext
{
    public HotelDbContext()
    {
    }

    public HotelDbContext(DbContextOptions<HotelDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Habitacion> Habitacions { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    public virtual DbSet<Reporte> Reportes { get; set; }

    public virtual DbSet<Reservacion> Reservacions { get; set; }

    public virtual DbSet<TipoHabitacion> TipoHabitacions { get; set; }

    public virtual DbSet<Transaccion> Transaccions { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente);

            entity.ToTable("Cliente");

            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(120)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Estatus).HasDefaultValue(true);
            entity.Property(e => e.IdUsuarioCrea).HasColumnName("idUsuarioCrea");
            entity.Property(e => e.Identificacion)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUsuarioCreaNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdUsuarioCrea)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cliente_idUsuarioCrea");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado);

            entity.ToTable("Empleado");

            entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");
            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Dierccion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Estatus).HasDefaultValue(true);
            entity.Property(e => e.Genero)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.IdUsuarioCrea).HasColumnName("idUsuarioCrea");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NumeroSeguroSocial)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Puesto)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Rfc)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("RFC");
            entity.Property(e => e.Salario).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUsuarioCreaNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdUsuarioCrea)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Empleado_idUsuarioCrea");
        });

        modelBuilder.Entity<Habitacion>(entity =>
        {
            entity.HasKey(e => e.IdHabitacion);

            entity.ToTable("Habitacion");

            entity.Property(e => e.IdHabitacion).HasColumnName("idHabitacion");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Estatus).HasDefaultValue(true);
            entity.Property(e => e.IdTipoHabitacion).HasColumnName("idTipoHabitacion");
            entity.Property(e => e.IdUsuarioCrea).HasColumnName("idUsuarioCrea");
            entity.Property(e => e.Precio).HasColumnType("money");

            entity.HasOne(d => d.IdTipoHabitacionNavigation).WithMany(p => p.Habitacions)
                .HasForeignKey(d => d.IdTipoHabitacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Habitacion_idTipoHabitacion");

            entity.HasOne(d => d.IdUsuarioCreaNavigation).WithMany(p => p.Habitacions)
                .HasForeignKey(d => d.IdUsuarioCrea)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Habitacion_idUsuarioCrea");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.IdPago);

            entity.ToTable("Pago");

            entity.Property(e => e.IdPago).HasColumnName("idPago");
            entity.Property(e => e.Comentarios).HasColumnType("text");
            entity.Property(e => e.Concepto)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EstadoPago)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Estatus).HasDefaultValue(true);
            entity.Property(e => e.FormaPago)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");
            entity.Property(e => e.IdUsuarioCrea).HasColumnName("idUsuarioCrea");
            entity.Property(e => e.Monto).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pago_idCliente");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pago_idEmpleado");

            entity.HasOne(d => d.IdUsuarioCreaNavigation).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.IdUsuarioCrea)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pago_idUsuarioCrea");
        });

        modelBuilder.Entity<Reporte>(entity =>
        {
            entity.HasKey(e => e.IdReporte);

            entity.ToTable("Reporte");

            entity.Property(e => e.IdReporte).HasColumnName("idReporte");
            entity.Property(e => e.Estatus).HasDefaultValue(true);
            entity.Property(e => e.IdTransaccion).HasColumnName("idTransaccion");
            entity.Property(e => e.IdUsuarioCrea).HasColumnName("idUsuarioCrea");
            entity.Property(e => e.NombreReporte)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TipoReporte)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdTransaccionNavigation).WithMany(p => p.Reportes)
                .HasForeignKey(d => d.IdTransaccion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reporte_idTransaccion");

            entity.HasOne(d => d.IdUsuarioCreaNavigation).WithMany(p => p.Reportes)
                .HasForeignKey(d => d.IdUsuarioCrea)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reporte_idUsuarioCrea");
        });

        modelBuilder.Entity<Reservacion>(entity =>
        {
            entity.HasKey(e => e.IdReservacion);

            entity.ToTable("Reservacion");

            entity.Property(e => e.IdReservacion).HasColumnName("idReservacion");
            entity.Property(e => e.Comentarios).HasColumnType("text");
            entity.Property(e => e.EstadoReserva)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Estatus).HasDefaultValue(true);
            entity.Property(e => e.FechaEntrada).HasColumnType("datetime");
            entity.Property(e => e.FechaReserva).HasColumnType("datetime");
            entity.Property(e => e.FechaSalida).HasColumnType("datetime");
            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.IdHabaitacion).HasColumnName("idHabaitacion");
            entity.Property(e => e.IdUsuarioCrea).HasColumnName("idUsuarioCrea");
            entity.Property(e => e.MotivoCancelacion)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Reservacions)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reservacion_idCliente");

            entity.HasOne(d => d.IdHabaitacionNavigation).WithMany(p => p.Reservacions)
                .HasForeignKey(d => d.IdHabaitacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reservacion_idHabaitacion");

            entity.HasOne(d => d.IdUsuarioCreaNavigation).WithMany(p => p.Reservacions)
                .HasForeignKey(d => d.IdUsuarioCrea)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reservacion_idUsuarioCrea");
        });

        modelBuilder.Entity<TipoHabitacion>(entity =>
        {
            entity.HasKey(e => e.IdTipoHabitacion);

            entity.ToTable("TipoHabitacion");

            entity.Property(e => e.IdTipoHabitacion).HasColumnName("idTipoHabitacion");
            entity.Property(e => e.Estatus).HasDefaultValue(true);
            entity.Property(e => e.IdUsuarioCrea).HasColumnName("idUsuarioCrea");
            entity.Property(e => e.NombreTipo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Tamaño)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.TipoClimatizacion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TipoVistas)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUsuarioCreaNavigation).WithMany(p => p.TipoHabitacions)
                .HasForeignKey(d => d.IdUsuarioCrea)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TipoHabitacion_idUsuarioCrea");
        });

        modelBuilder.Entity<Transaccion>(entity =>
        {
            entity.HasKey(e => e.IdTransaccion);

            entity.ToTable("Transaccion");

            entity.Property(e => e.IdTransaccion).HasColumnName("idTransaccion");
            entity.Property(e => e.Estatus).HasDefaultValue(true);
            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");
            entity.Property(e => e.IdPago).HasColumnName("idPago");
            entity.Property(e => e.IdReservacion).HasColumnName("idReservacion");
            entity.Property(e => e.IdUsuarioCrea).HasColumnName("idUsuarioCrea");
            entity.Property(e => e.NombreTransaccion)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Transaccions)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Transaccion_idCliente");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Transaccions)
                .HasForeignKey(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Transaccion_idEmpleado");

            entity.HasOne(d => d.IdPagoNavigation).WithMany(p => p.Transaccions)
                .HasForeignKey(d => d.IdPago)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Transaccion_idPago");

            entity.HasOne(d => d.IdReservacionNavigation).WithMany(p => p.Transaccions)
                .HasForeignKey(d => d.IdReservacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Transaccion_idReservacion");

            entity.HasOne(d => d.IdUsuarioCreaNavigation).WithMany(p => p.Transaccions)
                .HasForeignKey(d => d.IdUsuarioCrea)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Transaccion_idUsuarioCrea");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario);

            entity.ToTable("Usuario");

            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Contraseña)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Estatus).HasDefaultValue(true);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
