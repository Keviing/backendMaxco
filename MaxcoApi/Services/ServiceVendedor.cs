using MaxcoApi.Data;
using MaxcoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MaxcoApi.Services
{
    public class ServiceVendedor: IServiceVendedor
    {
        private readonly AppDbContext _context;

        public ServiceVendedor(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Vendedor>> GetVendedoresAsync()
        {
            return await _context.Vendedores.ToListAsync();
        }

        public async Task<Vendedor> GetVendedorByIdAsync(int id)
        {
            return await _context.Vendedores.FindAsync(id);
        }

        public async Task<Vendedor> AddVendedorAsync(Vendedor vendedor)
        {
            _context.Vendedores.Add(vendedor);
            await _context.SaveChangesAsync();
            return vendedor;
        }

        public async Task<Vendedor> UpdateVendedorAsync(Vendedor vendedor)
        {
            _context.Entry(vendedor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return vendedor;
        }

        public async Task DeleteVendedorAsync(int id)
        {
            var vendedor = await _context.Vendedores.FindAsync(id);
            if (vendedor != null)
            {
                _context.Vendedores.Remove(vendedor);
                await _context.SaveChangesAsync();
            }
        }
    }
}
