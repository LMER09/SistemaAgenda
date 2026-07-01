using SistemaAgenda.Datos;
using System;
using System.Linq;
using System.Collections.Generic;

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

        // ── AGENDAR CITA ─────────────────────────────────────────────
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

        // ── CANCELAR CITA ─────────────────────────────────────────────
        public string CancelarCita(int id)
        {
            try
            {

                var lista = _dal.ObtenerTodos();
                var cita = lista.FirstOrDefault(c => c.Id == id);

                if (cita == null)
                    return "ERROR: Cita no encontrada.";
                if (cita.Estado == "Completada")
                    return "ERROR: No se puede cancelar una cita que ya fue completada.";
                if (cita.Estado == "Cancelada")
                    return "ERROR: La cita ya está cancelada.";

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
        // ── REPROGRAMAR CITA ──────────────────────────────────────────
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
                if (cita.Estado == "Completada")
                    return "ERROR: No se puede reprogramar una cita que ya fue completada.";
                if (cita.Estado == "Cancelada")
                    return "ERROR: No se puede reprogramar una cita cancelada.";
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

}