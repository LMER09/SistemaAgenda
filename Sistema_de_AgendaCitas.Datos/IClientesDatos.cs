namespace SistemaAgenda.Datos
{
    public interface IClientesDatos
    {
        Task<bool> InsertarAsync(Clientes c);
        Task<List<Clientes>> ObtenerTodosAsync();
        Task<bool> ActualizarAsync(Clientes c);
        Task<bool> EliminarAsync(int id);
    }
}