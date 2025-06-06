using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoAPI.Custom;
using ProyectoAPI.Models;
using ProyectoAPI.Models.DTOs;
using System.Net.NetworkInformation;

namespace ProyectoAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class TipoHabitacionController : ControllerBase
    {
        private readonly HotelDbContext _dbPruebaContext;

        public TipoHabitacionController(HotelDbContext dbPruebaContext)
        {
            _dbPruebaContext = dbPruebaContext;
        }

        [HttpGet("Lista")]
        public async Task<IActionResult> Lista()
        {
            var lista = await _dbPruebaContext.TipoHabitacions.Where(c => c.Estatus == true).ToListAsync();
            return Ok(new { value = lista });
        }

        // GET: api/tipohabitacion/{id}
        [HttpGet("ConsutarId/{id}")]
        public async Task<ActionResult<List<TipoHabitacionDTO>>> GetSingleProducto(int id)
        {
            var tipohabitacion = await _dbPruebaContext.TipoHabitacions.FindAsync(id);
            if (tipohabitacion == null) return NotFound(new { message = "TipoHabitacion no encontrado" });

            return Ok(tipohabitacion);
        }

        // POST: api/tipohabitacion
        [HttpPost]
        public async Task<ActionResult<string>> CrearTipoHabitacion(TipoHabitacionDTO tipohabitacion)
        {
            var modeloTipoHabitacion = new TipoHabitacion
            {
                NombreTipo = tipohabitacion.NombreTipo,
                CapacidadPersonas = tipohabitacion.CapacidadPersonas,
                Tamaño = tipohabitacion.Tamaño,
                NumeroBaños = tipohabitacion.NumeroBaños,
                TipoClimatizacion = tipohabitacion.TipoClimatizacion,
                TipoVistas = tipohabitacion.TipoVistas,
                Estatus = tipohabitacion.Estatus,
                IdUsuarioCrea = tipohabitacion.IdUsuarioCrea,
                FechaCrea = tipohabitacion.FechaCrea
            };

            await _dbPruebaContext.TipoHabitacions.AddAsync(modeloTipoHabitacion);
            await _dbPruebaContext.SaveChangesAsync();

            if (modeloTipoHabitacion.IdTipoHabitacion != 0)
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = true });
            else
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = false });
        }

        // PUT: api/tipohabitacion/{id}
        [HttpPut("ConsutarId/{id}")]
        public async Task<IActionResult> Editar(int id, [FromBody] TipoHabitacionDTO tipohabitacionDTO)
        {
            if (id != tipohabitacionDTO.IdTipoHabitacion) return BadRequest(new { message = "IDs no coinciden" });

            var tipohabitacion = await _dbPruebaContext.TipoHabitacions.FindAsync(id);
            if (tipohabitacion == null) return NotFound(new { message = "Tipo habitacion no encontrado" });

            // Actualiza solo los campos necesarios

            tipohabitacion.NombreTipo = tipohabitacionDTO.NombreTipo;
            tipohabitacion.CapacidadPersonas = tipohabitacionDTO.CapacidadPersonas;
            tipohabitacion.Tamaño = tipohabitacionDTO.Tamaño;
            tipohabitacion.NumeroBaños = tipohabitacionDTO.NumeroBaños;
            tipohabitacion.TipoClimatizacion = tipohabitacionDTO.TipoClimatizacion;
            tipohabitacion.TipoVistas = tipohabitacionDTO.TipoVistas;
            tipohabitacion.Estatus = tipohabitacionDTO.Estatus;
            tipohabitacion.IdUsuarioCrea = tipohabitacion.IdUsuarioCrea;
            tipohabitacion.FechaCrea = tipohabitacion.FechaCrea;

            await _dbPruebaContext.SaveChangesAsync();

            return Ok(new { message = "Tipo Habitacion actualizado correctamente" });
        }

        [HttpDelete("EliminarId/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var tipoHabitacion = await _dbPruebaContext.TipoHabitacions.FindAsync(id);
            if (tipoHabitacion == null)
                return NotFound(new { message = "Tipo Habitacion no encontrado" });

            // Soft delete: marcamos Estatus como false
            tipoHabitacion.Estatus = false;

            _dbPruebaContext.TipoHabitacions.Update(tipoHabitacion);
            await _dbPruebaContext.SaveChangesAsync();

            return Ok(new { message = "Tipo Habitacion desactivado correctamente" });
        }
    }
}
