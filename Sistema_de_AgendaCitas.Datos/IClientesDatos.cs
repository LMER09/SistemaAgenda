namespace SistemaAgenda.Datos
{
    public interface IClientesDatos
    {
        bool Insertar(Clientes c);
        List<Clientes> ObtenerTodos();
        bool Actualizar(Clientes c);
        bool Eliminar(int id);
    }
}