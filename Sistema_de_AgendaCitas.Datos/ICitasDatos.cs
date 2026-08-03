namespace SistemaAgenda.Datos
{
    public interface ICitasDatos
    {
        bool Insertar(Citas c);
        List<Citas> ObtenerTodos();
        bool Actualizar(Citas c);
        bool Eliminar(int id);
    }
}
