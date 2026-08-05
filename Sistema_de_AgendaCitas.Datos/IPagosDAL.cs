namespace SistemaAgenda.Datos
{
    public interface IPagosDAL
    {
        bool Insertar(Pagos pago);

        List<Pagos> ObtenerTodos();

        bool Actualizar(Pagos pago);

        bool Eliminar(int id);
    }
}