using SistemaAgenda.Datos;
using System;
using System.Linq;
using System.Collections.Generic;

namespace SistemaAgenda.Negocios
{
    public class CitasBLL
    {
        //Esto se hace para poder utilizar lista metodo de la capa datos
        private readonly CitasDAL _dal = new CitasDAL();
        private readonly HorarioEstilistaBLL _horarioBLL = new HorarioEstilistaBLL();
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

        //TODO Métodos normales requeridos por el proyecto: agendarCita(), cancelarCita(), reprogramarCita()

        // TODO VALIDAR DISPONIBILIDAD DEL ESTILISTA ─────────────────────
        // Trae las citas de ese estilista en esa fecha/hora (del DAL) y
        // decide aquí qué estados cuentan como "ocupado".
        private bool EstilistaDisponible(int idEstilista, DateTime fecha)
        {
            var citasEnEseHorario = _dal.ObtenerPorEstilistaYFecha(idEstilista, fecha);

            for (int i = 0; i < citasEnEseHorario.Count; i++)
            {
                Citas cita = citasEnEseHorario[i];
                if (cita.Estado != "Cancelada" && cita.Estado != "Completada")
                    return false; //hay una cita activa que choca con ese horario
            }

            return true;
        }

        // TODO VALIDAR HORARIO LABORAL ──────────────────────────────────
        // Revisa que la fecha/hora de la cita caiga dentro de algún bloque
        // de horario registrado para esa estilista (tabla HorarioEstilista)
        private string? ValidarHorarioLaboral(int idEstilista, DateTime fecha)
        {
            var horarios = _horarioBLL.ObtenerPorEstilista(idEstilista);

            if (horarios.Count == 0)
                return "ERROR: La estilista no tiene un horario laboral registrado.";

            byte diaSemana = (byte)fecha.DayOfWeek; //0=domingo...6=sábado, igual que DiaSemana
            TimeSpan horaCita = fecha.TimeOfDay;

            bool dentroDeHorario = false;
            for (int i = 0; i < horarios.Count; i++)
            {
                HorarioEstilista h = horarios[i];
                if (h.DiaSemana == diaSemana && horaCita >= h.HoraInicio && horaCita < h.HoraFin)
                {
                    dentroDeHorario = true;
                    break;
                }
            }

            if (!dentroDeHorario)
                return "ERROR: La estilista no trabaja en ese día u horario.";

            return null;
        }

        // ── AGENDAR CITA ─────────────────────────────────────────────
        public string AgendarCita(Citas c)
        {
            try
            {
                if (c.Id_Clientes <= 0)
                    return "ERROR: Debe seleccionar un cliente.";

                if (c.Id_Servicios <= 0)
                    return "ERROR: Debe seleccionar un servicio.";

                if (c.Id_Estilista <= 0)
                    return "ERROR: Debe seleccionar una estilista.";

                if (c.Fecha < DateTime.Now)
                    return "ERROR: La fecha no puede ser en el pasado.";

                //TODO Verificar disponibilidad del estilista
                if (!EstilistaDisponible(c.Id_Estilista, c.Fecha))
                    return "ERROR: El estilista ya tiene una cita asignada para esa fecha y hora.";

                //TODO Verificar que la fecha/hora caiga dentro del horario laboral de la estilista
                string? errorHorario = ValidarHorarioLaboral(c.Id_Estilista, c.Fecha);
                if (errorHorario != null)
                    return errorHorario;

                c.Estado = "Pendiente";

                bool ok = _dal.Insertar(c);

                return ok
                    ? "OK: Cita agendada exitosamente."
                    : "ERROR: No se pudo agendar la cita.";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
        // ── CANCELAR CITA ─────────────────────────────────────────────
        public string CancelarCita(int id)
        {
            try
            {

                var lista = _dal.ObtenerTodos();
                Citas cita = null;

                for (int i = 0; i < lista.Count; i++)
                {
                    if (lista[i].Id == id)
                    {
                        cita = lista[i];
                        break;
                    }
                }

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
                Citas cita = null;

                for (int i = 0; i < lista.Count; i++)
                {
                    if (lista[i].Id == id)
                    {
                        cita = lista[i];
                        break;
                    }
                }

                if (cita == null)
                    return "ERROR: Cita no encontrada.";
                if (cita.Estado == "Completada")
                    return "ERROR: No se puede reprogramar una cita que ya fue completada.";
                if (cita.Estado == "Cancelada")
                    return "ERROR: No se puede reprogramar una cita cancelada.";

                // Verificar que la nueva fecha/hora caiga dentro del horario laboral de la estilista
                string? errorHorario = ValidarHorarioLaboral(cita.Id_Estilista, nuevaFecha);
                if (errorHorario != null)
                    return errorHorario;

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