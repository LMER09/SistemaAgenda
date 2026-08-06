using SistemaAgenda.Datos;

namespace SistemaAgenda.Negocios
{
    public class UsuariosBLL
    {
        private readonly IUsuariosDAL _dal;

        public UsuariosBLL() : this(new UsuariosDAL()) { }

        public UsuariosBLL(IUsuariosDAL dal)
        {
            _dal = dal;
        }

        public async Task<string> RegistrarAsync(Usuarios u)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(u.Usuario))
                    return "ERROR: El usuario es obligatorio.";

                if (string.IsNullOrWhiteSpace(u.Contrasena))
                    return "ERROR: La contraseña es obligatoria.";

                bool ok = await _dal.InsertarAsync(u);
                return ok
                    ? "OK: Usuario registrado exitosamente."
                    : "ERROR: No se pudo guardar en la base de datos.";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }

        // Se usa en el login para validar usuario/contraseña
        public async Task<Usuarios?> ObtenerPorUsuarioAsync(string usuario)
        {
            try
            {
                return await _dal.ObtenerPorUsuarioAsync(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar usuario: " + ex.Message);
            }
        }

        public async Task<List<Usuarios>> ObtenerTodosAsync()
        {
            try
            {
                return await _dal.ObtenerTodosAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener usuarios: " + ex.Message);
            }
        }

        public async Task<string> ActualizarAsync(Usuarios u)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(u.Usuario))
                    return "ERROR: El usuario es obligatorio.";

                if (string.IsNullOrWhiteSpace(u.Contrasena))
                    return "ERROR: La contraseña es obligatoria.";

                bool ok = await _dal.ActualizarAsync(u);
                return ok
                    ? "OK: Usuario actualizado exitosamente."
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
                    ? "OK: Usuario eliminado exitosamente."
                    : "ERROR: No se pudo eliminar.";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
    }
}