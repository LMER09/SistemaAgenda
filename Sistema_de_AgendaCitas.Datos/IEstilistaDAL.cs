namespace SistemaAgenda.Datos
{
    public interface IEstilistaDAL
    {
        bool Insertar(Estilista estilista);

        List<Estilista> ObtenerTodos();

        bool Actualizar(Estilista estilista);

        bool Eliminar(int id);
    }
}