using Microsoft.Data.SqlClient;

namespace SistemaAgenda.Datos
{
    public class PagosDAL
    {
        
        public bool Insertar(Pagos p)
        {
            using (var con = ConexionDB.ObtenerConexion())
            using (var cmd = new SqlCommand(@"
                INSERT INTO Pagos (id_Citas, Monto, Metodo_DePago)
                VALUES (@IdCita, @Monto, @Metodo)", con))
            {
                cmd.Parameters.AddWithValue("@IdCita", p.Id_Citas);
                cmd.Parameters.AddWithValue("@Monto", p.Monto);
                cmd.Parameters.AddWithValue("@Metodo", p.Metodo_DePago);

                int filas = cmd.ExecuteNonQuery();
                return filas > 0;
            }
        }

        public List<Pagos> ObtenerTodos()
        {
            var lista = new List<Pagos>();

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
            return lista;
        }

        public bool Actualizar(Pagos p)
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

                int filas = cmd.ExecuteNonQuery();
                return filas > 0;
            }
        }

        public bool Eliminar(int id)
        {
            using (var con = ConexionDB.ObtenerConexion())
            using (var cmd = new SqlCommand(
                "DELETE FROM Pagos WHERE id=@Id", con))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                int filas = cmd.ExecuteNonQuery();
                return filas > 0;
            }
        }
    }
}