namespace SistemaAgenda.Datos
{
    public interface IServiciosDAL
    {
        Task<bool> InsertarAsync(Servicios servicio);

        Task<List<Servicios>> ObtenerTodosAsync();

        Task<bool> ActualizarAsync(Servicios servicio);

        Task<bool> EliminarAsync(int id);
    }
}