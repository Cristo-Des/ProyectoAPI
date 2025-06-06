namespace ProyectoAPI.Models.DTOs
{
    public class TipoHabitacionDTO
    {
        public int IdTipoHabitacion { get; set; }

        public string NombreTipo { get; set; } = null!;

        public int CapacidadPersonas { get; set; }

        public string Tamaño { get; set; } = null!;

        public int NumeroBaños { get; set; }

        public string TipoClimatizacion { get; set; } = null!;

        public string TipoVistas { get; set; } = null!;

        public bool Estatus { get; set; }

        public int IdUsuarioCrea { get; set; }

        public DateOnly FechaCrea { get; set; }
    }
}
