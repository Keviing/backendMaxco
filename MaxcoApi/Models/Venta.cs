namespace MaxcoApi.Models
{
    public class Venta
    {
        public int Id { get; set; }
        public int Id_Cliente { get; set; }
        public int Id_Vendedor { get; set; }
        public int Id_Zona { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto_Total { get; set; }

        // Navigation properties
        public Cliente Cliente { get; set; }
        public Vendedor Vendedor { get; set; }
        public Zona Zona { get; set; }
        
    }
}
