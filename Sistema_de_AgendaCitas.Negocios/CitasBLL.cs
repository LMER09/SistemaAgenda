using SistemaAgenda.Datos;
namespace SistemaAgenda.Negocios
{
    public class CitasBLL
    {
        private readonly CitasDAL _dal = new CitasDAL();
        public List<Citas> ObtenerTodos()
        {

            try
            {
                return _dal.ObtenerTodos();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener citas: " + ex.Message);
            }
        }

        //Métodos normales: agendarCita(), cancelarCita(), reprogramarCita()
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
        public string Eliminar(int id)
        {
            try
            {
                bool ok = _dal.Eliminar(id);
                return ok
                    ? "OK: Cita eliminada exitosamente."
                    : "ERROR: No se pudo eliminar.";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }

    }

}