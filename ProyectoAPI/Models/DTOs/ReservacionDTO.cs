namespace ProyectoAPI.Models.DTOs
{
    public class ReservacionDTO
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

        public int IdUsuarioModifica { get; set; }

        public DateOnly FechaModifica { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; } = null!;

        public virtual Habitacion IdHabaitacionNavigation { get; set; } = null!;

        public virtual Usuario IdUsuarioCreaNavigation { get; set; } = null!;

        public virtual Usuario IdUsuarioModificaNavigation { get; set; } = null!;

        public virtual ICollection<Transaccion> Transaccions { get; set; } = new List<Transaccion>();
    }
}
