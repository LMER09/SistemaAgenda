using SistemaAgenda.Datos;

namespace SistemaAgenda.Negocios
{
    public class ClientesBLL
    {
        private readonly IClientesDAL _dal;

        public ClientesBLL(): this(new ClientesDAL()) { }

        public ClientesBLL(IClientesDAL dal)
        {
            _dal = dal;
        }
        public async Task<string> RegistrarAsync(Clientes c)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(c.Nombre) ||
                    string.IsNullOrWhiteSpace(c.Apellido) ||
                    string.IsNullOrWhiteSpace(c.Telefono) ||
                    string.IsNullOrWhiteSpace(c.Correo))
                    return "ERROR: Todos los campos son obligatorios, excepto la cedula.";

                if (!c.Correo.Contains("@"))
                    return "ERROR: El correo no es válido.";

                bool ok = await _dal.InsertarAsync(c);
                return ok
                    ? "OK: Cliente registrado exitosamente."
                    : "ERROR: No se pudo guardar en la base de datos.";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
        public async Task<List<Clientes>> ObtenerTodosAsync()
        {
            try
            {
                return await _dal.ObtenerTodosAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener clientes: " + ex.Message);
            }
        }
        public async Task<string> ActualizarAsync(Clientes c)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(c.Nombre) ||
                    string.IsNullOrWhiteSpace(c.Apellido) ||
                    string.IsNullOrWhiteSpace(c.Telefono) ||
                    string.IsNullOrWhiteSpace(c.Correo))
                    return "ERROR: Todos los campos son obligatorios, excepto la cedula.";

                bool ok = await _dal.ActualizarAsync(c);
                return ok
                    ? "OK: Cliente actualizado exitosamente."
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
                    ? "OK: Cliente eliminado exitosamente."
                    : "ERROR: No se pudo eliminar.";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
    }
}