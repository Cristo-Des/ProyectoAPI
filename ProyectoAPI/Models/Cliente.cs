using System;
using System.Collections.Generic;

namespace ProyectoAPI.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string Nombre { get; set; } = null!;

    public string ApellidoPaterno { get; set; } = null!;

    public string ApellidoMaterno { get; set; } = null!;

    public string Identificacion { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public bool Estatus { get; set; }

    public int IdUsuarioCrea { get; set; }

    public DateOnly FechaCrea { get; set; }

    public virtual Usuario? IdUsuarioCreaNavigation { get; set; }

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();

    public virtual ICollection<Reservacion> Reservacions { get; set; } = new List<Reservacion>();

    public virtual ICollection<Transaccion> Transaccions { get; set; } = new List<Transaccion>();
}
