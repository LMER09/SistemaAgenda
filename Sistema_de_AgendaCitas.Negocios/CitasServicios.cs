using SistemaAgenda.Datos;
using System.Linq;
using System.IO;

namespace SistemaAgenda.Negocios
{
    public class CitaNegocio
    {
        public Citas Cita { get; set; }
        public decimal Deposito { get; set; }

        public CitaNegocio()
        {
            Cita = new Citas();
            Deposito = 250;
        }

        public CitaNegocio(Clientes c, Servicios s, DateTime hora)
        {
            Cita = new Citas(c, s, hora);
            Deposito =250 ;
        }
    }
    //Métodos normales: agendarCita(), cancelarCita(), reprogramarCita()
    public class CitasServicios
    {
        private readonly CitasDAL _dal = new CitasDAL();

        public string AgendarCita(Citas c)
        {
            try
            {
                if (c.Id_Clientes <= 0) { return "ERROR: Debe seleccionar un cliente."; }
                if (c.Id_Servicios <= 0) { return "ERROR: Debe seleccionar un servicio."; }
                if (c.Fecha < DateTime.Now) { return "ERROR: La fecha no puede ser en el pasado."; }
                c.Estado = "Pendiente";

                bool ok = _dal.Insertar(c);
                return ok ? "OK: Cita agendada exitosamente." : "ERROR: No se pudo agendar la cita.";

            }
            catch (Exception ex) { return "ERROR: " + ex.Message; }
        }
        public string CancelarCita(int id)
        {
            try
            {
                var lista = _dal.ObtenerTodos();
                var cita = lista.FirstOrDefault(c => c.Id == id);

                if (cita == null) return "ERROR: Cita no encontrada.";

                cita.Estado = "Cancelada";

                bool ok = _dal.Actualizar(cita);
                return ok
                    ? "OK: Cita cancelada exitosamente."
                    : "ERROR: No se pudo cancelar la cita.";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
        public string ReprogramarCita(int id, DateTime nuevaFecha)
        {
            try
            {
                if (nuevaFecha < DateTime.Now)
                    return "ERROR: La nueva fecha no puede ser en el pasado.";

                var lista = _dal.ObtenerTodos();
                var cita = lista.FirstOrDefault(c => c.Id == id);

                if (cita == null)
                    return "ERROR: Cita no encontrada.";

                cita.Fecha = nuevaFecha;
                cita.Estado = "Reprogramada";

                bool ok = _dal.Actualizar(cita);
                return ok
                    ? "OK: Cita reprogramada exitosamente."
                    : "ERROR: No se pudo reprogramar la cita.";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
    }

    //Destructor de CorteDia
    public class CorteDia
    {
        private decimal _totalIngresos;
        public CorteDia(decimal totalIngresos) => _totalIngresos = totalIngresos;
        ~CorteDia()
        {

            File.WriteAllText("CorteDia.txt",
                 $"=== CORTE DEL DÍA ===\n" +
                 $"Fecha: {DateTime.Today:dd/MM/yyyy}\n" +
                 $"Total ingresos: RD${_totalIngresos:F2}");
        }
    }
}
