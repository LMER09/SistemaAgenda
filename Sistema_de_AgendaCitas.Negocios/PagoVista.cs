using System;
 
namespace SistemaAgenda.Negocios
{
    public class PagoVista
    {
        public int Id { get; set; }
        public string Cliente { get; set; } = string.Empty;
        public string Servicio { get; set; } = string.Empty;
        public DateTime FechaCita { get; set; }
        public decimal Monto { get; set; }
        public string MetodoDePago { get; set; } = string.Empty;
        public DateTime FechaPago { get; set; }
    }
}
