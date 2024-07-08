using MaxcoApi.Models;
using MaxcoApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace MaxcoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleVentaController : Controller
    {

        private readonly IServiceDetalle _detalleVentaService;

        public DetalleVentaController(IServiceDetalle detalleVentaService)
        {
            _detalleVentaService = detalleVentaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleVenta>>> GetDetallesVentas()
        {
            var detalles = await _detalleVentaService.GetAllAsync();
            return Ok(detalles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleVenta>> GetDetalleVenta(int id)
        {
            var detalle = await _detalleVentaService.GetByIdAsync(id);
            if (detalle == null)
            {
                return NotFound();
            }

            return Ok(detalle);
        }

        [HttpPost]
        public async Task<ActionResult<DetalleVenta>> PostDetalleVenta(DetalleVenta detalleVenta)
        {
            var createdDetalle = await _detalleVentaService.AddAsync(detalleVenta);
            return CreatedAtAction(nameof(GetDetalleVenta), new { id = createdDetalle.Id }, createdDetalle);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalleVenta(int id, DetalleVenta detalleVenta)
        {
            if (id != detalleVenta.Id)
            {
                return BadRequest();
            }

            var updatedDetalle = await _detalleVentaService.UpdateAsync(detalleVenta);
            if (updatedDetalle == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalleVenta(int id)
        {
            var result = await _detalleVentaService.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
