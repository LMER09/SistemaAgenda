using SistemaAgenda.Datos;

namespace SistemaAgenda.Negocios
{
    public class EstilistaBLL
    {
        private readonly IEstilistaDAL _dal;

        public EstilistaBLL() : this(new EstilistaDAL()) { }

        public EstilistaBLL(IEstilistaDAL dal)
        {
            _dal = dal;
        }

        public async Task<string> RegistrarAsync(Estilista e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(e.Nombre) ||
                    string.IsNullOrWhiteSpace(e.Apellido) ||
                    string.IsNullOrWhiteSpace(e.Telefono) ||
                    string.IsNullOrWhiteSpace(e.Correo) ||
                    string.IsNullOrWhiteSpace(e.Especialidad))
                    return "ERROR: Todos los campos son obligatorios, excepto la cedula.";

                if (!e.Correo.Contains("@"))
                    return "ERROR: El correo no es válido.";

                bool ok = await _dal.InsertarAsync(e);
                return ok
                    ? "OK: Estilista registrada exitosamente."
                    : "ERROR: No se pudo guardar en la base de datos.";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }

        public async Task<List<Estilista>> ObtenerTodosAsync()
        {
            try
            {
                return await _dal.ObtenerTodosAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener estilistas: " + ex.Message);
            }
        }

        public async Task<string> ActualizarAsync(Estilista e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(e.Nombre) ||
                    string.IsNullOrWhiteSpace(e.Apellido) ||
                    string.IsNullOrWhiteSpace(e.Telefono) ||
                    string.IsNullOrWhiteSpace(e.Correo) ||
                    string.IsNullOrWhiteSpace(e.Especialidad))
                    return "ERROR: Todos los campos son obligatorios, excepto la cedula.";

                bool ok = await _dal.ActualizarAsync(e);
                return ok
                    ? "OK: Estilista actualizada exitosamente."
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
                    ? "OK: Estilista eliminada exitosamente."
                    : "ERROR: No se pudo eliminar.";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
    }
}