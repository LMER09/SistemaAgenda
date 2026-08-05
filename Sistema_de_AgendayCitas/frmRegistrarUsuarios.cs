using SistemaAgenda.Negocios;
using SistemaAgenda.Datos;

namespace SistemaAgenda.UI
{
    public partial class frmRegistrarUsuarios : Form
    {
        private UsuariosBLL usuariosBLL = new UsuariosBLL();
        private bool habilitado = false;

        // Si no es null, el formulario esta editando este usuario
        // en vez de crear uno nuevo.
        private Usuarios? _usuarioEditando = null;
        private bool ModoEdicion => _usuarioEditando != null;

        // Constructor normal: registrar un usuario nuevo
        public frmRegistrarUsuarios()
        {
            InitializeComponent();
            HabilitarControles(false);
        }

        // Constructor de edicion: recibe el usuario ya existente,
        // desde frmConsultarUsuarios al presionar "Editar".
        public frmRegistrarUsuarios(Usuarios usuario) : this()
        {
            _usuarioEditando = usuario;
        }

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
            txtUsuario.Clear();
            txtContrasenaActual.Clear();
            txtContrasena.Clear();
            txtConfirmarContrasena.Clear();
        }

        private void frmRegistrarUsuarios_Load(object sender, EventArgs e)
        {
            if (ModoEdicion)
            {
                this.Text = "Editar Usuario";
                lblIngrese.Text = "Editando usuario:";
                btnAgregar.Text = "💾 Guardar cambios";

                txtUsuario.Text = _usuarioEditando!.Usuario;

                // La contraseña actual solo se pide si se va a cambiar la contraseña
                // (campos Contrasena/ConfirmarContrasena se dejan en blanco a proposito).
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

        private bool ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                MostrarResultado("Debe ingresar un nombre de usuario.", esExito: false);
                return false;
            }

            // Al crear un usuario nuevo, la contraseña es obligatoria.
            // Al editar, es opcional (vacio = no cambiarla).
            if (!ModoEdicion && string.IsNullOrWhiteSpace(txtContrasena.Text))
            {
                MostrarResultado("Debe ingresar una contraseña.", esExito: false);
                return false;
            }

            // Si escribio algo en contraseña (nuevo usuario, o editando y decidio cambiarla),
            // debe coincidir con la confirmacion.
            if (!string.IsNullOrEmpty(txtContrasena.Text) || !string.IsNullOrEmpty(txtConfirmarContrasena.Text))
            {
                if (txtContrasena.Text != txtConfirmarContrasena.Text)
                {
                    MostrarResultado("Las contraseñas no coinciden.", esExito: false);
                    txtConfirmarContrasena.Focus();
                    return false;
                }

                // Si esta editando y quiere cambiar la contraseña, primero debe
                // confirmar la contraseña actual correctamente.
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

        private void MostrarResultado(string mensaje, bool esExito)
        {
            lblResultado.Text = mensaje;
            lblResultado.ForeColor = esExito ? Color.DarkGreen : Color.Firebrick;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
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
                    // (no se pisa con vacio). Si escribio una nueva, ya se confirmo
                    // la contraseña actual en ValidarDatos antes de llegar aqui.
                    Contrasena = string.IsNullOrEmpty(txtContrasena.Text)
                        ? _usuarioEditando.Contrasena
                        : txtContrasena.Text
                };

                string resultadoEdicion = usuariosBLL.Actualizar(usuario);
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

            string resultado = usuariosBLL.Registrar(nuevoUsuario);
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
