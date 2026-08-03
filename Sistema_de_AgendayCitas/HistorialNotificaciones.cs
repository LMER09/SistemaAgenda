using System;
using System.Collections.Generic;

namespace SistemaAgenda.UI
{
    // Guarda en memoria el historial de todos los recordatorios que ha
    // generado el sistema durante esta sesión, para poder verlos luego
    // en frmNotificaciones (no solo el aviso momentáneo del toast).
    public static class HistorialNotificaciones
    {
        public class Entrada
        {
            public DateTime Fecha { get; set; }
            public string Mensaje { get; set; } = string.Empty;
        }

        private static readonly List<Entrada> _entradas = new List<Entrada>();

        // Se dispara cada vez que se agrega una notificación nueva,
        // para que una ventana abierta pueda refrescarse sola si quiere
        public static event Action? NotificacionAgregada;

        public static void Agregar(string mensaje)
        {
            _entradas.Insert(0, new Entrada { Fecha = DateTime.Now, Mensaje = mensaje });
            NotificacionAgregada?.Invoke();
        }

        public static List<Entrada> ObtenerTodas()
        {
            return new List<Entrada>(_entradas);
        }

        public static void Limpiar()
        {
            _entradas.Clear();
            NotificacionAgregada?.Invoke();
        }
    }
}