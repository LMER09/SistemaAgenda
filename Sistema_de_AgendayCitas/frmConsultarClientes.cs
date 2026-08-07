using SistemaAgenda.Negocios;
using SistemaAgenda.Datos;
using System.Linq;

namespace SistemaAgenda.UI
{
    public partial class frmConsultarClientes : Form
    {
        private ClientesBLL clientesBLL = new ClientesBLL();
        private List<Clientes> listaClientes = new List<Clientes>();
        public frmConsultarClientes()
        {
            InitializeComponent();
        }

        private async void frmConsultarClientes_Load(object sender, EventArgs e)
        {
            await CargarClientesAsync();
        }

        private async Task CargarClientesAsync()
        {
            listaClientes = await clientesBLL.ObtenerTodosAsync();

            dgvClientes.DataSource = null;
            dgvClientes.DataSource = listaClientes;

            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClientes.Columns["Id"].Visible = false;
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string texto = txtBuscar.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(texto))
            {
                dgvClientes.DataSource = null;
                dgvClientes.DataSource = listaClientes;
                return;
            }

            var resultado = listaClientes.Where(c =>
                c.Nombre.ToLower().Contains(texto) ||
                c.Apellido.ToLower().Contains(texto) ||
                c.Cedula.ToLower().Contains(texto)
            ).ToList();

            dgvClientes.DataSource = null;
            dgvClientes.DataSource = resultado;

            if (resultado.Count == 0)
                MessageBox.Show($"No se encontró ningún cliente que coincida con \"{txtBuscar.Text}\".",
                    "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private async void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un cliente de la tabla para editar.");
                return;
            }

            Clientes clienteSeleccionado = (Clientes)dgvClientes.CurrentRow.DataBoundItem;

            this.Hide();
            using (frmRegistrarClientes frmEditar = new frmRegistrarClientes(clienteSeleccionado))
            {
                frmEditar.ShowDialog();
            }
            this.Show();

            await CargarClientesAsync();
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un cliente de la tabla para eliminar.");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Desea eliminar este cliente?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.No)
                return;

            int id = Convert.ToInt32(dgvClientes.CurrentRow.Cells["Id"].Value);
            MessageBox.Show(await clientesBLL.EliminarAsync(id));

            await CargarClientesAsync();
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}