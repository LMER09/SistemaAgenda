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

            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClientes.Columns["Id"].Visible = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string texto = txtBuscar.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(texto))
            {
                dgvClientes.DataSource = null;
                dgvClientes.DataSource = listaClientes;
                return;
            }

            var resultado = listaClientes.Where(c =>
                c.Nombre.ToLower().Contains(texto) ||
                c.Apellido.ToLower().Contains(texto) ||
                c.Cedula.ToLower().Contains(texto)
            ).ToList();

            dgvClientes.DataSource = null;
            dgvClientes.DataSource = resultado;

            if (resultado.Count == 0)
                MessageBox.Show($"No se encontró ningún cliente que coincida con \"{txtBuscar.Text}\".",
                    "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un cliente de la tabla para editar.");
                return;
            }

            Clientes clienteSeleccionado = (Clientes)dgvClientes.CurrentRow.DataBoundItem;

            this.Hide();
            using (frmRegistrarClientes frmEditar = new frmRegistrarClientes(clienteSeleccionado))
            {
                frmEditar.ShowDialog();
            }
            this.Show();

            CargarClientes();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un cliente de la tabla para eliminar.");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Desea eliminar este cliente?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.No)
                return;

            int id = Convert.ToInt32(dgvClientes.CurrentRow.Cells["Id"].Value);
            MessageBox.Show(clientesBLL.Eliminar(id));

            CargarClientes();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}