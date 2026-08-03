using System;
using System.Windows.Forms;

namespace SistemaAgenda.UI
{
    public partial class frmNotificaciones : Form
    {
        public frmNotificaciones()
        {
            InitializeComponent();
            CargarHistorial();
            // Si llega una notificación nueva mientras esta ventana está abierta, se refresca sola
            HistorialNotificaciones.NotificacionAgregada += HistorialNotificaciones_NotificacionAgregada;
            FormClosed += (s, e) => HistorialNotificaciones.NotificacionAgregada -= HistorialNotificaciones_NotificacionAgregada;
        }

        private void HistorialNotificaciones_NotificacionAgregada()
        {
            // El evento puede llegar desde otro hilo (timer), así que nos aseguramos de actualizar en el hilo de la UI
            if (InvokeRequired)
            {
                Invoke(new Action(CargarHistorial));
            }
            else
            {
                CargarHistorial();
            }
        }

        private void CargarHistorial()
        {
            lstNotificaciones.Items.Clear();

            var entradas = HistorialNotificaciones.ObtenerTodas();

            if (entradas.Count == 0)
            {
                var vacio = new ListViewItem("—");
                vacio.SubItems.Add("No hay notificaciones todavía.");
                lstNotificaciones.Items.Add(vacio);
                return;
            }

            foreach (var entrada in entradas)
            {
                var item = new ListViewItem(entrada.Fecha.ToString("dd/MM/yyyy hh:mm:ss tt"));
                item.SubItems.Add(entrada.Mensaje);
                lstNotificaciones.Items.Add(item);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            var confirmacion = MessageBox.Show(
                "¿Seguro que quieres borrar todo el historial de notificaciones?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                HistorialNotificaciones.Limpiar();
            }
        }
    }
}