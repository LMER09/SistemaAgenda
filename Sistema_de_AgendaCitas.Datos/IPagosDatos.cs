namespace SistemaAgenda.Datos
{
    public interface IPagosDatos
    {
        Task<bool> InsertarAsync(Pagos p);
        Task<List<Pagos>> ObtenerTodosAsync();
        Task<bool> ActualizarAsync(Pagos p);
        Task<bool> EliminarAsync(int id);
    }
}