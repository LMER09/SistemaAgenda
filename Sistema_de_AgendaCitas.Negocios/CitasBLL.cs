using SistemaAgenda.Datos;
using System.Collections.Generic;


namespace SistemaAgenda.Negocios
{
    public class CitasBLL
    {
        private readonly CitasDAL _dal = new CitasDAL();

        public string Registrar(Citas c)
        {
            if (c.Id_Clientes <= 0)
            {
                return "ERROR: Debe seleccionar un cliente.";
            }

            if (c.Id_Servicios <= 0)
            {
                return "ERROR: Debe seleccionar un servicio.";
            }

            if (c.Id_Estilista <= 0)
            {
                return "ERROR: Debe seleccionar una estilista.";
            }

            if (c.Fecha < DateTime.Now)
            {
                return "ERROR: La fecha no puede ser en el pasado.";
            }

            if (string.IsNullOrWhiteSpace(c.Estado))
            {
                return "ERROR: El estado es obligatorio.";
            }

            bool ok = _dal.Insertar(c);
            return ok
                ? "OK: Cita registrada exitosamente."
                : "ERROR: No se pudo guardar en la base de datos.";
        }

        public List<Citas> ObtenerTodos()
        {
            return _dal.ObtenerTodos();
        }

        public string Actualizar(Citas c)
        {
            if (c.Id_Clientes <= 0 || c.Id_Servicios <= 0 || c.Id_Estilista <= 0)
            {
                return "ERROR: Todos los campos son obligatorios.";
            }

            if (string.IsNullOrWhiteSpace(c.Estado))
            {
                return "ERROR: El estado es obligatorio.";
            }

            bool ok = _dal.Actualizar(c);
            return ok
                ? "OK: Cita actualizada exitosamente."
                : "ERROR: No se pudo actualizar en la base de datos.";
        }

        public string Eliminar(int id)
        {
            bool ok = _dal.Eliminar(id);
            return ok
                ? "OK: Cita eliminada exitosamente."
                : "ERROR: No se pudo eliminar.";
        }
    }
}