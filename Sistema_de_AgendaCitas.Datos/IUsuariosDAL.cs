namespace SistemaAgenda.Datos
{
    public interface IUsuariosDAL
    {
        bool Insertar(Usuarios usuario);

        Usuarios? ObtenerPorUsuario(string usuario);

        List<Usuarios> ObtenerTodos();

        bool Actualizar(Usuarios usuario);

        bool Eliminar(int id);
    }
}