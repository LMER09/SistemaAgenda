using SistemaAgenda.Negocios;
using SistemaAgenda.Datos;

namespace SistemaAgenda.UI
{
    public partial class frmRegistrarServicios : Form
    {
        private ServiciosBLL serviciosBLL = new ServiciosBLL();
        private bool habilitado = false;

        // Si no es null, el formulario esta editando este servicio
        // en vez de crear uno nuevo.
        private Servicios? _servicioEditando = null;
        private bool ModoEdicion => _servicioEditando != null;

        // Constructor normal: registrar un servicio nuevo
        public frmRegistrarServicios()
        {
            InitializeComponent();
            HabilitarControles(false);
        }

        // Constructor de edicion: recibe el servicio ya existente,
        // desde frmConsultarServicios al presionar "Editar".
        public frmRegistrarServicios(Servicios servicio) : this()
        {
            _servicioEditando = servicio;
        }

        private void HabilitarControles(bool habilitar)
        {
            habilitado = habilitar;

            cmbTipo.Enabled = habilitar;
            cmbSubtipo.Enabled = habilitar;
            txtPrecio.Enabled = habilitar;
            txtDuracion.Enabled = habilitar;
            btnAgregar.Enabled = habilitar;
            btnCalcular.Enabled = habilitar;

            if (habilitar)
            {
                btnHabilitar.Text = "🔒 Deshabilitar campos";
                btnHabilitar.BackColor = Color.Gray;
                lblResultado.Text = ModoEdicion
                    ? "Modifique los datos y presione \"Guardar cambios\"."
                    : "Los campos están habilitados. Puede ingresar los datos.";
                lblResultado.ForeColor = Color.DarkGreen;
                cmbTipo.Focus();
            }
            else
            {
                btnHabilitar.Text = "🔓 Habilitar campos";
                btnHabilitar.BackColor = Color.DeepPink;
                lblResultado.Text = "Los campos están deshabilitados. Presione \"Habilitar campos\" para ingresar un nuevo servicio.";
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
            cmbTipo.SelectedIndex = -1;
            cmbSubtipo.Items.Clear();
            cmbSubtipo.SelectedIndex = -1;
            txtPrecio.Clear();
            txtDuracion.Clear();
        }

        private void frmRegistrarServicios_Load(object sender, EventArgs e)
        {
            if (ModoEdicion)
            {
                this.Text = "Editar Servicio";
                lblIngrese.Text = "Editando servicio:";
                btnAgregar.Text = "💾 Guardar cambios";

                cmbTipo.Text = _servicioEditando!.Tipo_DeServicio;
                // Dispara el llenado de cmbSubtipo con las opciones correctas
                // antes de intentar seleccionar el valor guardado.
                cmbTipo_SelectedIndexChanged(sender, e);
                if (cmbSubtipo.Items.Contains(_servicioEditando.Subtipo_DeServicio))
                    cmbSubtipo.Text = _servicioEditando.Subtipo_DeServicio;

                txtPrecio.Text = _servicioEditando.Precio.ToString();
                txtDuracion.Text = _servicioEditando.DuracionMinutos.ToString();

                HabilitarControles(true);
            }
            else
            {
                HabilitarControles(false);
            }
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

        private bool ValidarDatos()
        {
            if (cmbTipo.SelectedIndex == -1 || cmbSubtipo.SelectedIndex == -1 ||
                txtPrecio.Text == "" || txtDuracion.Text == "")
            {
                MostrarResultado("Debe llenar todos los datos, incluyendo el subtipo.", esExito: false);
                return false;
            }
            return true;
        }

        private void MostrarResultado(string mensaje, bool esExito)
        {
            lblResultado.Text = mensaje;
            lblResultado.ForeColor = esExito ? Color.DarkGreen : Color.Firebrick;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos())
                return;

            if (ModoEdicion)
            {
                Servicios servicio = new Servicios
                {
                    Id = _servicioEditando!.Id,
                    Tipo_DeServicio = cmbTipo.Text,
                    Subtipo_DeServicio = cmbSubtipo.Text,
                    Precio = Convert.ToDecimal(txtPrecio.Text),
                    DuracionMinutos = Convert.ToInt32(txtDuracion.Text)
                };

                string resultadoEdicion = serviciosBLL.Actualizar(servicio);
                bool exitoEdicion = resultadoEdicion.StartsWith("OK");

                if (exitoEdicion)
                {
                    MessageBox.Show("Servicio actualizado exitosamente.");
                    Close();
                }
                else
                {
                    MostrarResultado(resultadoEdicion, esExito: false);
                }
                return;
            }

            Servicios nuevoServicio = new Servicios
            {
                Tipo_DeServicio = cmbTipo.Text,
                Subtipo_DeServicio = cmbSubtipo.Text,
                Precio = Convert.ToDecimal(txtPrecio.Text),
                DuracionMinutos = Convert.ToInt32(txtDuracion.Text)
            };

            string resultado = serviciosBLL.Registrar(nuevoServicio);
            bool exito = resultado.StartsWith("OK");

            MostrarResultado(exito ? "Servicio registrado exitosamente." : resultado, exito);

            if (exito)
            {
                Limpiar();
                cmbTipo.Focus();
            }
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos())
                return;

            Servicios baseServicio = new Servicios
            {
                Tipo_DeServicio = cmbTipo.Text,
                Subtipo_DeServicio = cmbSubtipo.Text,
                Precio = Convert.ToDecimal(txtPrecio.Text),
                DuracionMinutos = Convert.ToInt32(txtDuracion.Text)
            };

            Servicio s = new Gestion_DeServicios(baseServicio);

            MostrarResultado($"Precio final: RD${s.CalcularPrecio():F2}  |  Duración: {s.CalcularDuracion()} min", esExito: true);
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
    }
}