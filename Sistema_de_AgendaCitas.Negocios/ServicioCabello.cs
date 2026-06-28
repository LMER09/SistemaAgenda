using System;
using SistemaAgenda.Datos;

namespace SistemaAgenda.Negocios
{
    public class ServicioCabello: ServicioBase
    {
        public ServicioCabello() { }
        public ServicioCabello(Servicios s): base(s){}
        public override decimal CalcularPrecio() => _servicio.Precio * 1.10m;
        public override int CalcularDuracion() => _servicio.DuracionMinutos;
        public override string ObtenerTipo() => "Cabello";
    }
}
