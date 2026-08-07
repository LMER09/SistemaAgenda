using SistemaAgenda.Negocios;
using SistemaAgenda.Datos;
using System.Linq;

namespace SistemaAgenda.UI
{
    public partial class frmRegistrarCita : Form
    {
        private readonly CitasBLL citasBLL = new CitasBLL();
        private readonly ClientesBLL clientesBLL = new ClientesBLL();
        private readonly ServiciosBLL serviciosBLL = new ServiciosBLL();
        private readonly EstilistaBLL estilistaBLL = new EstilistaBLL();

        private List<Clientes> _listaClientes = new List<Clientes>();
        private List<Servicios> _listaServicios = new List<Servicios>();
        private List<Estilista> _listaEstilistas = new List<Estilista>();

        private bool habilitado = false;
        private Citas? _citaEditando = null;
        private bool ModoEdicion => _citaEditando != null;

        public frmRegistrarCita()
        {
            InitializeComponent();
            HabilitarControles(false);
        }

        public frmRegistrarCita(Citas cita) : this()
        {
            _citaEditando = cita;
        }

        private void HabilitarControles(bool habilitar)
        {
            habilitado = habilitar;
            cmbClientes.Enabled = habilitar && !ModoEdicion;
            cmbServicios.Enabled = habilitar && !ModoEdicion;
            cmbEstilistas.Enabled = habilitar && !ModoEdicion;
            dtpFecha.Enabled = habilitar;
            dtpHora.Enabled = habilitar;
            btnAgregar.Enabled = habilitar;

            if (habilitar)
            {
                btnHabilitar.Text = "🔒 Deshabilitar campos";
                btnHabilitar.BackColor = Color.Gray;
                lblResultado.Text = ModoEdicion
                    ? "Modifique los datos y presione \"Guardar cambios\"."
                    : "Los campos están habilitados. Complete los datos de la cita.";
                lblResultado.ForeColor = Color.DarkGreen;
            }
            else
            {
                btnHabilitar.Text = "🔓 Habilitar campos";
                btnHabilitar.BackColor = Color.DeepPink;
                lblResultado.Text = "Los campos están deshabilitados. Presione \"Habilitar campos\" para agendar una cita.";
                lblResultado.ForeColor = Color.DimGray;
            }
        }

        private void btnHabilitar_Click(object sender, EventArgs e)
        {
            HabilitarControles(!habilitado);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Limpiar()
        {
            cmbClientes.SelectedIndex = -1;
            cmbServicios.SelectedIndex = -1;
            cmbEstilistas.SelectedIndex = -1;
            lblPrecioServicio.Text = "Precio servicio: RD$0.00";
            lblDeposito.Text = "Depósito requerido: RD$0.00";
        }

        private async void frmRegistrarCita_Load(object sender, EventArgs e)
        {
            await CargarCombosAsync();

            if (ModoEdicion)
            {
                this.Text = "Reprogramar Cita";
                lblIngrese.Text = "Editando cita:";
                btnAgregar.Text = "💾 Guardar cambios";

                SeleccionarPorId(cmbClientes, _listaClientes.Select(c => c.Id).ToList(), _citaEditando!.Id_Clientes);
                SeleccionarPorId(cmbServicios, _listaServicios.Select(s => s.Id).ToList(), _citaEditando.Id_Servicios);
                SeleccionarPorId(cmbEstilistas, _listaEstilistas.Select(es => es.Id).ToList(), _citaEditando.Id_Estilista);

                dtpFecha.Value = _citaEditando.Fecha.Date;
                dtpHora.Value = DateTime.Today.Add(_citaEditando.Fecha.TimeOfDay);

                HabilitarControles(true);
            }
            else
            {
                HabilitarControles(false);
            }
        }

        private void SeleccionarPorId(ComboBox combo, List<int> idsEnOrden, int idBuscado)
        {
            int indice = idsEnOrden.IndexOf(idBuscado);
            if (indice >= 0)
                combo.SelectedIndex = indice;
        }

        private async Task CargarCombosAsync()
        {
            _listaClientes = await clientesBLL.ObtenerTodosAsync();
            cmbClientes.Items.Clear();
            foreach (var c in _listaClientes)
                cmbClientes.Items.Add($"{c.Nombre} {c.Apellido}");

            _listaServicios = await serviciosBLL.ObtenerTodosAsync();
            cmbServicios.Items.Clear();
            foreach (var s in _listaServicios)
                cmbServicios.Items.Add($"{s.Tipo_DeServicio} - {s.Subtipo_DeServicio}");

            _listaEstilistas = await estilistaBLL.ObtenerTodosAsync();
            cmbEstilistas.Items.Clear();
            foreach (var es in _listaEstilistas)
                cmbEstilistas.Items.Add($"{es.Nombre} {es.Apellido}");
        }

        private DateTime ObtenerFechaHoraSeleccionada()
        {
            DateTime fecha = dtpFecha.Value.Date;
            TimeSpan hora = dtpHora.Value.TimeOfDay;
            return fecha + hora;
        }

        private void cmbServicios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbServicios.SelectedIndex == -1) return;

