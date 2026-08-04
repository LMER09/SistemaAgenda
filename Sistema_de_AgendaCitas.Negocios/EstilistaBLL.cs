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
                if (string.IsNullOrWhiteSpace(e.Nombre))
                    return "ERROR: El nombre es obligatorio.";

                if (string.IsNullOrWhiteSpace(e.Apellido))
                    return "ERROR: El apellido es obligatorio.";

                if (string.IsNullOrWhiteSpace(e.Telefono))
                    return "ERROR: El teléfono es obligatorio.";

                if (string.IsNullOrWhiteSpace(e.Correo))
                    return "ERROR: El correo es obligatorio.";

                if (string.IsNullOrWhiteSpace(e.Cedula))
                    return "ERROR: La cédula es obligatoria.";

                if (string.IsNullOrWhiteSpace(e.Especialidad))
                    return "ERROR: La especialidad es obligatoria.";

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
                    string.IsNullOrWhiteSpace(e.Especialidad) ||
                    string.IsNullOrWhiteSpace(e.Cedula))
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
