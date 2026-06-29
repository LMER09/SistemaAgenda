using Microsoft.Data.SqlClient;

namespace SistemaAgenda.Datos
{
    public class CitasDAL
    {
        public bool Insertar(Citas c)
        {
            try
            {
                using (var con = ConexionDB.ObtenerConexion())
                using (var cmd = new SqlCommand(@"
                INSERT INTO Citas (id_Clientes, id_Servicios, id_Estilista, Fecha, Estado)
                VALUES (@IdCliente, @IdServicio, @IdEstilista, @Fecha, @Estado)", con))
                {
                    cmd.Parameters.AddWithValue("@IdCliente", c.Id_Clientes);
                    cmd.Parameters.AddWithValue("@IdServicio", c.Id_Servicios);
                    cmd.Parameters.AddWithValue("@IdEstilista", c.Id_Estilista);
                    cmd.Parameters.AddWithValue("@Fecha", c.Fecha);
                    cmd.Parameters.AddWithValue("@Estado", c.Estado);

                    int filas = cmd.ExecuteNonQuery();
                    return filas > 0;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar cita: " + ex.Message);
            }

        }

        public List<Citas> ObtenerTodos()
        {
            var lista = new List<Citas>();
            try
            {
                using (var con = ConexionDB.ObtenerConexion())
                using (var cmd = new SqlCommand(
                    "SELECT id, id_Clientes, id_Servicios, id_Estilista, Fecha, Estado FROM Citas", con))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Citas
                        {
                            Id = reader.GetInt32(0),
                            Id_Clientes = reader.GetInt32(1),
                            Id_Servicios = reader.GetInt32(2),
                            Id_Estilista = reader.GetInt32(3),
                            Fecha = reader.GetDateTime(4),
                            Estado = reader.GetString(5)
                        });
                    }
                }
               
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener citas: " + ex.Message);
            }
            return lista;

        }

        public bool Actualizar(Citas c)
        {
            try
            {
                using (var con = ConexionDB.ObtenerConexion())
                using (var cmd = new SqlCommand(@"
                UPDATE Citas SET id_Clientes=@IdCliente, id_Servicios=@IdServicio,
                id_Estilista=@IdEstilista, Fecha=@Fecha, Estado=@Estado
                WHERE id=@Id", con))
                {
                    cmd.Parameters.AddWithValue("@IdCliente", c.Id_Clientes);
                    cmd.Parameters.AddWithValue("@IdServicio", c.Id_Servicios);
                    cmd.Parameters.AddWithValue("@IdEstilista", c.Id_Estilista);
                    cmd.Parameters.AddWithValue("@Fecha", c.Fecha);
                    cmd.Parameters.AddWithValue("@Estado", c.Estado);
                    cmd.Parameters.AddWithValue("@Id", c.Id);

                    int filas = cmd.ExecuteNonQuery();
                    return filas > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar cita: " + ex.Message);
            }
        }

        public bool Eliminar(int id)
        {
            try
            {
                using (var con = ConexionDB.ObtenerConexion())
                using (var cmd = new SqlCommand(
                    "DELETE FROM Citas WHERE id=@Id", con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    int filas = cmd.ExecuteNonQuery();
                    return filas > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar cita: " + ex.Message);
            }

        }
    }
}