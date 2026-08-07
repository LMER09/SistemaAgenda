using SistemaAgenda.Negocios;
using SistemaAgenda.Datos;
using System.Linq;

namespace SistemaAgenda.UI
{
    public partial class frmRegistrarPago : Form
    {
        private readonly PagosBLL pagosBLL = new PagosBLL();
        private readonly CitasBLL citasBLL = new CitasBLL();
        private readonly ClientesBLL clientesBLL = new ClientesBLL();
        private readonly ServiciosBLL serviciosBLL = new ServiciosBLL();

        private List<Citas> _citasPendientes = new List<Citas>();
        private List<Clientes> _listaClientes = new List<Clientes>();
        private List<Servicios> _listaServicios = new List<Servicios>();
        private bool habilitado = false;

        public frmRegistrarPago()
        {
            InitializeComponent();
            HabilitarControles(false);
        }

        // Carga las citas pendientes de pago al abrir el formulario
        private async void FrmRegistrarPago_Load(object sender, EventArgs e)
        {
            await CargarCitasPendientesAsync();
            HabilitarControles(false);
        }

        // Trae las citas que aun no estan pagadas y arma el texto legible del combo
        private async Task CargarCitasPendientesAsync()
        {
            _listaClientes = await clientesBLL.ObtenerTodosAsync();
            _listaServicios = await serviciosBLL.ObtenerTodosAsync();

            var todasLasCitas = await citasBLL.ObtenerTodosAsync();
            _citasPendientes = todasLasCitas
                .Where(c => c.Estado != "Cancelada" && c.Estado != "Completada")
                .OrderBy(c => c.Fecha)
                .ToList();
            cmbCita.Items.Clear();

            for (int i = 0; i < _citasPendientes.Count; i++)
            {
                var cita = _citasPendientes[i];
                var cliente = _listaClientes.FirstOrDefault(c => c.Id == cita.Id_Clientes);
                var servicio = _listaServicios.FirstOrDefault(s => s.Id == cita.Id_Servicios);

                string nombreCliente = cliente != null ? $"{cliente.Nombre} {cliente.Apellido}" : "Cliente desconocido";
                string nombreServicio = servicio != null ? servicio.Tipo_DeServicio : "Servicio desconocido";

                cmbCita.Items.Add($"{nombreCliente} - {nombreServicio} - {cita.Fecha:dd/MM/yyyy hh:mm tt} (Cita #{cita.Id})");
            }
        }

        // Habilita o deshabilita los campos y el boton de registrar
        private void HabilitarControles(bool habilitar)
        {
            habilitado = habilitar;
            cmbCita.Enabled = habilitar;
            txtMonto.Enabled = habilitar;
            cmbMetodoPago.Enabled = habilitar;
            btnRegistrar.Enabled = habilitar;

            if (habilitar)
            {
                btnHabilitar.Text = "🔒 Deshabilitar campos";
                btnHabilitar.BackColor = Color.Gray;
                lblResultado.Text = "Los campos están habilitados. Seleccione la cita y registre el pago.";
                lblResultado.ForeColor = Color.DarkGreen;
            }
            else
            {
                btnHabilitar.Text = "🔓 Habilitar campos";
                btnHabilitar.BackColor = Color.DeepPink;
                lblResultado.Text = "Los campos están deshabilitados. Presione \"Habilitar campos\" para registrar un pago.";
                lblResultado.ForeColor = Color.DimGray;
            }
        }

        // Al habilitar, refresca las citas pendientes por si algo cambio mientras tanto
        private async void btnHabilitar_Click(object sender, EventArgs e)
        {
            if (!habilitado)
                await CargarCitasPendientesAsync();
            HabilitarControles(!habilitado);
        }

        // Cierra el formulario
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void Limpiar()
        {
            cmbCita.SelectedIndex = -1;
            txtMonto.Clear();
            cmbMetodoPago.SelectedIndex = -1;
        }

        // Muestra el mensaje de resultado, en verde si fue exito o rojo si fue error
        private void MostrarResultado(string mensaje, bool esExito)
        {
            lblResultado.Text = mensaje;
            lblResultado.ForeColor = esExito ? Color.DarkGreen : Color.Firebrick;
        }

        // Valida los campos y registra el pago de la cita seleccionada
        private async void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (cmbCita.SelectedIndex == -1)
            {
                MostrarResultado("Debe seleccionar una cita.", esExito: false);
                return;
            }
            if (cmbMetodoPago.SelectedIndex == -1)
            {
                MostrarResultado("Debe seleccionar un método de pago.", esExito: false);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtMonto.Text))
            {
                MostrarResultado("Debe ingresar el monto.", esExito: false);
                return;
            }
            Citas citaSeleccionada = _citasPendientes[cmbCita.SelectedIndex];
            Pagos pago = new Pagos
            {
                Id_Citas = citaSeleccionada.Id,
                Monto = Convert.ToDecimal(txtMonto.Text),
                Metodo_DePago = cmbMetodoPago.Text
            };

            string resultado = await pagosBLL.RegistrarAsync(pago);
            bool exito = resultado.StartsWith("OK");

            MostrarResultado(exito ? "Pago registrado exitosamente. La cita quedó como Completada." : resultado, exito);

            if (exito)
            {
                Limpiar();
                await CargarCitasPendientesAsync();
            }
        }

        // Solo permite numeros y un punto decimal en el monto
        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
            if (e.KeyChar == '.' && txtMonto.Text.Contains('.'))
                e.Handled = true;
        }

        // Al elegir la cita, sugiere el monto (precio del servicio menos el deposito ya pagado)
        private void cmbCita_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCita.SelectedIndex == -1) return;

            Citas cita = _citasPendientes[cmbCita.SelectedIndex];
            var servicio = _listaServicios.FirstOrDefault(s => s.Id == cita.Id_Servicios);

            if (servicio != null)
            {
                decimal precioFinal = new Gestion_DeServicios(servicio).CalcularPrecio();
                decimal saldoPendiente = precioFinal - cita.Deposito;

                txtMonto.Text = saldoPendiente.ToString("F2");
                lblAyudaMonto.Text =
                    $"Precio del servicio: RD${precioFinal:F2}   |   " +
                    $"Depósito ya pagado: RD${cita.Deposito:F2}   |   " +
                    $"Saldo pendiente sugerido: RD${saldoPendiente:F2}. Puede cambiarlo si el cliente pagó un monto distinto.";
            }
        }
    }
}