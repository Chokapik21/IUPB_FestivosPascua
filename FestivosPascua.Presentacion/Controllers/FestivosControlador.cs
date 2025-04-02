using FestivosPascua.Core.Servicios;
using FestivosPascua.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace FestivosPascua.Presentacion.Controllers
{
    [ApiController]
    [Route("api/festivo")]
    public class FestivosController : Controller
    {
        private readonly IFestivoServicio _festivoServicio;

        public FestivosController(IFestivoServicio festivoServicio)
        {
            _festivoServicio = festivoServicio;
        }

        [HttpGet("listar")]
        public async Task<IActionResult> ObtenerTodos()
        {
            var festivos = await _festivoServicio.ObtenerTodos();
            return Ok(festivos);
        }

        [HttpGet("obtener/{id}")]
        public async Task<IActionResult> Obtener(int id)
        {
            var festivo = await _festivoServicio.Obtener(id);
            if (festivo == null) return NotFound();
            return Ok(festivo);
        }

        [HttpPost("agregar")]
        public async Task<IActionResult> Agregar([FromBody] ClsFestivos festivo)
        {
            var nuevoFestivo = await _festivoServicio.Agregar(festivo);
            return CreatedAtAction(nameof(Obtener), new { id = nuevoFestivo.Id }, nuevoFestivo);
        }

        [HttpGet("buscar/{Tipo}/{Dato}")]
        public async Task<IEnumerable<ClsFestivos>> Buscar(int Tipo, string Dato)
        {
            return await _festivoServicio.Buscar(Tipo, Dato);
        }

        [HttpPut("modificar/{id}")]
        public async Task<IActionResult> Modificar(int id, [FromBody] ClsFestivos festivo)
        {
            if (id != festivo.Id) return BadRequest();

            var festivoActualizado = await _festivoServicio.Modificar(festivo);
            if (festivoActualizado == null) return NotFound();

            return Ok(festivoActualizado);
        }

        [HttpDelete("eliminar/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var eliminado = await _festivoServicio.Eliminar(id);
            if (!eliminado) return NotFound();

            return NoContent();
        }
    }
}
