using System;
using System.Linq;
using System.Windows.Forms;
using SistemaAgenda.Negocios;

namespace SistemaAgenda.UI
{
    public partial class frmPrincipal : Form
    {
        private readonly CitasBLL _citasBLL = new CitasBLL();
        private readonly PagosBLL _pagosBLL = new PagosBLL();

        public frmPrincipal()
        {
            InitializeComponent();
        }
        private void btnAgenda_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmAgenda());
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmClientes());
        }

        private void btnServicios_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmServicios());
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmReportes());
        }
        private void btnEstilistas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmEstilistas());
        }
        private void AbrirFormulario(Form formulario)
        {
            // Cuando cierras el formulario hijo (agendaste, cobraste, etc.)
            // el panel de resumen se refresca solo
            formulario.FormClosed += (s, e) => CargarResumen();
            formulario.Show();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            CargarResumen();
        }

        // Llena el panel de resumen: citas de hoy, ingresos de hoy y la próxima cita pendiente
        private void CargarResumen()
        {
            try
            {
                DateTime hoy = DateTime.Today;

                var citas = _citasBLL.ObtenerTodos();
                var pagos = _pagosBLL.ObtenerTodos();

                int citasHoy = citas.Count(c => c.Fecha.Date == hoy);
                lblResumenCitasHoyValor.Text = citasHoy.ToString();

                decimal ingresosHoy = pagos
                    .Where(p => p.FechaPago.Date == hoy)
                    .Sum(p => p.Monto);
                lblResumenIngresosHoyValor.Text = "RD$" + ingresosHoy.ToString("N2");

                var proxima = citas
                    .Where(c => c.Fecha >= DateTime.Now &&
                                (c.Estado == "Pendiente" || c.Estado == "Confirmada" || c.Estado == "Reprogramada"))
                    .OrderBy(c => c.Fecha)
                    .FirstOrDefault();

                lblResumenProximaCitaValor.Text = proxima == null
                    ? "No hay citas pendientes"
                    : proxima.Fecha.ToString("dd/MM/yyyy hh:mm tt");
            }
            catch (Exception ex)
            {
                lblResumenCitasHoyValor.Text = "-";
                lblResumenIngresosHoyValor.Text = "-";
                lblResumenProximaCitaValor.Text = "Error: " + ex.Message;
            }
        }

        private void btnNotificaciones_Click(object sender, EventArgs e)
        {
            new frmNotificaciones().Show();
        }
    }
}