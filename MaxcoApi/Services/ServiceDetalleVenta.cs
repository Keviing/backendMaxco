using MaxcoApi.Data;
using MaxcoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MaxcoApi.Services
{
    public class ServiceDetalleVenta: IServiceDetalle
    {
        private readonly AppDbContext _context;

        public ServiceDetalleVenta(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DetalleVenta>> GetAllAsync()
        {
            return await _context.DetallesVentas
                .Include(dv => dv.Venta)
                .Include(dv => dv.Producto)
                .ToListAsync();
        }

        public async Task<DetalleVenta> GetByIdAsync(int id)
        {
            return await _context.DetallesVentas
                .Include(dv => dv.Venta)
                .Include(dv => dv.Producto)
                .FirstOrDefaultAsync(dv => dv.Id == id);
        }

        public async Task<DetalleVenta> AddAsync(DetalleVenta detalleVenta)
        {
            detalleVenta.Subtotal = detalleVenta.Cantidad * detalleVenta.PrecioUnitario;

            _context.DetallesVentas.Add(detalleVenta);
            await _context.SaveChangesAsync();
            return detalleVenta;
        }

        public async Task<DetalleVenta> UpdateAsync(DetalleVenta detalleVenta)
        {
            _context.Entry(detalleVenta).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return detalleVenta;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var detalleVenta = await _context.DetallesVentas.FindAsync(id);
            if (detalleVenta == null)
            {
                return false;
            }

            _context.DetallesVentas.Remove(detalleVenta);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
