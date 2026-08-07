using SistemaAgenda.Negocios;

namespace SistemaAgenda.UI
{
    public partial class frmNotificaciones : Form
    {
        public frmNotificaciones()
        {
            InitializeComponent();
        }

        private void frmNotificaciones_Load(object sender, EventArgs e)
        {
            CargarNotificaciones();
        }

        private void CargarNotificaciones()
        {
            var lista = HistorialNotificaciones.ObtenerTodas();

            dgvNotificaciones.DataSource = null;
            dgvNotificaciones.DataSource = lista;

            dgvNotificaciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            lblVacio.Visible = lista.Count == 0;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarNotificaciones();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}