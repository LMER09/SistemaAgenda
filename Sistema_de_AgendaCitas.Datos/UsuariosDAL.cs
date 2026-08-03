using Microsoft.Data.SqlClient;

    namespace SistemaAgenda.Datos
    {
    public class UsuariosDAL : IUsuariosDatos
    {
            public bool Insertar(Usuarios u)
            {
                try
                {
                    //Abre la conexion a SQL
                    using (var con = ConexionDB.ObtenerConexion())
                    //Envia una consulta a SQL Server
                    using (var cmd = new SqlCommand(@"
                INSERT INTO Usuarios (Usuario, Contrasena)
                VALUES (@Usuario, @Contrasena)", con))
                    {
                        cmd.Parameters.AddWithValue("@Usuario", u.Usuario);
                        cmd.Parameters.AddWithValue("@Contrasena", u.Contrasena);

                        //Esta línea ejecuta el INSERT y devuelve cuantas filas fueron afectadas
                        int filas = cmd.ExecuteNonQuery();
                        return filas > 0;
                    }
                }
                //Error 2627 = violación de restricción UNIQUE: ese nombre de usuario ya existe
                catch (SqlException ex) when (ex.Number == 2627)
                {
                    throw new Exception("Ese nombre de usuario ya existe, elige otro.");
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al insertar usuario: " + ex.Message);
                }
            }
            public Usuarios? ObtenerPorUsuario(string usuario)
            {
                try
                {
                    using (var con = ConexionDB.ObtenerConexion())
                    using (var cmd = new SqlCommand(
                        "SELECT id, Usuario, Contrasena FROM Usuarios WHERE Usuario = @Usuario", con))
                    {
                        cmd.Parameters.AddWithValue("@Usuario", usuario);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Usuarios
                                {
                                    Id = reader.GetInt32(0),
                                    Usuario = reader.GetString(1),
                                    Contrasena = reader.GetString(2)
                                };
                            }
                        }
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al buscar usuario: " + ex.Message);
                }
            }

            public List<Usuarios> ObtenerTodos()
            {
                var lista = new List<Usuarios>();
                try
                {
                    using (var con = ConexionDB.ObtenerConexion())
                    using (var cmd = new SqlCommand(
                        "SELECT id, Usuario, Contrasena FROM Usuarios", con))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Usuarios
                            {
                                Id = reader.GetInt32(0),
                                Usuario = reader.GetString(1),
                                Contrasena = reader.GetString(2)
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener usuarios: " + ex.Message);
                }
                return lista;
            }

            public bool Actualizar(Usuarios u)
            {
                try
                {
                    using (var con = ConexionDB.ObtenerConexion())
                    using (var cmd = new SqlCommand(@"
                UPDATE Usuarios SET Usuario=@Usuario, Contrasena=@Contrasena
                WHERE id=@Id", con))
                    {
                        cmd.Parameters.AddWithValue("@Usuario", u.Usuario);
                        cmd.Parameters.AddWithValue("@Contrasena", u.Contrasena);
                        cmd.Parameters.AddWithValue("@Id", u.Id);

                        int filas = cmd.ExecuteNonQuery();
                        return filas > 0;
                    }
                }
                //Error 2627 = violación de restricción UNIQUE: ese nombre de usuario ya existe
                catch (SqlException ex) when (ex.Number == 2627)
                {
                    throw new Exception("Ese nombre de usuario ya existe, elige otro.");
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar usuario: " + ex.Message);
                }
            }

            public bool Eliminar(int id)
            {
                try
                {
                    using (var con = ConexionDB.ObtenerConexion())
                    using (var cmd = new SqlCommand(
                        "DELETE FROM Usuarios WHERE id=@Id", con))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        int filas = cmd.ExecuteNonQuery();
                        return filas > 0;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al eliminar usuario: " + ex.Message);
                }
            }
        }
    }
