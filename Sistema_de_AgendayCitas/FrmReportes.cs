using SistemaAgenda.Negocios;
using SistemaAgenda.Datos;

namespace SistemaAgenda.UI
{
    public partial class frmReportes : Form
    {
        private PagosBLL pagosBLL = new PagosBLL();

        public frmReportes()
        {
            InitializeComponent();
        }

        private void CargarPagos()
        {
            // Solo los pagos de HOY, no todos los que ha tenido el sistema.
            var pagosHoy = pagosBLL.ObtenerPorFecha(DateTime.Today);

            dgvPagos.DataSource = null;
            dgvPagos.DataSource = pagosHoy;

            // La suma ya no se hace aqui con un for manual, la calcula PagosBLL.
            decimal total = pagosBLL.ObtenerTotal(pagosHoy);
            lblTotal.Text = $"RD$ {total:F2}";
        }

        private void FrmReportes_Load(object sender, EventArgs e)
        {
            CargarPagos();
        }

        private void btnCorteDia_Click(object sender, EventArgs e)
        {
            var pagosHoy = pagosBLL.ObtenerPorFecha(DateTime.Today);

            CorteDia corte = new CorteDia(DateTime.Today, pagosHoy);
            corte.Cerrar();

            MessageBox.Show(
                $"Corte del día generado.\nTotal: RD$ {corte.TotalDelDia:F2}\nPagos: {corte.CantidadDePagos}",
                "Corte del día");
        }
    }
}