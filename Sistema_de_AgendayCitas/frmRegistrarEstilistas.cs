using SistemaAgenda.Negocios;
using SistemaAgenda.Datos;

namespace SistemaAgenda.UI
{
    public partial class frmRegistrarEstilistas : Form
    {
        private EstilistaBLL estilistaBLL = new EstilistaBLL();
        private bool habilitado = false;

        public frmRegistrarEstilistas()
        {
            InitializeComponent();
            HabilitarControles(false);
        }

        // Alterna entre habilitado y deshabilitado con el mismo boton,
        // y deja claro al usuario en que estado esta (texto + color).
        private void HabilitarControles(bool habilitar)
        {
            habilitado = habilitar;

            txtNombre.Enabled = habilitar;
            txtApellido.Enabled = habilitar;
            txtTelefono.Enabled = habilitar;
            txtCorreo.Enabled = habilitar;
            txtCedula.Enabled = habilitar;
            txtEspecialidad.Enabled = habilitar;
            btnAgregar.Enabled = habilitar;

            if (habilitar)
            {
                btnHabilitar.Text = "🔒 Deshabilitar campos";
                btnHabilitar.BackColor = Color.Gray;
                lblResultado.Text = "Los campos están habilitados. Puede ingresar los datos.";
                lblResultado.ForeColor = Color.DarkGreen;
                txtNombre.Focus();
            }
            else
            {
                btnHabilitar.Text = "🔓 Habilitar campos";
                btnHabilitar.BackColor = Color.DeepPink;
                lblResultado.Text = "Los campos están deshabilitados. Presione \"Habilitar campos\" para ingresar un nuevo estilista.";
                lblResultado.ForeColor = Color.DimGray;
            }
        }

        private void btnHabilitar_Click(object sender, EventArgs e)
        {
            HabilitarControles(!habilitado);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Limpiar()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtCedula.Clear();
            txtEspecialidad.Clear();
        }

        private void FrmRegistrarEstilistas_Load(object sender, EventArgs e)
        {
            HabilitarControles(false);
        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                string.IsNullOrWhiteSpace(txtEspecialidad.Text))
            {
                MostrarResultado("Debe completar todos los campos.", esExito: false);
                return false;
            }

            if (!txtCorreo.Text.Contains("@") || !txtCorreo.Text.Contains("."))
            {
                MostrarResultado("Ingrese un correo válido.", esExito: false);
                txtCorreo.Focus();
                return false;
            }

            if (txtTelefono.Text.Length != 12)
            {
                MostrarResultado("Ingrese un teléfono válido (000-000-0000).", esExito: false);
                txtTelefono.Focus();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtCedula.Text) && txtCedula.Text.Length != 13)
            {
                MostrarResultado("Si ingresa cédula, debe tener el formato completo (000-0000000-0).", esExito: false);
                txtCedula.Focus();
                return false;
            }

            return true;
        }

        // Muestra el resultado del registro directamente en el formulario
        // (aqui ya no hay grid, asi que el label es la unica confirmacion visual)
        private void MostrarResultado(string mensaje, bool esExito)
        {
            lblResultado.Text = mensaje;
            lblResultado.ForeColor = esExito ? Color.DarkGreen : Color.Firebrick;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos())
                return;

            Estilista estilista = new Estilista
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Telefono = txtTelefono.Text,
                Correo = txtCorreo.Text,
                Cedula = txtCedula.Text.Trim(),
                Especialidad = txtEspecialidad.Text
            };

            string resultado = estilistaBLL.Registrar(estilista);
            bool exito = resultado.StartsWith("OK");

            MostrarResultado(exito ? "Estilista registrado exitosamente." : resultado, exito);

            if (exito)
            {
                Limpiar();
                txtNombre.Focus();
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
        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
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
        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }
    }
}