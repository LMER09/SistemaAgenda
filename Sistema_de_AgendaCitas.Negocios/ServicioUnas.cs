using System;
using SistemaAgenda.Datos;

namespace SistemaAgenda.Negocios
{
    public class ServicioUnas: ServicioBase
    {
        public ServicioUnas() { }
        public ServicioUnas(Servicios s): base(s) {}
        
        public override decimal CalcularPrecio() => _servicio.Precio;
        public override int CalcularDuracion() => _servicio.DuracionMinutos < 45 ? 45 : _servicio.DuracionMinutos;

        public override string ObtenerTipo() => "Uñas";

    }
}
