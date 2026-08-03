using Microsoft.Data.SqlClient;

public class ConexionDB
{
    private static readonly string _cadena =
       @"Server=.;Database=DB_Salon;" +
        "Trusted_Connection=True;TrustServerCertificate=True;";

    // La dejamos por si algo viejo todavía la usa, pero ya no la vamos a llamar desde los DAL
    public static SqlConnection ObtenerConexion()
    {
        var conexion = new SqlConnection(_cadena);
        conexion.Open();
        return conexion;
    }

    public static async Task<SqlConnection> ObtenerConexionAsync()
    {
        var conexion = new SqlConnection(_cadena);
        await conexion.OpenAsync();
        return conexion;
    }
}