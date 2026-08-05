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

        // Metodo para abrir cualquier formulario.
        // Se oculta el principal mientras la otra pantalla esta abierta,
        // asi solo queda visible la que el usuario eligio, y el principal
        // vuelve a aparecer automaticamente cuando esa pantalla se cierra.
        private void AbrirFormulario(Form formulario)
        {
            this.Hide();
            formulario.ShowDialog();
            this.Show();

            // Cada vez que se vuelve al Principal (por ejemplo, tras agendar
            // una cita o registrar un pago), se refresca el resumen del dia.
            CargarResumen();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            this.Hide();
            using (FrmLogin login = new FrmLogin())
            {
                if (login.ShowDialog() == DialogResult.OK)
                {
                    this.Show();
                    CargarResumen();
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        // Calcula y muestra el resumen del dia: citas de hoy, ingresos de hoy,
        // y la proxima cita pendiente. Se apoya en los mismos BLL que ya usan
        // el resto de los formularios, no accede a la base de datos directo.
        private void CargarResumen()
        {
            var citasBLL = new CitasBLL();
            var pagosBLL = new PagosBLL();

            var citasHoy = citasBLL.ObtenerTodos()
                .Where(c => c.Fecha.Date == DateTime.Today && c.Estado != "Cancelada")
                .ToList();

            var pagosHoy = pagosBLL.ObtenerTodos()
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

        // ======================================
        // ENTRADA
        // ======================================

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

        // ======================================
        // CONSULTA
        // ======================================

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

        // ======================================
        // SISTEMA
        // ======================================

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