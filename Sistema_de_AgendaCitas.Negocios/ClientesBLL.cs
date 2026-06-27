using SistemaAgenda.Datos;
using System.Collections.Generic;


namespace SistemaAgenda.Negocios
{
    public class ClientesBLL
    {
        private readonly ClientesDAL _dal = new ClientesDAL();

        public string Registrar(Clientes c)
        {

            if(string.IsNullOrWhiteSpace(c.Nombre)||
                string.IsNullOrWhiteSpace(c.Apellido)||
                string.IsNullOrWhiteSpace(c.Telefono)||
                string.IsNullOrWhiteSpace(c.Correo))
            {
                return "ERROR: Todos los campos son obligatorios";
            }
            if (!c.Correo.Contains("@"))
            {
                return "ERROR: El correo no es válido";
            }
            bool ok = _dal.Insertar(c);
            return ok
                ? "OK: Cliente registrado exitosamnete."
                : "Error: No se pudo guardar en la base de datos";
        }
        
        public List<Clientes> ObtenerTodos() => _dal.ObtenerTodos();
        public string Actualizar(Clientes c)
        {

            if (string.IsNullOrWhiteSpace(c.Nombre) ||
                string.IsNullOrWhiteSpace(c.Apellido) ||
                string.IsNullOrWhiteSpace(c.Telefono) ||
                string.IsNullOrWhiteSpace(c.Correo))
            {
                return "ERROR: Todos los campos son obligatorios.";
            }

            bool ok = _dal.Actualizar(c);
            return ok
                ? "OK: Cliente actualizado exitosamente."
                : "ERROR: No se pudo actualizar en la base de datos.";
        }

        public string Eliminar(int id)
        {
            bool ok = _dal.Eliminar(id);
            return ok
                ? "OK: Cliente eliminado exitosamente."
                : "ERROR: No se pudo eliminar.";
        }

    }
}
