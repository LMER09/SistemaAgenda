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

        // Si no es null, el formulario esta editando este estilista en vez de crear uno nuevo
        private Estilista? _estilistaEditando = null;
        private bool ModoEdicion => _estilistaEditando != null;

        // Constructor normal: registrar un estilista nuevo
        public frmRegistrarEstilistas()
        {
            InitializeComponent();
            HabilitarControles(false);
        }

        // Constructor de edicion: recibe el estilista ya existente
        public frmRegistrarEstilistas(Estilista estilista) : this()
        {
            _estilistaEditando = estilista;
        }

        // Habilita o deshabilita todos los campos y el boton de guardar
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

        // Alterna entre habilitado y deshabilitado
        private void btnHabilitar_Click(object sender, EventArgs e)
        {
            HabilitarControles(!habilitado);
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Vacia todos los campos, para dejar el formulario listo para otro registro
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
            dtpHoraInicio.Value = DateTime.Today.AddHours(9);
            dtpHoraFin.Value = DateTime.Today.AddHours(17);
        }

        // Si esta en modo edicion, precarga los datos y el horario de la estilista
        private async void FrmRegistrarEstilistas_Load(object sender, EventArgs e)
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

                await CargarHorarioExistenteAsync(_estilistaEditando.Id);

                HabilitarControles(true);
            }
            else
            {
                HabilitarControles(false);
            }
        }

        // Marca los checkboxes y pone la hora inicio y fin del horario que ya tenia guardado
        private async Task CargarHorarioExistenteAsync(int idEstilista)
        {
            var horarios = await horarioBLL.ObtenerPorEstilistaAsync(idEstilista);
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

        // Arma la lista de HorarioEstilista segun los dias marcados en pantalla
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

        // Valida los campos, el formato de telefono y cedula, y que haya al menos un dia marcado
        private bool ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                string.IsNullOrWhiteSpace(txtEspecialidad.Text) ||
                string.IsNullOrWhiteSpace(txtCedula.Text))
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

        // Muestra el mensaje de resultado en pantalla, en verde si fue exito o rojo si fue error
        private void MostrarResultado(string mensaje, bool esExito)
        {
            lblResultado.Text = mensaje;
            lblResultado.ForeColor = esExito ? Color.DarkGreen : Color.Firebrick;
        }

        // Registra un estilista nueva o guarda los cambios si esta en modo edicion, junto con su horario
        private async void btnAgregar_Click(object sender, EventArgs e)
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

                string resultadoEdicion = await estilistaBLL.ActualizarAsync(estilista);
                bool exitoEdicion = resultadoEdicion.StartsWith("OK");

                if (!exitoEdicion)
                {
                    MostrarResultado(resultadoEdicion, esExito: false);
                    return;
                }

                string resultadoHorario = await horarioBLL.GuardarHorarioCompletoAsync(estilista.Id, ArmarHorarioDesdeFormulario());
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

            string resultado = await estilistaBLL.RegistrarAsync(nuevoEstilista);
            bool exito = resultado.StartsWith("OK");

            if (!exito)
            {
                MostrarResultado(resultado, esExito: false);
                return;
            }

            // Insertar no devuelve el Id nuevo, asi que se busca por correo que es unico
            var listaEstilistas = await estilistaBLL.ObtenerTodosAsync();
            var estilistaCreada = listaEstilistas.FirstOrDefault(es => es.Correo == nuevoEstilista.Correo);

            if (estilistaCreada == null)
            {
                MostrarResultado("Estilista registrada, pero no se pudo asignar el horario automáticamente. Edítela para agregarlo.", esExito: false);
                Limpiar();
                return;
            }

            string resultadoHorarioNuevo = await horarioBLL.GuardarHorarioCompletoAsync(estilistaCreada.Id, ArmarHorarioDesdeFormulario());
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

        // Evita numeros en nombre y apellido
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

        // Da formato automatico al telefono: 000-000-0000
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

        // Da formato automatico a la cedula: 000-0000000-0
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