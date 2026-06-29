namespace SistemaAgenda.Negocios
{
    public delegate void RecordatorioDelegate(string mensaje);
    public class RecordatorioCitas
    {
        public event RecordatorioDelegate? RecordatorioDisparado;
        public void EnviarRecordatorio(string mensaje)
        {
            RecordatorioDisparado?.Invoke(mensaje);
        }
    }
}
