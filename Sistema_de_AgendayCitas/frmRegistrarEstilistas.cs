using SistemaAgenda.Negocios;
using SistemaAgenda.Datos;
using System.Linq;

namespace SistemaAgenda.UI
{
    public partial class frmRegistrarEstilistas : Form
    {
        private EstilistaBLL estilistaBLL = new EstilistaBLL();
        private HorarioEstilistaBLL horarioBLL = new HorarioEstilistaBLL();
        private bool habilitado = false;
        private Estilista? _estilistaEditando = null;
        private bool ModoEdicion => _estilistaEditando != null;
        public frmRegistrarEstilistas()
        {
            InitializeComponent();
            HabilitarControles(false);
        }
        public frmRegistrarEstilistas(Estilista estilista) : this()
        {
            _estilistaEditando = estilista;
        }

        private void HabilitarControles(bool habilitar)
        {
            habilitado = habilitar;

            txtNombre.Enabled = habilitar;
            txtApellido.Enabled = habilitar;
            txtTelefono.Enabled = habilitar;
            txtCorreo.Enabled = habilitar;
            txtCedula.Enabled = habilitar;
            txtEspecialidad.Enabled = habilitar;

            chkDomingo.Enabled = habilitar;
            chkLunes.Enabled = habilitar;
            chkMartes.Enabled = habilitar;
            chkMiercoles.Enabled = habilitar;
            chkJueves.Enabled = habilitar;
            chkViernes.Enabled = habilitar;
            chkSabado.Enabled = habilitar;
            dtpHoraInicio.Enabled = habilitar;
            dtpHoraFin.Enabled = habilitar;

            btnAgregar.Enabled = habilitar;

            if (habilitar)
            {
                btnHabilitar.Text = "🔒 Deshabilitar campos";
                btnHabilitar.BackColor = Color.Gray;
                lblResultado.Text = ModoEdicion
                    ? "Modifique los datos y presione \"Guardar cambios\"."
                    : "Los campos están habilitados. Puede ingresar los datos.";
                lblResultado.ForeColor = Color.DarkGreen;
                txtNombre.Focus();
            }
            else
            {
                btnHabilitar.Text = "🔓 Habilitar campos";
                btnHabilitar.BackColor = Color.DeepPink;
                lblResultado.Text = "Los campos están deshabilitados. Presione \"Habilitar campos\" para ingresar un nuevo estilista.";
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
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtCedula.Clear();
            txtEspecialidad.Clear();

            chkDomingo.Checked = false;
            chkLunes.Checked = false;
            chkMartes.Checked = false;
            chkMiercoles.Checked = false;
            chkJueves.Checked = false;
            chkViernes.Checked = false;
            chkSabado.Checked = false;
            dtpHoraInicio.Value = DateTime.Today.AddHours(9);   // por defecto
            dtpHoraFin.Value = DateTime.Today.AddHours(17);     // por defecto
        }

        private void FrmRegistrarEstilistas_Load(object sender, EventArgs e)
        {
            if (ModoEdicion)
            {
                this.Text = "Editar Estilista";
                lblIngrese.Text = "Editando estilista:";
                btnAgregar.Text = "💾 Guardar cambios";

                txtNombre.Text = _estilistaEditando!.Nombre;
                txtApellido.Text = _estilistaEditando.Apellido;
                txtTelefono.Text = _estilistaEditando.Telefono;
                txtCorreo.Text = _estilistaEditando.Correo;
                txtCedula.Text = _estilistaEditando.Cedula;
                txtEspecialidad.Text = _estilistaEditando.Especialidad;

                CargarHorarioExistente(_estilistaEditando.Id);

                HabilitarControles(true);
            }
            else
            {
                HabilitarControles(false);
            }
        }
        private void CargarHorarioExistente(int idEstilista)
        {
            var horarios = horarioBLL.ObtenerPorEstilista(idEstilista);
            if (horarios.Count == 0) return;

            foreach (var h in horarios)
            {
                switch (h.DiaSemana)
                {
                    case 0: chkDomingo.Checked = true; break;
                    case 1: chkLunes.Checked = true; break;
                    case 2: chkMartes.Checked = true; break;
                    case 3: chkMiercoles.Checked = true; break;
                    case 4: chkJueves.Checked = true; break;
                    case 5: chkViernes.Checked = true; break;
                    case 6: chkSabado.Checked = true; break;
                }
            }

            var primero = horarios[0];
            dtpHoraInicio.Value = DateTime.Today.Add(primero.HoraInicio);
            dtpHoraFin.Value = DateTime.Today.Add(primero.HoraFin);
        }

        // Arma la lista de HorarioEstilista segun los checkboxes marcados y las dos horas elegidas.
        private List<HorarioEstilista> ArmarHorarioDesdeFormulario()
        {
            var dias = new List<(byte numero, CheckBox chk)>
            {
                (0, chkDomingo),
                (1, chkLunes),
                (2, chkMartes),
                (3, chkMiercoles),
                (4, chkJueves),
                (5, chkViernes),
                (6, chkSabado),
            };

            var lista = new List<HorarioEstilista>();
            foreach (var (numero, chk) in dias)
            {
                if (chk.Checked)
                {
                    lista.Add(new HorarioEstilista
                    {
                        DiaSemana = numero,
                        HoraInicio = dtpHoraInicio.Value.TimeOfDay,
                        HoraFin = dtpHoraFin.Value.TimeOfDay
                    });
                }
            }
            return lista;
        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                string.IsNullOrWhiteSpace(txtEspecialidad.Text))
            {
                MostrarResultado("Debe completar todos los campos.", esExito: false);
                return false;
            }

            if (!txtCorreo.Text.Contains("@") || !txtCorreo.Text.Contains("."))
            {
                MostrarResultado("Ingrese un correo válido.", esExito: false);
                txtCorreo.Focus();
                return false;
            }

            if (txtTelefono.Text.Length != 12)
            {
                MostrarResultado("Ingrese un teléfono válido (000-000-0000).", esExito: false);
                txtTelefono.Focus();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtCedula.Text) && txtCedula.Text.Length != 13)
            {
                MostrarResultado("Si ingresa cédula, debe tener el formato completo (000-0000000-0).", esExito: false);
                txtCedula.Focus();
                return false;
            }

