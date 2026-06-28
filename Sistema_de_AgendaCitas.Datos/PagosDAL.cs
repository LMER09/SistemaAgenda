using Microsoft.Data.SqlClient;

namespace SistemaAgenda.Datos
{
    public class PagosDAL
    {
        public bool Insertar(Pagos p)
        {
            try
            {
                using (var con = ConexionDB.ObtenerConexion())
                using (var cmd = new SqlCommand(@"
                    INSERT INTO Pagos (id_Citas, Monto, Metodo_DePago)
                    VALUES (@IdCita, @Monto, @Metodo)", con))
                {
                    cmd.Parameters.AddWithValue("@IdCita", p.Id_Citas);
                    cmd.Parameters.AddWithValue("@Monto", p.Monto);
                    cmd.Parameters.AddWithValue("@Metodo", p.Metodo_DePago);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar pago: " + ex.Message);
            }
        }

        public List<Pagos> ObtenerTodos()
        {
            var lista = new List<Pagos>();
            try
            {
                using (var con = ConexionDB.ObtenerConexion())
                using (var cmd = new SqlCommand(
                    "SELECT id, id_Citas, Monto, Metodo_DePago, FechaPago FROM Pagos", con))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Pagos
                        {
                            Id = reader.GetInt32(0),
                            Id_Citas = reader.GetInt32(1),
                            Monto = reader.GetDecimal(2),
                            Metodo_DePago = reader.GetString(3),
                            FechaPago = reader.GetDateTime(4)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener pagos: " + ex.Message);
            }
            return lista;
        }

        public bool Actualizar(Pagos p)
        {
            try
            {
                using (var con = ConexionDB.ObtenerConexion())
                using (var cmd = new SqlCommand(@"
                    UPDATE Pagos SET id_Citas=@IdCita, Monto=@Monto,
                    Metodo_DePago=@Metodo WHERE id=@Id", con))
                {
                    cmd.Parameters.AddWithValue("@IdCita", p.Id_Citas);
                    cmd.Parameters.AddWithValue("@Monto", p.Monto);
                    cmd.Parameters.AddWithValue("@Metodo", p.Metodo_DePago);
                    cmd.Parameters.AddWithValue("@Id", p.Id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar pago: " + ex.Message);
            }
        }

        public bool Eliminar(int id)
        {
            try
            {
                using (var con = ConexionDB.ObtenerConexion())
                using (var cmd = new SqlCommand(
                    "DELETE FROM Pagos WHERE id=@Id", con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar pago: " + ex.Message);
            }
        }
    }
}