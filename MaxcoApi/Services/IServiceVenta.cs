using MaxcoApi.Models;

namespace MaxcoApi.Services
{
    public interface IServiceVenta
    {
        Task<IEnumerable<Venta>> GetVentasAsync();
        Task<Venta> GetVentaByIdAsync(int id);
        Task<Venta> AddVentaAsync(Venta venta);
        Task<Venta> UpdateVentaAsync(Venta venta);
        Task DeleteVentaAsync(int id);
    }
}
