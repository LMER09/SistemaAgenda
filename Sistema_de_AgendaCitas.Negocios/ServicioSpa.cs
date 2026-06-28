using System;
using SistemaAgenda.Datos;

namespace SistemaAgenda.Negocios
{
    public class ServicioSpa : ServicioBase
    {

        public ServicioSpa() { }    
        public ServicioSpa(Servicios s): base(s) { }

        public override decimal CalcularPrecio()=> _servicio.Precio * 1.15m;
        public override int CalcularDuracion()=> _servicio.DuracionMinutos < 60 ? 60 : _servicio.DuracionMinutos;
        public override string ObtenerTipo() => "Spa";

    }
}
