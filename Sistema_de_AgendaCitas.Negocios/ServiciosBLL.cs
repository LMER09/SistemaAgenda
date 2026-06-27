using SistemaAgenda.Datos;
using System.Collections.Generic;

namespace SistemaAgenda.Negocios
{
    public class ServiciosBLL
    {
        private readonly ServiciosDAL _dal = new ServiciosDAL();

       
        public string Registrar(Servicios s)
        {
            if (string.IsNullOrWhiteSpace(s.Tipo_DeServicio))
            {
                return "ERROR: El tipo de servicio es obligatorio.";
            }

            if (s.Precio <= 0)
            {
                return "ERROR: El precio debe ser mayor a 0.";
            }

            if (s.DuracionMinutos <= 0)
            {
                return "ERROR: La duración debe ser mayor a 0 minutos.";
            }

            bool ok = _dal.Insertar(s);
            return ok
                ? "OK: Servicio registrado exitosamente."
                : "ERROR: No se pudo guardar en la base de datos.";
        }

        public List<Servicios> ObtenerTodos()
        {
            return _dal.ObtenerTodos();
        }
        public string Actualizar(Servicios s)
        {
            if (string.IsNullOrWhiteSpace(s.Tipo_DeServicio))
            {
                return "ERROR: El tipo de servicio es obligatorio.";
            }

            if (s.Precio <= 0)
            {
                return "ERROR: El precio debe ser mayor a 0.";
            }

            if (s.DuracionMinutos <= 0)
            {
                return "ERROR: La duración debe ser mayor a 0 minutos.";
            }

            bool ok = _dal.Actualizar(s);
            return ok
                ? "OK: Servicio actualizado exitosamente."
                : "ERROR: No se pudo actualizar en la base de datos.";
        }

        public string Eliminar(int id)
        {
            bool ok = _dal.Eliminar(id);
            return ok
                ? "OK: Servicio eliminado exitosamente."
                : "ERROR: No se pudo eliminar.";
        }
    }
}
