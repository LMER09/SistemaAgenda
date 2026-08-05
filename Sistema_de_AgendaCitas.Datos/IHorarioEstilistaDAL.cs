namespace SistemaAgenda.Datos
{
    public interface IHorarioEstilistaDAL
    {
        bool Insertar(HorarioEstilista h);
        List<HorarioEstilista> ObtenerTodos();
        List<HorarioEstilista> ObtenerPorEstilista(int idEstilista);
        bool Actualizar(HorarioEstilista h);
        bool Eliminar(int id);
        bool EliminarPorEstilista(int idEstilista);
    }
}