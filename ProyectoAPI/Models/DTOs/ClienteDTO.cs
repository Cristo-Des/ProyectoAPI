namespace ProyectoAPI.Models.DTOs
{
    public class ClienteDTO
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


    }
}
