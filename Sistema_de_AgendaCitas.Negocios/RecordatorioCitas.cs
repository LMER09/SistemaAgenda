using SistemaAgenda.Datos;

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

        // Revisa las citas pendientes en la próxima hora y dispara un recordatorio por cada una
        public void RevisarCitasProximas(List<Citas> citas)
        {
            var proximas = new List<Citas>();

            for (int i = 0; i < citas.Count; i++)
            {
                Citas cita = citas[i];

                bool esPendiente = cita.Estado == "Pendiente";
                bool esDentroDeUnaHora = cita.Fecha >= DateTime.Now && cita.Fecha <= DateTime.Now.AddHours(1);

                if (esPendiente && esDentroDeUnaHora)
                {
                    proximas.Add(cita);
                }
            }

            if (proximas.Count == 0)
            {
                EnviarRecordatorio("No hay citas próximas en la siguiente hora.");
                return;
            }

            for (int i = 0; i < proximas.Count; i++)
            {
                Citas cita = proximas[i];
                EnviarRecordatorio("Recordatorio: cita #" + cita.Id + " a las " + cita.Fecha.ToString("HH:mm"));
            }
        }

    }
}
