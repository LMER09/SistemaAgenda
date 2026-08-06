using SistemaAgenda.Datos;

namespace SistemaAgenda.Negocios
{
    public class ServiciosBLL
    {
        private readonly IServiciosDAL _dal;
        public ServiciosBLL() : this(new ServiciosDAL()) { }
        public ServiciosBLL(IServiciosDAL dal)
        {
            _dal = dal;
        }
        public async Task<string> RegistrarAsync(Servicios s)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(s.Tipo_DeServicio))
                    return "ERROR: El tipo de servicio es obligatorio.";

                if (s.Precio <= 0)
                    return "ERROR: El precio debe ser mayor a 0.";

                if (s.DuracionMinutos <= 0)
                    return "ERROR: La duración debe ser mayor a 0 minutos.";

                if (string.IsNullOrWhiteSpace(s.Subtipo_DeServicio))
                    return "ERROR: El subtipo de servicio es obligatorio.";

                bool ok = await _dal.InsertarAsync(s);
                return ok
                    ? "OK: Servicio registrado exitosamente."
                    : "ERROR: No se pudo guardar en la base de datos.";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
        public async Task<List<Servicios>> ObtenerTodosAsync()
        {
            try
            {
                return await _dal.ObtenerTodosAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener servicios: " + ex.Message);
            }
        }
        public async Task<string> ActualizarAsync(Servicios s)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(s.Tipo_DeServicio))
                    return "ERROR: El tipo de servicio es obligatorio.";

                if (s.Precio <= 0)
                    return "ERROR: El precio debe ser mayor a 0.";

                if (s.DuracionMinutos <= 0)
                    return "ERROR: La duración debe ser mayor a 0 minutos.";

                if (string.IsNullOrWhiteSpace(s.Subtipo_DeServicio))
                    return "ERROR: El subtipo de servicio es obligatorio.";

                bool ok = await _dal.ActualizarAsync(s);
                return ok
                    ? "OK: Servicio actualizado exitosamente."
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