namespace SistemaAgenda.Datos
{
    public interface IServiciosDAL
    {
        bool Insertar(Servicios servicio);

        List<Servicios> ObtenerTodos();

        bool Actualizar(Servicios servicio);

        bool Eliminar(int id);
    }
}