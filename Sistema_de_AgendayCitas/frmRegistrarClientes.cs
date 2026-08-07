using SistemaAgenda.Negocios;
using SistemaAgenda.Datos;

namespace SistemaAgenda.UI
{
    public partial class frmRegistrarClientes : Form
    {
        private ClientesBLL clientesBLL = new ClientesBLL();
        private bool habilitado = false;

        private Clientes? _clienteEditando = null;
        private bool ModoEdicion => _clienteEditando != null;
        public frmRegistrarClientes()
        {
            InitializeComponent();
            HabilitarControles(false);
        }
        public frmRegistrarClientes(Clientes cliente) : this()
        {
            _clienteEditando = cliente;
        }

        private void HabilitarControles(bool habilitar)
        {
            habilitado = habilitar;
            txtNombre.Enabled = habilitar;
            txtApellido.Enabled = habilitar;
            txtTelefono.Enabled = habilitar;
            txtCorreo.Enabled = habilitar;
            txtCedula.Enabled = habilitar;
            btnAgregar.Enabled = habilitar;

            if (habilitar)
            {
                btnHabilitar.Text = "🔒 Deshabilitar campos";
                btnHabilitar.BackColor = Color.Gray;
                lblResultado.Text = ModoEdicion
                    ? "Modifique los datos y presione \"Guardar cambios\"."
                    : "Los campos están habilitados. Puede ingresar los datos.";
                lblResultado.ForeColor = Color.DarkGreen;
                txtNombre.Focus();
            }
            else
            {
                btnHabilitar.Text = "🔓 Habilitar campos";
                btnHabilitar.BackColor = Color.DeepPink;
                lblResultado.Text = "Los campos están deshabilitados. Presione \"Habilitar campos\" para ingresar un nuevo cliente.";
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
        }

        private void frmRegistrarClientes_Load(object sender, EventArgs e)
        {
            if (ModoEdicion)
            {
                // Cambia la pantalla a "modo editar": titulo, boton, y los campos ya cargados y habilitados de una vez.
                this.Text = "Editar Cliente";
                lblIngrese.Text = "Editando cliente:";
                btnAgregar.Text = "💾 Guardar cambios";

                txtNombre.Text = _clienteEditando!.Nombre;
                txtApellido.Text = _clienteEditando.Apellido;
                txtTelefono.Text = _clienteEditando.Telefono;
                txtCorreo.Text = _clienteEditando.Correo;
                txtCedula.Text = _clienteEditando.Cedula;

                HabilitarControles(true);
            }
            else
            {
                HabilitarControles(false);
            }
        }

        // Valida que los datos del cliente sean correctos antes de guardar
        private bool ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                MostrarResultado("Debe completar todos los campos.", esExito: false);
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

            if (!txtCorreo.Text.Contains("@") || !txtCorreo.Text.Contains("."))
            {
                MostrarResultado("Ingrese un correo válido.", esExito: false);
                txtCorreo.Focus();
                return false;
            }

            return true;
        }
        private void MostrarResultado(string mensaje, bool esExito)
        {
            lblResultado.Text = mensaje;
            lblResultado.ForeColor = esExito ? Color.DarkGreen : Color.Firebrick;
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos())
                return;

            btnAgregar.Enabled = false;
            try
            {
                if (ModoEdicion)
                {
                    Clientes cliente = new Clientes
                    {
                        Id = _clienteEditando!.Id,
                        Nombre = txtNombre.Text,
                        Apellido = txtApellido.Text,
                        Telefono = txtTelefono.Text,
                        Correo = txtCorreo.Text,
                        Cedula = txtCedula.Text
                    };

                    string resultadoEdicion = await clientesBLL.ActualizarAsync(cliente);
                    bool exitoEdicion = resultadoEdicion.StartsWith("OK");

                    if (exitoEdicion)
                    {
                        MessageBox.Show("Cliente actualizado exitosamente.");
                        Close();
                    }
                    else
                    {
                        MostrarResultado(resultadoEdicion, esExito: false);
                    }
                    return;
                }

                Clientes nuevoCliente = new Clientes
                {
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Telefono = txtTelefono.Text,
                    Correo = txtCorreo.Text,
                    Cedula = txtCedula.Text
                };

                string resultado = await clientesBLL.RegistrarAsync(nuevoCliente);
                bool exito = resultado.StartsWith("OK");

                MostrarResultado(exito ? "Cliente registrado exitosamente." : resultado, exito);

                if (exito)
                {
                    Limpiar();
                    txtNombre.Focus();
                }
            }
            finally
            {
                btnAgregar.Enabled = true;
            }
        }

        //Evita numeros en nombre/apellido
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

        // Da formato automaticamente al telefono: 000-000-0000
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

        // Formato automatico de cedula: 000-0000000-0
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