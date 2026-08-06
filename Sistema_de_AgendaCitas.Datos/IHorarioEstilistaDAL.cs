namespace SistemaAgenda.Datos
{
    public interface IHorarioEstilistaDAL
    {
        Task<bool> InsertarAsync(HorarioEstilista h);
        Task<List<HorarioEstilista>> ObtenerTodosAsync();
        Task<List<HorarioEstilista>> ObtenerPorEstilistaAsync(int idEstilista);
        Task<bool> ActualizarAsync(HorarioEstilista h);
        Task<bool> EliminarAsync(int id);
        Task<bool> EliminarPorEstilistaAsync(int idEstilista);
    }
}