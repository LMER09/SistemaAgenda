using System;
 
namespace SistemaAgenda.Negocios
{
    // TODO CLASE NUEVA: PagoVista
    // Solo para mostrarse en pantalla. Combina datos de Pagos con
    // Citas, Clientes y Servicios para no mostrar solo IDs.
    public class PagoVista
    {
        // Id del pago real, tal como esta en la base de datos
        public int Id { get; set; }

        // Nombre completo del cliente y tipo de servicio de la cita
        public string Cliente { get; set; } = string.Empty;
        public string Servicio { get; set; } = string.Empty;

        // Fecha de la cita a la que pertenece este pago
        public DateTime FechaCita { get; set; }

        // Datos propios del pago
        public decimal Monto { get; set; }
        public string MetodoDePago { get; set; } = string.Empty;
        public DateTime FechaPago { get; set; }
    }
}
