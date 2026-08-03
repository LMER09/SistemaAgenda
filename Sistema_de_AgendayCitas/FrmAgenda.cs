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

        // 1. async void: es un evento, no puede devolver Task
        private async void frmAgenda_Load(object sender, EventArgs e)
        {
            await CargarCombosAsync();
            await CargarCitasAsync();
            _recordatorio.RevisarCitasProximas(await _citasBLL.ObtenerTodosAsync());
        }

        // 2. Este método ya NO es un evento, pero SÍ usa await adentro,
        //    así que también debe ser async. Como no es un evento, usamos
        //    "async Task" (no "async void") — es la forma correcta cuando
        //    el método sí lo vas a "esperar" (await) desde otro lado.
        private async Task CargarCombosAsync()
        {
            _listaClientes = await _clientesBLL.ObtenerTodosAsync();
            cmbClientes.Items.Clear();
            for (int i = 0; i < _listaClientes.Count; i++)
            {
                cmbClientes.Items.Add(_listaClientes[i].Nombre + " " + _listaClientes[i].Apellido);
            }

            _listaServicios = await _serviciosBLL.ObtenerTodosAsync();
            cmbServicios.Items.Clear();
            for (int i = 0; i < _listaServicios.Count; i++)
            {
                cmbServicios.Items.Add(_listaServicios[i].Tipo_DeServicio);
            }

            _listaEstilistas = await _estilistaBLL.ObtenerTodosAsync();
            cmbEstilistas.Items.Clear();
            for (int i = 0; i < _listaEstilistas.Count; i++)
            {
                cmbEstilistas.Items.Add(_listaEstilistas[i].Nombre + " " + _listaEstilistas[i].Apellido);
            }
        }

        private async Task CargarCitasAsync()
        {
            dgvCitas.DataSource = null;
            dgvCitas.DataSource = await _citasBLL.ObtenerTodosAsync();
        }

        // Este método no toca la base de datos, no necesita async
        private DateTime ObtenerFechaHoraSeleccionada()
        {
            DateTime fecha = dtpFecha.Value.Date;
            TimeSpan hora = dtpHora.Value.TimeOfDay;
            return fecha + hora;
        }

        private async void btnAgendar_Click(object sender, EventArgs e)
        {
            if (cmbClientes.SelectedIndex == -1) { MessageBox.Show("Debe seleccionar un cliente."); return; }
            if (cmbServicios.SelectedIndex == -1) { MessageBox.Show("Debe seleccionar un servicio."); return; }
            if (cmbEstilistas.SelectedIndex == -1) { MessageBox.Show("Debe seleccionar una estilista."); return; }
            if (_listaClientes == null || _listaServicios == null || _listaEstilistas == null) return;

            Clientes cliente = _listaClientes[cmbClientes.SelectedIndex];
            Servicios servicio = _listaServicios[cmbServicios.SelectedIndex];
            Estilista estilista = _listaEstilistas[cmbEstilistas.SelectedIndex];

            Citas nuevaCita = new Citas(cliente, servicio, ObtenerFechaHoraSeleccionada());
            nuevaCita.Id_Estilista = estilista.Id;
            nuevaCita.Deposito = new Gestion_DeServicios(servicio).CalcularPrecio() * 0.20m;

            string resultado = await _citasBLL.AgendarCitaAsync(nuevaCita);
            MessageBox.Show(resultado);
            if (resultado.StartsWith("OK")) { await CargarCitasAsync(); Limpiar(); }
        }

        private async void btnCancelar_Click(object sender, EventArgs e)
        {
            if (dgvCitas.CurrentRow == null) { MessageBox.Show("Seleccione una cita."); return; }
            MessageBox.Show(await _citasBLL.CancelarCitaAsync((int)dgvCitas.CurrentRow.Cells["Id"].Value));
            await CargarCitasAsync(); Limpiar();
        }

        private async void btnReprogramar_Click(object sender, EventArgs e)
        {
            if (dgvCitas.CurrentRow == null) { MessageBox.Show("Seleccione una cita."); return; }
            MessageBox.Show(await _citasBLL.ReprogramarCitaAsync((int)dgvCitas.CurrentRow.Cells["Id"].Value, ObtenerFechaHoraSeleccionada()));
            await CargarCitasAsync(); Limpiar();
        }

        private async void btnActualizarLista_Click(object sender, EventArgs e)
        {
            await CargarCitasAsync();
        }

        private async void btnPagar_Click(object sender, EventArgs e)
        {
            if (dgvCitas.CurrentRow == null) { MessageBox.Show("Seleccione una cita."); return; }
            if (cmbMetodoPago.SelectedIndex == -1) { MessageBox.Show("Seleccione un método de pago."); return; }
            if (string.IsNullOrWhiteSpace(txtMonto.Text)) { MessageBox.Show("Ingrese el monto."); return; }

            int idCita = (int)dgvCitas.CurrentRow.Cells["Id"].Value;
            Pagos pago = new Pagos();
            pago.Id_Citas = idCita;
            pago.Monto = Convert.ToDecimal(txtMonto.Text);
            pago.Metodo_DePago = cmbMetodoPago.Text;

            MessageBox.Show(await _pagosBLL.RegistrarAsync(pago));
            await CargarCitasAsync(); Limpiar();
        }

        // No toca base de datos: sigue igual, sin async
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

        // No toca base de datos: sigue igual, sin async
        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
            if (e.KeyChar == '.' && txtMonto.Text.Contains('.'))
                e.Handled = true;
        }

        private async void dgvCitas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            _cargandoCita = true;

            int idCliente = (int)dgvCitas.CurrentRow.Cells["Id_Clientes"].Value;
            int idServicio = (int)dgvCitas.CurrentRow.Cells["Id_Servicios"].Value;
            int idEstilista = (int)dgvCitas.CurrentRow.Cells["Id_Estilista"].Value;

            if (_listaClientes != null)
            {
                for (int i = 0; i < _listaClientes.Count; i++)
                {
                    if (_listaClientes[i].Id == idCliente)
                    {
                        cmbClientes.SelectedIndex = i;
                        break;
                    }
                }
            }

            if (_listaServicios != null)
            {
                for (int i = 0; i < _listaServicios.Count; i++)
                {
                    if (_listaServicios[i].Id == idServicio)
                    {
                        cmbServicios.SelectedIndex = i;
                        break;
                    }
                }
            }

            if (_listaEstilistas != null)
            {
                for (int i = 0; i < _listaEstilistas.Count; i++)
                {
                    if (_listaEstilistas[i].Id == idEstilista)
                    {
                        cmbEstilistas.SelectedIndex = i;
                        break;
                    }
                }
            }

            dtpFecha.Value = (DateTime)dgvCitas.CurrentRow.Cells["Fecha"].Value;
            int idCita = (int)dgvCitas.CurrentRow.Cells["Id"].Value;

            List<Pagos> pagos = await _pagosBLL.ObtenerTodosAsync();
            Pagos pago = null;

            for (int i = 0; i < pagos.Count; i++)
            {
                if (pagos[i].Id_Citas == idCita)
                {
                    pago = pagos[i];
                    break;
                }
            }
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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}