using SistemaAgenda.Datos;

namespace SistemaAgenda.Negocios
{
    public class PagosBLL
    {
        private readonly PagosDAL _dal = new PagosDAL();

        // ── REGISTRAR ────────────────────────────────────────────────
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
                if (cita.Estado == "Completada")
                    return "ERROR: Cita completada y pagada.";

                bool ok = _dal.Insertar(p);

                if (ok)
                {
                    // Al registrar el pago, la cita pasa a Completada.
                    cita.Estado = "Completada";
                    citasDAL.Actualizar(cita);

                    return "OK: Pago registrado. Cita completada exitosamente.";
                }

                return "ERROR: No se pudo guardar en la base de datos.";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }

        // ── ACTUALIZAR ───────────────────────────────────────────────
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

        // ── ELIMINAR ─────────────────────────────────────────────────
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

        // ── OBTENER TODOS ────────────────────────────────────────────
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

        // ── REPORTES ─────────────────────────────────────────────────

        // Trae solo los pagos de una fecha especifica, para no mezclar dias en el reporte/corte del dia.
        public List<Pagos> ObtenerPorFecha(DateTime fecha)
        {
            var todos = ObtenerTodos();
            var resultado = new List<Pagos>();

            for (int i = 0; i < todos.Count; i++)
            {
                if (todos[i].FechaPago.Date == fecha.Date)
                    resultado.Add(todos[i]);
            }

            return resultado;
        }

        // Suma el monto de una lista de pagos
        public decimal ObtenerTotal(List<Pagos> pagos)
        {
            decimal total = 0;
            for (int i = 0; i < pagos.Count; i++)
            {
                total += pagos[i].Monto;
            }
            return total;
        }

        public List<PagoVista> ObtenerVista()
        {
            var pagos = ObtenerTodos();
            var citasBLL = new CitasBLL();
            var clientesBLL = new ClientesBLL();
            var serviciosBLL = new ServiciosBLL();

            var citas = citasBLL.ObtenerTodos();
            var clientes = clientesBLL.ObtenerTodos();
            var servicios = serviciosBLL.ObtenerTodos();

            var resultado = new List<PagoVista>();

            for (int i = 0; i < pagos.Count; i++)
            {
                Pagos p = pagos[i];

                Citas cita = null;
                for (int j = 0; j < citas.Count; j++)
                {
                    if (citas[j].Id == p.Id_Citas)
                    {
                        cita = citas[j];
                        break;
                    }
                }

                Clientes cliente = null;
                Servicios servicio = null;
                if (cita != null)
                {
                    for (int j = 0; j < clientes.Count; j++)
                    {
                        if (clientes[j].Id == cita.Id_Clientes)
                        {
                            cliente = clientes[j];
                            break;
                        }
                    }
                    for (int j = 0; j < servicios.Count; j++)
                    {
                        if (servicios[j].Id == cita.Id_Servicios)
                        {
                            servicio = servicios[j];
                            break;
                        }
                    }
                }

                resultado.Add(new PagoVista
                {
                    Id = p.Id,
                    Cliente = cliente != null ? $"{cliente.Nombre} {cliente.Apellido}" : "Cliente desconocido",
                    Servicio = servicio != null ? servicio.Tipo_DeServicio : "Servicio desconocido",
                    FechaCita = cita != null ? cita.Fecha : DateTime.MinValue,
                    Monto = p.Monto,
                    MetodoDePago = p.Metodo_DePago,
                    FechaPago = p.FechaPago
                });
            }
            return resultado;

          
        }
    }
}