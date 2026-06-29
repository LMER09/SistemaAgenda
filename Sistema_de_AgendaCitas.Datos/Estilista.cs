using System;
using System.Collections.Generic;


namespace SistemaAgenda.Datos
{
    public class Estilista
    {
        public int Id { get; set; }
        public string Nombre { get; set; }=  string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string Especialidad { get; set;} = string.Empty;

        public Estilista() { }
        public Estilista(int Id, string Nombre, string Apellido, string Telefono, string Correo, string Especialidad)
        {
            this.Id = Id;
            this.Nombre = Nombre;
            this.Apellido = Apellido;
            this.Telefono = Telefono;
            this.Correo = Correo;
            this.Especialidad = Especialidad;
        }

    }
}
