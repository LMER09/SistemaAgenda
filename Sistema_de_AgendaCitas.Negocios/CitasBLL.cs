using SistemaAgenda.Datos;

public class CitasBLL
{
    private readonly ICitasDatos _dal;
    public CitasBLL() : this(new CitasDAL()) { }
    public CitasBLL(ICitasDatos dal) { _dal = dal; }

    public async Task<List<Citas>> ObtenerTodosAsync()
    {
        try
        {
            return await _dal.ObtenerTodosAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("Error al obtener citas: " + ex.Message);
        }
    }

    public async Task<string> AgendarCitaAsync(Citas c)
    {
        try
        {
            if (c.Id_Clientes <= 0) { return "ERROR: Debe seleccionar un cliente."; }
            if (c.Id_Servicios <= 0) { return "ERROR: Debe seleccionar un servicio."; }
            if (c.Fecha < DateTime.Now) { return "ERROR: La fecha no puede ser en el pasado."; }
            c.Estado = "Pendiente";
            bool ok = await _dal.InsertarAsync(c);
            return ok ? "OK: Cita agendada exitosamente." : "ERROR: No se pudo agendar la cita.";
        }
        catch (Exception ex) { return "ERROR: " + ex.Message; }
    }

    public async Task<string> CancelarCitaAsync(int id)
    {
        try
        {
            var lista = await _dal.ObtenerTodosAsync();
            Citas cita = lista.FirstOrDefault(x => x.Id == id);

            if (cita == null) return "ERROR: Cita no encontrada.";
            if (cita.Estado == "Completada") return "ERROR: No se puede cancelar una cita que ya fue completada.";
            if (cita.Estado == "Cancelada") return "ERROR: La cita ya está cancelada.";

            cita.Estado = "Cancelada";
            bool ok = await _dal.ActualizarAsync(cita);
            return ok ? "OK: Cita cancelada exitosamente." : "ERROR: No se pudo cancelar la cita.";
        }
        catch (Exception ex) { return "ERROR: " + ex.Message; }
    }

    public async Task<string> ReprogramarCitaAsync(int id, DateTime nuevaFecha)
    {
        try
        {
            if (nuevaFecha < DateTime.Now) return "ERROR: La nueva fecha no puede ser en el pasado.";

            var lista = await _dal.ObtenerTodosAsync();
            Citas cita = lista.FirstOrDefault(x => x.Id == id);

            if (cita == null) return "ERROR: Cita no encontrada.";
            if (cita.Estado == "Completada") return "ERROR: No se puede reprogramar una cita que ya fue completada.";
            if (cita.Estado == "Cancelada") return "ERROR: No se puede reprogramar una cita cancelada.";

            cita.Fecha = nuevaFecha;
            cita.Estado = "Reprogramada";
            bool ok = await _dal.ActualizarAsync(cita);
            return ok ? "OK: Cita reprogramada exitosamente." : "ERROR: No se pudo reprogramar la cita.";
        }
        catch (Exception ex) { return "ERROR: " + ex.Message; }
    }
}