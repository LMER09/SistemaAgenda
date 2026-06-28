using Microsoft.Data.SqlClient;

namespace SistemaAgenda.Datos
{
    public class EstilistaDAL
    {
        public bool Insertar(Estilista e)
        {
            try
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
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar estilista: " + ex.Message);
            }
        }

        public List<Estilista> ObtenerTodos()
        {
            var lista = new List<Estilista>();
            try
            {
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
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener estilistas: " + ex.Message);
            }
            return lista;
        }

        public bool Actualizar(Estilista e)
        {
            try
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
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar estilista: " + ex.Message);
            }
        }

        public bool Eliminar(int id)
        {
            try
            {
                using (var con = ConexionDB.ObtenerConexion())
                using (var cmd = new SqlCommand(
                    "DELETE FROM Estilista WHERE id=@Id", con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar estilista: " + ex.Message);
            }
        }
    }
}