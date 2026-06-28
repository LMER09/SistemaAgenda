using System;
using System.Collections.Generic;

namespace SistemaAgenda.Datos
{
    public class Servicios
    {
        public int Id { get; set; }
        public string Tipo_DeServicio { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int DuracionMinutos { get; set; }

        public Servicios() { }

        public Servicios(int id, string tipo, decimal precio, int duracion)
        {

            Id= id;
            Tipo_DeServicio = tipo;
            Precio = precio;
            DuracionMinutos = duracion;
        } 
    }
    
}
