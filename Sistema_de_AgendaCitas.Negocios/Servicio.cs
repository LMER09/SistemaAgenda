using System;
using SistemaAgenda.Datos;


namespace SistemaAgenda.Negocios
{
    public abstract class ServicioBase
    {
        protected Servicios _servicio;

        public ServicioBase()
        {
            _servicio = new Servicios();
        }
        public ServicioBase(Servicios servicio)
        {
            _servicio = servicio;
        }
        public virtual decimal CalcularPrecio()=> _servicio.Precio;
        public virtual int CalcularDuracion() => _servicio.DuracionMinutos;
        public abstract string ObtenerTipo();
    }
}