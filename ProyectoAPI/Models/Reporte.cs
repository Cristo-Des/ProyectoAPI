using System;
using System.Collections.Generic;

namespace ProyectoAPI.Models;

public partial class Reporte
{
    public int IdReporte { get; set; }

    public string NombreReporte { get; set; } = null!;

    public DateOnly FechaReporte { get; set; }

    public string TipoReporte { get; set; } = null!;

    public int IdTransaccion { get; set; }

    public bool Estatus { get; set; }

    public int IdUsuarioCrea { get; set; }

    public DateOnly FechaCrea { get; set; }

    public virtual Transaccion IdTransaccionNavigation { get; set; } = null!;

    public virtual Usuario? IdUsuarioCreaNavigation { get; set; }
}
