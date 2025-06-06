using System;
using System.Collections.Generic;

namespace ProyectoAPI.Models;

public partial class Transaccion
{
    public int IdTransaccion { get; set; }

    public string NombreTransaccion { get; set; } = null!;

    public DateOnly FechaTransaccion { get; set; }

    public int IdCliente { get; set; }

    public int IdPago { get; set; }

    public int IdEmpleado { get; set; }

    public int IdReservacion { get; set; }

    public bool Estatus { get; set; }

    public int IdUsuarioCrea { get; set; }

    public DateOnly FechaCrea { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;

    public virtual Pago IdPagoNavigation { get; set; } = null!;

    public virtual Reservacion IdReservacionNavigation { get; set; } = null!;

    public virtual Usuario? IdUsuarioCreaNavigation { get; set; }

    public virtual ICollection<Reporte> Reportes { get; set; } = new List<Reporte>();
}
