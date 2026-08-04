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

        private void frmConsultarClientes_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }

        private void CargarClientes()
        {
            listaClientes = clientesBLL.ObtenerTodos();

            dgvClientes.DataSource = null;
            dgvClientes.DataSource = listaClientes;

            // Ocultar la columna Id
            dgvClientes.Columns["Id"].Visible = false;

            // Ajustar el ancho de las columnas
            dgvClientes.Columns["Nombre"].Width = 110;
            dgvClientes.Columns["Apellido"].Width = 110;
            dgvClientes.Columns["Telefono"].Width = 110;
            dgvClientes.Columns["Correo"].Width = 170;
            dgvClientes.Columns["Cedula"].Width = 120;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lblBuscar_Click(object sender, EventArgs e)
        {
            string texto = txtBuscar.Text.ToLower();

            var resultado = listaClientes.Where(c =>
                c.Nombre.ToLower().Contains(texto) ||
                c.Apellido.ToLower().Contains(texto) ||
                c.Cedula.ToLower().Contains(texto)
            ).ToList();

            dgvClientes.DataSource = null;
            dgvClientes.DataSource = resultado;
        }

        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            // Obtiene el texto escrito, elimina espacios al inicio y final
            // y lo convierte a minúsculas para evitar diferencias entre mayúsculas y minúsculas.
            string texto = txtBuscar.Text.Trim().ToLower();

            // Filtra la lista de clientes y muestra únicamente
            // los que coincidan con el texto ingresado.

            // Busca coincidencias por nombre, apellido o cédula.
            dgvClientes.DataSource = clientesBLL.ObtenerTodos()
                .Where(c =>
                    c.Nombre.ToLower().Contains(texto) ||
                    c.Apellido.ToLower().Contains(texto) ||
                    c.Cedula.ToLower().Contains(texto))

                // Convierte el resultado nuevamente en una lista.
                .ToList();
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void picLogo_Click(object sender, EventArgs e)
        {

        }
    }
}