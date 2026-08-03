namespace SistemaAgenda.Datos
{
    public interface IEstilistaDatos
    {
        Task<bool> InsertarAsync(Estilista e);
        Task<List<Estilista>> ObtenerTodosAsync();
        Task<bool> ActualizarAsync(Estilista e);
        Task<bool> EliminarAsync(int id);
    }
}