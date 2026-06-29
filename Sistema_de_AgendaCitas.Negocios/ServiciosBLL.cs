using SistemaAgenda.Datos;

namespace SistemaAgenda.Negocios
{
    public class ServiciosBLL
    {
        private readonly ServiciosDAL _dal = new ServiciosDAL();

        public string Registrar(Servicios s)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(s.Tipo_DeServicio))
                    return "ERROR: El tipo de servicio es obligatorio.";

                if (s.Precio <= 0)
                    return "ERROR: El precio debe ser mayor a 0.";

                if (s.DuracionMinutos <= 0)
                    return "ERROR: La duración debe ser mayor a 0 minutos.";

                bool ok = _dal.Insertar(s);
                return ok
                    ? "OK: Servicio registrado exitosamente."
                    : "ERROR: No se pudo guardar en la base de datos.";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }

        public List<Servicios> ObtenerTodos()
        {
            try
            {
                return _dal.ObtenerTodos();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener servicios: " + ex.Message);
            }
        }

        public string Actualizar(Servicios s)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(s.Tipo_DeServicio))
                    return "ERROR: El tipo de servicio es obligatorio.";

                if (s.Precio <= 0)
                    return "ERROR: El precio debe ser mayor a 0.";

                if (s.DuracionMinutos <= 0)
                    return "ERROR: La duración debe ser mayor a 0 minutos.";

                bool ok = _dal.Actualizar(s);
                return ok
                    ? "OK: Servicio actualizado exitosamente."
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
                    ? "OK: Servicio eliminado exitosamente."
                    : "ERROR: No se pudo eliminar.";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
    }
}