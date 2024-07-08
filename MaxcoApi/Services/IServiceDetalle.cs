using MaxcoApi.Models;

namespace MaxcoApi.Services
{
    public interface IServiceDetalle
    {
        Task<IEnumerable<DetalleVenta>> GetAllAsync();
        Task<DetalleVenta> GetByIdAsync(int id);
        Task<DetalleVenta> AddAsync(DetalleVenta detalleVenta);
        Task<DetalleVenta> UpdateAsync(DetalleVenta detalleVenta);
        Task<bool> DeleteAsync(int id);
    }
}
