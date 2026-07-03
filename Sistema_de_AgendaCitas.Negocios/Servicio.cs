using System;
using SistemaAgenda.Datos;


namespace SistemaAgenda.Negocios
{
    
    // Clase abstracta qque representa un servicio del salon
    public abstract class Servicio
    {

        // Atributo protegido que almacena los datos del servicio desde la base de datos
        protected Servicios _servicio;

        public Servicio()
        {
            _servicio = new Servicios();
        }

        // Constructor parametrizado: recibe un servicio de la BD
        public Servicio(Servicios servicio)
        {
            _servicio = servicio;
        }

        // ── MÉTODOS ABSTRACTOS ────────────────────────────────────────
        public abstract decimal ServicioCabello();
        public abstract decimal ServicioUnas();
        public abstract decimal ServicioSpa();

        // ── MÉTODOS VIRTUALES ─────────────────────────────────────────
        //Tienen implementación base pero pueden sobreescribirse
        public virtual decimal CalcularPrecio()=> _servicio.Precio;
        public virtual int CalcularDuracion() => _servicio.DuracionMinutos;
        
    }

    //Clase nueva creada para implementar los metodos abstractos y la sobreescritura en los metodos virtuales.
    public class Gestion_DeServicios : Servicio
    {
        public Gestion_DeServicios() { }
        public Gestion_DeServicios(Servicios s) : base(s) { }

        // Implementación de los métodos abstractos
        public override decimal ServicioCabello() => _servicio.Precio * 1.10m;
        public override decimal ServicioUnas() => _servicio.Precio;
        public override decimal ServicioSpa()=> _servicio.Precio * 1.15m;

        // Sobreescritura: calcula precio final según tipo de servicio
        public override decimal CalcularPrecio()
        {
            switch (_servicio.Tipo_DeServicio)
            {
                case "Cabello": return ServicioCabello();

                case "Uñas": return ServicioUnas();

                case "Spa": return ServicioSpa();

                default: return _servicio.Precio;
            }
        }

        // Sobreescritura: añade tiempo extra según el tipo de servicio
        public override int CalcularDuracion()
        {
            switch (_servicio.Tipo_DeServicio)
            {
                case "Cabello": return _servicio.DuracionMinutos + 10;

                case "Uñas": return _servicio.DuracionMinutos + 20;

                case "Spa":return _servicio.DuracionMinutos + 30;

                default: return _servicio.DuracionMinutos;
            }
        }

    }

}