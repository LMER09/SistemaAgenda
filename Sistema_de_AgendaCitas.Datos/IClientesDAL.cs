namespace SistemaAgenda.Datos
{
    public interface IClientesDAL
    {
        bool Insertar(Clientes cliente);

        List<Clientes> ObtenerTodos();

        bool Actualizar(Clientes cliente);

        bool Eliminar(int id);
    }
}