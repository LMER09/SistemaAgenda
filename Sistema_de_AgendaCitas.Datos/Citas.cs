using System;

namespace SistemaAgenda.Datos
{
    public class Citas
    {
        public int Id { get; set; }
        public int Id_Clientes { get; set; }
        public int Id_Servicios { get; set; }
        public int Id_Estilista { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; } = string.Empty;
        public decimal Deposito { get; set; }

        public Citas()
        {
            Deposito = 0;
        }
        public Citas(Clientes c, Servicios s, DateTime hora)
        {
            Id_Clientes = c.Id;
            Id_Servicios = s.Id;
            Fecha = hora;
            Estado = "Pendiente";
            Deposito = 0; // se asignará desde el formulario
        }

    }

}

