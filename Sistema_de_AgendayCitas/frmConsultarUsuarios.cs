using SistemaAgenda.Negocios;
using SistemaAgenda.Datos;
using System.Linq;

namespace SistemaAgenda.UI
{
    public partial class frmConsultarUsuarios : Form
    {
        private UsuariosBLL usuariosBLL = new UsuariosBLL();
        private List<Usuarios> listaUsuarios = new List<Usuarios>();

        public frmConsultarUsuarios()
        {
            InitializeComponent();
        }

        private void frmConsultarUsuarios_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
        }

        private void CargarUsuarios()
        {
            listaUsuarios = usuariosBLL.ObtenerTodos();

            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = listaUsuarios;

            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsuarios.Columns["Id"].Visible = false;

            // La contraseña NUNCA se muestra en la tabla
            if (dgvUsuarios.Columns["Contrasena"] != null)
                dgvUsuarios.Columns["Contrasena"].Visible = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string texto = txtBuscar.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(texto))
            {
                dgvUsuarios.DataSource = null;
                dgvUsuarios.DataSource = listaUsuarios;
                return;
            }

            var resultado = listaUsuarios.Where(u =>
                u.Usuario.ToLower().Contains(texto)
            ).ToList();

            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = resultado;

            if (resultado.Count == 0)
                MessageBox.Show($"No se encontró ningún usuario que coincida con \"{txtBuscar.Text}\".",
                    "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Abre frmRegistrarUsuarios en modo edicion. La contraseña actual
        // no se le pasa visible al formulario de edicion en ningun campo;
        // solo se usa por dentro si el usuario decide dejarla sin cambios.
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un usuario de la tabla para editar.");
                return;
            }

            Usuarios usuarioSeleccionado = (Usuarios)dgvUsuarios.CurrentRow.DataBoundItem;

            this.Hide();
            using (frmRegistrarUsuarios frmEditar = new frmRegistrarUsuarios(usuarioSeleccionado))
            {
                frmEditar.ShowDialog();
            }
            this.Show();

            CargarUsuarios();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un usuario de la tabla para eliminar.");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Desea eliminar este usuario?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.No)
                return;

            int id = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells["Id"].Value);
            // UsuariosBLL.Eliminar bloquea el borrado si es el ultimo usuario
            // del sistema, y devuelve el mensaje de error correspondiente.
            MessageBox.Show(usuariosBLL.Eliminar(id));
            CargarUsuarios();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}