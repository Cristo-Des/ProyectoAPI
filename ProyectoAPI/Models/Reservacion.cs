using System;
using System.Collections.Generic;

namespace ProyectoAPI.Models;

public partial class Reservacion
{
    public int IdReservacion { get; set; }

    public int IdCliente { get; set; }

    public int IdHabaitacion { get; set; }

    public DateTime FechaReserva { get; set; }

    public DateTime FechaEntrada { get; set; }

    public DateTime FechaSalida { get; set; }

    public int CantidadPersonas { get; set; }

    public string EstadoReserva { get; set; } = null!;

    public string Comentarios { get; set; } = null!;

    public DateOnly? FechaCancelacion { get; set; }

    public string? MotivoCancelacion { get; set; }

    public bool Estatus { get; set; }

    public int IdUsuarioCrea { get; set; }

    public DateOnly FechaCrea { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual Habitacion IdHabaitacionNavigation { get; set; } = null!;

    public virtual Usuario? IdUsuarioCreaNavigation { get; set; } 

    public virtual ICollection<Transaccion> Transaccions { get; set; } = new List<Transaccion>();
}
