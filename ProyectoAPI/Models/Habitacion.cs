using System;
using System.Collections.Generic;

namespace ProyectoAPI.Models;

public partial class Habitacion
{
    public int IdHabitacion { get; set; }

    public string Descripcion { get; set; } = null!;

    public decimal Precio { get; set; }

    public int IdTipoHabitacion { get; set; }

    public bool Estatus { get; set; }

    public int IdUsuarioCrea { get; set; }

    public DateOnly FechaCrea { get; set; }

    public virtual TipoHabitacion IdTipoHabitacionNavigation { get; set; } = null!;

    public virtual Usuario? IdUsuarioCreaNavigation { get; set; }

    public virtual ICollection<Reservacion> Reservacions { get; set; } = new List<Reservacion>();
}
