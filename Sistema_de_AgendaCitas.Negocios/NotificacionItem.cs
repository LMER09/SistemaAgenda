using System;

namespace SistemaAgenda.Negocios
{
    // Representa una notificacion ya disparada (recordatorio de cita proxima).
    // No es una entidad de base de datos, solo vive en memoria mientras
    // el programa esta abierto.
    public class NotificacionItem
    {
        public DateTime Fecha { get; set; }
        public string Mensaje { get; set; } = string.Empty;
    }
}
