using Microsoft.Data.SqlClient;

namespace SistemaAgenda.Datos
{
    public class EstilistaDAL
    {
       
        public bool Insertar(Estilista e)
        {
            using (var con = ConexionDB.ObtenerConexion())
            using (var cmd = new SqlCommand(@"
                INSERT INTO Estilista (Nombre, Apellido, Telefono, Correo, Especialidad)
                VALUES (@Nombre, @Apellido, @Telefono, @Correo, @Especialidad)", con))
            {
                cmd.Parameters.AddWithValue("@Nombre", e.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", e.Apellido);
                cmd.Parameters.AddWithValue("@Telefono", e.Telefono);
                cmd.Parameters.AddWithValue("@Correo", e.Correo);
                cmd.Parameters.AddWithValue("@Especialidad", e.Especialidad);

                int filas = cmd.ExecuteNonQuery();
                return filas > 0;
            }
        }

        public List<Estilista> ObtenerTodos()
        {
            var lista = new List<Estilista>();

            using (var con = ConexionDB.ObtenerConexion())
            using (var cmd = new SqlCommand(
                "SELECT id, Nombre, Apellido, Telefono, Correo, Especialidad FROM Estilista", con))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    lista.Add(new Estilista
                    {
                        Id = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Apellido = reader.GetString(2),
                        Telefono = reader.GetString(3),
                        Correo = reader.GetString(4),
                        Especialidad = reader.GetString(5)
                    });
                }
            }
            return lista;
        }

       
        public bool Actualizar(Estilista e)
        {
            using (var con = ConexionDB.ObtenerConexion())
            using (var cmd = new SqlCommand(@"
                UPDATE Estilista SET Nombre=@Nombre, Apellido=@Apellido,
                Telefono=@Telefono, Correo=@Correo, Especialidad=@Especialidad
                WHERE id=@Id", con))
            {
                cmd.Parameters.AddWithValue("@Nombre", e.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", e.Apellido);
                cmd.Parameters.AddWithValue("@Telefono", e.Telefono);
                cmd.Parameters.AddWithValue("@Correo", e.Correo);
                cmd.Parameters.AddWithValue("@Especialidad", e.Especialidad);
                cmd.Parameters.AddWithValue("@Id", e.Id);

                int filas = cmd.ExecuteNonQuery();
                return filas > 0;
            }
        }

        public bool Eliminar(int id)
        {
            using (var con = ConexionDB.ObtenerConexion())
            using (var cmd = new SqlCommand(
                "DELETE FROM Estilista WHERE id=@Id", con))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                int filas = cmd.ExecuteNonQuery();
                return filas > 0;
            }
        }
    }
}