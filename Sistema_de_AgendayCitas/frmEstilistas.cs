
using SistemaAgenda.Negocios;
using SistemaAgenda.Datos;

namespace SistemaAgenda.UI
{
    public partial class frmEstilistas : Form
    {
        private EstilistaBLL estilistaBLL = new EstilistaBLL();
        public frmEstilistas()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtEspecialidad.Clear();
            txtNombre.Focus();
        }
        private void CargarEstilistas()
        {
            dgvEstilistas.DataSource = null;
            dgvEstilistas.DataSource = estilistaBLL.ObtenerTodos();
        }
        private void FrmEstilistas_Load(object sender, EventArgs e)
        {
            CargarEstilistas();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Estilista estilista = new Estilista();

            estilista.Nombre = txtNombre.Text;
            estilista.Apellido = txtApellido.Text;
            estilista.Telefono = txtTelefono.Text;
            estilista.Correo = txtCorreo.Text;
            estilista.Cedula = txtCedula.Text.Trim();
            estilista.Especialidad = txtEspecialidad.Text;

            MessageBox.Show(estilistaBLL.Registrar(estilista));

            CargarEstilistas(); Limpiar();


        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Debe ingresar el nombre.");
                txtNombre.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("Debe ingresar el apellido.");
                txtApellido.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MessageBox.Show("Debe ingresar el teléfono.");
                txtTelefono.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                MessageBox.Show("Debe ingresar el correo.");
                txtCorreo.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCedula.Text))
            {
                MessageBox.Show("Debe ingresar la cédula.");
                txtCedula.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEspecialidad.Text))
            {
                MessageBox.Show("Debe ingresar la especialidad.");
                txtEspecialidad.Focus();
                return false;
            }

            return true;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvEstilistas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un estilista.");
                return;
            }

            Estilista estilista = new Estilista();
            estilista.Id = Convert.ToInt32(dgvEstilistas.CurrentRow.Cells["Id"].Value);
            estilista.Nombre = txtNombre.Text;
            estilista.Apellido = txtApellido.Text;
            estilista.Telefono = txtTelefono.Text;
            estilista.Correo = txtCorreo.Text;
            estilista.Especialidad = txtEspecialidad.Text;

            MessageBox.Show(estilistaBLL.Actualizar(estilista));

            CargarEstilistas(); Limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvEstilistas.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvEstilistas.CurrentRow.Cells["Id"].Value);

                MessageBox.Show(estilistaBLL.Eliminar(id));

                CargarEstilistas(); Limpiar();
            }
            else
            {
                MessageBox.Show("Seleccione un estilista.");
            }
        }

        private void dgvEstilistas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtNombre.Text = dgvEstilistas.CurrentRow.Cells["Nombre"].Value.ToString();
                txtApellido.Text = dgvEstilistas.CurrentRow.Cells["Apellido"].Value.ToString();
                txtTelefono.Text = dgvEstilistas.CurrentRow.Cells["Telefono"].Value.ToString();
                txtCorreo.Text = dgvEstilistas.CurrentRow.Cells["Correo"].Value.ToString();
                txtEspecialidad.Text = dgvEstilistas.CurrentRow.Cells["Especialidad"].Value.ToString();
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

        private void lblCedula_Click(object sender, EventArgs e)
        {

        }
    }
}
