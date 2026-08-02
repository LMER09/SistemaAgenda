using Microsoft.Data.SqlClient;

namespace SistemaAgenda.Datos
{
    public class HorarioEstilistaDAL
    {
        public bool Insertar(HorarioEstilista h)
        {
            try
            {
                using (var con = ConexionDB.ObtenerConexion())
                using (var cmd = new SqlCommand(@"
                INSERT INTO HorarioEstilista (id_Estilista, DiaSemana, HoraInicio, HoraFin)
                VALUES (@IdEstilista, @DiaSemana, @HoraInicio, @HoraFin)", con))
                {
                    cmd.Parameters.AddWithValue("@IdEstilista", h.IdEstilista);
                    cmd.Parameters.AddWithValue("@DiaSemana", h.DiaSemana);
                    cmd.Parameters.AddWithValue("@HoraInicio", h.HoraInicio);
                    cmd.Parameters.AddWithValue("@HoraFin", h.HoraFin);

                    int filas = cmd.ExecuteNonQuery();
                    return filas > 0;
                }
            }
            //Error 547 = violación de CHECK (día fuera de 0-6) o de FK (estilista inexistente),
            //o que HoraInicio no sea menor que HoraFin
            catch (SqlException ex) when (ex.Number == 547)
            {
                throw new Exception("Verifica el horario: el día debe estar entre 0 y 6, la hora de inicio debe ser antes que la hora fin, y la estilista debe existir.");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar horario: " + ex.Message);
            }
        }

        public List<HorarioEstilista> ObtenerTodos()
        {
            var lista = new List<HorarioEstilista>();
            try
            {
                using (var con = ConexionDB.ObtenerConexion())
                using (var cmd = new SqlCommand(
                    "SELECT id, id_Estilista, DiaSemana, HoraInicio, HoraFin FROM HorarioEstilista", con))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new HorarioEstilista
                        {
                            Id = reader.GetInt32(0),
                            IdEstilista = reader.GetInt32(1),
                            DiaSemana = reader.GetByte(2),
                            HoraInicio = reader.GetTimeSpan(3),
                            HoraFin = reader.GetTimeSpan(4)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener horarios: " + ex.Message);
            }
            return lista;
        }

        // Trae solo los bloques de horario de una estilista específica.
        // Pensado para que la capa de Negocios valide el día/hora de una cita nueva.
        public List<HorarioEstilista> ObtenerPorEstilista(int idEstilista)
        {
            var lista = new List<HorarioEstilista>();
            try
            {
                using (var con = ConexionDB.ObtenerConexion())
                using (var cmd = new SqlCommand(
                    "SELECT id, id_Estilista, DiaSemana, HoraInicio, HoraFin FROM HorarioEstilista WHERE id_Estilista = @IdEstilista", con))
                {
                    cmd.Parameters.AddWithValue("@IdEstilista", idEstilista);
                    //lee los registros uno por uno
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new HorarioEstilista
                            {
                                Id = reader.GetInt32(0),
                                IdEstilista = reader.GetInt32(1),
                                DiaSemana = reader.GetByte(2),
                                HoraInicio = reader.GetTimeSpan(3),
                                HoraFin = reader.GetTimeSpan(4)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener horario de la estilista: " + ex.Message);
            }
            return lista;
        }

        public bool Actualizar(HorarioEstilista h)
        {
            try
            {
                using (var con = ConexionDB.ObtenerConexion())
                using (var cmd = new SqlCommand(@"
                UPDATE HorarioEstilista SET id_Estilista=@IdEstilista, DiaSemana=@DiaSemana,
                HoraInicio=@HoraInicio, HoraFin=@HoraFin WHERE id=@Id", con))
                {
                    cmd.Parameters.AddWithValue("@IdEstilista", h.IdEstilista);
                    cmd.Parameters.AddWithValue("@DiaSemana", h.DiaSemana);
                    cmd.Parameters.AddWithValue("@HoraInicio", h.HoraInicio);
                    cmd.Parameters.AddWithValue("@HoraFin", h.HoraFin);
                    cmd.Parameters.AddWithValue("@Id", h.Id);

                    int filas = cmd.ExecuteNonQuery();
                    return filas > 0;
                }
            }
            //Error 547 = violación de CHECK (día fuera de 0-6) o de FK (estilista inexistente),
            //o que HoraInicio no sea menor que HoraFin
            catch (SqlException ex) when (ex.Number == 547)
            {
                throw new Exception("Verifica el horario: el día debe estar entre 0 y 6, la hora de inicio debe ser antes que la hora fin, y la estilista debe existir.");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar horario: " + ex.Message);
            }
        }

        public bool Eliminar(int id)
        {
            try
            {
                using (var con = ConexionDB.ObtenerConexion())
                using (var cmd = new SqlCommand(
                    "DELETE FROM HorarioEstilista WHERE id=@Id", con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    int filas = cmd.ExecuteNonQuery();
                    return filas > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar horario: " + ex.Message);
            }
        }
    }
}