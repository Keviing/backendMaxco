using MaxcoApi.Models;
using MaxcoApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace MaxcoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZonaController : Controller
    {
        private readonly IServiceZona _zonaService;

        public ZonaController(IServiceZona zonaService)
        {
            _zonaService = zonaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Zona>>> GetZonas()
        {
            var zonas = await _zonaService.GetZonasAsync();
            return Ok(zonas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Zona>> GetZona(int id)
        {
            var zona = await _zonaService.GetZonaByIdAsync(id);
            if (zona == null)
            {
                return NotFound();
            }
            return Ok(zona);
        }

        [HttpPost]
        public async Task<ActionResult<Zona>> AddZona(Zona zona)
        {
            var createdZona = await _zonaService.AddZonaAsync(zona);
            return CreatedAtAction(nameof(GetZona), new { id = createdZona.Id }, createdZona);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateZona(int id, Zona zona)
        {
            if (id != zona.Id)
            {
                return BadRequest();
            }
            await _zonaService.UpdateZonaAsync(zona);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteZona(int id)
        {
            await _zonaService.DeleteZonaAsync(id);
            return NoContent();
        }
    }
}
