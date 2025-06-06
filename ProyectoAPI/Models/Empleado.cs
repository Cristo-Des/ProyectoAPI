using System;
using System.Collections.Generic;

namespace ProyectoAPI.Models;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public string Nombre { get; set; } = null!;

    public string ApellidoPaterno { get; set; } = null!;

    public string ApellidoMaterno { get; set; } = null!;

    public DateOnly FechaNacimiento { get; set; }

    public string NumeroSeguroSocial { get; set; } = null!;

    public string Rfc { get; set; } = null!;

    public string Genero { get; set; } = null!;

    public string Dierccion { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public DateOnly FechaIngreso { get; set; }

    public string Puesto { get; set; } = null!;

    public decimal Salario { get; set; }

    public bool Estatus { get; set; }

    public int IdUsuarioCrea { get; set; }

    public DateOnly FechaCrea { get; set; }

    public virtual Usuario? IdUsuarioCreaNavigation { get; set; }

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();

    public virtual ICollection<Transaccion> Transaccions { get; set; } = new List<Transaccion>();
}
