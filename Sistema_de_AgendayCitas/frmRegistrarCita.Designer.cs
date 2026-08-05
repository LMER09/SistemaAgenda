namespace SistemaAgenda.UI
{
    partial class frmRegistrarCita
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblCliente = new Label();
            lblServicio = new Label();
            lblEstilista = new Label();
            lblFecha = new Label();
            lblHora = new Label();
            cmbClientes = new ComboBox();
            cmbServicios = new ComboBox();
            cmbEstilistas = new ComboBox();
            dtpFecha = new DateTimePicker();
            dtpHora = new DateTimePicker();
            lblPrecioServicio = new Label();
            lblDeposito = new Label();
            btnHabilitar = new Button();
            btnAgregar = new Button();
            btnCerrar = new Button();
            lblIngrese = new Label();
            lblResultado = new Label();
            picLogo = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Location = new Point(51, 94);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(60, 20);
            lblCliente.TabIndex = 0;
            lblCliente.Text = "Cliente:";
            // 
            // lblServicio
            // 
            lblServicio.AutoSize = true;
            lblServicio.Location = new Point(51, 127);
            lblServicio.Name = "lblServicio";
            lblServicio.Size = new Size(68, 20);
            lblServicio.TabIndex = 1;
            lblServicio.Text = "Servicio:";
            // 
            // lblEstilista
            // 
            lblEstilista.AutoSize = true;
            lblEstilista.Location = new Point(51, 160);
            lblEstilista.Name = "lblEstilista";
            lblEstilista.Size = new Size(63, 20);
            lblEstilista.TabIndex = 2;
            lblEstilista.Text = "Estilista:";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(51, 193);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(53, 20);
            lblFecha.TabIndex = 3;
            lblFecha.Text = "Fecha:";
            // 
            // lblHora
            // 
            lblHora.AutoSize = true;
            lblHora.Location = new Point(402, 200);
            lblHora.Name = "lblHora";
            lblHora.Size = new Size(47, 20);
            lblHora.TabIndex = 4;
            lblHora.Text = "Hora:";
            // 
            // cmbClientes
            // 
            cmbClientes.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbClientes.FormattingEnabled = true;
            cmbClientes.Location = new Point(230, 87);
            cmbClientes.Name = "cmbClientes";
            cmbClientes.Size = new Size(377, 28);
            cmbClientes.TabIndex = 5;
            // 
            // cmbServicios
            // 
            cmbServicios.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbServicios.FormattingEnabled = true;
            cmbServicios.Location = new Point(230, 120);
            cmbServicios.Name = "cmbServicios";
            cmbServicios.Size = new Size(377, 28);
            cmbServicios.TabIndex = 6;
            cmbServicios.SelectedIndexChanged += cmbServicios_SelectedIndexChanged;
            // 
            // cmbEstilistas
            // 
            cmbEstilistas.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstilistas.FormattingEnabled = true;
            cmbEstilistas.Location = new Point(230, 153);
            cmbEstilistas.Name = "cmbEstilistas";
            cmbEstilistas.Size = new Size(377, 28);
            cmbEstilistas.TabIndex = 7;
            // 
            // dtpFecha
            // 
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(230, 193);
            dtpFecha.MinDate = new DateTime(2020, 1, 1, 0, 0, 0, 0);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(156, 27);
            dtpFecha.TabIndex = 8;
            // 
            // dtpHora
            // 
            dtpHora.Format = DateTimePickerFormat.Time;
            dtpHora.Location = new Point(451, 193);
            dtpHora.Name = "dtpHora";
            dtpHora.ShowUpDown = true;
            dtpHora.Size = new Size(156, 27);
            dtpHora.TabIndex = 9;
            // 
            // lblPrecioServicio
            // 
            lblPrecioServicio.AutoSize = true;
            lblPrecioServicio.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPrecioServicio.ForeColor = Color.DeepPink;
            lblPrecioServicio.Location = new Point(51, 250);
            lblPrecioServicio.Name = "lblPrecioServicio";
            lblPrecioServicio.Size = new Size(192, 21);
            lblPrecioServicio.TabIndex = 10;
            lblPrecioServicio.Text = "Precio servicio: RD$0.00";
            // 
            // lblDeposito
            // 
            lblDeposito.AutoSize = true;
            lblDeposito.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDeposito.ForeColor = Color.DeepPink;
            lblDeposito.Location = new Point(51, 277);
            lblDeposito.Name = "lblDeposito";
            lblDeposito.Size = new Size(228, 21);
            lblDeposito.TabIndex = 11;
            lblDeposito.Text = "Depósito requerido: RD$0.00";
            // 
            // btnHabilitar
            // 
            btnHabilitar.BackColor = Color.DeepPink;
            btnHabilitar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHabilitar.ForeColor = Color.White;
            btnHabilitar.Location = new Point(51, 318);
            btnHabilitar.Name = "btnHabilitar";
            btnHabilitar.Size = new Size(195, 43);
            btnHabilitar.TabIndex = 12;
            btnHabilitar.Text = "🔓 Habilitar campos";
            btnHabilitar.UseVisualStyleBackColor = false;
            btnHabilitar.Click += btnHabilitar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.DeepPink;
            btnAgregar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAgregar.ForeColor = Color.White;
            btnAgregar.Location = new Point(254, 318);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(195, 43);
            btnAgregar.TabIndex = 13;
            btnAgregar.Text = "📅 Agendar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.BackColor = Color.Gray;
            btnCerrar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCerrar.ForeColor = Color.White;
            btnCerrar.Location = new Point(457, 318);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(150, 43);
            btnCerrar.TabIndex = 14;
            btnCerrar.Text = "❌ Cerrar";
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // lblIngrese
            // 
            lblIngrese.AutoSize = true;
            lblIngrese.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblIngrese.Location = new Point(51, 30);
            lblIngrese.Name = "lblIngrese";
            lblIngrese.Size = new Size(163, 23);
            lblIngrese.TabIndex = 15;
            lblIngrese.Text = "Agendar nueva cita:";
            // 
            // lblResultado
            // 
            lblResultado.AutoSize = true;
            lblResultado.Font = new Font("Segoe UI", 9.5F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblResultado.ForeColor = Color.DimGray;
            lblResultado.Location = new Point(51, 384);
            lblResultado.MaximumSize = new Size(650, 0);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(599, 21);
            lblResultado.TabIndex = 16;
            lblResultado.Text = "Los campos están deshabilitados. Presione \"Habilitar campos\" para agendar una cita.";
            // 
            // picLogo
            // 
            picLogo.BackColor = Color.Transparent;
            picLogo.Location = new Point(560, 30);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(1, 1);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 17;
            picLogo.TabStop = false;
            picLogo.Visible = false;
            // 
            // frmRegistrarCita
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(721, 433);
            Controls.Add(picLogo);
            Controls.Add(lblResultado);
            Controls.Add(lblIngrese);
            Controls.Add(btnCerrar);
            Controls.Add(btnAgregar);
            Controls.Add(btnHabilitar);
            Controls.Add(lblDeposito);
            Controls.Add(lblPrecioServicio);
            Controls.Add(dtpHora);
            Controls.Add(dtpFecha);
            Controls.Add(cmbEstilistas);
            Controls.Add(cmbServicios);
            Controls.Add(cmbClientes);
            Controls.Add(lblHora);
            Controls.Add(lblFecha);
            Controls.Add(lblEstilista);
            Controls.Add(lblServicio);
            Controls.Add(lblCliente);
            Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "frmRegistrarCita";
            Text = "Agendar Cita";
            TransparencyKey = Color.FromArgb(255, 224, 192);
            Load += frmRegistrarCita_Load;
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblCliente;
        private Label lblServicio;
        private Label lblEstilista;
        private Label lblFecha;
        private Label lblHora;
        private ComboBox cmbClientes;
        private ComboBox cmbServicios;
        private ComboBox cmbEstilistas;
        private DateTimePicker dtpFecha;
        private DateTimePicker dtpHora;
        private Label lblPrecioServicio;
        private Label lblDeposito;
        private Button btnHabilitar;
        private Button btnAgregar;
        private Button btnCerrar;
        private Label lblIngrese;
        private Label lblResultado;
        private PictureBox picLogo;
    }
}