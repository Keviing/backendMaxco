using MaxcoApi.Data;
using MaxcoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MaxcoApi.Services
{
    public class ServiceVenta: IServiceVenta
    {
        private readonly AppDbContext _context;

        public ServiceVenta(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Venta>> GetVentasAsync()
        {
            return await _context.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.Vendedor)
                .Include(v => v.Zona)
                .ToListAsync();
        }

        public async Task<Venta> GetVentaByIdAsync(int id)
        {
            return await _context.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.Vendedor)
                .Include(v => v.Zona)
                .FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<Venta> AddVentaAsync(Venta venta)
        {
            _context.Ventas.Add(venta);
            await _context.SaveChangesAsync();
            return venta;
        }

        public async Task<Venta> UpdateVentaAsync(Venta venta)
        {
            _context.Entry(venta).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return venta;
        }

        public async Task DeleteVentaAsync(int id)
        {
            var venta = await _context.Ventas.FindAsync(id);
            if (venta != null)
            {
                _context.Ventas.Remove(venta);
                await _context.SaveChangesAsync();
            }
        }
    }
}
