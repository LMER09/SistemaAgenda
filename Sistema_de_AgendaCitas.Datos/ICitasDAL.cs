namespace SistemaAgenda.Datos
{
    public interface ICitasDAL
    {
        bool Insertar(Citas c);

        List<Citas> ObtenerTodos();

        List<Citas> ObtenerPorEstilistaYFecha(int idEstilista, DateTime fecha);

        bool Actualizar(Citas c);

        bool Eliminar(int id);
    }
}