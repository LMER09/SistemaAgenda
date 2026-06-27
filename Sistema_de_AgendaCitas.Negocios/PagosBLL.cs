using SistemaAgenda.Datos;
using System.Collections.Generic;

namespace SistemaAgenda.Negocios
{
    public class PagosBLL
    {
        private readonly PagosDAL _dal = new PagosDAL();

        public string Registrar(Pagos p)
        {
            if (p.Id_Citas <= 0)
            {
                return "ERROR: Debe seleccionar una cita.";
            }

            if (p.Monto <= 0)
            {
                return "ERROR: El monto debe ser mayor a 0.";
            }

            if (string.IsNullOrWhiteSpace(p.Metodo_DePago))
            {
                return "ERROR: El método de pago es obligatorio.";
            }

            bool ok = _dal.Insertar(p);
            return ok
                ? "OK: Pago registrado exitosamente."
                : "ERROR: No se pudo guardar en la base de datos.";
        }

        public List<Pagos> ObtenerTodos()
        {
            return _dal.ObtenerTodos();
        }

        public string Actualizar(Pagos p)
        {
            if (p.Id_Citas <= 0)
            {
                return "ERROR: Debe seleccionar una cita.";
            }

            if (p.Monto <= 0)
            {
                return "ERROR: El monto debe ser mayor a 0.";
            }

            if (string.IsNullOrWhiteSpace(p.Metodo_DePago))
            {
                return "ERROR: El método de pago es obligatorio.";
            }

            bool ok = _dal.Actualizar(p);
            return ok
                ? "OK: Pago actualizado exitosamente."
                : "ERROR: No se pudo actualizar en la base de datos.";
        }

        public string Eliminar(int id)
        {
            bool ok = _dal.Eliminar(id);
            return ok
                ? "OK: Pago eliminado exitosamente."
                : "ERROR: No se pudo eliminar.";
        }
    }
}
