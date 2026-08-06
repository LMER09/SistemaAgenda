namespace SistemaAgenda.Datos
{
    public interface IUsuariosDAL
    {
        Task<bool> InsertarAsync(Usuarios usuario);
        Task<Usuarios?> ObtenerPorUsuarioAsync(string usuario);
        Task<List<Usuarios>> ObtenerTodosAsync();
        Task<bool> ActualizarAsync(Usuarios usuario);
        Task<bool> EliminarAsync(int id);
    }
}