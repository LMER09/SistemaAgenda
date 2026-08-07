using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using SistemaAgenda.Datos;

namespace SistemaAgenda.Negocios
{
    public delegate void RecordatorioDelegate(Citas? cita, string mensaje);

    public class RecordatorioCitas
    {
        private const string CorreoOrigen = "salonglowstyle@gmail.com";
        private const string ClaveApp = "zlbf qtjj hszq zkoc";

        public event RecordatorioDelegate? RecordatorioDisparado;

        public void EnviarRecordatorio(Citas? citas, string mensaje)
        {
            RecordatorioDisparado?.Invoke(citas, mensaje);
        }

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

        // Método convertido a Asíncrono para poder consultar los Clientes por BLL
        public async Task RevisarCitasProximasAsync(List<Citas> citas)
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

            // Obtenemos los clientes para buscar su correo y nombre
            var clientesBLL = new ClientesBLL();
            var clientes = await clientesBLL.ObtenerTodosAsync();

            for (int i = 0; i < proximas.Count; i++)
            {
                Citas cita = proximas[i];
                
                // Notifica por evento
                EnviarRecordatorio(cita, "Recordatorio: cita #" + cita.Id + " a las " + cita.Fecha.ToString("HH:mm"));

                // Busca el cliente correspondiente a la cita
                var cliente = clientes.FirstOrDefault(c => c.Id == cita.Id_Clientes);

                if (cliente != null && !string.IsNullOrEmpty(cliente.Correo))
                {
                    string nombreCompleto = $"{cliente.Nombre} {cliente.Apellido}";
                    
                    // Envía el correo con los datos reales del cliente
                    EnviarCorreo(cliente.Correo, nombreCompleto, cita.Fecha);
                }
            }
        }
    }
}