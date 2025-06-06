namespace ProyectoAPI.Models.DTOs
{
    public class ReporteDTO
    {
        public int IdReporte { get; set; }

        public string NombreReporte { get; set; } = null!;

        public DateOnly FechaReporte { get; set; }

        public string TipoReporte { get; set; } = null!;

        public int IdTransaccion { get; set; }

        public bool Estatus { get; set; }

        public int IdUsuarioCrea { get; set; }

        public DateOnly FechaCrea { get; set; }

        public int IdUsuarioModifica { get; set; }

        public DateOnly FechaModifica { get; set; }

        public virtual Transaccion IdTransaccionNavigation { get; set; } = null!;

        public virtual Usuario IdUsuarioCreaNavigation { get; set; } = null!;

        public virtual Usuario IdUsuarioModificaNavigation { get; set; } = null!;
    }
}
