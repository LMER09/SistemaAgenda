namespace SistemaAgenda.Datos
{
    public interface IEstilistaDAL
    {
        Task<bool> InsertarAsync(Estilista estilista);

        Task<List<Estilista>> ObtenerTodosAsync();

        Task<bool> ActualizarAsync(Estilista estilista);

        Task<bool> EliminarAsync(int id);
    }
}