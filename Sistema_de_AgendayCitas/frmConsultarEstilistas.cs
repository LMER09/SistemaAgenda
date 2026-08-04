using SistemaAgenda.Negocios;
using SistemaAgenda.Datos;
using System.Linq;

namespace SistemaAgenda.UI
{
    public partial class frmConsultarEstilistas : Form
    {
        private EstilistaBLL estilistaBLL = new EstilistaBLL();
        private List<Estilista> listaEstilistas = new List<Estilista>();

        public frmConsultarEstilistas()
        {
            InitializeComponent();
        }

        private void frmConsultarEstilistas_Load(object sender, EventArgs e)
        {
            CargarEstilistas();
        }

        private void CargarEstilistas()
        {
            listaEstilistas = estilistaBLL.ObtenerTodos();

            dgvEstilistas.DataSource = null;
            dgvEstilistas.DataSource = listaEstilistas;

            dgvEstilistas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEstilistas.Columns["Id"].Visible = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string texto = txtBuscar.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(texto))
            {
                dgvEstilistas.DataSource = null;
                dgvEstilistas.DataSource = listaEstilistas;
                return;
            }

            var resultado = listaEstilistas.Where(es =>
                es.Nombre.ToLower().Contains(texto) ||
                es.Apellido.ToLower().Contains(texto) ||
                es.Especialidad.ToLower().Contains(texto) ||
                es.Cedula.ToLower().Contains(texto)
            ).ToList();

            dgvEstilistas.DataSource = null;
            dgvEstilistas.DataSource = resultado;

            if (resultado.Count == 0)
                MessageBox.Show($"No se encontró ningún estilista que coincida con \"{txtBuscar.Text}\".",
                    "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Abre frmRegistrarEstilistas en modo edicion con el estilista seleccionado.
        // Al cerrarse ese formulario, esta pantalla se refresca sola.
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvEstilistas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un estilista de la tabla para editar.");
                return;
            }

            Estilista estilistaSeleccionado = (Estilista)dgvEstilistas.CurrentRow.DataBoundItem;

            this.Hide();
            using (frmRegistrarEstilistas frmEditar = new frmRegistrarEstilistas(estilistaSeleccionado))
            {
                frmEditar.ShowDialog();
            }
            this.Show();

            CargarEstilistas();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvEstilistas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un estilista de la tabla para eliminar.");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Desea eliminar este estilista?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.No)
                return;

            int id = Convert.ToInt32(dgvEstilistas.CurrentRow.Cells["Id"].Value);
            MessageBox.Show(estilistaBLL.Eliminar(id));

            CargarEstilistas();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}