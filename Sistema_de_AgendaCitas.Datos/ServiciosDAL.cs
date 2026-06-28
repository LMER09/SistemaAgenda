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
                    INSERT INTO Servicios (Tipo_DeServicio, Precio, DuracionMinutos)
                    VALUES (@Tipo, @Precio, @Duracion)", con))
                {
                    cmd.Parameters.AddWithValue("@Tipo", s.Tipo_DeServicio);
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
                    "SELECT id, Tipo_DeServicio, Precio, DuracionMinutos FROM Servicios", con))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Servicios
                        {
                            Id = reader.GetInt32(0),
                            Tipo_DeServicio = reader.GetString(1),
                            Precio = reader.GetDecimal(2),
                            DuracionMinutos = reader.GetInt32(3)
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
                    UPDATE Servicios SET Tipo_DeServicio=@Tipo,
                    Precio=@Precio, DuracionMinutos=@Duracion
                    WHERE id=@Id", con))
                {
                    cmd.Parameters.AddWithValue("@Tipo", s.Tipo_DeServicio);
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
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar servicio: " + ex.Message);
            }
        }
    }
}