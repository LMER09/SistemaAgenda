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
            // Muestra los pagos en la tabla
            dgvPagos.DataSource = pagos;

            decimal total = 0;

            for (int i = 0; i < pagos.Count; i++)
            {
                total = total + pagos[i].Monto;
            }

            lblTotal.Text = $"RD$ {total:F2}";
        }

        private void FrmReportes_Load(object sender, EventArgs e)
        {
            CargarPagos();
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
        }
    }
}
