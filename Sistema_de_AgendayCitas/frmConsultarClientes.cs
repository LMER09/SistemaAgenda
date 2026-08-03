using SistemaAgenda.Negocios;
using SistemaAgenda.Datos;
using System.Linq;
  
namespace SistemaAgenda.UI
{
    public partial class frmConsultarClientes : Form
    {
        private ClientesBLL clientesBLL = new ClientesBLL();
        private List<Clientes> listaClientes = new List<Clientes>();

        public frmConsultarClientes()
        {
            InitializeComponent();
        }

        private void frmConsultarClientes_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }

        private void CargarClientes()
        {
            listaClientes = clientesBLL.ObtenerTodos();

            dgvClientes.DataSource = null;
            dgvClientes.DataSource = listaClientes;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lblBuscar_Click(object sender, EventArgs e)
        {
            string texto = txtBuscar.Text.ToLower();

            var resultado = listaClientes.Where(c =>
                c.Nombre.ToLower().Contains(texto) ||
                c.Apellido.ToLower().Contains(texto) ||
                c.Cedula.ToLower().Contains(texto)
            ).ToList();

            dgvClientes.DataSource = null;
            dgvClientes.DataSource = resultado;
        }
    }
}