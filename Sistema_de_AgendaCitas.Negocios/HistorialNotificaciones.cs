using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaAgenda.Negocios
{
    // Guarda en memoria todas las notificaciones (recordatorios de citas
    // proximas) que se han disparado mientras el programa esta abierto.
    public static class HistorialNotificaciones
    {
        private static readonly List<NotificacionItem> _historial = new List<NotificacionItem>();

        public static void Agregar(string mensaje)
        {
            _historial.Add(new NotificacionItem
            {
                Fecha = DateTime.Now,
                Mensaje = mensaje
            });
        }

        // Devuelve las mas recientes primero.
        public static List<NotificacionItem> ObtenerTodas()
        {
            return _historial.OrderByDescending(n => n.Fecha).ToList();
        }
    }
}