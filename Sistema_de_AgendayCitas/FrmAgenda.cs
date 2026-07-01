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
        private readonly PagosBLL _pagosBLL = new PagosBLL();

        private List<Clientes>? _listaClientes;
        private List<Servicios>? _listaServicios;
        private List<Estilista>? _listaEstilistas;

        public frmAgenda()
        {
            InitializeComponent();
        }

        private void frmAgenda_Load(object sender, EventArgs e)
        {
            CargarCombos();
            CargarCitas();
        }

        // ── Cargar los ComboBox con datos de la BD ────────────────────
        private void CargarCombos()
        {
            _listaClientes = _clientesBLL.ObtenerTodos();
            cmbClientes.Items.Clear();
            for (int i = 0; i < _listaClientes.Count; i++)
                cmbClientes.Items.Add(_listaClientes[i].Nombre + " " + _listaClientes[i].Apellido);

            _listaServicios = _serviciosBLL.ObtenerTodos();
            cmbServicios.Items.Clear();
            for (int i = 0; i < _listaServicios.Count; i++)
                cmbServicios.Items.Add(_listaServicios[i].Tipo_DeServicio);

            _listaEstilistas = _estilistaBLL.ObtenerTodos();
            cmbEstilistas.Items.Clear();
            for (int i = 0; i < _listaEstilistas.Count; i++)
                cmbEstilistas.Items.Add(_listaEstilistas[i].Nombre + " " + _listaEstilistas[i].Apellido);
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

            Gestion_DeServicios gestor = new Gestion_DeServicios(servicioSeleccionado);
            decimal deposito = gestor.CalcularPrecio() * 0.20m;

            Citas nuevaCita = new Citas(clienteSeleccionado, servicioSeleccionado, ObtenerFechaHoraSeleccionada());
            nuevaCita.Id_Estilista = estilistaSeleccionada.Id;
            nuevaCita.Deposito = deposito;

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

        // ── Botón Registrar Pago ───────────────────────────────────────
        private void btnPagar_Click(object sender, EventArgs e)
        {
            if (dgvCitas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una cita de la lista.");
                return;
            }

            if (cmbMetodoPago.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un método de pago.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMonto.Text))
            {
                MessageBox.Show("Ingrese el monto.");
                return;
            }

            Pagos pago = new Pagos();
            pago.Id_Citas = (int)dgvCitas.CurrentRow.Cells["Id"].Value;
            pago.Monto = Convert.ToDecimal(txtMonto.Text);
            pago.Metodo_DePago = cmbMetodoPago.Text;

            MessageBox.Show(_pagosBLL.Registrar(pago));

            txtMonto.Clear();
            cmbMetodoPago.SelectedIndex = -1;
        }

        private void cmbServicios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbServicios.SelectedIndex == -1) return;

            Servicios servicioSeleccionado = _listaServicios[cmbServicios.SelectedIndex];
            Gestion_DeServicios gestor = new Gestion_DeServicios(servicioSeleccionado);

            decimal precioFinal = gestor.CalcularPrecio();
            decimal deposito = precioFinal * 0.20m;

            lblDeposito.Text = "Depósito requerido: RD$" + deposito.ToString("F2");
        }
    }
}
