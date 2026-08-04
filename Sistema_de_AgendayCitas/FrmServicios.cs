using SistemaAgenda.Negocios;
using SistemaAgenda.Datos;

namespace SistemaAgenda.UI
{
    public partial class frmServicios : Form
    {
        private ServiciosBLL serviciosBLL = new ServiciosBLL();

        public frmServicios()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            cmbTipo.SelectedIndex = -1;
            cmbSubtipo.Items.Clear();
            cmbSubtipo.SelectedIndex = -1;
            txtPrecio.Clear();
            txtDuracion.Clear();
            lblResultado.Text = "";
            cmbTipo.Focus();
        }

        private void CargarServicios()
        {
            dgvServicios.DataSource = null;
            dgvServicios.DataSource = serviciosBLL.ObtenerTodos();
        }

        private void FrmServicios_Load(object sender, EventArgs e)
        {
            CargarServicios();
        }

        // Llena cmbSubtipo segun el tipo elegido en cmbTipo.
        // Los valores deben coincidir exactamente con el CHECK de la base de datos.
        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbSubtipo.Items.Clear();

            switch (cmbTipo.Text)
            {
                case "Cabello":
                    cmbSubtipo.Items.AddRange(new object[] { "Corte", "Tinte", "Completo" });
                    break;
                case "Uñas":
                    cmbSubtipo.Items.AddRange(new object[] { "Manicura", "Pedicura", "Completo" });
                    break;
                case "Spa":
                    cmbSubtipo.Items.AddRange(new object[] { "Sencillo", "Premium", "Profesional" });
                    break;
            }

            cmbSubtipo.SelectedIndex = -1;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cmbTipo.SelectedIndex == -1 || cmbSubtipo.SelectedIndex == -1 || txtPrecio.Text == "" || txtDuracion.Text == "")
            {
                MessageBox.Show("Debe llenar los datos requeridos, incluyendo el subtipo");
                return;
            }
            Servicios servicio = new Servicios();
            servicio.Tipo_DeServicio = cmbTipo.Text;
            servicio.Subtipo_DeServicio = cmbSubtipo.Text;
            servicio.Precio = Convert.ToDecimal(txtPrecio.Text);
            servicio.DuracionMinutos = Convert.ToInt32(txtDuracion.Text);

            MessageBox.Show(serviciosBLL.Registrar(servicio));

            CargarServicios(); Limpiar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (cmbTipo.SelectedIndex == -1 || cmbSubtipo.SelectedIndex == -1 || txtPrecio.Text == "" || txtDuracion.Text == "")
            {
                MessageBox.Show("Seleccione la opcion que desea editar, incluyendo el subtipo");
                return;
            }
            if (dgvServicios.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un servicio.");
                return;
            }

            Servicios servicio = new Servicios();
            servicio.Id = Convert.ToInt32(dgvServicios.CurrentRow.Cells["Id"].Value);
            servicio.Tipo_DeServicio = cmbTipo.Text;
            servicio.Subtipo_DeServicio = cmbSubtipo.Text;
            servicio.Precio = Convert.ToDecimal(txtPrecio.Text);
            servicio.DuracionMinutos = Convert.ToInt32(txtDuracion.Text);

            MessageBox.Show(serviciosBLL.Actualizar(servicio));

            CargarServicios(); Limpiar();
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvServicios.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvServicios.CurrentRow.Cells["Id"].Value);
                MessageBox.Show(serviciosBLL.Eliminar(id));
                CargarServicios();
                Limpiar();
            }
            else
            {
                MessageBox.Show("Seleccione un servicio.");
            }
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (cmbTipo.SelectedIndex == -1 || cmbSubtipo.SelectedIndex == -1 || txtPrecio.Text == "" || txtDuracion.Text == "")
            {
                MessageBox.Show("Complete tipo, subtipo, precio y duración primero" +
                    " o seleccione el servicio que desea calcular");
                return;
            }

            Servicios baseServicio = new Servicios
            {
                Tipo_DeServicio = cmbTipo.Text,
                Subtipo_DeServicio = cmbSubtipo.Text,
                Precio = Convert.ToDecimal(txtPrecio.Text),
                DuracionMinutos = Convert.ToInt32(txtDuracion.Text)
            };

            Servicio s = new Gestion_DeServicios(baseServicio);

            lblResultado.Text = $"Precio final: RD${s.CalcularPrecio():F2}  |  Duración: {s.CalcularDuracion()} min";
        }

        private void dgvServicios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                cmbTipo.Text = dgvServicios.CurrentRow.Cells["Tipo_DeServicio"].Value.ToString();

                // Dispara cmbTipo_SelectedIndexChanged para llenar las opciones de subtipo
                // correctas antes de intentar seleccionar el valor guardado.
                cmbTipo_SelectedIndexChanged(sender, e);

                var valorSubtipo = dgvServicios.CurrentRow.Cells["Subtipo_DeServicio"].Value?.ToString();
                if (!string.IsNullOrEmpty(valorSubtipo) && cmbSubtipo.Items.Contains(valorSubtipo))
                    cmbSubtipo.Text = valorSubtipo;

                txtPrecio.Text = dgvServicios.CurrentRow.Cells["Precio"].Value.ToString();
                txtDuracion.Text = dgvServicios.CurrentRow.Cells["DuracionMinutos"].Value.ToString();
            }
        }

        //Evita entrar letras en precio y duracion
        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != (char)Keys.Back)
                e.Handled = true;

            if (e.KeyChar == '.' && txtPrecio.Text.Contains('.'))
                e.Handled = true;
        }
        private void txtDuracion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}