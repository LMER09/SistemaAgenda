namespace SistemaAgenda.Datos
{
    public interface IEstilistaDatos
    {
        bool Insertar(Estilista e);
        List<Estilista> ObtenerTodos();
        bool Actualizar(Estilista e);
        bool Eliminar(int id);
    }
}