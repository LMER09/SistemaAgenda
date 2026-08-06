namespace SistemaAgenda.Datos
{
    public interface ICitasDAL
    {
        Task<bool> InsertarAsync(Citas c);

        Task<List<Citas>> ObtenerTodosAsync();

        Task<List<Citas>> ObtenerPorEstilistaYFechaAsync(int idEstilista, DateTime fecha);

        Task<bool> ActualizarAsync(Citas c);

        Task<bool> EliminarAsync(int id);
    }
}