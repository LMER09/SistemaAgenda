using SistemaAgenda.Datos;
using SistemaAgenda.Negocios;

namespace SistemaAgenda.UI
{
    public partial class frmAgenda : Form
    {
        private readonly CitasBLL _citasBLL = new CitasBLL();
        private readonly ClientesBLL _clientesBLL = new ClientesBLL();
        private readonly ServiciosBLL _serviciosBLL = new ServiciosBLL();
        private readonly EstilistaBLL _estilistaBLL = new EstilistaBLL();

        private List<Clientes>? _listaClientes;
        private List<Servicios>? _listaServicios;
        private List<Estilista>? _listaEstilistas;

        public frmAgenda()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarCombos();
            CargarCitas();
        }

        // ── Cargar los ComboBox con datos de la BD ────────────────────
        private void CargarCombos()
        {
            _listaClientes = _clientesBLL.ObtenerTodos();
            cmbClientes.Items.Clear();
            foreach (var c in _listaClientes)
                cmbClientes.Items.Add(c.Nombre + " " + c.Apellido);

            _listaServicios = _serviciosBLL.ObtenerTodos();
            cmbServicios.Items.Clear();
            foreach (var s in _listaServicios)
                cmbServicios.Items.Add(s.Tipo_DeServicio);

            _listaEstilistas = _estilistaBLL.ObtenerTodos();
            cmbEstilistas.Items.Clear();
            foreach (var es in _listaEstilistas)
                cmbEstilistas.Items.Add(es.Nombre + " " + es.Apellido);
        }

        // ── Cargar el DataGridView con las citas ──────────────────────
        private void CargarCitas()
        {
            dgvCitas.DataSource = null;
            dgvCitas.DataSource = _citasBLL.ObtenerTodos();
        }

        // ── Combina fecha y hora seleccionadas ────────────────────────
        private DateTime ObtenerFechaHoraSeleccionada()
        {
            DateTime fecha = dtpFecha.Value.Date;
            TimeSpan hora = dtpHora.Value.TimeOfDay;
            return fecha + hora;
        }

        // ── Botón Agendar ──────────────────────────────────────────────
        private void btnAgendar_Click(object sender, EventArgs e)
        {
            if (_listaClientes == null || _listaServicios == null || _listaEstilistas == null)
            {
                MessageBox.Show("Los datos aún no se han cargado.");
                return;
            }

            if (cmbClientes.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un cliente.");
                return;
            }
            if (cmbServicios.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un servicio.");
                return;
            }
            if (cmbEstilistas.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una estilista.");
                return;
            }

            Clientes clienteSeleccionado = _listaClientes[cmbClientes.SelectedIndex];
            Servicios servicioSeleccionado = _listaServicios[cmbServicios.SelectedIndex];
            Estilista estilistaSeleccionada = _listaEstilistas[cmbEstilistas.SelectedIndex];

            Citas nuevaCita = new Citas(clienteSeleccionado, servicioSeleccionado, ObtenerFechaHoraSeleccionada());
            nuevaCita.Id_Estilista = estilistaSeleccionada.Id;

            string resultado = _citasBLL.AgendarCita(nuevaCita);

            MessageBox.Show(resultado);
            if (resultado.StartsWith("OK"))
            {
                CargarCitas();
            }
        }

        // ── Botón Cancelar ─────────────────────────────────────────────
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (dgvCitas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una cita de la lista.");
                return;
            }

            int idSeleccionado = (int)dgvCitas.CurrentRow.Cells["Id"].Value;
            string resultado = _citasBLL.CancelarCita(idSeleccionado);

            MessageBox.Show(resultado);
            CargarCitas();
        }

        // ── Botón Reprogramar ──────────────────────────────────────────
        private void btnReprogramar_Click(object sender, EventArgs e)
        {
            if (dgvCitas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una cita de la lista.");
                return;
            }

            int idSeleccionado = (int)dgvCitas.CurrentRow.Cells["Id"].Value;
            string resultado = _citasBLL.ReprogramarCita(idSeleccionado, ObtenerFechaHoraSeleccionada());

            MessageBox.Show(resultado);
            CargarCitas();
        }

        // ── Botón Actualizar Lista ──────────────────────────────────────
        private void btnActualizarLista_Click(object sender, EventArgs e)
        {
            CargarCitas();
        }
    }
}
