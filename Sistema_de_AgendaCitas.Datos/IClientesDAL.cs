namespace SistemaAgenda.Datos
{
    public interface IClientesDAL
    {
        Task<bool> InsertarAsync(Clientes cliente);

        Task<List<Clientes>> ObtenerTodosAsync();

        Task<bool> ActualizarAsync(Clientes cliente);

        Task<bool> EliminarAsync(int id);
    }
}