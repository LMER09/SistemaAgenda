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

        private async Task CargarPagosAsync()
        {
            var pagos = await pagosBLL.ObtenerTodosAsync();

            dgvPagos.DataSource = null;
            dgvPagos.DataSource = pagos;

            decimal total = 0;

            for (int i = 0; i < pagos.Count; i++)
            {
                total = total + pagos[i].Monto;
            }

            lblTotal.Text = $"RD$ {total:F2}";
        }

        private async void FrmReportes_Load(object sender, EventArgs e)
        {
            await CargarPagosAsync();
        }

        private async void btnCorteDia_Click(object sender, EventArgs e)
        {
            List<Pagos> pagos = await pagosBLL.ObtenerTodosAsync();

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