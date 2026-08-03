namespace SistemaAgenda.Datos
{
    public interface IUsuariosDatos
    {
        Task<bool> InsertarAsync(Usuarios u);
        Task<Usuarios?> ObtenerPorUsuarioAsync(string usuario);
        Task<List<Usuarios>> ObtenerTodosAsync();
        Task<bool> ActualizarAsync(Usuarios u);
        Task<bool> EliminarAsync(int id);
    }
}