using Microsoft.Data.SqlClient;

namespace SistemaAgenda.Datos
{
    public class ServiciosDAL
    {
        
        public bool Insertar(Servicios s)
        {
            using (var con = ConexionDB.ObtenerConexion())
            using (var cmd = new SqlCommand(@"
                INSERT INTO Servicios (Tipo_DeServicio, Precio, DuracionMinutos)
                VALUES (@Tipo, @Precio, @Duracion)", con))
            {
                cmd.Parameters.AddWithValue("@Tipo", s.Tipo_DeServicio);
                cmd.Parameters.AddWithValue("@Precio", s.Precio);
                cmd.Parameters.AddWithValue("@Duracion", s.DuracionMinutos);

                int filas = cmd.ExecuteNonQuery();
                return filas > 0;
            }
        }

        
        public List<Servicios> ObtenerTodos()
        {
            var lista = new List<Servicios>();

            using (var con = ConexionDB.ObtenerConexion())
            using (var cmd = new SqlCommand(
                "SELECT id, Tipo_DeServicio, Precio, DuracionMinutos FROM Servicios", con))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Servicios servicio;
                    string tipo = reader.GetString(1);

                    switch (tipo)
                    {
                        case "Cabello": servicio = new ServicioCabello();
                            break;
                        case "Uñas": servicio = new ServicioUñas();
                            break;
                        case "Spa": servicio = new ServicioSpa();
                            break;
                        default: throw new Exception("Tipo de servicio no valido");
                         
                    }

                    servicio.Id = reader.GetInt32(0);
                    servicio.Tipo_DeServicio = tipo;
                    servicio.Precio = reader.GetDecimal(2);
                    servicio.DuracionMinutos = reader.GetInt32(3);

                    lista.Add(servicio);
                }
            }
            return lista;
        }

        
        public bool Actualizar(Servicios s)
        {
            using (var con = ConexionDB.ObtenerConexion())
            using (var cmd = new SqlCommand(@"
                UPDATE Servicios SET Tipo_DeServicio=@Tipo,
                Precio=@Precio, DuracionMinutos=@Duracion
                WHERE id=@Id", con))
            {
                cmd.Parameters.AddWithValue("@Tipo", s.Tipo_DeServicio);
                cmd.Parameters.AddWithValue("@Precio", s.Precio);
                cmd.Parameters.AddWithValue("@Duracion", s.DuracionMinutos);
                cmd.Parameters.AddWithValue("@Id", s.Id);

                int filas = cmd.ExecuteNonQuery();
                return filas > 0;
            }
        }

        public bool Eliminar(int id)
        {
            using (var con = ConexionDB.ObtenerConexion())
            using (var cmd = new SqlCommand(
                "DELETE FROM Servicios WHERE id=@Id", con))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                int filas = cmd.ExecuteNonQuery();
                return filas > 0;
            }
        }
    }
}
