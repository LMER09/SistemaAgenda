using Microsoft.Data.SqlClient;

namespace SistemaAgenda.Datos
{
    public class ServiciosDAL
    {
        public bool Insertar(Servicios s)
        {
            try
            {
                using (var con = ConexionDB.ObtenerConexion())
                using (var cmd = new SqlCommand(@"
                    INSERT INTO Servicios (Tipo_DeServicio,Subtipo_DeServicio, Precio, DuracionMinutos)
                    VALUES (@Tipo, @Subtipo, @Precio, @Duracion)", con))
                {
                    cmd.Parameters.AddWithValue("@Tipo", s.Tipo_DeServicio);
                    cmd.Parameters.AddWithValue("@Subtipo", s.Subtipo_DeServicio);
                    cmd.Parameters.AddWithValue("@Precio", s.Precio);
                    cmd.Parameters.AddWithValue("@Duracion", s.DuracionMinutos);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar servicio: " + ex.Message);
            }
        }

        public List<Servicios> ObtenerTodos()
        {
            var lista = new List<Servicios>();

            try
            {
                using (var con = ConexionDB.ObtenerConexion())
                using (var cmd = new SqlCommand(
                    "SELECT Id, Tipo_DeServicio, Subtipo_DeServicio, Precio, DuracionMinutos FROM Servicios", con))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Servicios
                        {
                            Id = reader.GetInt32(0),

                            Tipo_DeServicio = reader.IsDBNull(1) ? "": reader.GetString(1),

                            Subtipo_DeServicio = reader.IsDBNull(2) ? "": reader.GetString(2),

                            Precio = reader.IsDBNull(3) ? 0 : reader.GetDecimal(3),

                            DuracionMinutos = reader.IsDBNull(4) ? 0: reader.GetInt32(4)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener servicios: " + ex.Message);
            }

            return lista;
        }

        public bool Actualizar(Servicios s)
        {
            try
            {
                using (var con = ConexionDB.ObtenerConexion())
                using (var cmd = new SqlCommand(@"
                    UPDATE Servicios SET Tipo_DeServicio=@Tipo, Subtipo_DeServicio=@Subtipo,
                    Precio=@Precio, DuracionMinutos=@Duracion
                    WHERE id=@Id", con))
                {
                    cmd.Parameters.AddWithValue("@Tipo", s.Tipo_DeServicio);
                    cmd.Parameters.AddWithValue("@Subtipo", s.Subtipo_DeServicio);
                    cmd.Parameters.AddWithValue("@Precio", s.Precio);
                    cmd.Parameters.AddWithValue("@Duracion", s.DuracionMinutos);
                    cmd.Parameters.AddWithValue("@Id", s.Id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar servicio: " + ex.Message);
            }
        }

        public bool Eliminar(int id)
        {
            try
            {
                using (var con = ConexionDB.ObtenerConexion())
                using (var cmd = new SqlCommand(
                    "DELETE FROM Servicios WHERE id=@Id", con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            //Error 547 = violación de llave foránea: el servicio tiene citas
            //en su historial (ya no se borran en cascada, así se conserva el historial)
            catch (SqlException ex) when (ex.Number == 547)
            {
                throw new Exception("No se puede eliminar el servicio: tiene citas registradas en su historial.");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar servicio: " + ex.Message);
            }
        }
    }
}