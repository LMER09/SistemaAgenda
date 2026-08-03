namespace SistemaAgenda.Datos
{
    public interface IHorarioEstilistaDatos
    {
        bool Insertar(HorarioEstilista h);
        List<HorarioEstilista> ObtenerTodos();
        List<HorarioEstilista> ObtenerPorEstilista(int idEstilista);
        bool Actualizar(HorarioEstilista h);
        bool Eliminar(int id);
    }
}