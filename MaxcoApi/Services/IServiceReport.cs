namespace MaxcoApi.Services
{
    public interface IServiceReport
    {
        IQueryable<object> GetZonasConMayorCantidadDeVentasPorVendedor();

        IQueryable<string> GetZonasSinVentas(DateTime fechaInicio, DateTime fechaFin);
        IQueryable<string> GetVendedoresSinVentas(DateTime fechaInicio, DateTime fechaFin);

    }
}
