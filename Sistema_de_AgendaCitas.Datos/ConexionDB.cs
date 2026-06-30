using Microsoft.Data.SqlClient;  

namespace SistemaAgenda.Datos
{
    public class ConexionDB
    {
        private static readonly string _cadena =

           @"Server=(local);Database=DB_Salon;" +
            "Trusted_Connection=True;TrustServerCertificate=True;";

        public static SqlConnection ObtenerConexion()
        {
            var conexion = new SqlConnection(_cadena);
            conexion.Open();
            return conexion;
        }
    }
}