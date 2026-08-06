using System;

namespace SistemaAgenda.Negocios
{
    // TODO CLASE NUEVA: otificacionItem
    // Representa una notificacion ya disparada - Recordatorio.
    public class NotificacionItem
    {
        public DateTime Fecha { get; set; }
        public string Mensaje { get; set; } = string.Empty;
    }
}
