using System;

namespace SistemaAgenda.Datos
{
    public class Servicios
    {
        public int Id {  get; set; } 
        public string Tipo_DeServicio { get; set; } = string.Empty;
        public string Subtipo_DeServicio { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int DuracionMinutos { get; set; }
        public Servicios() { }
        public Servicios(int Id, string Tipo_DeServicio, string Subtipo_DeServicio, decimal Precio, int DuracionMinutos)
        {
            this.Id = Id;
            this.Tipo_DeServicio= Tipo_DeServicio;
            this.Subtipo_DeServicio = Subtipo_DeServicio;
            this.Precio = Precio;
            this.DuracionMinutos= DuracionMinutos;
        }
 
    }
    
}
