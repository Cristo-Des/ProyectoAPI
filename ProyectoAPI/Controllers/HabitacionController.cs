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
    public class HabitacionController : ControllerBase
    {
        private readonly HotelDbContext _dbPruebaContext;

        public HabitacionController(HotelDbContext dbPruebaContext)
        {
            _dbPruebaContext = dbPruebaContext;
        }

        [HttpGet("Lista")]
        public async Task<IActionResult> Lista()
        {
            var lista = await _dbPruebaContext.Habitacions.Where(c => c.Estatus == true).ToListAsync();
            return Ok(new { value = lista });
        }

        // GET: api/habitacion/{id}
        [HttpGet("ConsutarId/{id}")]
        public async Task<ActionResult<List<HabitacionDTO>>> GetSingleProducto(int id)
        {
            var habitacion = await _dbPruebaContext.Habitacions.FindAsync(id);
            if (habitacion == null) return NotFound(new { message = "Habitacion no encontrado" });

            return Ok(habitacion);
        }

        // POST: api/tipohabitacion
        [HttpPost]
        public async Task<ActionResult<string>> CrearHabitacion(HabitacionDTO habitacion)
        {
            var modeloHabitacion = new Habitacion
            {
                Descripcion = habitacion.Descripcion,
                Precio = habitacion.Precio,
                IdTipoHabitacion = habitacion.IdTipoHabitacion,
                Estatus = habitacion.Estatus,
                IdUsuarioCrea = habitacion.IdUsuarioCrea,
                FechaCrea = habitacion.FechaCrea
            };

            await _dbPruebaContext.Habitacions.AddAsync(modeloHabitacion);
            await _dbPruebaContext.SaveChangesAsync();

            if (modeloHabitacion.IdHabitacion != 0)
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = true });
            else
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = false });
        }

        // PUT: api/habitacion/{id}
        [HttpPut("ConsutarId/{id}")]
        public async Task<IActionResult> Editar(int id, [FromBody] HabitacionDTO habitacionDTO)
        {
            if (id != habitacionDTO.IdHabitacion) return BadRequest(new { message = "IDs no coinciden" });

            var habitacion = await _dbPruebaContext.Habitacions.FindAsync(id);
            if (habitacion == null) return NotFound(new { message = "Habitacion no encontrado" });

            // Actualiza solo los campos necesarios

            habitacion.Descripcion = habitacionDTO.Descripcion;
            habitacion.Precio = habitacionDTO.Precio;
            habitacion.IdTipoHabitacion = habitacionDTO.IdTipoHabitacion;
            habitacion.Estatus = habitacionDTO.Estatus;
            habitacion.IdUsuarioCrea = habitacionDTO.IdUsuarioCrea;
            habitacion.FechaCrea = habitacion.FechaCrea;

            await _dbPruebaContext.SaveChangesAsync();

            return Ok(new { message = "Habitacion actualizado correctamente" });
        }

        [HttpDelete("EliminarId/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var Habitacion = await _dbPruebaContext.Habitacions.FindAsync(id);
            if (Habitacion == null)
                return NotFound(new { message = "Habitacion no encontrado" });

            // Soft delete: marcamos Estatus como false
            Habitacion.Estatus = false;

            _dbPruebaContext.Habitacions.Update(Habitacion);
            await _dbPruebaContext.SaveChangesAsync();

            return Ok(new { message = "Habitacion desactivado correctamente" });
        }

    }
}
