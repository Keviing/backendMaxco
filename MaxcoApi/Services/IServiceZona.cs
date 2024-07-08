using MaxcoApi.Models;

namespace MaxcoApi.Services
{
    public interface IServiceZona
    {
        Task<IEnumerable<Zona>> GetZonasAsync();
        Task<Zona> GetZonaByIdAsync(int id);
        Task<Zona> AddZonaAsync(Zona zona);
        Task<Zona> UpdateZonaAsync(Zona zona);
        Task DeleteZonaAsync(int id);
    }
}
