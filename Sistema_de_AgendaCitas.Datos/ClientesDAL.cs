using Microsoft.Data.SqlClient;

namespace SistemaAgenda.Datos
{
    public class ClientesDAL
    {
        public bool Insertar(Clientes c)
        {
            try
            {
                using (var con = ConexionDB.ObtenerConexion())
                using (var cmd = new SqlCommand(@"
                    INSERT INTO Clientes (Nombre, Apellido, Telefono, Correo, Cedula)
                    VALUES (@Nombre, @Apellido, @Telefono, @Correo, @Cedula)", con))
                {
                    cmd.Parameters.AddWithValue("@Nombre", c.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", c.Apellido);
                    cmd.Parameters.AddWithValue("@Telefono", c.Telefono);
                    cmd.Parameters.AddWithValue("@Correo", c.Correo);
                    cmd.Parameters.AddWithValue("@Cedula", c.Cedula);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (SqlException ex) when (ex.Number == 2627)
            {
                throw new Exception("Ese correo ya está registrado a otro cliente.");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar cliente: " + ex.Message);
            }
        }
        public List<Clientes> ObtenerTodos()
        {
            var lista = new List<Clientes>();
            try
            {
                using (var con = ConexionDB.ObtenerConexion())
                using (var cmd = new SqlCommand(
                    "SELECT id, Nombre, Apellido, Telefono, Correo, Cedula FROM Clientes", con))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Clientes
                        {
                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Apellido = reader.GetString(2),
                            Telefono = reader.GetString(3),
                            Correo = reader.GetString(4),
                            Cedula = reader.IsDBNull(5) ? "" : reader.GetString(5)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener clientes: " + ex.Message);
            }
            return lista;
        }public bool Actualizar(Clientes c)
        {
            try
            {
                using (var con = ConexionDB.ObtenerConexion())
                using (var cmd = new SqlCommand(@"
                    UPDATE Clientes SET Nombre=@Nombre, Apellido=@Apellido,
                    Telefono=@Telefono, Correo=@Correo, Cedula=@Cedula WHERE id=@Id", con))
                {
                    cmd.Parameters.AddWithValue("@Nombre", c.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", c.Apellido);
                    cmd.Parameters.AddWithValue("@Telefono", c.Telefono);
                    cmd.Parameters.AddWithValue("@Correo", c.Correo);
                    cmd.Parameters.AddWithValue("@Cedula", c.Cedula);
                    cmd.Parameters.AddWithValue("@Id", c.Id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (SqlException ex) when (ex.Number == 2627)
            {
                throw new Exception("Ese correo ya está registrado a otro cliente.");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar cliente: " + ex.Message);
            }
        }
        public bool Eliminar(int id)
        {
            try
            {
                using (var con = ConexionDB.ObtenerConexion())
                using (var cmd = new SqlCommand(
                    "DELETE FROM Clientes WHERE id=@Id", con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            //Error 547 = violación de llave foránea: el cliente tiene citas
            //en su historial (ya no se borran en cascada, así se conserva el historial)
            catch (SqlException ex) when (ex.Number == 547)
            {
                throw new Exception("No se puede eliminar el cliente: tiene citas registradas en su historial.");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar cliente: " + ex.Message);
            }
        }
    }
}