using SistemaAgenda.Datos;

namespace SistemaAgenda.Negocios
{
    public class ClientesBLL
    {
        private readonly ClientesDAL _dal = new ClientesDAL();

        public string Registrar(Clientes c)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(c.Nombre) ||
                    string.IsNullOrWhiteSpace(c.Apellido) ||
                    string.IsNullOrWhiteSpace(c.Telefono) ||
                    string.IsNullOrWhiteSpace(c.Correo))
                    return "ERROR: Todos los campos son obligatorios.";

                if (!c.Correo.Contains("@"))
                    return "ERROR: El correo no es válido.";

                bool ok = _dal.Insertar(c);
                return ok
                    ? "OK: Cliente registrado exitosamente."
                    : "ERROR: No se pudo guardar en la base de datos.";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }

        public List<Clientes> ObtenerTodos()
        {
            try
            {
                return _dal.ObtenerTodos();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener clientes: " + ex.Message);
            }
        }

        public string Actualizar(Clientes c)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(c.Nombre) ||
                    string.IsNullOrWhiteSpace(c.Apellido)