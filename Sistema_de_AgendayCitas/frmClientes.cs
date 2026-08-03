using SistemaAgenda.Negocios;
using SistemaAgenda.Datos;
using System.Linq;

namespace SistemaAgenda.UI
{
    public partial class frmClientes : Form
    {

        private ClientesBLL clientesBLL = new ClientesBLL();
        private List<Clientes> _todosLosClientes = new List<Clientes>();
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
            _todosLosClientes = clientesBLL.ObtenerTodos();
            AplicarBusqueda();
        }

        // Filtra la lista de clientes según lo escrito en txtBuscar (nombre, apellido, teléfono o correo)
        private void AplicarBusqueda()
        {
            dgvClientes.DataSource = null;

            string texto = txtBuscar.Text.Trim();

            if (string.IsNullOrEmpty(texto))
            {
                dgvClientes.DataSource = _todosLosClientes;
                return;
            }

            dgvClientes.DataSource = _todosLosClientes.Where(c =>
                (c.Nombre?.Contains(texto, StringComparison.OrdinalIgnoreCase) ?? false) ||
                (c.Apellido?.Contains(texto, StringComparison.OrdinalIgnoreCase) ?? false) ||
                (c.Telefono?.Contains(texto, StringComparison.OrdinalIgnoreCase) ?? false) ||
                (c.Correo?.Contains(texto, StringComparison.OrdinalIgnoreCase) ?? false)
            ).ToList();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            AplicarBusqueda();
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

            CargarClientes(); Limpiar();
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

            CargarClientes(); Limpiar();
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvClientes.CurrentRow.Cells["Id"].Value);

                MessageBox.Show(clientesBLL.Eliminar(id));

                CargarClientes(); Limpiar();
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

        //Evita números en nombre/apellido
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }
        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }

        //Evita letras en teléfono
        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}