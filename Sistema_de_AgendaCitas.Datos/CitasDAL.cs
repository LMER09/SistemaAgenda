using Microsoft.Data.SqlClient;

namespace SistemaAgenda.Datos
{
    public class CitasDAL
    {
        public bool Insertar(Citas c)
        {
            try
            {
                //Abre la conexion a SQL
                using (var con = ConexionDB.ObtenerConexion())
                //Envia una consulta a SQL Server
                using (var cmd = new SqlCommand(@"
                INSERT INTO Citas (id_Clientes, id_Servicios, id_Estilista, Fecha, Estado, Deposito)
                VALUES (@IdCliente, @IdServicio, @IdEstilista, @Fecha, @Estado, @Deposito)", con))
                {
                    cmd.Parameters.AddWithValue("@IdCliente", c.Id_Clientes);
                    cmd.Parameters.AddWithValue("@IdServicio", c.Id_Servicios);
                    cmd.Parameters.AddWithValue("@IdEstilista", c.Id_Estilista);
                    cmd.Parameters.AddWithValue("@Fecha", c.Fecha);
                    cmd.Parameters.AddWithValue("@Estado", c.Estado);
                    cmd.Parameters.AddWithValue("@Deposito", c.Deposito);

                    //Esta línea ejecuta el INSERT y devuelve cuantas filas fueron afectadas
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
                    "SELECT id, id_Clientes, id_Servicios, id_Estilista, Fecha, Estado, Deposito FROM Citas", con))
                //lee los registros uno por uno
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
                            Estado = reader.GetString(5),
                            Deposito = reader.GetDecimal(6)
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
        // Verifica si el estilista ya tiene una cita en la fecha y hora indicada
        public bool EstilistaDisponible(int idEstilista, DateTime fecha)
        {
            try
            {
                using (var con = ConexionDB.ObtenerConexion())
                using (var cmd = new SqlCommand(@"
            SELECT COUNT(*)
            FROM Citas
            WHERE id_Estilista = @IdEstilista
              AND Fecha = @Fecha", con))
                {
                    cmd.Parameters.AddWithValue("@IdEstilista", idEstilista);
                    cmd.Parameters.AddWithValue("@Fecha", fecha);

                    int cantidad = (int)cmd.ExecuteScalar();

                    //Si no hay citas, el estilista está disponible
                    return cantidad == 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar disponibilidad del estilista: " + ex.Message);
            }
        }
        public bool Actualizar(Citas c)
        {
            try
            {
                using (var con = ConexionDB.ObtenerConexion())
                using (var cmd = new SqlCommand(@"
                UPDATE Citas SET id_Clientes=@IdCliente, id_Servicios=@IdServicio,
                id_Estilista=@IdEstilista, Fecha=@Fecha, Estado=@Estado, Deposito=@Deposito
                WHERE id=@Id", con))
                //Solo actualiza solo cita que seleccionamos WHERE id=@Id
                {
                    cmd.Parameters.AddWithValue("@IdCliente", c.Id_Clientes);
                    cmd.Parameters.AddWithValue("@IdServicio", c.Id_Servicios);
                    cmd.Parameters.AddWithValue("@IdEstilista", c.Id_Estilista);
                    cmd.Parameters.AddWithValue("@Fecha", c.Fecha);
                    cmd.Parameters.AddWithValue("@Estado", c.Estado);
                    cmd.Parameters.AddWithValue("@Deposito", c.Deposito);
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