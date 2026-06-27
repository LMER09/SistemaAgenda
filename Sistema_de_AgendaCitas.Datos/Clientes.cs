using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAgenda.Datos
{
    public  class Clientes
    {

        public int Id { get; set; }
        public string Nombre { get; set; }= string.Empty;
        public string Apellido {  get; set; }= string.Empty;
        public string Telefono {  get; set; }= string.Empty;
        public string Correo {  get; set; }= string.Empty;

    }
}
