using MaxcoApi.Data;
using System.Linq;

namespace MaxcoApi.Services
{
    public class ServiceReport : IServiceReport
    {
        private readonly AppDbContext _context;

        public ServiceReport(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<object> GetZonasConMayorCantidadDeVentasPorVendedor()
        {
            var query = from venta in _context.Ventas
                        join vendedor in _context.Vendedores on venta.Id_Vendedor equals vendedor.Id
                        join zona in _context.Zonas on venta.Id_Zona equals zona.Id
                        group venta by new { Zona = zona.NombreZona, Vendedor = vendedor.Nombre } into g
                        select new
                        {
                            ZonaVendedor = $"{g.Key.Zona} - {g.Key.Vendedor}",
                            TotalVentas = g.Count()
                        };

            return query.OrderByDescending(x => x.TotalVentas).AsQueryable();
        }
    }
}
