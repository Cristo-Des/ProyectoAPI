namespace ProyectoAPI.Models.DTOs
{
    public class HabitacionDTO
    {
        public int IdHabitacion { get; set; }

        public string Descripcion { get; set; } = null!;

        public decimal Precio { get; set; }

        public int IdTipoHabitacion { get; set; }

        public bool Estatus { get; set; }

        public int IdUsuarioCrea { get; set; }

        public DateOnly FechaCrea { get; set; }

    }
}
