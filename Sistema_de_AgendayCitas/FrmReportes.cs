using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SistemaAgenda.Negocios;
using SistemaAgenda.Datos;

namespace SistemaAgenda.UI
{
    public partial class frmReportes : Form
    {
        private PagosBLL pagosBLL = new PagosBLL();
        private CitasBLL citasBLL = new CitasBLL();

        public frmReportes()
        {
            InitializeComponent();
        }

        private void CargarPagos()
        {
            var pagos = pagosBLL.ObtenerTodos();

            dgvPagos.DataSource = null;
            // Muestra los pagos en la tabla
            dgvPagos.DataSource = pagos;

            decimal total = 0;

            for (int i = 0; i < pagos.Count; i++)
            {
                total = total + pagos[i].Monto;
            }

            lblTotal.Text = $"RD$ {total:F2}";
        }

        // Llena el panel de resumen: citas de hoy, ingresos de hoy y la próxima cita pendiente
        private void CargarResumen()
        {
            try
            {
                DateTime hoy = DateTime.Today;

                var citas = citasBLL.ObtenerTodos();
                var pagos = pagosBLL.ObtenerTodos();

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

        private void FrmReportes_Load(object sender, EventArgs e)
        {
            CargarPagos();
            CargarResumen();
        }

        private void btnCorteDia_Click(object sender, EventArgs e)
        {
            List<Pagos> pagos = pagosBLL.ObtenerTodos();

            decimal total = 0;

            for (int i = 0; i < pagos.Count; i++)
            {
                total += pagos[i].Monto;
            }

            CorteDia corte = new CorteDia(total);
            corte.Cerrar();
            MessageBox.Show($"Corte del día generado.\nTotal: RD$ {total:F2}", "Corte del día");
            CargarResumen();
        }

        private void lblResumenProximaCitaValor_Click(object sender, EventArgs e)
        {

        }

        private void btnNotificaciones_Click(object sender, EventArgs e)
        {
            new frmNotificaciones().Show();
        }

        private void lblResumenCitasHoyValor_Click(object sender, EventArgs e)
        {

        }
    }
}