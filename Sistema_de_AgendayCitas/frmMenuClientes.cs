namespace SistemaAgenda.UI
{
    public partial class frmMenuClientes : Form
    {
        public frmMenuClientes()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            frmRegistrarClientes frm = new frmRegistrarClientes();
            frm.ShowDialog();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            frmConsultarClientes frm = new frmConsultarClientes();
            frm.ShowDialog();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

       
    }
}