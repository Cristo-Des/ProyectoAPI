using System;
using System.Collections.Generic;

namespace ProyectoAPI.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? Nombre { get; set; }

    public string ApellidoPaterno { get; set; } = null!;

    public string ApellidoMaterno { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public bool Estatus { get; set; }

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();

    public virtual ICollection<Habitacion> Habitacions { get; set; } = new List<Habitacion>();

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();

    public virtual ICollection<Reporte> Reportes { get; set; } = new List<Reporte>();

    public virtual ICollection<Reservacion> Reservacions { get; set; } = new List<Reservacion>();

    public virtual ICollection<TipoHabitacion> TipoHabitacions { get; set; } = new List<TipoHabitacion>();

    public virtual ICollection<Transaccion> Transaccions { get; set; } = new List<Transaccion>();
}
