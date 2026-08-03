namespace SistemaAgenda.UI
{
    partial class frmAgenda
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAgenda));
            dgvCitas = new DataGridView();
            btnAgendar = new Button();
            groupBox1 = new GroupBox();
            btnActualizarLista = new Button();
            btnCancelar = new Button();
            btnReprogramar = new Button();
            lblDeposito = new Label();
            dtpHora = new DateTimePicker();
            lblHora = new Label();
            dtpFecha = new DateTimePicker();
            lblFecha = new Label();
            cmbEstilistas = new ComboBox();
            lblEstilistas = new Label();
            cmbServicios = new ComboBox();
            lblServicios = new Label();
            cmbClientes = new ComboBox();
            lblClientes = new Label();
            lblPrecioServicio = new Label();
            groupBox2 = new GroupBox();
            picLogo = new PictureBox();
            btnLimpiar = new Button();
            lblPuedeCambiar = new Label();
            btnPagar = new Button();
            cmbMetodoPago = new ComboBox();
            lblMetodoPago = new Label();
            txtMonto = new TextBox();
            lblMonto = new Label();
            mcalCitas = new MonthCalendar();
            btnVerTodas = new Button();
            lblFiltroCalendario = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvCitas).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            // 
            // dgvCitas
            // 
            dgvCitas.BackgroundColor = Color.LavenderBlush;
            dgvCitas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCitas.GridColor = Color.LavenderBlush;
            dgvCitas.Location = new Point(45, 476);
            dgvCitas.Name = "dgvCitas";
            dgvCitas.RowHeadersWidth = 51;
            dgvCitas.Size = new Size(660, 196);
            dgvCitas.TabIndex = 8;
            dgvCitas.CellClick += dgvCitas_CellClick;
            dgvCitas.CellFormatting += dgvCitas_CellFormatting;
            // 
            // btnAgendar
            // 
            btnAgendar.BackColor = Color.DeepPink;
            btnAgendar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAgendar.ForeColor = Color.White;
            btnAgendar.Location = new Point(24, 310);
            btnAgendar.Name = "btnAgendar";
            btnAgendar.Size = new Size(164, 43);
            btnAgendar.TabIndex = 9;
            btnAgendar.Text = "🗓 Agendar";
            btnAgendar.UseVisualStyleBackColor = false;
            btnAgendar.Click += btnAgendar_Click;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.ButtonHighlight;
            groupBox1.Controls.Add(btnActualizarLista);
            groupBox1.Controls.Add(btnCancelar);
            groupBox1.Controls.Add(btnReprogramar);
            groupBox1.Controls.Add(lblDeposito);
            groupBox1.Controls.Add(dtpHora);
            groupBox1.Controls.Add(lblHora);
            groupBox1.Controls.Add(dtpFecha);
            groupBox1.Controls.Add(lblFecha);
            groupBox1.Controls.Add(cmbEstilistas);
            groupBox1.Controls.Add(lblEstilistas);
            groupBox1.Controls.Add(cmbServicios);
            groupBox1.Controls.Add(lblServicios);
            groupBox1.Controls.Add(cmbClientes);
            groupBox1.Controls.Add(lblClientes);
            groupBox1.Controls.Add(btnAgendar);
            groupBox1.Location = new Point(45, 28);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(453, 424);
            groupBox1.TabIndex = 23;
            groupBox1.TabStop = false;
            groupBox1.Text = "Registrar Cita:";
            // 
            // btnActualizarLista
            // 
            btnActualizarLista.BackColor = Color.DeepPink;
            btnActualizarLista.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnActualizarLista.ForeColor = Color.White;
            btnActualizarLista.Location = new Point(215, 311);
            btnActualizarLista.Name = "btnActualizarLista";
            btnActualizarLista.Size = new Size(164, 43);
            btnActualizarLista.TabIndex = 25;
            btnActualizarLista.Text = "🔃 Actualizar lista";
            btnActualizarLista.UseVisualStyleBackColor = false;
            btnActualizarLista.Click += btnActualizarLista_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.DeepPink;
            btnCancelar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(215, 362);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(164, 43);
            btnCancelar.TabIndex = 24;
            btnCancelar.Text = "❌ Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnReprogramar
            // 
            btnReprogramar.BackColor = Color.DeepPink;
            btnReprogramar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReprogramar.ForeColor = Color.White;
            btnReprogramar.Location = new Point(24, 362);
            btnReprogramar.Name = "btnReprogramar";
            btnReprogramar.Size = new Size(164, 43);
            btnReprogramar.TabIndex = 23;
            btnReprogramar.Text = "🔄 Reprogramar";
            btnReprogramar.UseVisualStyleBackColor = false;
            btnReprogramar.Click += btnReprogramar_Click;
            // 
            // lblDeposito
            // 
            lblDeposito.AutoSize = true;
            lblDeposito.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDeposito.ForeColor = Color.DeepPink;
            lblDeposito.Location = new Point(24, 274);
            lblDeposito.Name = "lblDeposito";
            lblDeposito.Size = new Size(273, 25);
            lblDeposito.TabIndex = 22;
            lblDeposito.Text = "Depósito requerido: RD$0.00";
            // 
            // dtpHora
            // 
            dtpHora.Format = DateTimePickerFormat.Time;
            dtpHora.Location = new Point(255, 232);
            dtpHora.Name = "dtpHora";
            dtpHora.ShowUpDown = true;
            dtpHora.Size = new Size(124, 31);
            dtpHora.TabIndex = 17;
            dtpHora.ValueChanged += dtpHora_ValueChanged;
            // 
            // lblHora
            // 
            lblHora.AutoSize = true;
            lblHora.Location = new Point(255, 209);
            lblHora.Name = "lblHora";
            lblHora.Size = new Size(56, 25);
            lblHora.TabIndex = 16;
            lblHora.Text = "Hora:";
            // 
            // dtpFecha
            // 
            dtpFecha.Location = new Point(24, 232);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(225, 31);
            dtpFecha.TabIndex = 15;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(24, 209);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(62, 25);
            lblFecha.TabIndex = 14;
            lblFecha.Text = "Fecha:";
            lblFecha.Click += lblFecha_Click;
            // 
            // cmbEstilistas
            // 
            cmbEstilistas.FormattingEnabled = true;
            cmbEstilistas.Location = new Point(24, 173);
            cmbEstilistas.Name = "cmbEstilistas";
            cmbEstilistas.Size = new Size(355, 33);
            cmbEstilistas.TabIndex = 9;
            // 
            // lblEstilistas
            // 
            lblEstilistas.AutoSize = true;
            lblEstilistas.Location = new Point(20, 148);
            lblEstilistas.Name = "lblEstilistas";
            lblEstilistas.Size = new Size(83, 25);
            lblEstilistas.TabIndex = 8;
            lblEstilistas.Text = "Estilistas";
            // 
            // cmbServicios
            // 
            cmbServicios.FormattingEnabled = true;
            cmbServicios.Location = new Point(24, 114);
            cmbServicios.Name = "cmbServicios";
            cmbServicios.Size = new Size(355, 33);
            cmbServicios.TabIndex = 7;
            cmbServicios.SelectedIndexChanged += cmbServicios_SelectedIndexChanged;
            // 
            // lblServicios
            // 
            lblServicios.AutoSize = true;
            lblServicios.Location = new Point(24, 91);
            lblServicios.Name = "lblServicios";
            lblServicios.Size = new Size(86, 25);
            lblServicios.TabIndex = 6;
            lblServicios.Text = "Servicios";
            // 
            // cmbClientes
            // 
            cmbClientes.FormattingEnabled = true;
            cmbClientes.Location = new Point(24, 55);
            cmbClientes.Name = "cmbClientes";
            cmbClientes.Size = new Size(355, 33);
            cmbClientes.TabIndex = 5;
            // 
            // lblClientes
            // 
            lblClientes.AutoSize = true;
            lblClientes.Location = new Point(24, 32);
            lblClientes.Name = "lblClientes";
            lblClientes.Size = new Size(79, 25);
            lblClientes.TabIndex = 4;
            lblClientes.Text = "Clientes";
            lblClientes.Click += lblClientes_Click;
            // 
            // lblPrecioServicio
            // 
            lblPrecioServicio.AutoSize = true;
            lblPrecioServicio.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPrecioServicio.ForeColor = Color.DeepPink;
            lblPrecioServicio.Location = new Point(22, 47);
            lblPrecioServicio.Name = "lblPrecioServicio";
            lblPrecioServicio.Size = new Size(230, 25);
            lblPrecioServicio.TabIndex = 21;
            lblPrecioServicio.Text = "Precio servicio: RD$0.00";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(picLogo);
            groupBox2.Controls.Add(btnLimpiar);
            groupBox2.Controls.Add(lblPuedeCambiar);
            groupBox2.Controls.Add(btnPagar);
            groupBox2.Controls.Add(cmbMetodoPago);
            groupBox2.Controls.Add(lblMetodoPago);
            groupBox2.Controls.Add(lblPrecioServicio);
            groupBox2.Controls.Add(txtMonto);
            groupBox2.Controls.Add(lblMonto);
            groupBox2.Location = new Point(536, 28);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(436, 424);
            groupBox2.TabIndex = 24;
            groupBox2.TabStop = false;
            groupBox2.Text = "Registre el pago de la cita seleccionada:";
            // 
            // picLogo
            // 
            picLogo.BackColor = Color.Transparent;
            picLogo.Image = (Image)resources.GetObject("picLogo.Image");
            picLogo.Location = new Point(251, 168);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(127, 137);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 24;
            picLogo.TabStop = false;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.DeepPink;
            btnLimpiar.BackgroundImageLayout = ImageLayout.Center;
            btnLimpiar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLimpiar.ForeColor = Color.White;
            btnLimpiar.Location = new Point(224, 310);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(164, 43);
            btnLimpiar.TabIndex = 23;
            btnLimpiar.Text = "🗑️Limpiar todo";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // lblPuedeCambiar
            // 
            lblPuedeCambiar.AutoSize = true;
            lblPuedeCambiar.Font = new Font("Segoe UI Semibold", 7.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblPuedeCambiar.ForeColor = Color.DimGray;
            lblPuedeCambiar.Location = new Point(22, 148);
            lblPuedeCambiar.Name = "lblPuedeCambiar";
            lblPuedeCambiar.Size = new Size(471, 21);
            lblPuedeCambiar.TabIndex = 22;
            lblPuedeCambiar.Text = "Nota: Puede cambiar el precio si hizo mas del precio establecido";
            // 
            // btnPagar
            // 
            btnPagar.BackColor = Color.DeepPink;
            btnPagar.BackgroundImageLayout = ImageLayout.Center;
            btnPagar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPagar.ForeColor = Color.White;
            btnPagar.Location = new Point(36, 311);
            btnPagar.Name = "btnPagar";
            btnPagar.Size = new Size(164, 43);
            btnPagar.TabIndex = 21;
            btnPagar.Text = "💳 Registrar pago";
            btnPagar.UseVisualStyleBackColor = false;
            btnPagar.Click += btnPagar_Click;
            // 
            // cmbMetodoPago
            // 
            cmbMetodoPago.FormattingEnabled = true;
            cmbMetodoPago.Items.AddRange(new object[] { "Efectivo", "Tarjeta", "Transferencia" });
            cmbMetodoPago.Location = new Point(22, 221);
            cmbMetodoPago.Name = "cmbMetodoPago";
            cmbMetodoPago.Size = new Size(201, 33);
            cmbMetodoPago.TabIndex = 20;
            // 
            // lblMetodoPago
            // 
            lblMetodoPago.AutoSize = true;
            lblMetodoPago.Location = new Point(22, 189);
            lblMetodoPago.Name = "lblMetodoPago";
            lblMetodoPago.Size = new Size(156, 25);
            lblMetodoPago.TabIndex = 19;
            lblMetodoPago.Text = "Método de pago:";
            // 
            // txtMonto
            // 
            txtMonto.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMonto.Location = new Point(22, 114);
            txtMonto.Name = "txtMonto";
            txtMonto.PlaceholderText = "Ej: 200";
            txtMonto.Size = new Size(201, 31);
            txtMonto.TabIndex = 18;
            txtMonto.KeyPress += txtMonto_KeyPress;
            // 
            // lblMonto
            // 
            lblMonto.AutoSize = true;
            lblMonto.Location = new Point(22, 81);
            lblMonto.Name = "lblMonto";
            lblMonto.Size = new Size(73, 25);
            lblMonto.TabIndex = 16;
            lblMonto.Text = "Monto:";
            // 
            // mcalCitas
            // 
            mcalCitas.Location = new Point(722, 476);
            mcalCitas.MaxSelectionCount = 1;
            mcalCitas.Name = "mcalCitas";
            mcalCitas.TabIndex = 26;
            mcalCitas.DateChanged += mcalCitas_DateChanged;
            // 
            // btnVerTodas
            // 
            btnVerTodas.BackColor = Color.DeepPink;
            btnVerTodas.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnVerTodas.ForeColor = Color.White;
            btnVerTodas.Location = new Point(470, 687);
            btnVerTodas.Name = "btnVerTodas";
            btnVerTodas.Size = new Size(240, 33);
            btnVerTodas.TabIndex = 27;
            btnVerTodas.Text = "📋 Ver todas las citas";
            btnVerTodas.UseVisualStyleBackColor = false;
            btnVerTodas.Click += btnVerTodas_Click;
            // 
            // lblFiltroCalendario
            // 
            lblFiltroCalendario.AutoSize = true;
            lblFiltroCalendario.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFiltroCalendario.ForeColor = Color.DimGray;
            lblFiltroCalendario.Location = new Point(760, 455);
            lblFiltroCalendario.Name = "lblFiltroCalendario";
            lblFiltroCalendario.Size = new Size(233, 21);
            lblFiltroCalendario.TabIndex = 28;
            lblFiltroCalendario.Text = "Los días en negrita tienen citas";
            // 
            // frmAgenda
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(1043, 732);
            Controls.Add(lblFiltroCalendario);
            Controls.Add(btnVerTodas);
            Controls.Add(mcalCitas);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(dgvCitas);
            Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = Color.Black;
            Name = "frmAgenda";
            Text = "Agenda y Pagos";
            Load += frmAgenda_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCitas).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dgvCitas;
        private Button btnAgendar;
        private GroupBox groupBox1;
        private Label lblDeposito;
        private DateTimePicker dtpHora;
        private Label lblHora;
        private DateTimePicker dtpFecha;
        private Label lblFecha;
        private ComboBox cmbEstilistas;
        private Label lblEstilistas;
        private ComboBox cmbServicios;
        private Label lblServicios;
        private ComboBox cmbClientes;
        private Label lblClientes;
        private Button btnActualizarLista;
        private Button btnCancelar;
        private Button btnReprogramar;
        private GroupBox groupBox2;
        private ComboBox cmbMetodoPago;
        private Label lblMetodoPago;
        private TextBox txtMonto;
        private Label lblMonto;
        private Button btnPagar;
        private Label lblPrecioServicio;
        private Label lblPuedeCambiar;
        private Button btnLimpiar;
        private PictureBox picLogo;
        private MonthCalendar mcalCitas;
        private Button btnVerTodas;
        private Label lblFiltroCalendario;
    }
}