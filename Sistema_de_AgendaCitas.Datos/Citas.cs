using SistemaAgenda.Datos;
using System.Collections.Generic;


public class Citas
{
    public int Id { get; set; }
    public int Id_Clientes { get; set; }
    public int Id_Servicios { get; set; }
    public int Id_Estilista { get; set; }
    public DateTime Fecha { get; set; }
    public string Estado { get; set; } = string.Empty;
    public decimal Deposito { get; set; }

}