            Servicios s = _listaServicios[cmbServicios.SelectedIndex];
            Servicio servicioCalculo = new Gestion_DeServicios(s);
            decimal precioFinal = servicioCalculo.CalcularPrecio();

            lblPrecioServicio.Text = "Precio servicio: RD$ " + precioFinal.ToString("F2");
            lblDeposito.Text = "Depósito requerido: RD$ " + servicioCalculo.CalcularDeposito().ToString("F2");
        }

        private bool ValidarSelecciones()
        {
            if (cmbClientes.SelectedIndex == -1)
            {
                lblResultado.Text = "Debe seleccionar un cliente.";
                lblResultado.ForeColor = Color.Firebrick;
                return false;
            }
            if (cmbServicios.SelectedIndex == -1)
            {
                lblResultado.Text = "Debe seleccionar un servicio.";
                lblResultado.ForeColor = Color.Firebrick;
                return false;
            }
            if (cmbEstilistas.SelectedIndex == -1)
            {
                lblResultado.Text = "Debe seleccionar una estilista.";
                lblResultado.ForeColor = Color.Firebrick;
                return false;
            }
            return true;
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarSelecciones())
                return;

            Clientes cliente = _listaClientes[cmbClientes.SelectedIndex];
            Servicios servicio = _listaServicios[cmbServicios.SelectedIndex];
            Estilista estilista = _listaEstilistas[cmbEstilistas.SelectedIndex];

            btnAgregar.Enabled = false;
            try
            {
                if (ModoEdicion)
                {
                    string resultadoEdicion = await citasBLL.ReprogramarCitaAsync(_citaEditando!.Id, ObtenerFechaHoraSeleccionada());
                    bool exitoEdicion = resultadoEdicion.StartsWith("OK");

                    if (exitoEdicion)
                    {
                        // AGREGADO AQUÍ: Dispara revisión de correo tras reprogramar
                        var listaCitasRepo = await citasBLL.ObtenerTodosAsync();
                        var recordatorioRepo = new RecordatorioCitas();
                        await recordatorioRepo.RevisarCitasProximasAsync(listaCitasRepo);

                        MessageBox.Show("Cita reprogramada exitosamente.");
                        Close();
                    }
                    else
                    {
                        lblResultado.Text = resultadoEdicion;
                        lblResultado.ForeColor = Color.Firebrick;
                    }
                    return;
                }

                Citas nuevaCita = new Citas(cliente, servicio, ObtenerFechaHoraSeleccionada());
                nuevaCita.Id_Estilista = estilista.Id;
                nuevaCita.Deposito = new Gestion_DeServicios(servicio).CalcularDeposito();

                string resultado = await citasBLL.AgendarCitaAsync(nuevaCita);
                bool exito = resultado.StartsWith("OK");

                lblResultado.Text = exito ? "Cita agendada exitosamente." : resultado;
                lblResultado.ForeColor = exito ? Color.DarkGreen : Color.Firebrick;

                if (exito)
                {
                    // AGREGADO AQUÍ: Obtiene la lista y envía el correo si la cita cae en la próxima hora
                    var listaCitas = await citasBLL.ObtenerTodosAsync();
                    var recordatorio = new RecordatorioCitas();
                    await recordatorio.RevisarCitasProximasAsync(listaCitas);

                    Limpiar();
                    cmbClientes.Focus();
                }
            }
            finally
            {
                btnAgregar.Enabled = true;
            }
        }
    }
}