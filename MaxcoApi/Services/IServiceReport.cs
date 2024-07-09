namespace MaxcoApi.Services
{
    public interface IServiceReport
    {
        IQueryable<object> GetZonasConMayorCantidadDeVentasPorVendedor();

    }
}
