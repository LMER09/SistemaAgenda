using SistemaAgenda.Negocios;
using SistemaAgenda.Datos;
using System.Linq;

namespace SistemaAgenda.UI
{
    public partial class frmConsultarPagos : Form
    {
        private readonly PagosBLL pagosBLL = new PagosBLL();
        private readonly CitasBLL citasBLL = new CitasBLL();
        private readonly ClientesBLL clientesBLL = new ClientesBLL();
        private readonly ServiciosBLL serviciosBLL = new ServiciosBLL();

        // Clase auxiliar solo para mostrar en la tabla -- no es una entidad de la
        // base de datos, es una combinacion legible de Pagos + Citas + Clientes + Servicios.
        private class PagoVista
        {
            public int Id { get; set; }
            public string Cliente { get; set; } = string.Empty;
            public string Servicio { get; set; } = string.Empty;
            public DateTime FechaCita { get; set; }
            public decimal Monto { get; set; }
            public string MetodoDePago { get; set; } = string.Empty;
            public DateTime FechaPago { get; set; }
        }

        private List<PagoVista> _listaPagos = new List<PagoVista>();

        public frmConsultarPagos()
        {
            InitializeComponent();
        }

        private void frmConsultarPagos_Load(object sender, EventArgs e)
        {
            CargarPagos();
        }

        private void CargarPagos()
        {
            var pagos = pagosBLL.ObtenerTodos();
            var citas = citasBLL.ObtenerTodos();
            var clientes = clientesBLL.ObtenerTodos();
            var servicios = serviciosBLL.ObtenerTodos();

            _listaPagos = pagos.Select(p =>
            {
                var cita = citas.FirstOrDefault(c => c.Id == p.Id_Citas);
                var cliente = cita != null ? clientes.FirstOrDefault(c => c.Id == cita.Id_Clientes) : null;
                var servicio = cita != null ? servicios.FirstOrDefault(s => s.Id == cita.Id_Servicios) : null;

                return new PagoVista
                {
                    Id = p.Id,
                    Cliente = cliente != null ? $"{cliente.Nombre} {cliente.Apellido}" : "Cliente desconocido",
                    Servicio = servicio != null ? servicio.Tipo_DeServicio : "Servicio desconocido",
                    FechaCita = cita?.Fecha ?? DateTime.MinValue,
                    Monto = p.Monto,
                    MetodoDePago = p.Metodo_DePago,
                    FechaPago = p.FechaPago
                };
            }).OrderByDescending(pv => pv.FechaPago).ToList();

            dgvPagos.DataSource = null;
            dgvPagos.DataSource = _listaPagos;

            dgvPagos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (dgvPagos.Columns["Id"] != null)
                dgvPagos.Columns["Id"].Visible = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string texto = txtBuscar.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(texto))
            {
                dgvPagos.DataSource = null;
                dgvPagos.DataSource = _listaPagos;
                return;
            }

            var resultado = _listaPagos.Where(p =>
                p.Cliente.ToLower().Contains(texto) ||
                p.Servicio.ToLower().Contains(texto) ||
                p.MetodoDePago.ToLower().Contains(texto)
            ).ToList();

            dgvPagos.DataSource = null;
            dgvPagos.DataSource = resultado;

            if (resultado.Count == 0)
                MessageBox.Show($"No se encontró ningún pago que coincida con \"{txtBuscar.Text}\".",
                    "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvPagos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un pago de la tabla para eliminar.");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Desea eliminar este pago? Esto no revierte el estado de la cita.",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.No)
                return;

            int id = Convert.ToInt32(dgvPagos.CurrentRow.Cells["Id"].Value);
            MessageBox.Show(pagosBLL.Eliminar(id));

            CargarPagos();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}