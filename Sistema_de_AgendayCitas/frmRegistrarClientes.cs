using SistemaAgenda.Negocios;
using SistemaAgenda.Datos;

namespace SistemaAgenda.UI
{
    public partial class frmRegistrarClientes : Form
    {

        private ClientesBLL clientesBLL = new ClientesBLL();
        public frmRegistrarClientes()
        {
            InitializeComponent();

            HabilitarControles(false);
        }

        private void HabilitarControles(bool habilitar)
        {
            txtNombre.Enabled = habilitar;
            txtApellido.Enabled = habilitar;
            txtTelefono.Enabled = habilitar;
            txtCorreo.Enabled = habilitar;
            txtCedula.Enabled = habilitar;


            btnAgregar.Enabled = habilitar;
            btnEditar.Enabled = habilitar;
            btnEliminar.Enabled = habilitar;
            btnLimpiar.Enabled = habilitar;

        }
        private void Limpiar()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtCedula.Clear();
            txtNombre.Focus();
        }

        private void CargarClientes()
        {
            dgvClientes.DataSource = null;
            dgvClientes.DataSource = clientesBLL.ObtenerTodos();
            // Ajusta automáticamente el ancho de todas las columnas
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Asigna un ancho mayor a la columna Cédula
            dgvClientes.Columns["Cedula"].FillWeight = 120;
            // Ocultar la columna Id
            dgvClientes.Columns["Id"].Visible = false;

            // Ajustar el ancho de las columnas
            dgvClientes.Columns["Nombre"].Width = 110;
            dgvClientes.Columns["Apellido"].Width = 110;
            dgvClientes.Columns["Telefono"].Width = 110;
            dgvClientes.Columns["Correo"].Width = 170;
            dgvClientes.Columns["Cedula"].Width = 120;
        }

        private void frmRegistrarClientes_Load(object sender, EventArgs e)
        {
            HabilitarControles(false);
            CargarClientes();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Clientes cliente = new Clientes();

            cliente.Nombre = txtNombre.Text;
            cliente.Apellido = txtApellido.Text;
            cliente.Telefono = txtTelefono.Text;
            cliente.Correo = txtCorreo.Text;
            cliente.Cedula = txtCedula.Text;

            // Valida los datos antes de registrar
            if (!ValidarDatos())
                return;

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
            cliente.Cedula = txtCedula.Text;

            MessageBox.Show(clientesBLL.Actualizar(cliente));

            CargarClientes(); Limpiar();
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow != null)
            {
                DialogResult respuesta = MessageBox.Show(
                    "¿Desea eliminar este cliente?",
                    "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

                if (respuesta == DialogResult.No)
                    return;

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
                txtCedula.Text = dgvClientes.CurrentRow.Cells["Cedula"].Value?.ToString() ?? "";
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


        // Da formato automáticamente al teléfono: 000-000-0000
        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            string texto = txtTelefono.Text.Replace("-", "");

            if (texto.Length > 10)
                texto = texto.Substring(0, 10);

            if (texto.Length > 3)
                texto = texto.Insert(3, "-");

            if (texto.Length > 7)
                texto = texto.Insert(7, "-");

            txtTelefono.Text = texto;
            txtTelefono.SelectionStart = txtTelefono.Text.Length;
        }
        // Permite únicamente números y la tecla Retroceso
        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) &&
                e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        // Valida que los datos del cliente sean correctos antes de guardar o editar
        private bool ValidarDatos()
        {
            // Verifica que todos los campos estén completos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                MessageBox.Show("Debe completar todos los campos.",
                                "Campos obligatorios",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return false;
            }

            // Verifica que el teléfono tenga el formato completo (000-000-0000)
            if (txtTelefono.Text.Length != 12)
            {
                MessageBox.Show("Ingrese un teléfono válido.",
                                "Teléfono",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                txtTelefono.Focus();
                return false;
            }

            // Verifica que la cédula tenga el formato completo (000-0000000-0)
            if (!string.IsNullOrWhiteSpace(txtCedula.Text) && txtCedula.Text.Length != 13)
            {
                MessageBox.Show("Si ingresa cédula, debe tener el formato completo (000-0000000-0).",
                        "Cédula",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                txtCedula.Focus();
                return false;
            }

            // Verifica que el correo tenga un formato básico válido
            if (!txtCorreo.Text.Contains("@") || !txtCorreo.Text.Contains("."))
            {
                MessageBox.Show("Ingrese un correo válido.",
                                "Correo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                txtCorreo.Focus();
                return false;
            }

            return true;
        }
        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            HabilitarControles(true);

            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtCedula.Clear();

            txtNombre.Focus();
        }

        // Formato automático de cédula: 000-0000000-0
        private void txtCedula_TextChanged(object sender, EventArgs e)
        {
            string texto = txtCedula.Text.Replace("-", "");

            if (texto.Length > 11)
                texto = texto.Substring(0, 11);

            if (texto.Length > 3)
                texto = texto.Insert(3, "-");

            if (texto.Length > 11)
                texto = texto.Insert(11, "-");

            txtCedula.Text = texto;
            txtCedula.SelectionStart = txtCedula.Text.Length;
        }
        // Permite únicamente números y la tecla Retroceso
        // Solo permite escribir números y la tecla Retroceso (Backspace)
        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) &&
                e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Bloquea cualquier letra o símbolo
            }
        }
    }
}