            bool algunDiaMarcado = chkDomingo.Checked || chkLunes.Checked || chkMartes.Checked ||
                                    chkMiercoles.Checked || chkJueves.Checked || chkViernes.Checked || chkSabado.Checked;

            if (!algunDiaMarcado)
            {
                MostrarResultado("Debe marcar al menos un día de trabajo. Sin horario, no se le podrán agendar citas.", esExito: false);
                return false;
            }

            if (dtpHoraInicio.Value.TimeOfDay >= dtpHoraFin.Value.TimeOfDay)
            {
                MostrarResultado("La hora de inicio debe ser antes que la hora de fin.", esExito: false);
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
                Estilista estilista = new Estilista
                {
                    Id = _estilistaEditando!.Id,
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Telefono = txtTelefono.Text,
                    Correo = txtCorreo.Text,
                    Cedula = txtCedula.Text.Trim(),
                    Especialidad = txtEspecialidad.Text
                };

                string resultadoEdicion = estilistaBLL.Actualizar(estilista);
                bool exitoEdicion = resultadoEdicion.StartsWith("OK");

                if (!exitoEdicion)
                {
                    MostrarResultado(resultadoEdicion, esExito: false);
                    return;
                }

                // Reemplaza el horario completo con lo que este marcado ahora en pantalla
                string resultadoHorario = horarioBLL.GuardarHorarioCompleto(estilista.Id, ArmarHorarioDesdeFormulario());
                if (!resultadoHorario.StartsWith("OK"))
                {
                    MostrarResultado("Estilista actualizada, pero hubo un problema con el horario: " + resultadoHorario, esExito: false);
                    return;
                }

                MessageBox.Show("Estilista y horario actualizados exitosamente.");
                Close();
                return;
            }

            Estilista nuevoEstilista = new Estilista
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Telefono = txtTelefono.Text,
                Correo = txtCorreo.Text,
                Cedula = txtCedula.Text.Trim(),
                Especialidad = txtEspecialidad.Text
            };

            string resultado = estilistaBLL.Registrar(nuevoEstilista);
            bool exito = resultado.StartsWith("OK");

            if (!exito)
            {
                MostrarResultado(resultado, esExito: false);
                return;
            }

            // El Insertar no devuelve el Id nuevo, asi que lo buscamos por el correo, que ya es unico en la base de datos.
            var estilistaCreada = estilistaBLL.ObtenerTodos()
                .FirstOrDefault(es => es.Correo == nuevoEstilista.Correo);

            if (estilistaCreada == null)
            {
                MostrarResultado("Estilista registrada, pero no se pudo asignar el horario automáticamente. Edítela para agregarlo.", esExito: false);
                Limpiar();
                return;
            }

            string resultadoHorarioNuevo = horarioBLL.GuardarHorarioCompleto(estilistaCreada.Id, ArmarHorarioDesdeFormulario());
            bool exitoHorario = resultadoHorarioNuevo.StartsWith("OK");

            MostrarResultado(exitoHorario
                ? "Estilista y horario registrados exitosamente."
                : "Estilista registrada, pero hubo un problema con el horario: " + resultadoHorarioNuevo,
                exitoHorario);

            if (exitoHorario)
            {
                Limpiar();
                txtNombre.Focus();
            }
        }

        //Evita números en nombre/apellido
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }
        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }

        // Da formato automáticamente al teléfono: 000-000-0000
        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            string texto = txtTelefono.Text.Replace("-", "");

            if (texto.Length > 10)
                texto = texto.Substring(0, 10);

            if (texto.Length > 3)
                texto = texto.Insert(3, "-");

            if (texto.Length > 7)
                texto = texto.Insert(7, "-");

            txtTelefono.Text = texto;
            txtTelefono.SelectionStart = txtTelefono.Text.Length;
        }
        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }

        // Formato automático de cédula: 000-0000000-0
        private void txtCedula_TextChanged(object sender, EventArgs e)
        {
            string texto = txtCedula.Text.Replace("-", "");

            if (texto.Length > 11)
                texto = texto.Substring(0, 11);

            if (texto.Length > 3)
                texto = texto.Insert(3, "-");

            if (texto.Length > 11)
                texto = texto.Insert(11, "-");

            txtCedula.Text = texto;
            txtCedula.SelectionStart = txtCedula.Text.Length;
        }
        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }
    }
}