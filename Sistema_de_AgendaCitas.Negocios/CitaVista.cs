using System;
using SistemaAgenda.Datos;

namespace SistemaAgenda.Negocios
{
    // TODO CLASE NUEVA: CitaVista
    // Solo para mostrarse en pantalla. Guarda tambien la citas original,
    // para poder cancelarla o reprogramarla sin tener que volver a buscarla.
    public class CitaVista
    {
        // La cita real tal como está en la base de datos
        public Citas CitaOriginal { get; set; } = null!;

        // Atajos que leen el valor directo de CitaOriginal
        public int Id => CitaOriginal.Id;
        public DateTime Fecha => CitaOriginal.Fecha;
        public string Estado => CitaOriginal.Estado;
        public decimal Deposito => CitaOriginal.Deposito;

        // Nombre completo del cliente, del servicio y nombre de la estilista
        public string Cliente { get; set; } = string.Empty;
        public string Servicio { get; set; } = string.Empty;
        public string Estilista { get; set; } = string.Empty;
       
    }
}
