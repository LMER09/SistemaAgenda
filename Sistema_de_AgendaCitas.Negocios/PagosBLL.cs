using SistemaAgenda.Datos;
using System.Linq;

namespace SistemaAgenda.Negocios
{
    public class PagosBLL
    {
        private readonly IPagosDAL _dal;
        private readonly ICitasDAL _citasDal;

        // Recibe las interfaces de Pagos y Citas por parametro
        // para poder validar el estado de la cita antes de registrar un pago.
        public PagosBLL() : this(new PagosDAL(), new CitasDAL()) { }
        public PagosBLL(IPagosDAL dal, ICitasDAL citasDal)
        {
            _dal = dal;
            _citasDal = citasDal;
        }

        // REGISTRAR ────────────────────────────────────────────────
        public async Task<string> RegistrarAsync(Pagos p)
        {
            try
            {
                if (p.Id_Citas <= 0)
                    return "ERROR: Debe seleccionar una cita.";

                if (p.Monto <= 0)
                    return "ERROR: El monto debe ser mayor a 0.";

                if (string.IsNullOrWhiteSpace(p.Metodo_DePago))
                    return "ERROR: El método de pago es obligatorio.";

                var citas = await _citasDal.ObtenerTodosAsync();
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

                bool ok = await _dal.InsertarAsync(p);

                if (ok)
                {
                    // Al registrar el pago, la cita pasa a Completada.
                    cita.Estado = "Completada";
                    await _citasDal.ActualizarAsync(cita);

                    return "OK: Pago registrado. Cita completada exitosamente.";
                }

                return "ERROR: No se pudo guardar en la base de datos.";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
        // ACTUALIZAR ───────────────────────────────────────────────
        public async Task<string> ActualizarAsync(Pagos p)
        {
            try
            {
                if (p.Id_Citas <= 0)
                    return "ERROR: Debe seleccionar una cita.";

                if (p.Monto <= 0)
                    return "ERROR: El monto debe ser mayor a 0.";

                if (string.IsNullOrWhiteSpace(p.Metodo_DePago))
                    return "ERROR: El método de pago es obligatorio.";

                bool ok = await _dal.ActualizarAsync(p);
                return ok
                    ? "OK: Pago actualizado exitosamente."
                    : "ERROR: No se pudo actualizar en la base de datos.";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
        // ELIMINAR ─────────────────────────────────────────────────
        public async Task<string> EliminarAsync(int id)
        {
            try
            {
                bool ok = await _dal.EliminarAsync(id);
                return ok
                    ? "OK: Pago eliminado exitosamente."
                    : "ERROR: No se pudo eliminar.";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
        // OBTENER TODOS ────────────────────────────────────────────
        public async Task<List<Pagos>> ObtenerTodosAsync()
        {
            try
            {
                return await _dal.ObtenerTodosAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener pagos: " + ex.Message);
            }
        }

        // TODO METODOS NUEVOS ─────────────────────────────────────────────────

        // Trae solo los pagos de una fecha especifica
        public async Task<List<Pagos>> ObtenerPorFechaAsync(DateTime fecha)
        {
            var todos = await ObtenerTodosAsync();
            var resultado = new List<Pagos>();

            for (int i = 0; i < todos.Count; i++)
            {
                if (todos[i].FechaPago.Date == fecha.Date)
                    resultado.Add(todos[i]);
            }

            return resultado;
        }
        // Suma el monto de una lista de pagos.
        public decimal ObtenerTotal(List<Pagos> pagos)
        {
            decimal total = 0;
            for (int i = 0; i < pagos.Count; i++)
            {
                total += pagos[i].Monto;
            }
            return total;
        }
        // Arma la lista de pagos con nombres de cliente y servicio, para mostrar en pantalla.
        public async Task<List<PagoVista>> ObtenerVistaAsync()
        {
            var pagos = await ObtenerTodosAsync();
            var citasBLL = new CitasBLL();
            var clientesBLL = new ClientesBLL();
            var serviciosBLL = new ServiciosBLL();

            var citas = await citasBLL.ObtenerTodosAsync();
            var clientes = await clientesBLL.ObtenerTodosAsync();
            var servicios = await serviciosBLL.ObtenerTodosAsync();

            return pagos.Select(p =>
            {
                var cita = citas.FirstOrDefault(c => c.Id == p.Id_Citas);
                var cliente = cita != null ? clientes.FirstOrDefault(c => c.Id == cita.Id_Clientes) : null;
                var servicio = cita != null ? servicios.FirstOrDefault(s => s.Id == cita.Id_Servicios) : null;

                return new PagoVista
                {
                    Id = p.Id,
                    Cliente = cliente != null ? $"{cliente.Nombre} {cliente.Apellido}" : "Cliente desconocido",
                    Servicio = servicio != null ? servicio.Tipo_DeServicio : "Servicio desconocido",
                    FechaCita = cita != null ? cita.Fecha : DateTime.MinValue,
                    Monto = p.Monto,
                    MetodoDePago = p.Metodo_DePago,
                    FechaPago = p.FechaPago
                };
            }).ToList();
        }
        // // Filtra los pagos entre dos fechas para el reporte,
        // para el reporte que se exporta a Excel/PDF
        public async Task<List<PagoVista>> ObtenerReporteAsync(DateTime desde, DateTime hasta)
        {
            List<PagoVista> todos = await ObtenerVistaAsync();
            List<PagoVista> reporte = new List<PagoVista>();

            for (int i = 0; i < todos.Count; i++)
            {
                if (todos[i].FechaPago.Date >= desde.Date &&
                    todos[i].FechaPago.Date <= hasta.Date)
                {
                    reporte.Add(todos[i]);
                }
            }

            return reporte;
        }
        // Suma el monto total del reporte.
        public decimal ObtenerTotalReporte(List<PagoVista> reporte)
        {
            decimal total = 0;

            for (int i = 0; i < reporte.Count; i++)
            {
                total += reporte[i].Monto;
            }

            return total;
        }
    }
}