
using SistemaAgenda.Negocios;
using SistemaAgenda.Datos;

namespace SistemaAgenda.UI
{
    public partial class frmClientes : Form
    {
        private ClientesBLL clientesBLL = new ClientesBLL();


        public frmClientes()
        {
            InitializeComponent();
        }
        private void Limpiar()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtNombre.Focus();
        }

        private void CargarClientes()
        {
            dgvClientes.DataSource = null;
            dgvClientes.DataSource = clientesBLL.ObtenerTodos();
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Clientes cliente = new Clientes();

            cliente.Nombre = txtNombre.Text;
            cliente.Apellido = txtApellido.Text;
            cliente.Telefono = txtTelefono.Text;
            cliente.Correo = txtCorreo.Text;

            MessageBox.Show(clientesBLL.Registrar(cliente));

            CargarClientes();
            Limpiar();
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            Clientes cliente = new Clientes();

            if (dgvClientes.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un cliente.");
                return;
            }

            cliente.Id = Convert.ToInt32(dgvClientes.CurrentRow.Cells["Id"].Value);
            cliente.Nombre = txtNombre.Text;
            cliente.Apellido = txtApellido.Text;
            cliente.Telefono = txtTelefono.Text;
            cliente.Correo = txtCorreo.Text;

            MessageBox.Show(clientesBLL.Actualizar(cliente));

            CargarClientes();
            Limpiar();
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvClientes.CurrentRow.Cells["Id"].Value);

                MessageBox.Show(clientesBLL.Eliminar(id));

                CargarClientes();
                Limpiar();
            }
            else
            {
                MessageBox.Show("Seleccione un cliente.");
            }
        }
        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtNombre.Text = dgvClientes.CurrentRow.Cells["Nombre"].Value.ToString();
                txtApellido.Text = dgvClientes.CurrentRow.Cells["Apellido"].Value.ToString();
                txtTelefono.Text = dgvClientes.CurrentRow.Cells["Telefono"].Value.ToString();
                txtCorreo.Text = dgvClientes.CurrentRow.Cells["Correo"].Value.ToString();
            }
        }


    }
}
