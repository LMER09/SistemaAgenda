using System;

namespace SistemaAgenda.Negocios
{
    // Representa una notificacion ya disparada (recordatorio de cita proxima)
    public class NotificacionItem
    {
        public DateTime Fecha { get; set; }
        public string Mensaje { get; set; } = string.Empty;
    }
}
