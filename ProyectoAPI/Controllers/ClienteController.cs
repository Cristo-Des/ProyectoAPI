using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoAPI.Custom;
using ProyectoAPI.Models;
using ProyectoAPI.Models.DTOs;

namespace ProyectoAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly HotelDbContext _dbPruebaContext;

        public ClienteController(HotelDbContext dbPruebaContext)
        {
            _dbPruebaContext = dbPruebaContext;
        }

        [HttpGet("lista")]
        public async Task<IActionResult> Lista()
        {
            var lista = await _dbPruebaContext.Clientes.Where(c => c.Estatus == true).ToListAsync();
            return Ok(new { value = lista });
        }


        // GET: api/cliente/{id}
        [HttpGet("ConsultarId/{id}")]
        public async Task<ActionResult<List<ClienteDTO>>> GetSingleProducto(int id)
        {
            var cliente = await _dbPruebaContext.Clientes.FindAsync(id);
            if (cliente == null) return NotFound(new { message = "Cliente no encontrado" });

            return Ok(cliente);
        }

        // POST: api/cliente
        [HttpPost]
        public async Task<ActionResult<string>> CrearCliente(ClienteDTO cliente)
        {
            var modeloCliente = new Cliente
            {
                Nombre = cliente.Nombre,
                ApellidoPaterno = cliente.ApellidoPaterno,
                ApellidoMaterno = cliente.ApellidoMaterno,
                Identificacion=cliente.Identificacion,
                Telefono= cliente.Telefono,
                Email = cliente.Email,
                Direccion=cliente.Direccion,
                Estatus = cliente.Estatus,
                IdUsuarioCrea=cliente.IdUsuarioCrea,
                FechaCrea= cliente.FechaCrea
            };

            await _dbPruebaContext.Clientes.AddAsync(modeloCliente);
            await _dbPruebaContext.SaveChangesAsync();

            if (modeloCliente.IdCliente != 0)
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = true });
            else
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = false });
        }


        // PUT: api/cliente/{id}
        [HttpPut("EditarId/{id}")]
        public async Task<IActionResult> Editar(int id, [FromBody] ClienteDTO clienteDto)
        {
            if (id != clienteDto.IdCliente) return BadRequest(new { message = "IDs no coinciden" });

            var cliente = await _dbPruebaContext.Clientes.FindAsync(id);
            if (cliente == null) return NotFound(new { message = "Cliente no encontrado" });

            // Actualiza solo los campos necesarios
            cliente.Nombre = clienteDto.Nombre;
            cliente.ApellidoPaterno = clienteDto.ApellidoPaterno;
            cliente.ApellidoMaterno = clienteDto.ApellidoMaterno;
            cliente.Identificacion = clienteDto.Identificacion;
            cliente.Telefono = clienteDto.Telefono;
            cliente.Email = clienteDto.Email;
            cliente.Direccion = clienteDto.Direccion;
            cliente.Estatus = clienteDto.Estatus;
            cliente.IdUsuarioCrea = clienteDto.IdUsuarioCrea;
            cliente.FechaCrea = clienteDto.FechaCrea;

            await _dbPruebaContext.SaveChangesAsync();

            return Ok(new { message = "Cliente actualizado correctamente" });
        }


        [HttpDelete("EliminarId/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var cliente = await _dbPruebaContext.Clientes.FindAsync(id);
            if (cliente == null)
                return NotFound(new { message = "Cliente no encontrado" });

            // Soft delete: marcamos Estatus como false
            cliente.Estatus = false;

            _dbPruebaContext.Clientes.Update(cliente);
            await _dbPruebaContext.SaveChangesAsync();

            return Ok(new { message = "Cliente desactivado correctamente" });
        }
    }
}
