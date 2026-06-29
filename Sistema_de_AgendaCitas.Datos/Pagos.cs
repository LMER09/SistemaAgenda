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

        public Pagos() {}

        public Pagos(int Id, int Id_Citas, decimal Monto, string Metodo_DePago, DateTime fechaPago)
        {
            this.Id= Id;
            this.Id_Citas = Id_Citas;
            this.Monto = Monto;
            this.Metodo_DePago = Metodo_DePago;
            this.FechaPago = fechaPago;
        }

    }
}
