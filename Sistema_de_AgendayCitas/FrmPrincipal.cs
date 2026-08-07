using System;
using System.Linq;
using System.Windows.Forms;
using SistemaAgenda.Negocios;

namespace SistemaAgenda.UI
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }
        private async void AbrirFormulario(Form formulario)
        {
            this.Hide();
            formulario.ShowDialog();
            this.Show();
            await CargarResumenAsync();
        }
        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            this.Hide();
            using (FrmLogin login = new FrmLogin())
            {
                if (login.ShowDialog() == DialogResult.OK)
                {
                    this.Show();
                    _ = CargarResumenAsync();
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        // Calcula y muestra el resumen del dia
        private async Task CargarResumenAsync()
        {
            var citasBLL = new CitasBLL();
            var pagosBLL = new PagosBLL();

            var todasLasCitas = await citasBLL.ObtenerTodosAsync();
            var citasHoy = todasLasCitas
                .Where(c => c.Fecha.Date == DateTime.Today && c.Estado != "Cancelada")
                .ToList();

            var todosLosPagos = await pagosBLL.ObtenerTodosAsync();
            var pagosHoy = todosLosPagos
                .Where(p => p.FechaPago.Date == DateTime.Today)
                .ToList();

            lblCitasHoy.Text = $"📅 Citas hoy: {citasHoy.Count}";
            lblIngresosHoy.Text = $"💰 Ingresos hoy: RD$ {pagosHoy.Sum(p => p.Monto):F2}";

            var proxima = citasHoy
                .Where(c => c.Fecha >= DateTime.Now)
                .OrderBy(c => c.Fecha)
                .FirstOrDefault();

            lblProximaCita.Text = proxima != null
                ? $"⏰ Próxima cita: {proxima.Fecha:hh:mm tt}"
                : "⏰ Próxima cita: ninguna";
        }

        // ENTRADA ======================================

        private void btnAgenda_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmRegistrarCita());
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmRegistrarClientes());
        }

        private void btnServicios_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmRegistrarServicios());
        }

        private void btnEstilistas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmRegistrarEstilistas());
        }

        private void registrarPagoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmRegistrarPago());
        }

        private void registrarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmRegistrarUsuarios());
        }

        // CONSULTA ======================================

        private void verClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmConsultarClientes());
        }

        private void verEstilistaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmConsultarEstilistas());
        }

        private void verServicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmConsultarServicios());
        }

        private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmConsultarCitas());
        }

        private void reportesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmReportes());
        }

        private void verPagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmConsultarPagos());
        }

        private void verUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmConsultarUsuarios());
        }

        // SISTEMA ======================================

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
     "Sistema de Agenda y Citas\n\n" +
     "Versión 1.0\n\n" +
     "Desarrollado por:\n" +
     "• Novaly Pujols\n" +
     "• Luzmairy Espiritusanto\n" +
     "• Juan Manuel Contreras\n" +
     "• Mercy Báez 4\n\n" +
     "• Sebastian vargas\n\n" +
     "Proyecto Final\n" +
     "Ingeniería en Software\n\n" +
     "Universidad Central del Este (UCE)",
     "Acerca del sistema",
     MessageBoxButtons.OK,
     MessageBoxIcon.Information);
        }
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show(
                "¿Desea salir del sistema?",
                "Salir",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}