using System;
using System.Collections.Generic;

namespace SistemaAgenda.Datos
{
    public abstract class Servicios
    {
        public int Id { get; set; }
        public string Tipo_DeServicio { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int DuracionMinutos { get; set; }

        

        public abstract decimal CalcularPrecio();
        public abstract int CalcularDuracion();
    }
    public class ServicioCabello : Servicios
    {
        public override decimal CalcularPrecio()
        {
            return Precio;
        }

        public override int CalcularDuracion()
        {
            return DuracionMinutos;
        }
    }
    public class ServicioUñas : Servicios
    {
        public override decimal CalcularPrecio()
        {
            return Precio;
        }

        public override int CalcularDuracion()
        {
            return DuracionMinutos;
        }
    }
    public class ServicioSpa : Servicios
    {
        public override decimal CalcularPrecio()
        {
            return Precio;
        }

        public override int CalcularDuracion()
        {
            return DuracionMinutos;
        }
    }


}
