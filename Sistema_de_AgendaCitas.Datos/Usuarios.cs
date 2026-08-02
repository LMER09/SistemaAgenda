using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAgenda.Datos
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string Usuario { get; set; } = string.Empty;
        public string Contrasena { get; set; } = string.Empty;

        public Usuarios() { }
        public Usuarios(int Id, string Usuario, string Contrasena)
        {
            this.Id = Id;
            this.Usuario = Usuario;
            this.Contrasena = Contrasena;
        }
    }
}
