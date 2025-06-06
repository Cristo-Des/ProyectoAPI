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
    public class EmpleadoController : ControllerBase
    {
        private readonly HotelDbContext _dbPruebaContext;

        public EmpleadoController(HotelDbContext dbPruebaContext)
        {
            _dbPruebaContext = dbPruebaContext;
        }

        [HttpGet("Lista")]
        public async Task<IActionResult> Lista()
        {
            var lista = await _dbPruebaContext.Empleados.Where(c => c.Estatus == true).ToListAsync();
            return Ok(new { value = lista });
        }
        // GET: api/empleado/{id}
        [HttpGet("ConsutarId/{id}")]
        public async Task<ActionResult<List<EmpleadoDTO>>> GetSingleProducto(int id)
        {
            var empleado = await _dbPruebaContext.Empleados.FindAsync(id);
            if (empleado == null) return NotFound(new { message = "Empleado no encontrado" });

            return Ok(empleado);
        }

        // POST: api/empleado
        [HttpPost]
        public async Task<ActionResult<string>> CrearEmpleado(EmpleadoDTO empleado)
        {
            var modeloEmpleado = new Empleado
            {
                Nombre = empleado.Nombre,
                ApellidoPaterno = empleado  .ApellidoPaterno,
                ApellidoMaterno = empleado.ApellidoMaterno,
                FechaNacimiento = empleado.FechaNacimiento,
                NumeroSeguroSocial = empleado.NumeroSeguroSocial,
                Rfc = empleado.Rfc,
                Genero = empleado.Genero,
                Dierccion = empleado.Dierccion,
                Telefono = empleado.Telefono,
                Correo = empleado.Correo,
                FechaIngreso=empleado.FechaIngreso,
                Puesto=empleado.Puesto,
                Salario = empleado.Salario,
                Estatus = empleado.Estatus,
                IdUsuarioCrea = empleado.IdUsuarioCrea,
                FechaCrea = empleado.FechaCrea
            };

            await _dbPruebaContext.Empleados.AddAsync(modeloEmpleado);
            await _dbPruebaContext.SaveChangesAsync();

            if (modeloEmpleado.IdEmpleado != 0)
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = true });
            else
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = false });
        }

        // PUT: api/empleado/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Editar(int id, [FromBody] EmpleadoDTO empleadoDTO)
        {
            if (id != empleadoDTO.IdEmpleado) return BadRequest(new { message = "IDs no coinciden" });

            var empleado = await _dbPruebaContext.Empleados.FindAsync(id);
            if (empleado == null) return NotFound(new { message = "Empleado no encontrado" });

            // Actualiza solo los campos necesarios
            empleado.Nombre = empleadoDTO.Nombre;
            empleado.ApellidoPaterno = empleadoDTO.ApellidoPaterno;
            empleado.ApellidoMaterno = empleadoDTO.ApellidoMaterno;
            empleado.FechaNacimiento = empleadoDTO.FechaNacimiento;
            empleado.NumeroSeguroSocial = empleadoDTO.NumeroSeguroSocial;
            empleado.Rfc = empleadoDTO.Rfc;
            empleado.Genero = empleadoDTO.Genero;
            empleado.Dierccion = empleadoDTO.Dierccion;
            empleado.Telefono = empleadoDTO.Telefono;
            empleado.Correo = empleadoDTO.Correo;
            empleado.FechaIngreso = empleadoDTO.FechaIngreso;
            empleado.Puesto = empleadoDTO.Puesto;
            empleado.Salario = empleadoDTO.Salario;
            empleado.Estatus = empleadoDTO.Estatus;
            empleado.IdUsuarioCrea = empleadoDTO.IdUsuarioCrea;
            empleado.FechaCrea = empleadoDTO.FechaCrea;

            await _dbPruebaContext.SaveChangesAsync();

            return Ok(new { message = "Cliente actualizado correctamente" });
        }
        [HttpDelete("EliminarId/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var empleado = await _dbPruebaContext.Empleados.FindAsync(id);
            if (empleado == null)
                return NotFound(new { message = "Empleado no encontrado" });

            // Soft delete: marcamos Estatus como false
            empleado.Estatus = false;

            _dbPruebaContext.Empleados.Update(empleado);
            await _dbPruebaContext.SaveChangesAsync();

            return Ok(new { message = "Empleado desactivado correctamente" });
        }

    }
}
