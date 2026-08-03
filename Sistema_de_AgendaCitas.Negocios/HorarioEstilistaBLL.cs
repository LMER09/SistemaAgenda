using SistemaAgenda.Datos;

namespace SistemaAgenda.Negocios
{
    public class HorarioEstilistaBLL
    {
        private readonly IHorarioEstilistaDatos _dal;
        public HorarioEstilistaBLL() : this(new HorarioEstilistaDAL()) { }
        public HorarioEstilistaBLL(IHorarioEstilistaDatos dal) { _dal = dal; }

        public async Task<string> RegistrarAsync(HorarioEstilista h)
        {
            try
            {
                if (h.IdEstilista <= 0)
                    return "ERROR: Debe seleccionar una estilista.";

                if (h.DiaSemana > 6)
                    return "ERROR: El día de la semana debe estar entre 0 y 6.";

                if (h.HoraInicio >= h.HoraFin)
                    return "ERROR: La hora de inicio debe ser antes que la hora fin.";

                bool ok = await _dal.InsertarAsync(h);
                return ok
                    ? "OK: Horario registrado exitosamente."
                    : "ERROR: No se pudo guardar en la base de datos.";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }

        public async Task<List<HorarioEstilista>> ObtenerTodosAsync()
        {
            try
            {
                return await _dal.ObtenerTodosAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener horarios: " + ex.Message);
            }
        }

        public async Task<List<HorarioEstilista>> ObtenerPorEstilistaAsync(int idEstilista)
        {
            try
            {
                return await _dal.ObtenerPorEstilistaAsync(idEstilista);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener horario de la estilista: " + ex.Message);
            }
        }

        public async Task<string> ActualizarAsync(HorarioEstilista h)
        {
            try
            {
                if (h.IdEstilista <= 0)
                    return "ERROR: Debe seleccionar una estilista.";

                if (h.DiaSemana > 6)
                    return "ERROR: El día de la semana debe estar entre 0 y 6.";

                if (h.HoraInicio >= h.HoraFin)
                    return "ERROR: La hora de inicio debe ser antes que la hora fin.";

                bool ok = await _dal.ActualizarAsync(h);
                return ok
                    ? "OK: Horario actualizado exitosamente."
                    : "ERROR: No se pudo actualizar en la base de datos.";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }

        public async Task<string> EliminarAsync(int id)
        {
            try
            {
                bool ok = await _dal.EliminarAsync(id);
                return ok
                    ? "OK: Horario eliminado exitosamente."
                    : "ERROR: No se pudo eliminar.";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
    }
}