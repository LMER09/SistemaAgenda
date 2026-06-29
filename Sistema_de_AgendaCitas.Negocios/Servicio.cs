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
    public class ServicioCabello : ServicioBase
    {
        public ServicioCabello() { }
        public ServicioCabello(Servicios s) : base(s) { }
        public override decimal CalcularPrecio() => _servicio.Precio * 1.10m;
        public override int CalcularDuracion() => _servicio.DuracionMinutos;
        public override string ObtenerTipo() => "Cabello";
    }
    public class ServicioSpa : ServicioBase
    {

        public ServicioSpa() { }
        public ServicioSpa(Servicios s) : base(s) { }

        public override decimal CalcularPrecio() => _servicio.Precio * 1.15m;
        public override int CalcularDuracion() => _servicio.DuracionMinutos < 60 ? 60 : _servicio.DuracionMinutos;
        public override string ObtenerTipo() => "Spa";

    }
    public class ServicioUnas : ServicioBase
    {
        public ServicioUnas() { }
        public ServicioUnas(Servicios s) : base(s) { }

        public override decimal CalcularPrecio() => _servicio.Precio;
        public override int CalcularDuracion() => _servicio.DuracionMinutos < 45 ? 45 : _servicio.DuracionMinutos;

        public override string ObtenerTipo() => "Uñas";

    }

}