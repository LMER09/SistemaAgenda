using SistemaAgenda.Datos;
using System;
using System.Linq;
using System.Collections.Generic;

namespace SistemaAgenda.Negocios
{
    public class CitasBLL
    {
        private readonly ICitasDAL _dal;
        private readonly HorarioEstilistaBLL _horarioBLL;

        public CitasBLL()
            : this(new CitasDAL())
        {
        }

        public CitasBLL(ICitasDAL dal)
        {
            _dal = dal;
            _horarioBLL = new HorarioEstilistaBLL();
        }
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
        private bool EstilistaDisponible(int idEstilista, DateTime fecha)
        {
            var citasEnEseHorario = _dal.ObtenerPorEstilistaYFecha(idEstilista, fecha);

            for (int i = 0; i < citasEnEseHorario.Count; i++)
            {
                Citas cita = citasEnEseHorario[i];
                if (cita.Estado != "Cancelada" && cita.Estado != "Completada")
                    return false;
            }

            return true;
        }

        // TODO VALIDAR HORARIO LABORAL ──────────────────────────────────
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
        public List<CitaVista> ObtenerVista()
        {
            var citas = ObtenerTodos();
            var clientesBLL = new ClientesBLL();
            var serviciosBLL = new ServiciosBLL();
            var estilistaBLL = new EstilistaBLL();

            var clientes = clientesBLL.ObtenerTodos();
            var servicios = serviciosBLL.ObtenerTodos();
            var estilistas = estilistaBLL.ObtenerTodos();

            return citas.Select(c =>
            {
                var cliente = clientes.FirstOrDefault(cl => cl.Id == c.Id_Clientes);
                var servicio = servicios.FirstOrDefault(s => s.Id == c.Id_Servicios);
                var estilista = estilistas.FirstOrDefault(es => es.Id == c.Id_Estilista);

                return new CitaVista
                {
                    CitaOriginal = c,
                    Cliente = cliente != null ? $"{cliente.Nombre} {cliente.Apellido}" : "Cliente desconocido",
                    Servicio = servicio != null ? $"{servicio.Tipo_DeServicio} - {servicio.Subtipo_DeServicio}" : "Servicio desconocido",
                    Estilista = estilista != null ? $"{estilista.Nombre} {estilista.Apellido}" : "Estilista desconocida"
                };
            }).OrderBy(cv => cv.Fecha).ToList();
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

                if (!EstilistaDisponible(cita.Id_Estilista, nuevaFecha))
                    return "ERROR: El estilista ya tiene una cita asignada para esa fecha y hora.";

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

        public string EditarCita(Citas citaEditada)
        {
            try
            {
                if (citaEditada.Id_Clientes <= 0)
                    return "ERROR: Debe seleccionar un cliente.";

                if (citaEditada.Id_Servicios <= 0)
                    return "ERROR: Debe seleccionar un servicio.";

                if (citaEditada.Id_Estilista <= 0)
                    return "ERROR: Debe seleccionar una estilista.";

                if (citaEditada.Fecha < DateTime.Now)
                    return "ERROR: La fecha no puede ser en el pasado.";

                var lista = _dal.ObtenerTodos();
                Citas citaOriginal = lista.FirstOrDefault(c => c.Id == citaEditada.Id);

                if (citaOriginal == null)
                    return "ERROR: Cita no encontrada.";
                if (citaOriginal.Estado == "Completada")
                    return "ERROR: No se puede editar una cita que ya fue completada.";
                if (citaOriginal.Estado == "Cancelada")
                    return "ERROR: No se puede editar una cita cancelada.";

                var citasEnEseHorario = _dal.ObtenerPorEstilistaYFecha(citaEditada.Id_Estilista, citaEditada.Fecha);
                bool ocupado = citasEnEseHorario.Any(c =>
                    c.Id != citaEditada.Id &&
                    c.Estado != "Cancelada" &&
                    c.Estado != "Completada");

                if (ocupado)
                    return "ERROR: El estilista ya tiene una cita asignada para esa fecha y hora.";

                string? errorHorario = ValidarHorarioLaboral(citaEditada.Id_Estilista, citaEditada.Fecha);
                if (errorHorario != null)
                    return errorHorario;

                citaOriginal.Id_Clientes = citaEditada.Id_Clientes;
                citaOriginal.Id_Servicios = citaEditada.Id_Servicios;
                citaOriginal.Id_Estilista = citaEditada.Id_Estilista;
                citaOriginal.Fecha = citaEditada.Fecha;
                citaOriginal.Estado = "Reprogramada";

                bool ok = _dal.Actualizar(citaOriginal);
                return ok
                    ? "OK: Cita actualizada exitosamente."
                    : "ERROR: No se pudo actualizar la cita.";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }

    }
}