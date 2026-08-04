namespace SistemaAgenda.UI
{
    partial class frmRegistrarEstilistas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblNombre = new Label();
            lblApellido = new Label();
            lblTelefono = new Label();
            lblCorreo = new Label();
            lblCedula = new Label();
            lblEspecialidad = new Label();
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            txtTelefono = new TextBox();
            txtCorreo = new TextBox();
            txtCedula = new TextBox();
            txtEspecialidad = new TextBox();
            lblHorario = new Label();
            chkDomingo = new CheckBox();
            chkLunes = new CheckBox();
            chkMartes = new CheckBox();
            chkMiercoles = new CheckBox();
            chkJueves = new CheckBox();
            chkViernes = new CheckBox();
            chkSabado = new CheckBox();
            lblHoraInicio = new Label();
            dtpHoraInicio = new DateTimePicker();
            lblHoraFin = new Label();
            dtpHoraFin = new DateTimePicker();
            btnHabilitar = new Button();
            btnAgregar = new Button();
            btnCerrar = new Button();
            lblIngrese = new Label();
            lblResultado = new Label();
            picLogo = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(51, 94);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(70, 20);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre:";
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(51, 127);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(70, 20);
            lblApellido.TabIndex = 1;
            lblApellido.Text = "Apellido:";
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(51, 160);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(72, 20);
            lblTelefono.TabIndex = 2;
            lblTelefono.Text = "Teléfono:";
            // 
            // lblCorreo
            // 
            lblCorreo.AutoSize = true;
            lblCorreo.Location = new Point(51, 193);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(60, 20);
            lblCorreo.TabIndex = 3;
            lblCorreo.Text = "Correo:";
            // 
            // lblCedula
            // 
            lblCedula.AutoSize = true;
            lblCedula.Location = new Point(51, 226);
            lblCedula.Name = "lblCedula";
            lblCedula.Size = new Size(60, 20);
            lblCedula.TabIndex = 4;
            lblCedula.Text = "Cedula:";
            // 
            // lblEspecialidad
            // 
            lblEspecialidad.AutoSize = true;
            lblEspecialidad.Location = new Point(51, 259);
            lblEspecialidad.Name = "lblEspecialidad";
            lblEspecialidad.Size = new Size(97, 20);
            lblEspecialidad.TabIndex = 5;
            lblEspecialidad.Text = "Especialidad:";
            // 
            // txtNombre
            // 
            txtNombre.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombre.Location = new Point(162, 87);
            txtNombre.Name = "txtNombre";
            txtNombre.PlaceholderText = "Ej: Maria";
            txtNombre.Size = new Size(357, 27);
            txtNombre.TabIndex = 6;
            txtNombre.KeyPress += txtNombre_KeyPress;
            // 
            // txtApellido
            // 
            txtApellido.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtApellido.Location = new Point(162, 120);
            txtApellido.Name = "txtApellido";
            txtApellido.PlaceholderText = "Ej: Cedano";
            txtApellido.Size = new Size(357, 27);
            txtApellido.TabIndex = 7;
            txtApellido.KeyPress += txtApellido_KeyPress;
            // 
            // txtTelefono
            // 
            txtTelefono.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTelefono.Location = new Point(162, 153);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.PlaceholderText = "Ej: 000-000-0000";
            txtTelefono.Size = new Size(357, 27);
            txtTelefono.TabIndex = 8;
            txtTelefono.TextChanged += txtTelefono_TextChanged;
            txtTelefono.KeyPress += txtTelefono_KeyPress;
            // 
            // txtCorreo
            // 
            txtCorreo.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCorreo.Location = new Point(162, 186);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.PlaceholderText = "Ej: maria@gmail.com";
            txtCorreo.Size = new Size(357, 27);
            txtCorreo.TabIndex = 9;
            // 
            // txtCedula
            // 
            txtCedula.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCedula.Location = new Point(162, 219);
            txtCedula.Name = "txtCedula";
            txtCedula.PlaceholderText = "Ej: 001-1234567-8";
            txtCedula.Size = new Size(357, 27);
            txtCedula.TabIndex = 10;
            txtCedula.TextChanged += txtCedula_TextChanged;
            txtCedula.KeyPress += txtCedula_KeyPress;
            // 
            // txtEspecialidad
            // 
            txtEspecialidad.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEspecialidad.Location = new Point(162, 252);
            txtEspecialidad.Name = "txtEspecialidad";
            txtEspecialidad.PlaceholderText = "Ej: Cortes de pelo";
            txtEspecialidad.Size = new Size(357, 27);
            txtEspecialidad.TabIndex = 11;
            // 
            // lblHorario
            // 
            lblHorario.AutoSize = true;
            lblHorario.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHorario.Location = new Point(51, 304);
            lblHorario.Name = "lblHorario";
            lblHorario.Size = new Size(124, 21);
            lblHorario.TabIndex = 12;
            lblHorario.Text = "Horario laboral:";
            // 
            // chkDomingo
            // 
            chkDomingo.AutoSize = true;
            chkDomingo.Location = new Point(54, 333);
            chkDomingo.Name = "chkDomingo";
            chkDomingo.Size = new Size(95, 24);
            chkDomingo.TabIndex = 13;
            chkDomingo.Text = "Domingo";
            chkDomingo.UseVisualStyleBackColor = true;
            // 
            // chkLunes
            // 
            chkLunes.AutoSize = true;
            chkLunes.Location = new Point(165, 333);
            chkLunes.Name = "chkLunes";
            chkLunes.Size = new Size(70, 24);
            chkLunes.TabIndex = 14;
            chkLunes.Text = "Lunes";
            chkLunes.UseVisualStyleBackColor = true;
            // 
            // chkMartes
            // 
            chkMartes.AutoSize = true;
            chkMartes.Location = new Point(253, 333);
            chkMartes.Name = "chkMartes";
            chkMartes.Size = new Size(78, 24);
            chkMartes.TabIndex = 15;
            chkMartes.Text = "Martes";
            chkMartes.UseVisualStyleBackColor = true;
            // 
            // chkMiercoles
            // 
            chkMiercoles.AutoSize = true;
            chkMiercoles.Location = new Point(353, 333);
            chkMiercoles.Name = "chkMiercoles";
            chkMiercoles.Size = new Size(97, 24);
            chkMiercoles.TabIndex = 16;
            chkMiercoles.Text = "Miércoles";
            chkMiercoles.UseVisualStyleBackColor = true;
            // 
            // chkJueves
            // 
            chkJueves.AutoSize = true;
            chkJueves.Location = new Point(474, 333);
            chkJueves.Name = "chkJueves";
            chkJueves.Size = new Size(76, 24);
            chkJueves.TabIndex = 17;
            chkJueves.Text = "Jueves";
            chkJueves.UseVisualStyleBackColor = true;
            // 
            // chkViernes
            // 
            chkViernes.AutoSize = true;
            chkViernes.Location = new Point(574, 333);
            chkViernes.Name = "chkViernes";
            chkViernes.Size = new Size(82, 24);
            chkViernes.TabIndex = 18;
            chkViernes.Text = "Viernes";
            chkViernes.UseVisualStyleBackColor = true;
            // 
            // chkSabado
            // 
            chkSabado.AutoSize = true;
            chkSabado.Location = new Point(698, 333);
            chkSabado.Name = "chkSabado";
            chkSabado.Size = new Size(82, 24);
            chkSabado.TabIndex = 19;
            chkSabado.Text = "Sábado";
            chkSabado.UseVisualStyleBackColor = true;
            // 
            // lblHoraInicio
            // 
            lblHoraInicio.AutoSize = true;
            lblHoraInicio.Location = new Point(51, 382);
            lblHoraInicio.Name = "lblHoraInicio";
            lblHoraInicio.Size = new Size(88, 20);
            lblHoraInicio.TabIndex = 20;
            lblHoraInicio.Text = "Hora inicio:";
            // 
            // dtpHoraInicio
            // 
            dtpHoraInicio.Format = DateTimePickerFormat.Time;
            dtpHoraInicio.Location = new Point(145, 375);
            dtpHoraInicio.Name = "dtpHoraInicio";
            dtpHoraInicio.ShowUpDown = true;
            dtpHoraInicio.Size = new Size(272, 27);
            dtpHoraInicio.TabIndex = 21;
            // 
            // lblHoraFin
            // 
            lblHoraFin.AutoSize = true;
            lblHoraFin.Location = new Point(434, 382);
            lblHoraFin.Name = "lblHoraFin";
            lblHoraFin.Size = new Size(69, 20);
            lblHoraFin.TabIndex = 22;
            lblHoraFin.Text = "Hora fin:";
            // 
            // dtpHoraFin
            // 
            dtpHoraFin.Format = DateTimePickerFormat.Time;
            dtpHoraFin.Location = new Point(509, 377);
            dtpHoraFin.Name = "dtpHoraFin";
            dtpHoraFin.ShowUpDown = true;
            dtpHoraFin.Size = new Size(271, 27);
            dtpHoraFin.TabIndex = 23;
            // 
            // btnHabilitar
            // 
            btnHabilitar.BackColor = Color.DeepPink;
            btnHabilitar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHabilitar.ForeColor = Color.White;
            btnHabilitar.Location = new Point(51, 423);
            btnHabilitar.Name = "btnHabilitar";
            btnHabilitar.Size = new Size(262, 43);
            btnHabilitar.TabIndex = 24;
            btnHabilitar.Text = "🔓 Habilitar campos";
            btnHabilitar.UseVisualStyleBackColor = false;
            btnHabilitar.Click += btnHabilitar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.DeepPink;
            btnAgregar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAgregar.ForeColor = Color.White;
            btnAgregar.Location = new Point(317, 423);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(262, 43);
            btnAgregar.TabIndex = 25;
            btnAgregar.Text = "➕ Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.BackColor = Color.Gray;
            btnCerrar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCerrar.ForeColor = Color.White;
            btnCerrar.Location = new Point(585, 423);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(195, 43);
            btnCerrar.TabIndex = 26;
            btnCerrar.Text = "❌ Cerrar";
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // lblIngrese
            // 
            lblIngrese.AutoSize = true;
            lblIngrese.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblIngrese.Location = new Point(51, 34);
            lblIngrese.Name = "lblIngrese";
            lblIngrese.Size = new Size(184, 23);
            lblIngrese.TabIndex = 27;
            lblIngrese.Text = "Ingrese nuevo estilista:";
            // 
            // lblResultado
            // 
            lblResultado.AutoSize = true;
            lblResultado.Font = new Font("Segoe UI", 9.5F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblResultado.ForeColor = Color.DimGray;
            lblResultado.Location = new Point(51, 485);
            lblResultado.MaximumSize = new Size(700, 0);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(661, 21);
            lblResultado.TabIndex = 28;
            lblResultado.Text = "Los campos están deshabilitados. Presione \"Habilitar campos\" para ingresar un nuevo estilista.";
            // 
            // picLogo
            // 
            picLogo.BackColor = Color.Transparent;
            picLogo.Location = new Point(538, 34);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(242, 245);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 29;
            picLogo.TabStop = false;
            // 
            // frmRegistrarEstilistas
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(818, 536);
            Controls.Add(picLogo);
            Controls.Add(lblResultado);
            Controls.Add(lblIngrese);
            Controls.Add(btnCerrar);
            Controls.Add(btnAgregar);
            Controls.Add(btnHabilitar);
            Controls.Add(dtpHoraFin);
            Controls.Add(lblHoraFin);
            Controls.Add(dtpHoraInicio);
            Controls.Add(lblHoraInicio);
            Controls.Add(chkSabado);
            Controls.Add(chkViernes);
            Controls.Add(chkJueves);
            Controls.Add(chkMiercoles);
            Controls.Add(chkMartes);
            Controls.Add(chkLunes);
            Controls.Add(chkDomingo);
            Controls.Add(lblHorario);
            Controls.Add(txtEspecialidad);
            Controls.Add(txtCedula);
            Controls.Add(txtCorreo);
            Controls.Add(txtTelefono);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            Controls.Add(lblEspecialidad);
            Controls.Add(lblCedula);
            Controls.Add(lblCorreo);
            Controls.Add(lblTelefono);
            Controls.Add(lblApellido);
            Controls.Add(lblNombre);
            Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "frmRegistrarEstilistas";
            Text = "Registro de Estilistas";
            TransparencyKey = Color.FromArgb(255, 224, 192);
            Load += FrmRegistrarEstilistas_Load;
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNombre;
        private Label lblApellido;
        private Label lblTelefono;
        private Label lblCorreo;
        private Label lblCedula;
        private Label lblEspecialidad;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtTelefono;
        private TextBox txtCorreo;
        private TextBox txtCedula;
        private TextBox txtEspecialidad;
        private Label lblHorario;
        private CheckBox chkDomingo;
        private CheckBox chkLunes;
        private CheckBox chkMartes;
        private CheckBox chkMiercoles;
        private CheckBox chkJueves;
        private CheckBox chkViernes;
        private CheckBox chkSabado;
        private Label lblHoraInicio;
        private DateTimePicker dtpHoraInicio;
        private Label lblHoraFin;
        private DateTimePicker dtpHoraFin;
        private Button btnHabilitar;
        private Button btnAgregar;
        private Button btnCerrar;
        private Label lblIngrese;
        private Label lblResultado;
        private PictureBox picLogo;
    }
}