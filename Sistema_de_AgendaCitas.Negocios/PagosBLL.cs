using System.Linq;
using SistemaAgenda.Datos;

namespace SistemaAgenda.Negocios
{
    public class PagosBLL
    {
        private readonly IPagosDatos _dal;
        private readonly ICitasDatos _citasDal;

        public PagosBLL() : this(new PagosDAL(), new CitasDAL()) { }
        public PagosBLL(IPagosDatos dal, ICitasDatos citasDal) { _dal = dal; _citasDal = citasDal; }

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
                Citas cita = citas.FirstOrDefault(c => c.Id == p.Id_Citas);

                if (cita == null)
                    return "ERROR: Cita no encontrada.";
                if (cita.Estado == "Cancelada")
                    return "ERROR: No se puede registrar un pago para una cita cancelada.";
                if (cita.Estado == "Completada")
                    return "ERROR: Esta cita ya fue completada y pagada.";

                bool ok = await _dal.InsertarAsync(p);

                if (ok)
                {
                    cita.Estado = "Completada";
                    await _citasDal.ActualizarAsync(cita);
                    return "OK: Pago registrado y cita completada exitosamente.";
                }

                return "ERROR: No se pudo guardar en la base de datos.";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }

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
    }
}