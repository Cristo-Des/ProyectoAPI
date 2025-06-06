using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoAPI.Custom;
using ProyectoAPI.Models;
using ProyectoAPI.Models.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace ProyectoAPI.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class AccesoController : ControllerBase
    {
        private readonly HotelDbContext _dbPruebaContext;
        private readonly Utilidades _utilidades;
        public AccesoController(HotelDbContext dbPruebaContext, Utilidades utilidades)
        {
            _dbPruebaContext = dbPruebaContext;
            _utilidades = utilidades;
        }

        [HttpPost]
        [Route("Registrarse")]
        public async Task<IActionResult> Registrarse(UsuarioDTO objeto)
        {

            var modeloUsuario = new Usuario
            {
                Nombre = objeto.Nombre,
                ApellidoPaterno = objeto.ApellidoPaterno,
                ApellidoMaterno = objeto.ApellidoMaterno,
                Email = objeto.Email,
                Contraseña = _utilidades.encriptarSHA256(objeto.Contraseña),
                Estatus = objeto.Estatus
            };

            await _dbPruebaContext.Usuarios.AddAsync(modeloUsuario);
            await _dbPruebaContext.SaveChangesAsync();

            if (modeloUsuario.IdUsuario != 0)
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = true });
            else
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = false });
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginDTO objeto)
        {
            var usuarioEncontrado = await _dbPruebaContext.Usuarios
                                                    .Where(u =>
                                                        u.Email == objeto.Email &&
                                                        u.Contraseña == _utilidades.encriptarSHA256(objeto.Contraseña) && u.Estatus == true
                                                      ).FirstOrDefaultAsync();

            if (usuarioEncontrado == null)
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = false, token = "" });
            else
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = true, token = _utilidades.generarJWT(usuarioEncontrado),
                    idUsuario = usuarioEncontrado.IdUsuario,             
                    nombre = usuarioEncontrado.Nombre
                });
        }
    

    }
}
