using SistemaAgenda.Datos;

namespace SistemaAgenda.Negocios
{
    public class EstilistaBLL
    {
        private readonly EstilistaDAL _dal = new EstilistaDAL();

        public string Registrar(Estilista e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(e.Nombre) ||
                    string.IsNullOrWhiteSpace(e.Apellido) ||
                    string.IsNullOrWhiteSpace(e.Telefono) ||
                    string.IsNullOrWhiteSpace(e.Correo) ||
                    string.IsNullOrWhiteSpace(e.Especialidad))
                    return "ERROR: Todos los campos son obligatorios.";

                if (!e.Correo.Contains("@"))
                    return "ERROR: El correo no es válido.";

                bool ok = _dal.Insertar(e);
                return ok
                    ? "OK: Estilista registrada exitosamente."
                    : "ERROR: No se pudo guardar en la base de datos.";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }

        public List<Estilista> ObtenerTodos()
        {
            try
            {
                return _dal.ObtenerTodos();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener estilistas: " + ex.Message);
            }
        }

        public string Actualizar(Estilista e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(e.Nombre) ||
                    string.IsNullOrWhiteSpace(e.Apellido) ||
                    string.IsNullOrWhiteSpace(e.Telefono) ||
                    string.IsNullOrWhiteSpace(e.Correo) ||
                    string.IsNullOrWhiteSpace(e.Especialidad))
                    return "ERROR: Todos los campos son obligatorios.";

                bool ok = _dal.Actualizar(e);
                return ok
                    ? "OK: Estilista actualizada exitosamente."
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
