using MaxcoApi.Models;
using MaxcoApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace MaxcoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendedorController : Controller
    {
        private readonly IServiceVendedor _vendedorService;

        public VendedorController(IServiceVendedor vendedorService)
        {
            _vendedorService = vendedorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vendedor>>> GetVendedores()
        {
            var vendedores = await _vendedorService.GetVendedoresAsync();
            return Ok(vendedores);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Vendedor>> GetVendedor(int id)
        {
            var vendedor = await _vendedorService.GetVendedorByIdAsync(id);
            if (vendedor == null)
            {
                return NotFound();
            }
            return Ok(vendedor);
        }

        [HttpPost]
        public async Task<ActionResult<Vendedor>> AddVendedor(Vendedor vendedor)
        {
            var createdVendedor = await _vendedorService.AddVendedorAsync(vendedor);
            return CreatedAtAction(nameof(GetVendedor), new { id = createdVendedor.Id }, createdVendedor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVendedor(int id, Vendedor vendedor)
        {
            if (id != vendedor.Id)
            {
                return BadRequest();
            }
            await _vendedorService.UpdateVendedorAsync(vendedor);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVendedor(int id)
        {
            await _vendedorService.DeleteVendedorAsync(id);
            return NoContent();
        }
    }
}
