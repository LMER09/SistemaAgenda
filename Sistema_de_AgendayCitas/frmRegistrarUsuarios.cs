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
                // La contraseña NUNCA se precarga, ni siquiera para editar.
                // Se deja en blanco a proposito: si el usuario no escribe nada
                // ahi, se entiende que quiere mantener la contraseña actual.
                lblAyudaContrasena.Visible = true;

                HabilitarControles(true);
            }
            else
            {
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
                    // (no se pisa con vacio). Si escribio una nueva, se usa esa.
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
