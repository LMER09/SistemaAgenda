using SistemaAgenda.Negocios;
using SistemaAgenda.Datos;
using System.Linq;

namespace SistemaAgenda.UI
{
    public partial class frmConsultarServicios : Form
    {
        private ServiciosBLL serviciosBLL = new ServiciosBLL();
        private List<Servicios> listaServicios = new List<Servicios>();

        public frmConsultarServicios()
        {
            InitializeComponent();
        }

        private async void frmConsultarServicios_Load(object sender, EventArgs e)
        {
            await CargarServiciosAsync();
        }

        private async Task CargarServiciosAsync()
        {
            listaServicios = await serviciosBLL.ObtenerTodosAsync();

            dgvServicios.DataSource = null;
            dgvServicios.DataSource = listaServicios;

            dgvServicios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvServicios.Columns["Id"].Visible = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string texto = txtBuscar.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(texto))
            {
                dgvServicios.DataSource = null;
                dgvServicios.DataSource = listaServicios;
                return;
            }

            var resultado = listaServicios.Where(s =>
                s.Tipo_DeServicio.ToLower().Contains(texto) ||
                s.Subtipo_DeServicio.ToLower().Contains(texto)
            ).ToList();

            dgvServicios.DataSource = null;
            dgvServicios.DataSource = resultado;

            if (resultado.Count == 0)
                MessageBox.Show($"No se encontró ningún servicio que coincida con \"{txtBuscar.Text}\".",
                    "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Abre frmRegistrarServicios en modo edicion con el servicio seleccionado.
        private async void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvServicios.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un servicio de la tabla para editar.");
                return;
            }

            Servicios servicioSeleccionado = (Servicios)dgvServicios.CurrentRow.DataBoundItem;

            this.Hide();
            using (frmRegistrarServicios frmEditar = new frmRegistrarServicios(servicioSeleccionado))
            {
                frmEditar.ShowDialog();
            }
            this.Show();

            await CargarServiciosAsync();
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvServicios.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un servicio de la tabla para eliminar.");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Desea eliminar este servicio?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.No)
                return;

            int id = Convert.ToInt32(dgvServicios.CurrentRow.Cells["Id"].Value);
            MessageBox.Show(await serviciosBLL.EliminarAsync(id));

            await CargarServiciosAsync();
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}