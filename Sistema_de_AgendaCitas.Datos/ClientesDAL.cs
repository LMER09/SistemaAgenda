using Microsoft.Data.SqlClient;

namespace SistemaAgenda.Datos
{
    public class ClientesDAL
    {
       
        public bool Insertar(Clientes c)
        {
            using (var con = ConexionDB.ObtenerConexion())
            using (var cmd = new SqlCommand(@"
                INSERT INTO Clientes (Nombre, Apellido, Telefono, Correo)
                VALUES (@Nombre, @Apellido, @Telefono, @Correo)", con))
            {
                cmd.Parameters.AddWithValue("@Nombre", c.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", c.Apellido);
                cmd.Parameters.AddWithValue("@Telefono", c.Telefono);
                cmd.Parameters.AddWithValue("@Correo", c.Correo);

                int filas = cmd.ExecuteNonQuery();
                return filas > 0;
            }
        }

        
        public List<Clientes> ObtenerTodos()
        {
            var lista = new List<Clientes>();

            using (var con = ConexionDB.ObtenerConexion())
            using (var cmd = new SqlCommand(
                "SELECT id, Nombre, Apellido, Telefono, Correo FROM Clientes", con))
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
                        Correo = reader.GetString(4)
                    });
                }
            }
            return lista;
        }

        
        public bool Actualizar(Clientes c)
        {
            using (var con = ConexionDB.ObtenerConexion())
            using (var cmd = new SqlCommand(@"
                UPDATE Clientes SET Nombre=@Nombre, Apellido=@Apellido,
                Telefono=@Telefono, Correo=@Correo WHERE id=@Id", con))
            {
                cmd.Parameters.AddWithValue("@Nombre", c.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", c.Apellido);
                cmd.Parameters.AddWithValue("@Telefono", c.Telefono);
                cmd.Parameters.AddWithValue("@Correo", c.Correo);
                cmd.Parameters.AddWithValue("@Id", c.Id);

                int filas = cmd.ExecuteNonQuery();
                return filas > 0;
            }
        }

        
        public bool Eliminar(int id)
        {
            using (var con = ConexionDB.ObtenerConexion())
            using (var cmd = new SqlCommand(
                "DELETE FROM Clientes WHERE id=@Id", con))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                int filas = cmd.ExecuteNonQuery();
                return filas > 0;
            }
        }
    }
}
