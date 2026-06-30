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
            cmbClientes = new ComboBox();
            cmbServicios = new ComboBox();
            cmbEstilistas = new ComboBox();
            lblClientes = new Label();
            lblServicios = new Label();
            lblEstilistas = new Label();
            dtpFecha = new DateTimePicker();
            dtpHora = new DateTimePicker();
            dgvCitas = new DataGridView();
            btnAgendar = new Button();
            btnCancelar = new Button();
            btnReprogramar = new Button();
            btnActualizarLista = new Button();
            lblFecha = new Label();
            lblHora = new Label();
            txtMonto = new TextBox();
            cmbMetodoPago = new ComboBox();
            btnPagar = new Button();
            lblMonto = new Label();
            lblMetodoPago = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvCitas).BeginInit();
            SuspendLayout();
            // 
            // cmbClientes
            // 
            cmbClientes.FormattingEnabled = true;
            cmbClientes.Location = new Point(54, 126);
            cmbClientes.Name = "cmbClientes";
            cmbClientes.Size = new Size(293, 28);
            cmbClientes.TabIndex = 0;
            // 
            // cmbServicios
            // 
            cmbServicios.FormattingEnabled = true;
            cmbServicios.Location = new Point(54, 203);
            cmbServicios.Name = "cmbServicios";
            cmbServicios.Size = new Size(293, 28);
            cmbServicios.TabIndex = 1;
            // 
            // cmbEstilistas
            // 
            cmbEstilistas.FormattingEnabled = true;
            cmbEstilistas.Location = new Point(54, 278);
            cmbEstilistas.Name = "cmbEstilistas";
            cmbEstilistas.Size = new Size(293, 28);
            cmbEstilistas.TabIndex = 2;
            // 
            // lblClientes
            // 
            lblClientes.AutoSize = true;
            lblClientes.Location = new Point(54, 85);
            lblClientes.Name = "lblClientes";
            lblClientes.Size = new Size(62, 20);
            lblClientes.TabIndex = 3;
            lblClientes.Text = "Clientes";
            // 
            // lblServicios
            // 
            lblServicios.AutoSize = true;
            lblServicios.Location = new Point(54, 172);
            lblServicios.Name = "lblServicios";
            lblServicios.Size = new Size(70, 20);
            lblServicios.TabIndex = 4;
            lblServicios.Text = "Servicios";
            lblServicios.Click += lblServicios_Click;
            // 
            // lblEstilistas
            // 
            lblEstilistas.AutoSize = true;
            lblEstilistas.Location = new Point(54, 244);
            lblEstilistas.Name = "lblEstilistas";
            lblEstilistas.Size = new Size(65, 20);
            lblEstilistas.TabIndex = 5;
            lblEstilistas.Text = "Estilistas";
            // 
            // dtpFecha
            // 
            dtpFecha.Location = new Point(394, 127);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(291, 27);
            dtpFecha.TabIndex = 6;
            // 
            // dtpHora
            // 
            dtpHora.Format = DateTimePickerFormat.Time;
            dtpHora.Location = new Point(394, 204);
            dtpHora.Name = "dtpHora";
            dtpHora.ShowUpDown = true;
            dtpHora.Size = new Size(291, 27);
            dtpHora.TabIndex = 7;
            // 
            // dgvCitas
            // 
            dgvCitas.BackgroundColor = Color.OldLace;
            dgvCitas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCitas.GridColor = Color.LavenderBlush;
            dgvCitas.Location = new Point(54, 398);
            dgvCitas.Name = "dgvCitas";
            dgvCitas.RowHeadersWidth = 51;
            dgvCitas.Size = new Size(929, 173);
            dgvCitas.TabIndex = 8;
            // 
            // btnAgendar
            // 
            btnAgendar.Location = new Point(54, 335);
            btnAgendar.Name = "btnAgendar";
            btnAgendar.Size = new Size(164, 29);
            btnAgendar.TabIndex = 9;
            btnAgendar.Text = "Agendar";
            btnAgendar.UseVisualStyleBackColor = true;
            btnAgendar.Click += btnAgendar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(394, 335);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(152, 29);
            btnCancelar.TabIndex = 10;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnReprogramar
            // 
            btnReprogramar.Location = new Point(224, 335);
            btnReprogramar.Name = "btnReprogramar";
            btnReprogramar.Size = new Size(164, 29);
            btnReprogramar.TabIndex = 11;
            btnReprogramar.Text = "Reprogramar";
            btnReprogramar.UseVisualStyleBackColor = true;
            btnReprogramar.Click += btnReprogramar_Click;
            // 
            // btnActualizarLista
            // 
            btnActualizarLista.Location = new Point(552, 335);
            btnActualizarLista.Name = "btnActualizarLista";
            btnActualizarLista.Size = new Size(140, 29);
            btnActualizarLista.TabIndex = 12;
            btnActualizarLista.Text = "Actualizar lista";
            btnActualizarLista.UseVisualStyleBackColor = true;
            btnActualizarLista.Click += btnActualizarLista_Click;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(394, 85);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(53, 20);
            lblFecha.TabIndex = 13;
            lblFecha.Text = "Fecha:";
            // 
            // lblHora
            // 
            lblHora.AutoSize = true;
            lblHora.Location = new Point(394, 172);
            lblHora.Name = "lblHora";
            lblHora.Size = new Size(47, 20);
            lblHora.TabIndex = 14;
            lblHora.Text = "Hora:";
            // 
            // txtMonto
            // 
            txtMonto.Location = new Point(815, 203);
            txtMonto.Name = "txtMonto";
            txtMonto.PlaceholderText = "Ej: 200";
            txtMonto.Size = new Size(168, 27);
            txtMonto.TabIndex = 17;
            // 
            // cmbMetodoPago
            // 
            cmbMetodoPago.FormattingEnabled = true;
            cmbMetodoPago.Items.AddRange(new object[] { "Efectivo", "Tarjeta", "Transferencia" });
            cmbMetodoPago.Location = new Point(815, 278);
            cmbMetodoPago.Name = "cmbMetodoPago";
            cmbMetodoPago.Size = new Size(201, 28);
            cmbMetodoPago.TabIndex = 18;
            // 
            // btnPagar
            // 
            btnPagar.Location = new Point(815, 335);
            btnPagar.Name = "btnPagar";
            btnPagar.Size = new Size(201, 29);
            btnPagar.TabIndex = 19;
            btnPagar.Text = "Registrar pago";
            btnPagar.UseVisualStyleBackColor = true;
            btnPagar.Click += btnPagar_Click;
            // 
            // lblMonto
            // 
            lblMonto.AutoSize = true;
            lblMonto.Location = new Point(815, 172);
            lblMonto.Name = "lblMonto";
            lblMonto.Size = new Size(59, 20);
            lblMonto.TabIndex = 15;
            lblMonto.Text = "Monto:";
            // 
            // lblMetodoPago
            // 
            lblMetodoPago.AutoSize = true;
            lblMetodoPago.Location = new Point(815, 244);
            lblMetodoPago.Name = "lblMetodoPago";
            lblMetodoPago.Size = new Size(127, 20);
            lblMetodoPago.TabIndex = 16;
            lblMetodoPago.Text = "Método de pago:";
            // 
            // frmAgenda
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(1123, 638);
            Controls.Add(lblMonto);
            Controls.Add(lblMetodoPago);
            Controls.Add(txtMonto);
            Controls.Add(cmbMetodoPago);
            Controls.Add(btnPagar);
            Controls.Add(lblHora);
            Controls.Add(lblFecha);
            Controls.Add(btnActualizarLista);
            Controls.Add(btnReprogramar);
            Controls.Add(btnCancelar);
            Controls.Add(btnAgendar);
            Controls.Add(dgvCitas);
            Controls.Add(dtpHora);
            Controls.Add(dtpFecha);
            Controls.Add(lblEstilistas);
            Controls.Add(lblServicios);
            Controls.Add(lblClientes);
            Controls.Add(cmbEstilistas);
            Controls.Add(cmbServicios);
            Controls.Add(cmbClientes);
            Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = Color.Black;
            Name = "frmAgenda";
            Text = "Agenda";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCitas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbClientes;
        private ComboBox cmbServicios;
        private ComboBox cmbEstilistas;
        private Label lblClientes;
        private Label lblServicios;
        private Label lblEstilistas;
        private DateTimePicker dtpFecha;
        private DateTimePicker dtpHora;
        private DataGridView dgvCitas;
        private Button btnAgendar;
        private Button btnCancelar;
        private Button btnReprogramar;
        private Button btnActualizarLista;
        private Label lblFecha;
        private Label lblHora;
        private TextBox txtMonto;
        private ComboBox cmbMetodoPago;
        private Button btnPagar;
        private Label lblMonto;
        private Label lblMetodoPago;
    }
}
