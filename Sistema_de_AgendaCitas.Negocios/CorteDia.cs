using System;
using System.IO;
using System.Collections.Generic;
using SistemaAgenda.Datos;

namespace SistemaAgenda.Negocios
{
    // TODO CorteDia
    // Genera el resumen de ingresos de un día en un archivo de texto.
    // Recibe los pagos ya filtrados por fecha, para no mezclar dias.
    public class CorteDia
    {
        private readonly DateTime _fecha;
        private readonly List<Pagos> _pagosDelDia;
        public CorteDia(DateTime fecha, List<Pagos> pagosDelDia)
        {
            _fecha = fecha.Date;
            _pagosDelDia = pagosDelDia;
        }
        public decimal TotalDelDia
        {
            get
            {
                decimal total = 0;
                for (int i = 0; i < _pagosDelDia.Count; i++)
                {
                    total += _pagosDelDia[i].Monto;
                }
                return total;
            }
        }

        public int CantidadDePagos => _pagosDelDia.Count;

        // Guarda el resumen en un archivo con la fecha en el nombre,
        // dentro de una carpeta fija "Reportes".
        public void Cerrar()
        {
            string carpeta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reportes");
            Directory.CreateDirectory(carpeta);

            string ruta = Path.Combine(carpeta, $"CorteDia_{_fecha:yyyy-MM-dd}.txt");

            File.WriteAllText(ruta,
                $"=== CORTE DEL DIA ===\n" +
                $"Fecha: {_fecha:dd/MM/yyyy}\n" +
                $"Total ingresos: RD${TotalDelDia:F2}\n" +
                $"Cantidad de pagos: {CantidadDePagos}\n");
        }
        ~CorteDia() { }
    }
}