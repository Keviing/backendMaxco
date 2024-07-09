using MaxcoApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace MaxcoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : Controller
    {
        private readonly IServiceReport _reportService;

        public ReportController(IServiceReport reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("zonaVentaMayor")]
        public IActionResult GetZonasConMayorCantidadDeVentasPorVendedor()
        {
            var result = _reportService.GetZonasConMayorCantidadDeVentasPorVendedor().ToList();
            return Ok(result);
        }
    }
}
