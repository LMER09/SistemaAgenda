using System;
using SistemaAgenda.Datos;

namespace SistemaAgenda.Negocios
{
    // Solo para mostrarse en pantalla. Guarda tambien la Citas original,
    // para poder cancelarla o reprogramarla sin tener que volver a buscarla.
    public class CitaVista
    {
        public Citas CitaOriginal { get; set; } = null!;
        public int Id => CitaOriginal.Id;
        public string Cliente { get; set; } = string.Empty;
        public string Servicio { get; set; } = string.Empty;
        public string Estilista { get; set; } = string.Empty;
        public DateTime Fecha => CitaOriginal.Fecha;
        public string Estado => CitaOriginal.Estado;
        public decimal Deposito => CitaOriginal.Deposito;
    }
}
