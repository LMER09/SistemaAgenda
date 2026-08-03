namespace SistemaAgenda.Datos
{
    public interface IUsuariosDatos
    {
        bool Insertar(Usuarios u);
        Usuarios? ObtenerPorUsuario(string usuario);
        List<Usuarios> ObtenerTodos();
        bool Actualizar(Usuarios u);
        bool Eliminar(int id);
    }
}