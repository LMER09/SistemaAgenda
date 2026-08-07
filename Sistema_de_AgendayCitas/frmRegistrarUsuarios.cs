using SistemaAgenda.Negocios;
using SistemaAgenda.Datos;

namespace SistemaAgenda.UI
{
    public partial class frmRegistrarUsuarios : Form
    {
        private UsuariosBLL usuariosBLL = new UsuariosBLL();
        private bool habilitado = false;

        // Si no es null, el formulario esta editando este usuario en vez de crear uno nuevo
        private Usuarios? _usuarioEditando = null;
        private bool ModoEdicion => _usuarioEditando != null;

        // Constructor normal: registrar un usuario nuevo
        public frmRegistrarUsuarios()
        {
            InitializeComponent();
            HabilitarControles(false);
        }

        // Constructor de edicion: recibe el usuario ya existente
        public frmRegistrarUsuarios(Usuarios usuario) : this()
        {
            _usuarioEditando = usuario;
        }

        // Habilita o deshabilita los campos y el boton de guardar
        private void HabilitarControles(bool habilitar)
        {
            habilitado = habilitar;

            txtContrasenaActual.Enabled = habilitar;
            txtUsuario.Enabled = habilitar;
            txtContrasena.Enabled = habilitar;
            txtConfirmarContrasena.Enabled = habilitar;
            btnAgregar.Enabled = habilitar;

            if (habilitar)
            {
                btnHabilitar.Text = "🔒 Deshabilitar campos";
                btnHabilitar.BackColor = Color.Gray;
                lblResultado.Text = ModoEdicion
                    ? "Modifique los datos y presione \"Guardar cambios\"."
                    : "Los campos están habilitados. Puede ingresar los datos.";
                lblResultado.ForeColor = Color.DarkGreen;
                txtUsuario.Focus();
            }
            else
            {
                btnHabilitar.Text = "🔓 Habilitar campos";
                btnHabilitar.BackColor = Color.DeepPink;
                lblResultado.Text = "Los campos están deshabilitados. Presione \"Habilitar campos\" para ingresar un nuevo usuario.";
                lblResultado.ForeColor = Color.DimGray;
            }
        }
        // Alterna entre habilitado y deshabilitado
        private void btnHabilitar_Click(object sender, EventArgs e)
        {
            HabilitarControles(!habilitado);
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Vacia todos los campos, para dejar el formulario listo para otro registro
        private void Limpiar()
        {
            txtUsuario.Clear();
            txtContrasenaActual.Clear();
            txtContrasena.Clear();
            txtConfirmarContrasena.Clear();
        }

        // Si esta en modo edicion, precarga el usuario y muestra el campo de contraseña actual
        private void frmRegistrarUsuarios_Load(object sender, EventArgs e)
        {
            if (ModoEdicion)
            {
                this.Text = "Editar Usuario";
                lblIngrese.Text = "Editando usuario:";
                btnAgregar.Text = "💾 Guardar cambios";

                txtUsuario.Text = _usuarioEditando!.Usuario;

                lblContrasenaActual.Visible = true;
                txtContrasenaActual.Visible = true;
                lblAyudaContrasena.Visible = true;

                HabilitarControles(true);
            }
            else
            {
                lblContrasenaActual.Visible = false;
                txtContrasenaActual.Visible = false;
                lblAyudaContrasena.Visible = false;
                HabilitarControles(false);
            }
        }

        // Valida el usuario y, si se va a cambiar la contraseña, que coincida con la confirmacion
        // y que la contraseña actual sea correcta (en modo edicion)
        private bool ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                MostrarResultado("Debe ingresar un nombre de usuario.", esExito: false);
                return false;
            }

            if (!ModoEdicion && string.IsNullOrWhiteSpace(txtContrasena.Text))
            {
                MostrarResultado("Debe ingresar una contraseña.", esExito: false);
                return false;
            }

            if (!string.IsNullOrEmpty(txtContrasena.Text) || !string.IsNullOrEmpty(txtConfirmarContrasena.Text))
            {
                if (txtContrasena.Text != txtConfirmarContrasena.Text)
                {
                    MostrarResultado("Las contraseñas no coinciden.", esExito: false);
                    txtConfirmarContrasena.Focus();
                    return false;
                }

                if (ModoEdicion)
                {
                    if (txtContrasenaActual.Text != _usuarioEditando!.Contrasena)
                    {
                        MostrarResultado("La contraseña actual no es correcta.", esExito: false);
                        txtContrasenaActual.Focus();
                        return false;
                    }
                }
            }

            return true;
        }

        // Muestra el mensaje de resultado, en verde si fue exito o rojo si fue error
        private void MostrarResultado(string mensaje, bool esExito)
        {
            lblResultado.Text = mensaje;
            lblResultado.ForeColor = esExito ? Color.DarkGreen : Color.Firebrick;
        }

        // Registra un usuario nuevo o guarda los cambios si esta en modo edicion
        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos())
                return;

            if (ModoEdicion)
            {
                Usuarios usuario = new Usuarios
                {
                    Id = _usuarioEditando!.Id,
                    Usuario = txtUsuario.Text,
                    // Si dejo la contraseña en blanco, se manda la misma que ya tenia
                    Contrasena = string.IsNullOrEmpty(txtContrasena.Text)
                        ? _usuarioEditando.Contrasena
                        : txtContrasena.Text
                };

                string resultadoEdicion = await usuariosBLL.ActualizarAsync(usuario);
                bool exitoEdicion = resultadoEdicion.StartsWith("OK");

                if (exitoEdicion)
                {
                    MessageBox.Show("Usuario actualizado exitosamente.");
                    Close();
                }
                else
                {
                    MostrarResultado(resultadoEdicion, esExito: false);
                }
                return;
            }

            Usuarios nuevoUsuario = new Usuarios
            {
                Usuario = txtUsuario.Text,
                Contrasena = txtContrasena.Text
            };

            string resultado = await usuariosBLL.RegistrarAsync(nuevoUsuario);
            bool exito = resultado.StartsWith("OK");

            MostrarResultado(exito ? "Usuario registrado exitosamente." : resultado, exito);

            if (exito)
            {
                Limpiar();
                txtUsuario.Focus();
            }
        }
    }
}