namespace SistemaAgenda.Datos
{
    public interface IServiciosDatos
    {
        bool Insertar(Servicios s);
        List<Servicios> ObtenerTodos();
        bool Actualizar(Servicios s);
        bool Eliminar(int id);
    }
}