using SistemaAgenda.Datos;
using System.Linq;

namespace SistemaAgenda.Negocios
{
    public class PagosBLL
    {
        private readonly PagosDAL _dal = new PagosDAL();

        public string Registrar(Pagos p)
        {
            try
            {
                if (p.Id_Citas <= 0)
                    return "ERROR: Debe seleccionar una cita.";

                if (p.Monto <= 0)
                    return "ERROR: El monto debe ser mayor a 0.";

                if (string.IsNullOrWhiteSpace(p.Metodo_DePago))
                    return "ERROR: El método de pago es obligatorio.";

                bool ok = _dal.Insertar(p);

                if (ok)
                {
                    // Actualizar el estado de la cita a "Completada"
                    CitasDAL citasDAL = new CitasDAL();
                    var citas = citasDAL.ObtenerTodos();
                    var cita = citas.FirstOrDefault(c => c.Id == p.Id_Citas);

                    if (cita != null)
                    {
                        cita.Estado = "Completada";
                        citasDAL.Actualizar(cita);
                    }

                    return "OK: Pago registrado y cita completada exitosamente.";
                }
                return ok
                    ? "OK: Pago registrado exitosamente."
                    : "ERROR: No se pudo guardar en la base de datos.";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }

        public List<Pagos> ObtenerTodos()
        {
            try
            {
                return _dal.ObtenerTodos();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener pagos: " + ex.Message);
            }
        }

        public string Actualizar(Pagos p)
        {
            try
            {
                if (p.Id_Citas <= 0)
                    return "ERROR: Debe seleccionar una cita.";

                if (p.Monto <= 0)
                    return "ERROR: El monto debe ser mayor a 0.";

                if (string.IsNullOrWhiteSpace(p.Metodo_DePago))
                    return "ERROR: El método de pago es obligatorio.";

                bool ok = _dal.Actualizar(p);
                return ok
                    ? "OK: Pago actualizado exitosamente."
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
                    ? "OK: Pago eliminado exitosamente."
                    : "ERROR: No se pudo eliminar.";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
    }
}