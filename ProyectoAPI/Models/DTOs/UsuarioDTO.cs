namespace ProyectoAPI.Models.DTOs
{
    public class UsuarioDTO
    {
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public bool Estatus { get; set; }
    }
}
