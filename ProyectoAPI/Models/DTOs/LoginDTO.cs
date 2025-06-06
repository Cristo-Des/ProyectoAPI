namespace ProyectoAPI.Models.DTOs
{
    public class LoginDTO
    {
        public int IdUsuario { get; set; }
        public string? Nombre { get; set; }
        public string? Email { get; set; }
        public string Contraseña { get; set; }
        public bool Estatus { get; set; }
    }
}
