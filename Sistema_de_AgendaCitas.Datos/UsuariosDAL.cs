using Microsoft.Data.SqlClient;

namespace SistemaAgenda.Datos
{
    public class UsuariosDAL : IUsuariosDatos
    {
        public async Task<bool> InsertarAsync(Usuarios u)
        {
            try
            {
                using (var con = await ConexionDB.ObtenerConexionAsync())
                using (var cmd = new SqlCommand(@"
                INSERT INTO Usuarios (Usuario, Contrasena)
                VALUES (@Usuario, @Contrasena)", con))
                {
                    cmd.Parameters.AddWithValue("@Usuario", u.Usuario);
                    cmd.Parameters.AddWithValue("@Contrasena", u.Contrasena);
                    int filas = await cmd.ExecuteNonQueryAsync();
                    return filas > 0;
                }
            }
            catch (SqlException ex) when (ex.Number == 2627)
            {
                throw new Exception("Ese nombre de usuario ya existe, elige otro.");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar usuario: " + ex.Message);
            }
        }

        public async Task<Usuarios?> ObtenerPorUsuarioAsync(string usuario)
        {
            try
            {
                using (var con = await ConexionDB.ObtenerConexionAsync())
                using (var cmd = new SqlCommand(
                    "SELECT id, Usuario, Contrasena FROM Usuarios WHERE Usuario = @Usuario", con))
                {
                    cmd.Parameters.AddWithValue("@Usuario", usuario);
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
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

        public async Task<List<Usuarios>> ObtenerTodosAsync()
        {
            var lista = new List<Usuarios>();
            try
            {
                using (var con = await ConexionDB.ObtenerConexionAsync())
                using (var cmd = new SqlCommand("SELECT id, Usuario, Contrasena FROM Usuarios", con))
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
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

        public async Task<bool> ActualizarAsync(Usuarios u)
        {
            try
            {
                using (var con = await ConexionDB.ObtenerConexionAsync())
                using (var cmd = new SqlCommand(@"
                UPDATE Usuarios SET Usuario=@Usuario, Contrasena=@Contrasena
                WHERE id=@Id", con))
                {
                    cmd.Parameters.AddWithValue("@Usuario", u.Usuario);
                    cmd.Parameters.AddWithValue("@Contrasena", u.Contrasena);
                    cmd.Parameters.AddWithValue("@Id", u.Id);
                    int filas = await cmd.ExecuteNonQueryAsync();
                    return filas > 0;
                }
            }
            catch (SqlException ex) when (ex.Number == 2627)
            {
                throw new Exception("Ese nombre de usuario ya existe, elige otro.");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar usuario: " + ex.Message);
            }
        }

        public async Task<bool> EliminarAsync(int id)
        {
            try
            {
                using (var con = await ConexionDB.ObtenerConexionAsync())
                using (var cmd = new SqlCommand("DELETE FROM Usuarios WHERE id=@Id", con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    int filas = await cmd.ExecuteNonQueryAsync();
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