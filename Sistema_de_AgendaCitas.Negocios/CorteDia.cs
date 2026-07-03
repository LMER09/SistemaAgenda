using System;
using System.IO;

namespace SistemaAgenda.Negocios
{
    // Destructor de CorteDia
    // Aal cerrar el corte del día, genera un resumen de ingresos en un archivo de texto.
   
    public class CorteDia
    {
        // Atributo que almacena el total de ingresos del día
        private decimal _totalIngresos;

        // Constructor: recibe el total de ingresos calculado desde frmReportes
        public CorteDia(decimal totalIngresos) => _totalIngresos = totalIngresos;

        // Método Cerrar: genera el resumen del día al presionar el botón en frmReportes
        public void Cerrar()
        {
            File.AppendAllText("CorteDia.txt",
                $"=== CORTE DEL DÍA ===\nFecha: {DateTime.Today:dd/MM/yyyy}\nTotal ingresos: RD${_totalIngresos:F2}\n\n");
        }

        // Destructor: registra el resumen del día y libera el recurso asociado
        // al archivo de texto una vez finalizada la escritura.
        ~CorteDia()
        { 
            File.AppendAllText("CorteDia.txt",
                 $"=== CORTE DEL DÍA ===\n" +
                 $"Fecha: {DateTime.Today:dd/MM/yyyy}\n" +
                 $"Total ingresos: RD${_totalIngresos:F2}");
        }
    }
}