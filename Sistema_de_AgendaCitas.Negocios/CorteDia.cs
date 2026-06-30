using System;
using System.Linq;
using System.IO;

namespace SistemaAgenda.Negocios
{
    // Destructor de CorteDia
    // Destructor: al cerrar el corte del día, genera un resumen de ingresos en un archivo de texto.
    // El recurso que libera/finaliza es el registro del cierre diario de caja.
    public class CorteDia
    {
        private decimal _totalIngresos;

        public CorteDia(decimal totalIngresos) => _totalIngresos = totalIngresos;

        ~CorteDia()
        {
            File.WriteAllText("CorteDia.txt",
                 $"=== CORTE DEL DÍA ===\n" +
                 $"Fecha: {DateTime.Today:dd/MM/yyyy}\n" +
                 $"Total ingresos: RD${_totalIngresos:F2}");
        }
    }
}