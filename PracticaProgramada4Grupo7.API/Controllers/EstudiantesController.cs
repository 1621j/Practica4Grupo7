using Microsoft.AspNetCore.Mvc;
using PracticaProgramada4Grupo7.BLL.Dtos;
using PracticaProgramada4Grupo7.BLL.Services;

namespace PracticaProgramada4Grupo7.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstudiantesController : ControllerBase
    {
        private readonly IEstudianteService _servicio;

        public EstudiantesController(IEstudianteService servicio)
        {
            _servicio = servicio;
        }

        [HttpGet]
        public async Task<ActionResult<List<EstudianteDto>>> Listar()
        {
            return Ok(await _servicio.ObtenerTodosAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<EstudianteDto>> Consultar(int id)
        {
            var estudiante = await _servicio.ObtenerPorIdAsync(id);
            return estudiante == null
                ? NotFound(new { mensaje = "El estudiante no existe." })
                : Ok(estudiante);
        }

        [HttpPost]
        public async Task<ActionResult<EstudianteDto>> Registrar(EstudianteDto estudiante)
        {
            try
            {
                var creado = await _servicio.RegistrarAsync(estudiante);
                return CreatedAtAction(nameof(Consultar), new { id = creado.Id }, creado);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { mensaje = ex.Message });
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Actualizar(int id, EstudianteActualizarDto estudiante)
        {
            try
            {
                return await _servicio.ActualizarAsync(id, estudiante)
                    ? NoContent()
                    : NotFound(new { mensaje = "El estudiante no existe." });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { mensaje = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            return await _servicio.EliminarAsync(id)
                ? NoContent()
                : NotFound(new { mensaje = "El estudiante no existe." });
        }
    }
}