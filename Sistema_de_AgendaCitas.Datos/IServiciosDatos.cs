namespace SistemaAgenda.Datos
{
    public interface IServiciosDatos
    {
        Task<bool> InsertarAsync(Servicios s);
        Task<List<Servicios>> ObtenerTodosAsync();
        Task<bool> ActualizarAsync(Servicios s);
        Task<bool> EliminarAsync(int id);
    }
}