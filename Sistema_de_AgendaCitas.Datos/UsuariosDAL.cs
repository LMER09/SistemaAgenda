
    using Microsoft.Data.SqlClient;
using System.Collections;

    namespace SistemaAgenda.Datos
    {
        public class UsuariosDAL
        {
            public bool Insertar(Usuarios u)
            {
                try
                {
                    using (var con = ConexionDB.ObtenerConexion())
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
                //TODO ERROR 2627 = violación de restricción UNIQUE:Ese nombre de usuario ya existe
                catch (SqlException ex) when (ex.Number == 2627)
                {
                    throw new Exception("Ese nombre de usuario ya existe, elige otro.");
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al insertar usuario: " + ex.Message);
                }
            }
            // TODO ObtenerTodos: Lee todas las filas, una por una hasta que no queden más
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

            //TODO METODO NUEVO: ObtenerPorUsuario: solo lee la PRIMERA fila que coincida.
            //El "?" indica que el método puede devolver null si el usuario no existe en la BD.
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
                //ERROR 2627 = violación de restricción UNIQUE: Ese nombre de usuario ya existe
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