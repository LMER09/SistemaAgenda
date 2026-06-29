using SistemaAgenda.Datos;

namespace SistemaAgenda.Negocios
{
    public class CitaNegocio
    {
        public Citas Cita {  get; set; }
        public decimal Deposito {  get; set; }

        public CitaNegocio()
        {
            Cita = new Citas();
            Deposito = 500;
            Cita.Estado = "Pendiente";
        }

        public CitaNegocio(Clientes c, Servicios s, DateTime hora)
        {
            Cita = new Citas();
            Cita.Id_Clientes = c.Id;
            Cita.Id_Servicios = s.Id;
            Cita.Fecha = hora;
            Cita.Estado = "Pendiente";
            Deposito = 0;

        }

    }
}
