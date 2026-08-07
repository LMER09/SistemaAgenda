using SistemaAgenda.Datos;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaAgenda.Negocios
{
    public class CitasBLL
    {
        private readonly ICitasDAL _dal;
        private readonly HorarioEstilistaBLL _horarioBLL;
        private readonly ServiciosBLL _serviciosBLL;
        public CitasBLL() : this(new CitasDAL()) { }

        // TODO CITASBLL Constructor: guarda el DAL y crea las BLL que necesita para validar cita
        public CitasBLL(ICitasDAL dal)
        {
            _dal = dal;
            _horarioBLL = new HorarioEstilistaBLL();
            _serviciosBLL = new ServiciosBLL();
        }
        public async Task<List<Citas>> ObtenerTodosAsync()
        {
            try
            {
                return await _dal.ObtenerTodosAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener citas: " + ex.Message);
            }
        }

        // TODO AGENDAR CITA ─────────────────────────────────────────────
        public async Task<string> AgendarCitaAsync(Citas c)
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
                int duracion = await ObtenerDuracionServicioAsync(c.Id_Servicios);

                DateTime? horaLibre = await EstilistaDisponibleAsync(c.Id_Estilista, c.Fecha, duracion);
                if (horaLibre != null)
                    return $"ERROR: El estilista ya tiene una cita en ese horario. Está disponible nuevamente a partir de las {horaLibre:hh:mm tt}.";

                string? errorHorario = await ValidarHorarioLaboralAsync(c.Id_Estilista, c.Fecha);
                if (errorHorario != null)
                    return errorHorario;

                c.Estado = "Pendiente";

                bool ok = await _dal.InsertarAsync(c);

                return ok
                    ? "OK: Cita agendada exitosamente."
                    : "ERROR: No se pudo agendar la cita.";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
        // TODO CANCELAR CITA ─────────────────────────────────────────────
        public async Task<string> CancelarCitaAsync(int id)
        {
            try
            {
                var lista = await _dal.ObtenerTodosAsync();
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

                bool ok = await _dal.ActualizarAsync(cita);
                return ok
                    ? "OK: Cita cancelada exitosamente."
                    : "ERROR: No se pudo cancelar la cita.";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
        // TODO REPROGRAMAR CITA ──────────────────────────────────────────
        public async Task<string> ReprogramarCitaAsync(int id, DateTime nuevaFecha)
        {
            try
            {
                if (nuevaFecha < DateTime.Now)
                    return "ERROR: La nueva fecha no puede ser en el pasado.";

                var lista = await _dal.ObtenerTodosAsync();
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

                int duracion = await ObtenerDuracionServicioAsync(cita.Id_Servicios);

                DateTime? horaLibre = await EstilistaDisponibleAsync(cita.Id_Estilista, nuevaFecha, duracion, id);
                if (horaLibre != null)
                    return $"ERROR: El estilista ya tiene una cita en ese horario. Está disponible nuevamente a partir de las {horaLibre:hh:mm tt}.";

                string? errorHorario = await ValidarHorarioLaboralAsync(cita.Id_Estilista, nuevaFecha);
                if (errorHorario != null)
                    return errorHorario;

                cita.Fecha = nuevaFecha;
                cita.Estado = "Reprogramada";

                bool ok = await _dal.ActualizarAsync(cita);
                return ok
                    ? "OK: Cita reprogramada exitosamente."
                    : "ERROR: No se pudo reprogramar la cita.";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }

        // TODO METODO NUEVO: ObtenerDuracionServicioAsync
        // Busca el servicio y devuelve su duración ya ajustada según el tipo/subtipo
        private async Task<int> ObtenerDuracionServicioAsync(int idServicios)
        {
            var servicios = await _serviciosBLL.ObtenerTodosAsync();
            var servicio = servicios.FirstOrDefault(s => s.Id == idServicios);

            if (servicio == null)
                return 60;

            return new Gestion_DeServicios(servicio).CalcularDuracion();
        }
        // TODO METODO NUEVO: EstilistaDisponibleAsync
        // Revisa si la estilista está libre en ese horario.
        // Devuelve null si está disponible o la hora en que se desocupa.
        private async Task<DateTime?> EstilistaDisponibleAsync(int idEstilista, DateTime fecha, int duracionMinutos, int idCitaAExcluir = 0)
        {
            var todasLasCitas = await _dal.ObtenerTodosAsync();

            DateTime inicioNueva = fecha;
            DateTime finNueva = fecha.AddMinutes(duracionMinutos);

            for (int i = 0; i < todasLasCitas.Count; i++)
            {
                Citas existente = todasLasCitas[i];

                if (existente.Id == idCitaAExcluir)
                    continue;
                if (existente.Id_Estilista != idEstilista)
                    continue;
                if (existente.Estado == "Cancelada" || existente.Estado == "Completada")
                    continue;

                int duracionExistente = await ObtenerDuracionServicioAsync(existente.Id_Servicios);
                DateTime finExistente = existente.Fecha.AddMinutes(duracionExistente);

                bool seSolapan = inicioNueva < finExistente && existente.Fecha < finNueva;

                if (seSolapan)
                    return finExistente;
            }

            return null;
        }
        // TODO METODO NUEVO: ValidarHorarioLaboralAsync
        // Revisa que el día y la hora de la cita caigan dentro de algun horario registrado de una estilista.
        // Devuelve null si está dentro del horario o un mensaje de error si no.
        private async Task<string?> ValidarHorarioLaboralAsync(int idEstilista, DateTime fecha)
        {
            var horarios = await _horarioBLL.ObtenerPorEstilistaAsync(idEstilista);

            if (horarios.Count == 0)
                return "ERROR: La estilista no tiene un horario laboral registrado.";

            byte diaSemana = (byte)fecha.DayOfWeek;
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
        // TODO METODO NUEVO: ObtenerVistaAsync
        // Arma la lista de citas para mostrar en pantalla, cambiando los
        // IDs de cliente,servicio Y estilista por sus nombres reales.
        public async Task<List<CitaVista>> ObtenerVistaAsync()
        {
            var citas = await ObtenerTodosAsync();
            var clientesBLL = new ClientesBLL();
            var serviciosBLL = new ServiciosBLL();
            var estilistaBLL = new EstilistaBLL();

            var clientes = await clientesBLL.ObtenerTodosAsync();
            var servicios = await serviciosBLL.ObtenerTodosAsync();
            var estilistas = await estilistaBLL.ObtenerTodosAsync();

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
    }
}