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
            var pagos = pagosBLL.ObtenerTodos();

            dgvPagos.DataSource = null;
            dgvPagos.DataSource = pagos;

            decimal total = pagos.Sum(p => p.Monto);
            lblTotal.Text = $"RD$ {total:F2}";
        }

        private void FrmReportes_Load(object sender, EventArgs e)
        {
            CargarPagos();
        }

        private void btnCorteDia_Click(object sender, EventArgs e)
        {
            decimal total = pagosBLL.ObtenerTodos().Sum(p => p.Monto);

            
            CorteDia corte = new CorteDia(total);
            corte.Cerrar();


            MessageBox.Show($"Corte del día generado.\nTotal: RD$ {total:F2}", "Corte del día");
        }
    }
}
