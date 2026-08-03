using Microsoft.Data.SqlClient;

namespace SistemaAgenda.Datos
{
    public class HorarioEstilistaDAL : IHorarioEstilistaDatos
    {
        public async Task<bool> InsertarAsync(HorarioEstilista h)
        {
            try
            {
                using (var con = await ConexionDB.ObtenerConexionAsync())
                using (var cmd = new SqlCommand(@"
                INSERT INTO HorarioEstilista (id_Estilista, DiaSemana, HoraInicio, HoraFin)
                VALUES (@IdEstilista, @DiaSemana, @HoraInicio, @HoraFin)", con))
                {
                    cmd.Parameters.AddWithValue("@IdEstilista", h.IdEstilista);
                    cmd.Parameters.AddWithValue("@DiaSemana", h.DiaSemana);
                    cmd.Parameters.AddWithValue("@HoraInicio", h.HoraInicio);
                    cmd.Parameters.AddWithValue("@HoraFin", h.HoraFin);
                    int filas = await cmd.ExecuteNonQueryAsync();
                    return filas > 0;
                }
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                throw new Exception("Verifica el horario: el día debe estar entre 0 y 6, la hora de inicio debe ser antes que la hora fin, y la estilista debe existir.");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar horario: " + ex.Message);
            }
        }

        public async Task<List<HorarioEstilista>> ObtenerTodosAsync()
        {
            var lista = new List<HorarioEstilista>();
            try
            {
                using (var con = await ConexionDB.ObtenerConexionAsync())
                using (var cmd = new SqlCommand(
                    "SELECT id, id_Estilista, DiaSemana, HoraInicio, HoraFin FROM HorarioEstilista", con))
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
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

        public async Task<List<HorarioEstilista>> ObtenerPorEstilistaAsync(int idEstilista)
        {
            var lista = new List<HorarioEstilista>();
            try
            {
                using (var con = await ConexionDB.ObtenerConexionAsync())
                using (var cmd = new SqlCommand(
                    "SELECT id, id_Estilista, DiaSemana, HoraInicio, HoraFin FROM HorarioEstilista WHERE id_Estilista = @IdEstilista", con))
                {
                    cmd.Parameters.AddWithValue("@IdEstilista", idEstilista);
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
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

        public async Task<bool> ActualizarAsync(HorarioEstilista h)
        {
            try
            {
                using (var con = await ConexionDB.ObtenerConexionAsync())
                using (var cmd = new SqlCommand(@"
                UPDATE HorarioEstilista SET id_Estilista=@IdEstilista, DiaSemana=@DiaSemana,
                HoraInicio=@HoraInicio, HoraFin=@HoraFin WHERE id=@Id", con))
                {
                    cmd.Parameters.AddWithValue("@IdEstilista", h.IdEstilista);
                    cmd.Parameters.AddWithValue("@DiaSemana", h.DiaSemana);
                    cmd.Parameters.AddWithValue("@HoraInicio", h.HoraInicio);
                    cmd.Parameters.AddWithValue("@HoraFin", h.HoraFin);
                    cmd.Parameters.AddWithValue("@Id", h.Id);
                    int filas = await cmd.ExecuteNonQueryAsync();
                    return filas > 0;
                }
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                throw new Exception("Verifica el horario: el día debe estar entre 0 y 6, la hora de inicio debe ser antes que la hora fin, y la estilista debe existir.");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar horario: " + ex.Message);
            }
        }

        public async Task<bool> EliminarAsync(int id)
        {
            try
            {
                using (var con = await ConexionDB.ObtenerConexionAsync())
                using (var cmd = new SqlCommand("DELETE FROM HorarioEstilista WHERE id=@Id", con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    int filas = await cmd.ExecuteNonQueryAsync();
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