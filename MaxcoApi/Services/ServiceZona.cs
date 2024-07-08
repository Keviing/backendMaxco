using MaxcoApi.Data;
using MaxcoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MaxcoApi.Services
{
    public class ServiceZona: IServiceZona
    {
        private readonly AppDbContext _context;

        public ServiceZona(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Zona>> GetZonasAsync()
        {
            return await _context.Zonas.ToListAsync();
        }

        public async Task<Zona> GetZonaByIdAsync(int id)
        {
            return await _context.Zonas.FindAsync(id);
        }

        public async Task<Zona> AddZonaAsync(Zona zona)
        {
            _context.Zonas.Add(zona);
            await _context.SaveChangesAsync();
            return zona;
        }

        public async Task<Zona> UpdateZonaAsync(Zona zona)
        {
            _context.Entry(zona).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return zona;
        }

        public async Task DeleteZonaAsync(int id)
        {
            var zona = await _context.Zonas.FindAsync(id);
            if (zona != null)
            {
                _context.Zonas.Remove(zona);
                await _context.SaveChangesAsync();
            }
        }
    }
}
