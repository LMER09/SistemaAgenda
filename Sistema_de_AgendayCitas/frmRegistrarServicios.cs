using SistemaAgenda.Negocios;
using SistemaAgenda.Datos;

namespace SistemaAgenda.UI
{
    public partial class frmRegistrarServicios : Form
    {
        private ServiciosBLL serviciosBLL = new ServiciosBLL();
        private bool habilitado = false;

        // Si no es null, el formulario esta editando este servicio en vez de crear uno nuevo
        private Servicios? _servicioEditando = null;
        private bool ModoEdicion => _servicioEditando != null;

        // Constructor normal: registrar un servicio nuevo
        public frmRegistrarServicios()
        {
            InitializeComponent();
            HabilitarControles(false);
        }

        // Constructor de edicion: recibe el servicio ya existente
        public frmRegistrarServicios(Servicios servicio) : this()
        {
            _servicioEditando = servicio;
        }

        // Habilita o deshabilita los campos y los botones de guardar/calcular
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

        // Alterna entre habilitado y deshabilitado
        private void btnHabilitar_Click(object sender, EventArgs e)
        {
            HabilitarControles(!habilitado);
        }

        // Cierra el formulario
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Vacia los campos, para dejar el formulario listo para otro registro
        private void Limpiar()
        {
            cmbTipo.SelectedIndex = -1;
            cmbSubtipo.Items.Clear();
            cmbSubtipo.SelectedIndex = -1;
            txtPrecio.Clear();
            txtDuracion.Clear();
        }

        // Si esta en modo edicion, precarga los datos del servicio
        private void frmRegistrarServicios_Load(object sender, EventArgs e)
        {
            if (ModoEdicion)
            {
                this.Text = "Editar Servicio";
                lblIngrese.Text = "Editando servicio:";
                btnAgregar.Text = "💾 Guardar cambios";

                cmbTipo.Text = _servicioEditando!.Tipo_DeServicio;
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

        // Llena el combo de subtipo segun el tipo elegido, para que coincida con el CHECK de la base de datos
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

        // Valida que se hayan elegido tipo, subtipo, precio y duracion
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

        // Muestra el mensaje de resultado, en verde si fue exito o rojo si fue error
        private void MostrarResultado(string mensaje, bool esExito)
        {
            lblResultado.Text = mensaje;
            lblResultado.ForeColor = esExito ? Color.DarkGreen : Color.Firebrick;
        }

        // Registra un servicio nuevo o guarda los cambios si esta en modo edicion
        private async void btnAgregar_Click(object sender, EventArgs e)
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

                string resultadoEdicion = await serviciosBLL.ActualizarAsync(servicio);
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

            string resultado = await serviciosBLL.RegistrarAsync(nuevoServicio);
            bool exito = resultado.StartsWith("OK");

            MostrarResultado(exito ? "Servicio registrado exitosamente." : resultado, exito);

            if (exito)
            {
                Limpiar();
                cmbTipo.Focus();
            }
        }

        // Calcula y muestra el precio final y la duracion, sin guardar nada
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

        // Solo permite numeros y un punto decimal en el precio
        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != (char)Keys.Back)
                e.Handled = true;

            if (e.KeyChar == '.' && txtPrecio.Text.Contains('.'))
                e.Handled = true;
        }

        // Solo permite numeros en la duracion
        private void txtDuracion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }
    }
}