using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAgenda.Datos
{
    public class Pagos
    {
        public int Id { get; set; }
        public int Id_Citas { get; set; }
        public decimal Monto { get; set; }
        public string Metodo_DePago { get; set; }=string.Empty;
        public DateTime FechaPago {  get; set; }

    }
}
