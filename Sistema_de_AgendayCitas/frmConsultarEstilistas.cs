using SistemaAgenda.Negocios;
using SistemaAgenda.Datos;
using System.Linq;
using System.Text;

namespace SistemaAgenda.UI
{
    public partial class frmConsultarEstilistas : Form
    {
        private EstilistaBLL estilistaBLL = new EstilistaBLL();
        private HorarioEstilistaBLL horarioBLL = new HorarioEstilistaBLL();
        private List<Estilista> listaEstilistas = new List<Estilista>();

        // Nombres de los dias en el mismo orden que DiaSemana (0=Domingo...6=Sabado)
        private static readonly string[] NombresDias =
            { "Domingo", "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado" };

        public frmConsultarEstilistas()
        {
            InitializeComponent();
        }
        private async void frmConsultarEstilistas_Load(object sender, EventArgs e)
        {
            await CargarEstilistasAsync();
        }
        // Trae todas las estilistas y las muestra en la tabla
        private async Task CargarEstilistasAsync()
        {
            listaEstilistas = await estilistaBLL.ObtenerTodosAsync();

            dgvEstilistas.DataSource = null;
            dgvEstilistas.DataSource = listaEstilistas;

            dgvEstilistas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEstilistas.Columns["Id"].Visible = false;

            lblHorarioDetalle.Text = "Seleccione un estilista para ver su horario.";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string texto = txtBuscar.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(texto))
            {
                dgvEstilistas.DataSource = null;
                dgvEstilistas.DataSource = listaEstilistas;
                return;
            }

            var resultado = listaEstilistas.Where(es =>
                es.Nombre.ToLower().Contains(texto) ||
                es.Apellido.ToLower().Contains(texto) ||
                es.Especialidad.ToLower().Contains(texto) ||
                es.Cedula.ToLower().Contains(texto)
            ).ToList();

            dgvEstilistas.DataSource = null;
            dgvEstilistas.DataSource = resultado;

            if (resultado.Count == 0)
                MessageBox.Show($"No se encontró ningún estilista que coincida con \"{txtBuscar.Text}\".",
                    "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Al seleccionar una fila, muestra el horario de esa estilista abajo
        private async void dgvEstilistas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            Estilista estilistaSeleccionado = (Estilista)dgvEstilistas.CurrentRow.DataBoundItem;
            await MostrarHorarioAsync(estilistaSeleccionado.Id);
        }

        private async Task MostrarHorarioAsync(int idEstilista)
        {
            var horarios = await horarioBLL.ObtenerPorEstilistaAsync(idEstilista);

            if (horarios.Count == 0)
            {
                lblHorarioDetalle.Text = "Sin horario laboral registrado.";
                lblHorarioDetalle.ForeColor = Color.Firebrick;
                return;
            }

            var dias = horarios
                .OrderBy(h => h.DiaSemana)
                .Select(h => NombresDias[h.DiaSemana]);

            string diasTexto = string.Join(", ", dias);

            var primero = horarios[0];
            string horaTexto = $"{DateTime.Today.Add(primero.HoraInicio):hh:mm tt} a {DateTime.Today.Add(primero.HoraFin):hh:mm tt}";

            lblHorarioDetalle.Text = $"{diasTexto} — {horaTexto}";
            lblHorarioDetalle.ForeColor = Color.DarkGreen;
        }

        // Abre frmRegistrarEstilistas en modo edicion con el estilista seleccionado.
        private async void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvEstilistas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un estilista de la tabla para editar.");
                return;
            }

            Estilista estilistaSeleccionado = (Estilista)dgvEstilistas.CurrentRow.DataBoundItem;

            this.Hide();
            using (frmRegistrarEstilistas frmEditar = new frmRegistrarEstilistas(estilistaSeleccionado))
            {
                frmEditar.ShowDialog();
            }
            this.Show();

            await CargarEstilistasAsync();
        }
        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvEstilistas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un estilista de la tabla para eliminar.");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Desea eliminar este estilista?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.No)
                return;

            int id = Convert.ToInt32(dgvEstilistas.CurrentRow.Cells["Id"].Value);
            MessageBox.Show(await estilistaBLL.EliminarAsync(id));

            await CargarEstilistasAsync();
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}