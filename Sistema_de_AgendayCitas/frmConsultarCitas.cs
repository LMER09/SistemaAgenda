using SistemaAgenda.Negocios;
using System.Linq;

namespace SistemaAgenda.UI
{
    public partial class frmConsultarCitas : Form
    {
        private readonly CitasBLL citasBLL = new CitasBLL();
        private readonly ClientesBLL clientesBLL = new ClientesBLL();
        private readonly RecordatorioCitas recordatorio = new RecordatorioCitas();

        private List<CitaVista> _listaCitas = new List<CitaVista>();

        public frmConsultarCitas()
        {
            InitializeComponent();

            // Conecta el evento del recordatorio para enviar el correo
            // al cliente cuando una cita esta proxima
            recordatorio.RecordatorioDisparado += async (cita, mensaje) =>
            {
                if (cita == null) return;

                // Guarda la notificacion en el historial
                HistorialNotificaciones.Agregar(mensaje);

                var clientes = await clientesBLL.ObtenerTodosAsync();
                var cliente = clientes.FirstOrDefault(c => c.Id == cita.Id_Clientes);

                if (cliente != null)
                {
                    try
                    {
                        recordatorio.EnviarCorreo(cliente.Correo, cliente.Nombre, cita.Fecha);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se pudo enviar el correo: " + ex.Message);
                    }
                }
            };
        }

        // Carga la tabla y revisa citas proximas al abrir el formulario
        private async void frmConsultarCitas_Load(object sender, EventArgs e)
        {
            await CargarCitasAsync();
            recordatorio.RevisarCitasProximas(await citasBLL.ObtenerTodosAsync());
        }

        // Trae la lista de citas (con nombres, no IDs) y actualiza tabla y calendario
        private async Task CargarCitasAsync()
        {
            _listaCitas = await citasBLL.ObtenerVistaAsync();

            MostrarEnTabla(_listaCitas);
            CargarCalendario();
        }

        // Muestra en el DataGridView la lista de citas utilizando la clase CitaVista
        private void MostrarEnTabla(List<CitaVista> lista)
        {
            dgvCitas.DataSource = null;
            dgvCitas.DataSource = lista.Select(cv => new
            {
                cv.Id,  cv.Cliente,
                cv.Servicio, cv.Estilista,
                cv.Fecha, cv.Estado,
                cv.Deposito
            }).ToList();

            dgvCitas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // Marca en el calendario los dias que tienen al menos una cita activa.
        private void CargarCalendario()
        {
            var fechasConCita = new List<DateTime>();

            for (int i = 0; i < _listaCitas.Count; i++)
            {
                CitaVista cv = _listaCitas[i];

                if (cv.Estado == "Cancelada")
                    continue;

                DateTime fecha = cv.Fecha.Date;

                if (!fechasConCita.Contains(fecha))
                    fechasConCita.Add(fecha);
            }

            calCitas.BoldedDates = fechasConCita.ToArray();
        }

        // Al elegir un dia en el calendario, filtra la tabla
        // para mostrar solo las citas de ese dia.
        private void calCitas_DateChanged(object sender, DateRangeEventArgs e)
        {
            DateTime fechaSeleccionada = calCitas.SelectionStart.Date;
            var citasDelDia = _listaCitas.Where(cv => cv.Fecha.Date == fechaSeleccionada).ToList();
            MostrarEnTabla(citasDelDia);
        }
        private void btnVerTodas_Click(object sender, EventArgs e)
        {
            MostrarEnTabla(_listaCitas);
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string texto = txtBuscar.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(texto))
            {
                MostrarEnTabla(_listaCitas);
                return;
            }

            var resultado = _listaCitas.Where(cv =>
                cv.Cliente.ToLower().Contains(texto) ||
                cv.Servicio.ToLower().Contains(texto) ||
                cv.Estilista.ToLower().Contains(texto) ||
                cv.Estado.ToLower().Contains(texto)
            ).ToList();

            MostrarEnTabla(resultado);

            if (resultado.Count == 0)
                MessageBox.Show($"No se encontró ninguna cita que coincida con \"{txtBuscar.Text}\".",
                    "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Colorea cada fila segun el estado de la cita, para identificarlo
        // de un vistazo sin tener que leer la columna Estado.
        private void dgvCitas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || dgvCitas.Columns["Estado"] == null) return;

            string estado = dgvCitas.Rows[e.RowIndex].Cells["Estado"].Value?.ToString() ?? "";

            Color color = estado switch
            {
                "Completada" => Color.LightGreen,
                "Pendiente" => Color.LightYellow,
                "Cancelada" => Color.MistyRose,
                "Reprogramada" => Color.LightBlue,
                _ => Color.White
            };

            dgvCitas.Rows[e.RowIndex].DefaultCellStyle.BackColor = color;
        }

        // Busca en la lista cargada la cita que corresponde a la fila seleccionada
        private CitaVista? ObtenerCitaSeleccionada()
        {
            if (dgvCitas.CurrentRow == null) return null;
            int id = Convert.ToInt32(dgvCitas.CurrentRow.Cells["Id"].Value);
            return _listaCitas.FirstOrDefault(cv => cv.Id == id);
        }
        private async void btnCancelar_Click(object sender, EventArgs e)
        {
            var citaSeleccionada = ObtenerCitaSeleccionada();
            if (citaSeleccionada == null)
            {
                MessageBox.Show("Seleccione una cita de la tabla para cancelar.");
                return;
            }

            if (citaSeleccionada.Estado == "Cancelada")
            {
                MessageBox.Show("Esta cita ya está cancelada.");
                return;
            }
            if (citaSeleccionada.Estado == "Completada")
            {
                MessageBox.Show("Esta cita ya fue completada, no se puede cancelar.");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Desea cancelar esta cita?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.No)
                return;

            MessageBox.Show(await citasBLL.CancelarCitaAsync(citaSeleccionada.Id));
            await CargarCitasAsync();
        }

        // Abre frmRegistrarCita en modo reprogramar con la cita seleccionada
        private async void btnReprogramar_Click(object sender, EventArgs e)
        {
            var citaSeleccionada = ObtenerCitaSeleccionada();
            if (citaSeleccionada == null)
            {
                MessageBox.Show("Seleccione una cita de la tabla para reprogramar.");
                return;
            }

            if (citaSeleccionada.Estado == "Cancelada")
            {
                MessageBox.Show("Esta cita ya está cancelada, no se puede reprogramar.");
                return;
            }
            if (citaSeleccionada.Estado == "Completada")
            {
                MessageBox.Show("Esta cita ya fue completada, no se puede reprogramar.");
                return;
            }

            this.Hide();
            using (frmRegistrarCita frmReprogramar = new frmRegistrarCita(citaSeleccionada.CitaOriginal))
            {
                frmReprogramar.ShowDialog();
            }
            this.Show();

            await CargarCitasAsync();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}