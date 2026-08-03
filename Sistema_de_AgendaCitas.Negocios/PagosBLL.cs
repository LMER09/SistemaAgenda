using SistemaAgenda.Datos;

namespace SistemaAgenda.Negocios
{
    public class PagosBLL
    {
        private readonly IPagosDatos _dal;
        public PagosBLL() : this(new PagosDAL()) { }
        public PagosBLL(IPagosDatos dal) { _dal = dal; }

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


                CitasDAL citasDAL = new CitasDAL();
                var citas = citasDAL.ObtenerTodos();
                Citas cita = null;

                for (int i = 0; i < citas.Count; i++)
                {
                    if (citas[i].Id == p.Id_Citas)
                    {
                        cita = citas[i];
                        break;
                    }
                }

                if (cita == null)
                    return "ERROR: Cita no encontrada.";
                if (cita.Estado == "Cancelada")
                    return "ERROR: No se puede registrar un pago para una cita cancelada.";

                // Verificar si la cita ya fue completada
                if (cita.Estado == "Completada")
                    return "ERROR: Esta cita ya fue completada y pagada.";

                bool ok = _dal.Insertar(p);

                if (ok)
                {
                    // Actualizar el estado de la cita a "Completada" cuando se hace el pago

                    if (cita != null)
                    {
                        cita.Estado = "Completada";
                        citasDAL.Actualizar(cita);
                    }

                    return "OK: Pago registrado y cita completada exitosamente.";
                }
                
                return "ERROR: No se pudo guardar en la base de datos.";
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