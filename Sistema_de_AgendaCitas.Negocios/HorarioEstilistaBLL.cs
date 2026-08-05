using SistemaAgenda.Datos;

namespace SistemaAgenda.Negocios
{
    public class HorarioEstilistaBLL
    {
        private readonly IHorarioEstilistaDAL _dal;

        public HorarioEstilistaBLL() : this(new HorarioEstilistaDAL()) { }

        public HorarioEstilistaBLL(IHorarioEstilistaDAL dal)
        {
            _dal = dal;
        }

        public string Registrar(HorarioEstilista h)
        {
            try
            {
                if (h.IdEstilista <= 0)
                    return "ERROR: Debe seleccionar una estilista.";

                if (h.DiaSemana > 6)
                    return "ERROR: El día de la semana debe estar entre 0 y 6.";

                if (h.HoraInicio >= h.HoraFin)
                    return "ERROR: La hora de inicio debe ser antes que la hora fin.";

                bool ok = _dal.Insertar(h);
                return ok
                    ? "OK: Horario registrado exitosamente."
                    : "ERROR: No se pudo guardar en la base de datos.";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
        public string GuardarHorarioCompleto(int idEstilista, List<HorarioEstilista> nuevoHorario)
        {
            try
            {
                _dal.EliminarPorEstilista(idEstilista);

                foreach (var h in nuevoHorario)
                {
                    h.IdEstilista = idEstilista;
                    bool ok = _dal.Insertar(h);
                    if (!ok)
                        return "ERROR: No se pudo guardar uno de los horarios.";
                }

                return "OK: Horario guardado exitosamente.";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
        public List<HorarioEstilista> ObtenerTodos()
        {
            try
            {
                return _dal.ObtenerTodos();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener horarios: " + ex.Message);
            }
        }

        public List<HorarioEstilista> ObtenerPorEstilista(int idEstilista)
        {
            try
            {
                return _dal.ObtenerPorEstilista(idEstilista);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener horario de la estilista: " + ex.Message);
            }
        }

        public string Actualizar(HorarioEstilista h)
        {
            try
            {
                if (h.IdEstilista <= 0)
                    return "ERROR: Debe seleccionar una estilista.";

                if (h.DiaSemana > 6)
                    return "ERROR: El día de la semana debe estar entre 0 y 6.";

                if (h.HoraInicio >= h.HoraFin)
                    return "ERROR: La hora de inicio debe ser antes que la hora fin.";

                bool ok = _dal.Actualizar(h);
                return ok
                    ? "OK: Horario actualizado exitosamente."
                    : "ERROR: No se pudo actualizar en la base de datos.";
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
