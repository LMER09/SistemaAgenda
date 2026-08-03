namespace SistemaAgenda.Datos
{
    public interface ICitasDatos
    {
        Task<bool> InsertarAsync(Citas c);
        Task<List<Citas>> ObtenerTodosAsync();
        Task<bool> ActualizarAsync(Citas c);
        Task<bool> EliminarAsync(int id);
    }
}