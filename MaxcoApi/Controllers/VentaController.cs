using MaxcoApi.Models;
using MaxcoApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace MaxcoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : Controller
    {
        private readonly IServiceVenta _ventaService;

        public VentaController(IServiceVenta ventaService)
        {
            _ventaService = ventaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Venta>>> GetVentas()
        {
            var ventas = await _ventaService.GetVentasAsync();
            return Ok(ventas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Venta>> GetVenta(int id)
        {
            var venta = await _ventaService.GetVentaByIdAsync(id);
            if (venta == null)
            {
                return NotFound();
            }
            return Ok(venta);
        }

        [HttpPost]
        public async Task<ActionResult<Venta>> AddVenta(Venta venta)
        {
        

            var createdVenta = await _ventaService.AddVentaAsync(venta);
            return CreatedAtAction(nameof(GetVenta), new { id = createdVenta.Id }, createdVenta);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVenta(int id, Venta venta)
        {
            if (id != venta.Id)
            {
                return BadRequest();
            }
            await _ventaService.UpdateVentaAsync(venta);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVenta(int id)
        {
            await _ventaService.DeleteVentaAsync(id);
            return NoContent();
        }
    }
}
