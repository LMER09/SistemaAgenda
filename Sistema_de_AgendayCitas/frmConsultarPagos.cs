using SistemaAgenda.Negocios;
using System.Linq;

namespace SistemaAgenda.UI
{
    public partial class frmConsultarPagos : Form
    {
        private readonly PagosBLL pagosBLL = new PagosBLL();
        private List<Vistas> _listaPagos = new List<Vistas>();

        public frmConsultarPagos()
        {
            InitializeComponent();
        }

        private void frmConsultarPagos_Load(object sender, EventArgs e)
        {
            CargarPagos();
        }

        private void CargarPagos()
        {
            
            _listaPagos = pagosBLL.ObtenerVista();

            dgvPagos.DataSource = null;
            dgvPagos.DataSource = _listaPagos;

            dgvPagos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (dgvPagos.Columns["Id"] != null)
                dgvPagos.Columns["Id"].Visible = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string texto = txtBuscar.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(texto))
            {
                dgvPagos.DataSource = null;
                dgvPagos.DataSource = _listaPagos;
                return;
            }

            var resultado = _listaPagos.Where(p =>
                p.Cliente.ToLower().Contains(texto) ||
                p.Servicio.ToLower().Contains(texto) ||
                p.MetodoDePago.ToLower().Contains(texto)
            ).ToList();

            dgvPagos.DataSource = null;
            dgvPagos.DataSource = resultado;

            if (resultado.Count == 0)
                MessageBox.Show($"No se encontró ningún pago que coincida con \"{txtBuscar.Text}\".",
                    "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvPagos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un pago de la tabla para eliminar.");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Desea eliminar este pago? Esto no revierte el estado de la cita.",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.No)
                return;

            int id = Convert.ToInt32(dgvPagos.CurrentRow.Cells["Id"].Value);
            MessageBox.Show(pagosBLL.Eliminar(id));

            CargarPagos();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}