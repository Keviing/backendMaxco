using MaxcoApi.Models;

namespace MaxcoApi.Services
{
    public interface IServiceVendedor
    {
        Task<IEnumerable<Vendedor>> GetVendedoresAsync();
        Task<Vendedor> GetVendedorByIdAsync(int id);
        Task<Vendedor> AddVendedorAsync(Vendedor vendedor);
        Task<Vendedor> UpdateVendedorAsync(Vendedor vendedor);
        Task DeleteVendedorAsync(int id);
    }
}
