using SistemaAgenda.Datos;
using SistemaAgenda.Negocios;
using System.Linq;

namespace SistemaAgenda.UI
{
    public partial class frmAgenda : Form
    {
        // Se crean objetos de todas las clases que utilizaremos
        private readonly CitasBLL _citasBLL = new CitasBLL();
        private readonly ClientesBLL _clientesBLL = new ClientesBLL();
        private readonly ServiciosBLL _serviciosBLL = new ServiciosBLL();
        private readonly EstilistaBLL _estilistaBLL = new EstilistaBLL();
        private readonly PagosBLL _pagosBLL = new PagosBLL();
        private readonly RecordatorioCitas _recordatorio = new RecordatorioCitas();

        // Almacenan los datos obtenidos de la base de datos
        private List<Clientes>? _listaClientes;
        private List<Servicios>? _listaServicios;
        private List<Estilista>? _listaEstilistas;

        // Evita cambios automáticos mientras se carga una cita
        private bool _cargandoCita = false;

        // Guarda todas las citas sin filtrar, y la fecha seleccionada en el calendario (si hay alguna)
        private List<Citas>? _todasLasCitas;
        private DateTime? _fechaFiltro = null;

        public frmAgenda()
        {
            InitializeComponent();
            // conecta el evento del recordatorio
            _recordatorio.RecordatorioDisparado += (mensaje) =>
            {
                if (mensaje.StartsWith("No hay citas próximas")) return;
                HistorialNotificaciones.Agregar(mensaje);
                Toast.Mostrar(mensaje);
            };
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
            for (int i = 0; i < _listaClientes.Count; i++)
            {
                cmbClientes.Items.Add(_listaClientes[i].Nombre + " " + _listaClientes[i].Apellido);
            }

            _listaServicios = _serviciosBLL.ObtenerTodos();
            cmbServicios.Items.Clear();
            for (int i = 0; i < _listaServicios.Count; i++)
            {
                cmbServicios.Items.Add(_listaServicios[i].Tipo_DeServicio);
            }

            _listaEstilistas = _estilistaBLL.ObtenerTodos();
            cmbEstilistas.Items.Clear();
            for (int i = 0; i < _listaEstilistas.Count; i++)
            {
                cmbEstilistas.Items.Add(_listaEstilistas[i].Nombre + " " + _listaEstilistas[i].Apellido);
            }
        }

        private void CargarCitas()
        {
            _todasLasCitas = _citasBLL.ObtenerTodos();
            ActualizarDiasEnCalendario();
            AplicarFiltroCalendario();
        }

        // Pone en negrita, en el MonthCalendar, todos los días que tengan al menos una cita
        private void ActualizarDiasEnCalendario()
        {
            mcalCitas.RemoveAllBoldedDates();
            if (_todasLasCitas == null) return;

            var fechasConCitas = _todasLasCitas
                .Select(c => c.Fecha.Date)
                .Distinct();

            foreach (DateTime fecha in fechasConCitas)
            {
                mcalCitas.AddBoldedDate(fecha);
            }
            mcalCitas.UpdateBoldedDates();
        }

        // Muestra en el grid solo las citas del día seleccionado en el calendario,
        // o todas las citas si no hay ningún filtro activo
        private void AplicarFiltroCalendario()
        {
            if (_todasLasCitas == null) return;

            dgvCitas.DataSource = null;

            if (_fechaFiltro.HasValue)
            {
                dgvCitas.DataSource = _todasLasCitas
                    .Where(c => c.Fecha.Date == _fechaFiltro.Value.Date)
                    .ToList();
            }
            else
            {
                dgvCitas.DataSource = _todasLasCitas;
            }
        }

        private void mcalCitas_DateChanged(object sender, DateRangeEventArgs e)
        {
            _fechaFiltro = e.Start.Date;
            AplicarFiltroCalendario();
        }

        private void btnVerTodas_Click(object sender, EventArgs e)
        {
            _fechaFiltro = null;
            AplicarFiltroCalendario();
        }

        // Colorea cada fila del grid según el estado de la cita
        private void dgvCitas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = dgvCitas.Rows[e.RowIndex];
            object? valorEstado = fila.Cells["Estado"].Value;
            string estado = valorEstado?.ToString() ?? string.Empty;

            Color colorFondo = estado switch
            {
                "Pendiente" => Color.LightYellow,
                "Confirmada" => Color.LightBlue,
                "Completada" => Color.LightGreen,
                "Cancelada" => Color.LightCoral,
                "Reprogramada" => Color.Plum,
                _ => Color.White
            };

            fila.DefaultCellStyle.BackColor = colorFondo;
        }

        // Une la fecha y la hora seleccionadas
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
            if (_listaClientes == null || _listaServicios == null || _listaEstilistas == null) return;

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

            // Obtiene el Id de la cita seleccionada
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

        // Permite escribir solo números y un punto decimal
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

            List<Pagos> pagos = _pagosBLL.ObtenerTodos();
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

        // Estos tres quedaron enganchados en el Designer pero sin método —
        // los dejamos vacíos para que compile; bórralos del Designer si no los usas.
        private void dtpHora_ValueChanged(object sender, EventArgs e)
        {
        }

        private void lblFecha_Click(object sender, EventArgs e)
        {
        }

        private void lblClientes_Click(object sender, EventArgs e)
        {
        }
    }
}