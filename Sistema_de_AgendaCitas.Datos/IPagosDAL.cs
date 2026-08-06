namespace SistemaAgenda.Datos
{
    public interface IPagosDAL
    {
        Task<bool> InsertarAsync(Pagos pago);
        Task<List<Pagos>> ObtenerTodosAsync();
        Task<bool> ActualizarAsync(Pagos pago);
        Task<bool> EliminarAsync(int id);
    }
}