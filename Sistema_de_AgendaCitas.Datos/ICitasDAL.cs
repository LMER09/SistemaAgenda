namespace SistemaAgenda.Datos
{
    // TODO Contrato que debe cumplir cualquier clase de acceso a datos para Citas.
    // CitasBLL depende de esta interfaz no de CitasDAL directamente,
    // lo que permite cambiar la implementación.
    public interface ICitasDAL
    {
        Task<bool> InsertarAsync(Citas c);
        Task<List<Citas>> ObtenerTodosAsync();
        Task<List<Citas>> ObtenerPorEstilistaYFechaAsync(int idEstilista, DateTime fecha);
        Task<bool> ActualizarAsync(Citas c);
        Task<bool> EliminarAsync(int id);
    }
}