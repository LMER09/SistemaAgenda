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
        private readonly RecordatorioCitas _recordatorio = new RecordatorioCitas();

        private List<Clientes>? _listaClientes;
        private List<Servicios>? _listaServicios;
        private List<Estilista>? _listaEstilistas;
        private bool _cargandoCita = false;

        public frmAgenda()
        {
            InitializeComponent();
            _recordatorio.RecordatorioDisparado += (mensaje) => MessageBox.Show(mensaje, "Recordatorio");
        }

        private void Limpiar()
        {
            cmbClientes.SelectedIndex = -1;
            cmbServicios.SelectedIndex = -1;
            cmbEstilistas.SelectedIndex = -1;
            cmbMetodoPago.SelectedIndex = -1;
            txtMonto.Clear();
            lblPrecioServicio.Text = "Precio servicio: RD$0.00";
            lblDeposito.Text = "Depósito requerido: RD$0.00";
        }

        private void frmAgenda_Load(object sender, EventArgs e)
        {
            CargarCombos();
            CargarCitas();
            _recordatorio.RevisarCitasProximas(_citasBLL.ObtenerTodos());
        }

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

        private void CargarCitas()
        {
            dgvCitas.DataSource = null;
            dgvCitas.DataSource = _citasBLL.ObtenerTodos();
        }

        private DateTime ObtenerFechaHoraSeleccionada()
        {
            DateTime fecha = dtpFecha.Value.Date;
            TimeSpan hora = dtpHora.Value.TimeOfDay;
            return fecha + hora;
        }

        private void btnAgendar_Click(object sender, EventArgs e)
        {
            if (cmbClientes.SelectedIndex == -1) { MessageBox.Show("Debe seleccionar un cliente."); return; }
            if (cmbServicios.SelectedIndex == -1) { MessageBox.Show("Debe seleccionar un servicio."); return; }
            if (cmbEstilistas.SelectedIndex == -1) { MessageBox.Show("Debe seleccionar una estilista."); return; }

            Clientes cliente = _listaClientes[cmbClientes.SelectedIndex];
            Servicios servicio = _listaServicios[cmbServicios.SelectedIndex];
            Estilista estilista = _listaEstilistas[cmbEstilistas.SelectedIndex];

            Citas nuevaCita = new Citas(cliente, servicio, ObtenerFechaHoraSeleccionada());
            nuevaCita.Id_Estilista = estilista.Id;
            nuevaCita.Deposito = new Gestion_DeServicios(servicio).CalcularPrecio() * 0.20m;

            string resultado = _citasBLL.AgendarCita(nuevaCita);
            MessageBox.Show(resultado);
            if (resultado.StartsWith("OK")) { CargarCitas(); Limpiar(); }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (dgvCitas.CurrentRow == null) { MessageBox.Show("Seleccione una cita."); return; }
            MessageBox.Show(_citasBLL.CancelarCita((int)dgvCitas.CurrentRow.Cells["Id"].Value));
            CargarCitas(); Limpiar();
        }

        private void btnReprogramar_Click(object sender, EventArgs e)
        {
            if (dgvCitas.CurrentRow == null) { MessageBox.Show("Seleccione una cita."); return; }
            MessageBox.Show(_citasBLL.ReprogramarCita((int)dgvCitas.CurrentRow.Cells["Id"].Value, ObtenerFechaHoraSeleccionada()));
            CargarCitas(); Limpiar();
        }

        private void btnActualizarLista_Click(object sender, EventArgs e)
        {
            CargarCitas();
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            if (dgvCitas.CurrentRow == null) { MessageBox.Show("Seleccione una cita."); return; }
            if (cmbMetodoPago.SelectedIndex == -1) { MessageBox.Show("Seleccione un método de pago."); return; }
            if (string.IsNullOrWhiteSpace(txtMonto.Text)) { MessageBox.Show("Ingrese el monto."); return; }

            int idCita = (int)dgvCitas.CurrentRow.Cells["Id"].Value;
            Pagos pago = new Pagos();
            pago.Id_Citas = idCita;
            pago.Monto = Convert.ToDecimal(txtMonto.Text);
            pago.Metodo_DePago = cmbMetodoPago.Text;

            MessageBox.Show(_pagosBLL.Registrar(pago));
            CargarCitas(); Limpiar();
        }

        private void cmbServicios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbServicios.SelectedIndex == -1 || _listaServicios == null) return;

            Servicios s = _listaServicios[cmbServicios.SelectedIndex];
            decimal precioFinal = new Gestion_DeServicios(s).CalcularPrecio();

            lblPrecioServicio.Text = "Precio servicio: RD$ " + precioFinal.ToString("F2");
            lblDeposito.Text = "Depósito requerido: RD$ " + (precioFinal * 0.20m).ToString("F2");

            if (!_cargandoCita)
                txtMonto.Text = precioFinal.ToString("F2");
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
            if (e.KeyChar == '.' && txtMonto.Text.Contains('.'))
                e.Handled = true;
        }

        private void dgvCitas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            _cargandoCita = true;

            int idCliente = (int)dgvCitas.CurrentRow.Cells["Id_Clientes"].Value;
            int idServicio = (int)dgvCitas.CurrentRow.Cells["Id_Servicios"].Value;
            int idEstilista = (int)dgvCitas.CurrentRow.Cells["Id_Estilista"].Value;

            if (_listaClientes != null)
                cmbClientes.SelectedIndex = _listaClientes.FindIndex(c => c.Id == idCliente);
            if (_listaServicios != null)
                cmbServicios.SelectedIndex = _listaServicios.FindIndex(s => s.Id == idServicio);
            if (_listaEstilistas != null)
                cmbEstilistas.SelectedIndex = _listaEstilistas.FindIndex(es => es.Id == idEstilista);

            dtpFecha.Value = (DateTime)dgvCitas.CurrentRow.Cells["Fecha"].Value;

            int idCita = (int)dgvCitas.CurrentRow.Cells["Id"].Value;
            var pago = _pagosBLL.ObtenerTodos().FirstOrDefault(p => p.Id_Citas == idCita);
            if (pago != null)
            {
                txtMonto.Text = pago.Monto.ToString();
                cmbMetodoPago.Text = pago.Metodo_DePago;
            }
            else
            {
                txtMonto.Clear();
                cmbMetodoPago.SelectedIndex = -1;
            }

            _cargandoCita = false;
        }
    }
}
