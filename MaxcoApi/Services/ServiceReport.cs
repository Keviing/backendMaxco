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

        public IQueryable<string> GetZonasSinVentas(DateTime fechaInicio, DateTime fechaFin)
        {
            var zonasConVentas = from venta in _context.Ventas
                                 where venta.Fecha >= fechaInicio && venta.Fecha <= fechaFin
                                 select venta.Id_Zona;

            var zonasSinVentas = from zona in _context.Zonas
                                 where !zonasConVentas.Contains(zona.Id)
                                 select zona.NombreZona;

            return zonasSinVentas.AsQueryable();
        }

        public IQueryable<string> GetVendedoresSinVentas(DateTime fechaInicio, DateTime fechaFin)
        {
            var vendedoresConVentas = from venta in _context.Ventas
                                      where venta.Fecha >= fechaInicio && venta.Fecha <= fechaFin
                                      select venta.Id_Vendedor;

            var vendedoresSinVentas = from vendedor in _context.Vendedores
                                      where !vendedoresConVentas.Contains(vendedor.Id)
                                      select vendedor.Nombre;

            return vendedoresSinVentas.AsQueryable();
        }
    }
}
