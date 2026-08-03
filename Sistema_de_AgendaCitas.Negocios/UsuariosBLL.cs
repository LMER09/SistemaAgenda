using SistemaAgenda.Datos;

namespace SistemaAgenda.Negocios
{
    public class UsuariosBLL
    {
        private readonly UsuariosDAL _dal = new UsuariosDAL();

        public string Registrar(Usuarios u)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(u.Usuario) ||
                    string.IsNullOrWhiteSpace(u.Contrasena))
                    return "ERROR: Todos los campos son obligatorios.";

                bool ok = _dal.Insertar(u);
                return ok
                    ? "OK: Usuario registrado exitosamente."
                    : "ERROR: No se pudo guardar en la base de datos.";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
        public List<Usuarios> ObtenerTodos()
        {
            try
            {
                return _dal.ObtenerTodos();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener usuarios: " + ex.Message);
            }
        }

        public string Actualizar(Usuarios u)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(u.Usuario) ||
                    string.IsNullOrWhiteSpace(u.Contrasena))
                    return "ERROR: Todos los campos son obligatorios.";

                bool ok = _dal.Actualizar(u);
                return ok
                    ? "OK: Usuario actualizado exitosamente."
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
                    ? "OK: Usuario eliminado exitosamente."
                    : "ERROR: No se pudo eliminar.";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
        // Valida usuario/contraseña
        public bool ValidarCredenciales(string usuario, string contrasena)
        {
            try
            {
                Usuarios? u = _dal.ObtenerPorUsuario(usuario);
                if (u == null)
                    return false;

                return u.Contrasena == contrasena;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al validar credenciales: " + ex.Message);
            }
        }
    }
}
