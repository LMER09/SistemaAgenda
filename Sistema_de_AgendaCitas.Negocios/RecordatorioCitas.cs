using System.Net.Mail;
using System.Net;
using SistemaAgenda.Datos;
namespace SistemaAgenda.Negocios
{
    //TODO Delegate: define la firma del método que manejará los recordatorios automáticos
    public delegate void RecordatorioDelegate(Citas cita, string mensaje);
    public class RecordatorioCitas
    {
        private const string CorreoOrigen = "salonglowstyle@gmail.com";
        private const string ClaveApp = "zlbf qtjj hszq zkoc";

        //Evento basado en el delegate: se dispara cuando hay citas próximas
        public event RecordatorioDelegate? RecordatorioDisparado;

        //Método que invoca el evento enviando el mensaje al usuario (frmAgenda)
        public void EnviarRecordatorio(Citas citas, string mensaje)
        {
            RecordatorioDisparado?.Invoke(citas, mensaje);
        }
        // Envía el correo de recordatorio al cliente
        public void EnviarCorreo(string correoDestino, string nombreCliente, DateTime fechaCita)
        {
            try
            {
                using (var mensaje = new MailMessage(CorreoOrigen, correoDestino))
                {
                    mensaje.Subject = "Recordatorio de tu cita";
                    mensaje.Body = $"Hola {nombreCliente}, te recordamos tu cita hoy a las {fechaCita:HH:mm}.";

                    using (var smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential(CorreoOrigen, ClaveApp);
                        smtp.EnableSsl = true;
                        smtp.Send(mensaje);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al enviar correo: " + ex.Message);
            }
        }


        // Revisa las citas pendientes y reprogramadas en la próxima hora y dispara un recordatorio por cada una
        public void RevisarCitasProximas(List<Citas> citas)
        {
            var proximas = new List<Citas>();

            for (int i = 0; i < citas.Count; i++)
            {
                Citas cita = citas[i];

                bool esValida = cita.Estado == "Pendiente" || cita.Estado == "Reprogramada";
                bool esDentroDeUnaHora = cita.Fecha >= DateTime.Now && cita.Fecha <= DateTime.Now.AddHours(1);

                if (esValida && esDentroDeUnaHora)
                {
                    proximas.Add(cita);
                }
            }

            if (proximas.Count == 0)
            {
                EnviarRecordatorio(null, "No hay citas próximas en la siguiente hora.");
                return;
            }

            for (int i = 0; i < proximas.Count; i++)
            {
                Citas cita = proximas[i];
                EnviarRecordatorio(cita, "Recordatorio: cita #" + cita.Id + " a las " + cita.Fecha.ToString("HH:mm"));
            }
        }

    }
}
