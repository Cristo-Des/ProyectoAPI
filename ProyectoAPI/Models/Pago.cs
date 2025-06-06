using System;
using System.Collections.Generic;

namespace ProyectoAPI.Models;

public partial class Pago
{
    public int IdPago { get; set; }

    public int IdCliente { get; set; }

    public int IdEmpleado { get; set; }

    public DateOnly FechaPago { get; set; }

    public decimal Monto { get; set; }

    public string FormaPago { get; set; } = null!;

    public string Concepto { get; set; } = null!;

    public string EstadoPago { get; set; } = null!;

    public DateOnly FechaVencimiento { get; set; }

    public string Comentarios { get; set; } = null!;

    public bool Estatus { get; set; }

    public int IdUsuarioCrea { get; set; }

    public DateOnly FechaCrea { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;

    public virtual Usuario? IdUsuarioCreaNavigation { get; set; }

    public virtual ICollection<Transaccion> Transaccions { get; set; } = new List<Transaccion>();
}
