using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaAgenda.Negocios
{
    // TODO CLASE NUEVA: HistorialNotificaciones
    // Guarda en memoria todas las notificaciones (recordatorios de citas
    // proximas) que se han disparado mientras el programa esta abierto.
    public static class HistorialNotificaciones
    {
        // Lista en memoria, se vacía al cerrar el programa
        private static readonly List<NotificacionItem> _historial = new List<NotificacionItem>();

        // Guarda una notificación con la hora en que se disparó
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