using System;
using SistemaAgenda.Datos;


namespace SistemaAgenda.Negocios
{
    
    // TODO Clase abstracta que representa un servicio del salon
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

        // ─TODO MÉTODOS ABSTRACTOS ────────────────────────────────────────
        public abstract decimal ServicioCabello();
        public abstract decimal ServicioUnas();
        public abstract decimal ServicioSpa();

        // TODO MÉTODOS VIRTUALES ─────────────────────────────────────────
        //Tienen implementación base pero pueden sobreescribirse
        public virtual decimal CalcularPrecio()=> _servicio.Precio;
        public virtual int CalcularDuracion() => _servicio.DuracionMinutos;
        
    }

    //TODO Clase nueva creada para implementar los metodos abstractos y la sobreescritura en los metodos virtuales.
    public class Gestion_DeServicios : Servicio
    {
        public Gestion_DeServicios() { }
        public Gestion_DeServicios(Servicios s) : base(s) { }

        //TODO Implementación de los métodos abstractos
        //TODO Cada subtipo dentro del tipo tiene su propio multiplicador sobre el precio base,

        public override decimal ServicioCabello()
        {
            switch (_servicio.Subtipo_DeServicio)
            {
                case "Corte": return _servicio.Precio * 1.00m;
                case "Tinte": return _servicio.Precio * 1.30m;
                case "Completo": return _servicio.Precio * 1.50m;
                default: return _servicio.Precio * 1.10m; // valor anterior, por si el subtipo viniera vacío
            }
        }
        public override decimal ServicioUnas()
        {
            switch (_servicio.Subtipo_DeServicio)
            {
                case "Manicura": return _servicio.Precio * 1.00m;
                case "Pedicura": return _servicio.Precio * 1.10m;
                case "Completo": return _servicio.Precio * 1.80m;
                default: return _servicio.Precio;
            }
        }
        public override decimal ServicioSpa()
        {
            switch (_servicio.Subtipo_DeServicio)
            {
                case "Sencillo": return _servicio.Precio * 1.00m;
                case "Premium": return _servicio.Precio * 1.30m;
                case "Profesional": return _servicio.Precio * 1.50m;
                default: return _servicio.Precio * 1.15m; // valor anterior, por si el subtipo viniera vacío
            }
        }

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