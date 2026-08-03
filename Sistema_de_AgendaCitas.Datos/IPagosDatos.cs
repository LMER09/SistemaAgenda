namespace SistemaAgenda.Datos
{
    public interface IPagosDatos
    {
        bool Insertar(Pagos p);
        List<Pagos> ObtenerTodos();
        bool Actualizar(Pagos p);
        bool Eliminar(int id);
    }
}