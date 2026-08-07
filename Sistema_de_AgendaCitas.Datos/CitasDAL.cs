using Microsoft.Data.SqlClient;

namespace SistemaAgenda.Datos
{
    public class CitasDAL : ICitasDAL
    {
        public async Task<bool> InsertarAsync(Citas c)
        {
            try
            {
                //Abre la conexion a SQL de forma asincrona
                using (var con = await ConexionDB.ObtenerConexionAsync())
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

                    //Esta línea ejecuta el INSERT sin bloquear el hilo y devuelve cuantas filas fueron afectadas
                    int filas = await cmd.ExecuteNonQueryAsync();
                    return filas > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar cita: " + ex.Message);
            }
        }
        public async Task<List<Citas>> ObtenerTodosAsync()
        {
            var lista = new List<Citas>();
            try
            {
                using (var con = await ConexionDB.ObtenerConexionAsync())
                using (var cmd = new SqlCommand(
                    "SELECT id, id_Clientes, id_Servicios, id_Estilista, Fecha, Estado, Deposito FROM Citas", con))
                //lee los registros uno por uno de forma asincrona
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
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
        public async Task<bool> ActualizarAsync(Citas c)
        {
            try
            {
                using (var con = await ConexionDB.ObtenerConexionAsync())
                using (var cmd = new SqlCommand(@"
                UPDATE Citas SET id_Clientes=@IdCliente, id_Servicios=@IdServicio,
                id_Estilista=@IdEstilista, Fecha=@Fecha, Estado=@Estado, Deposito=@Deposito
                WHERE id=@Id", con))
                //Solo actualiza la cita que seleccionamos WHERE id=@Id
                {
                    cmd.Parameters.AddWithValue("@IdCliente", c.Id_Clientes);
                    cmd.Parameters.AddWithValue("@IdServicio", c.Id_Servicios);
                    cmd.Parameters.AddWithValue("@IdEstilista", c.Id_Estilista);
                    cmd.Parameters.AddWithValue("@Fecha", c.Fecha);
                    cmd.Parameters.AddWithValue("@Estado", c.Estado);
                    cmd.Parameters.AddWithValue("@Deposito", c.Deposito);
                    cmd.Parameters.AddWithValue("@Id", c.Id);

                    int filas = await cmd.ExecuteNonQueryAsync();
                    return filas > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar cita: " + ex.Message);
            }
        }
        public async Task<bool> EliminarAsync(int id)
        {
            try
            {
                using (var con = await ConexionDB.ObtenerConexionAsync())
                using (var cmd = new SqlCommand(
                    "DELETE FROM Citas WHERE id=@Id", con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    int filas = await cmd.ExecuteNonQueryAsync();
                    return filas > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar cita: " + ex.Message);
            }
        }
        // TODO METODO NUEVO: ObtenerPorEstilistaYFechaAsyn
        // Trae las citas de un estilista en una fecha/hora exacta.
        public async Task<List<Citas>> ObtenerPorEstilistaYFechaAsync(int idEstilista, DateTime fecha)
        {
            var lista = new List<Citas>();
            try
            {
                using (var con = await ConexionDB.ObtenerConexionAsync())
                using (var cmd = new SqlCommand(@"
                    SELECT id, id_Clientes, id_Servicios, id_Estilista, Fecha, Estado, Deposito
                    FROM Citas
                    WHERE id_Estilista = @IdEstilista AND Fecha = @Fecha", con))
                {
                    cmd.Parameters.AddWithValue("@IdEstilista", idEstilista);
                    cmd.Parameters.AddWithValue("@Fecha", fecha);
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
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
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener citas del estilista: " + ex.Message);
            }
            return lista;
        }
    }
}