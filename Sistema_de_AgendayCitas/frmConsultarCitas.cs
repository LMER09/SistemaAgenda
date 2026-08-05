using SistemaAgenda.Negocios;
using SistemaAgenda.Datos;
using System.Linq;

namespace SistemaAgenda.UI
{
    public partial class frmConsultarCitas : Form
    {
        private readonly CitasBLL citasBLL = new CitasBLL();
        private readonly ClientesBLL clientesBLL = new ClientesBLL();
        private readonly ServiciosBLL serviciosBLL = new ServiciosBLL();
        private readonly EstilistaBLL estilistaBLL = new EstilistaBLL();
        private readonly RecordatorioCitas recordatorio = new RecordatorioCitas();

        // Clase auxiliar solo para mostrar en la tabla -- no es una entidad de la
        // base de datos, es una combinacion legible de Citas + Clientes + Servicios + Estilista.
        // Guarda tambien la Citas original, para no tener que volver a buscarla
        // al cancelar o reprogramar.
        private class CitaVista
        {
            public Citas CitaOriginal { get; set; } = null!;
            public int Id => CitaOriginal.Id;
            public string Cliente { get; set; } = string.Empty;
            public string Servicio { get; set; } = string.Empty;
            public string Estilista { get; set; } = string.Empty;
            public DateTime Fecha => CitaOriginal.Fecha;
            public string Estado => CitaOriginal.Estado;
            public decimal Deposito => CitaOriginal.Deposito;
        }

        private List<CitaVista> _listaCitas = new List<CitaVista>();

        public frmConsultarCitas()
        {
            InitializeComponent();

            // Conecta el evento del recordatorio para enviar el correo al cliente
            // cuando una cita esta proxima (misma logica que tenia el frmAgenda viejo).
            recordatorio.RecordatorioDisparado += (cita, mensaje) =>
            {
                if (cita == null) return;

                var clientes = clientesBLL.ObtenerTodos();
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

        private void frmConsultarCitas_Load(object sender, EventArgs e)
        {
            CargarCitas();
            // Revisa aqui las citas proximas (envia recordatorio por correo si aplica),
            // ya que este es el formulario donde se "vigilan" las citas.
            recordatorio.RevisarCitasProximas(citasBLL.ObtenerTodos());
        }

        private void CargarCitas()
        {
            var citas = citasBLL.ObtenerTodos();
            var clientes = clientesBLL.ObtenerTodos();
            var servicios = serviciosBLL.ObtenerTodos();
            var estilistas = estilistaBLL.ObtenerTodos();

            _listaCitas = citas.Select(c =>
            {
                var cliente = clientes.FirstOrDefault(cl => cl.Id == c.Id_Clientes);
                var servicio = servicios.FirstOrDefault(s => s.Id == c.Id_Servicios);
                var estilista = estilistas.FirstOrDefault(es => es.Id == c.Id_Estilista);

                return new CitaVista
                {
                    CitaOriginal = c,
                    Cliente = cliente != null ? $"{cliente.Nombre} {cliente.Apellido}" : "Cliente desconocido",
                    Servicio = servicio != null ? $"{servicio.Tipo_DeServicio} - {servicio.Subtipo_DeServicio}" : "Servicio desconocido",
                    Estilista = estilista != null ? $"{estilista.Nombre} {estilista.Apellido}" : "Estilista desconocida"
                };
            }).OrderBy(cv => cv.Fecha).ToList();

            MostrarEnTabla(_listaCitas);
            CargarCalendario();
        }

        private void MostrarEnTabla(List<CitaVista> lista)
        {
            dgvCitas.DataSource = null;
            dgvCitas.DataSource = lista.Select(cv => new
            {
                cv.Id,
                cv.Cliente,
                cv.Servicio,
                cv.Estilista,
                cv.Fecha,
                cv.Estado,
                cv.Deposito
            }).ToList();

            dgvCitas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // Marca en el calendario los dias que tienen al menos una cita activa
        // (no canceladas), para que se vean de un vistazo.
        private void CargarCalendario()
        {
            var fechasConCita = _listaCitas
                .Where(cv => cv.Estado != "Cancelada")
                .Select(cv => cv.Fecha.Date)
                .Distinct()
                .ToArray();

            calCitas.BoldedDates = fechasConCita;
        }

        // Al elegir un dia en el calendario, filtra la tabla para mostrar
        // solo las citas de ese dia.
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

        private CitaVista? ObtenerCitaSeleccionada()
        {
            if (dgvCitas.CurrentRow == null) return null;
            int id = Convert.ToInt32(dgvCitas.CurrentRow.Cells["Id"].Value);
            return _listaCitas.FirstOrDefault(cv => cv.Id == id);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
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

            MessageBox.Show(citasBLL.CancelarCita(citaSeleccionada.Id));
            CargarCitas();
        }

        // Abre frmRegistrarCita en modo reprogramar con la cita seleccionada.
        // Al cerrarse ese formulario, esta pantalla se refresca sola.
        private void btnReprogramar_Click(object sender, EventArgs e)
        {
            var citaSeleccionada = ObtenerCitaSeleccionada();
            if (citaSeleccionada == null)
            {
                MessageBox.Show("Seleccione una cita de la tabla para reprogramar.");
                return;
            }

            // Mismo bloqueo que ya tiene CitasBLL.ReprogramarCita, pero se avisa
            // aqui de una vez para no dejar abrir el formulario innecesariamente.
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

            CargarCitas();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}