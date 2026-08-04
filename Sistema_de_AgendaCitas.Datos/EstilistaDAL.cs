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
                    INSERT INTO Estilista (Nombre, Apellido, Telefono, Correo, Especialidad, Cedula)
                    VALUES (@Nombre, @Apellido, @Telefono, @Correo, @Especialidad, @Cedula)", con))
                {
                    cmd.Parameters.AddWithValue("@Nombre", e.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", e.Apellido);
                    cmd.Parameters.AddWithValue("@Telefono", e.Telefono);
                    cmd.Parameters.AddWithValue("@Correo", e.Correo);
                    cmd.Parameters.AddWithValue("@Especialidad", e.Especialidad);
                    cmd.Parameters.AddWithValue("@Cedula", e.Cedula);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (SqlException ex) when (ex.Number == 2627)
            {
                throw new Exception("Ese correo ya está registrado a otra estilista.");
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
                    "SELECT id, Nombre, Apellido, Telefono, Correo, Especialidad, Cedula FROM Estilista", con))
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
                            Especialidad = reader.GetString(5),
                            Cedula = reader.IsDBNull(6) ? "" : reader.GetString(6)
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
                    Telefono=@Telefono, Correo=@Correo, Especialidad=@Especialidad, Cedula=@Cedula
                    WHERE id=@Id", con))
                {
                    cmd.Parameters.AddWithValue("@Nombre", e.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", e.Apellido);
                    cmd.Parameters.AddWithValue("@Telefono", e.Telefono);
                    cmd.Parameters.AddWithValue("@Correo", e.Correo);
                    cmd.Parameters.AddWithValue("@Especialidad", e.Especialidad);
                    cmd.Parameters.AddWithValue("@Cedula", e.Cedula);
                    cmd.Parameters.AddWithValue("@Id", e.Id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (SqlException ex) when (ex.Number == 2627)
            {
                throw new Exception("Ese correo ya está registrado a otra estilista.");
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
            //TODO Error 547 = violación de llave foránea: la estilista tiene citas
            //TODO en su historial, o tiene un horario laboral asociado
            catch (SqlException ex) when (ex.Number == 547)
            {
                throw new Exception("No se puede eliminar la estilista: tiene citas u horario laboral registrados.");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar estilista: " + ex.Message);
            }
        }
    }
}