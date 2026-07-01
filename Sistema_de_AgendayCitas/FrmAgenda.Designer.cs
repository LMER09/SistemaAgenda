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
            groupBox2 = new GroupBox();
            btnPagar = new Button();
            cmbMetodoPago = new ComboBox();
            lblMetodoPago = new Label();
            txtMonto = new TextBox();
            lblMonto = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvCitas).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // dgvCitas
            // 
            dgvCitas.BackgroundColor = Color.OldLace;
            dgvCitas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCitas.GridColor = Color.LavenderBlush;
            dgvCitas.Location = new Point(45, 476);
            dgvCitas.Name = "dgvCitas";
            dgvCitas.RowHeadersWidth = 51;
            dgvCitas.Size = new Size(928, 141);
            dgvCitas.TabIndex = 8;
            // 
            // btnAgendar
            // 
            btnAgendar.Location = new Point(24, 322);
            btnAgendar.Name = "btnAgendar";
            btnAgendar.Size = new Size(164, 29);
            btnAgendar.TabIndex = 9;
            btnAgendar.Text = "Agendar";
            btnAgendar.UseVisualStyleBackColor = true;
            btnAgendar.Click += btnAgendar_Click;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.LavenderBlush;
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
            btnActualizarLista.Location = new Point(215, 367);
            btnActualizarLista.Name = "btnActualizarLista";
            btnActualizarLista.Size = new Size(164, 29);
            btnActualizarLista.TabIndex = 25;
            btnActualizarLista.Text = "Actualizar lista";
            btnActualizarLista.UseVisualStyleBackColor = true;
            btnActualizarLista.Click += btnActualizarLista_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(215, 322);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(164, 29);
            btnCancelar.TabIndex = 24;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnReprogramar
            // 
            btnReprogramar.Location = new Point(24, 367);
            btnReprogramar.Name = "btnReprogramar";
            btnReprogramar.Size = new Size(164, 29);
            btnReprogramar.TabIndex = 23;
            btnReprogramar.Text = "Reprogramar";
            btnReprogramar.UseVisualStyleBackColor = true;
            btnReprogramar.Click += btnReprogramar_Click;
            // 
            // lblDeposito
            // 
            lblDeposito.AutoSize = true;
            lblDeposito.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDeposito.ForeColor = Color.Crimson;
            lblDeposito.Location = new Point(24, 275);
            lblDeposito.Name = "lblDeposito";
            lblDeposito.Size = new Size(213, 20);
            lblDeposito.TabIndex = 22;
            lblDeposito.Text = "Depósito requerido: RD$0.00";
            // 
            // dtpHora
            // 
            dtpHora.Format = DateTimePickerFormat.Time;
            dtpHora.Location = new Point(255, 222);
            dtpHora.Name = "dtpHora";
            dtpHora.ShowUpDown = true;
            dtpHora.Size = new Size(124, 27);
            dtpHora.TabIndex = 17;
            // 
            // lblHora
            // 
            lblHora.AutoSize = true;
            lblHora.Location = new Point(255, 199);
            lblHora.Name = "lblHora";
            lblHora.Size = new Size(47, 20);
            lblHora.TabIndex = 16;
            lblHora.Text = "Hora:";
            // 
            // dtpFecha
            // 
            dtpFecha.Location = new Point(24, 222);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(204, 27);
            dtpFecha.TabIndex = 15;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(24, 199);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(53, 20);
            lblFecha.TabIndex = 14;
            lblFecha.Text = "Fecha:";
            // 
            // cmbEstilistas
            // 
            cmbEstilistas.FormattingEnabled = true;
            cmbEstilistas.Location = new Point(24, 168);
            cmbEstilistas.Name = "cmbEstilistas";
            cmbEstilistas.Size = new Size(355, 28);
            cmbEstilistas.TabIndex = 9;
            // 
            // lblEstilistas
            // 
            lblEstilistas.AutoSize = true;
            lblEstilistas.Location = new Point(24, 145);
            lblEstilistas.Name = "lblEstilistas";
            lblEstilistas.Size = new Size(65, 20);
            lblEstilistas.TabIndex = 8;
            lblEstilistas.Text = "Estilistas";
            // 
            // cmbServicios
            // 
            cmbServicios.FormattingEnabled = true;
            cmbServicios.Location = new Point(24, 114);
            cmbServicios.Name = "cmbServicios";
            cmbServicios.Size = new Size(355, 28);
            cmbServicios.TabIndex = 7;
            cmbServicios.SelectedIndexChanged += cmbServicios_SelectedIndexChanged;
            // 
            // lblServicios
            // 
            lblServicios.AutoSize = true;
            lblServicios.Location = new Point(24, 91);
            lblServicios.Name = "lblServicios";
            lblServicios.Size = new Size(70, 20);
            lblServicios.TabIndex = 6;
            lblServicios.Text = "Servicios";
            // 
            // cmbClientes
            // 
            cmbClientes.FormattingEnabled = true;
            cmbClientes.Location = new Point(24, 60);
            cmbClientes.Name = "cmbClientes";
            cmbClientes.Size = new Size(355, 28);
            cmbClientes.TabIndex = 5;
            // 
            // lblClientes
            // 
            lblClientes.AutoSize = true;
            lblClientes.Location = new Point(24, 37);
            lblClientes.Name = "lblClientes";
            lblClientes.Size = new Size(62, 20);
            lblClientes.TabIndex = 4;
            lblClientes.Text = "Clientes";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnPagar);
            groupBox2.Controls.Add(cmbMetodoPago);
            groupBox2.Controls.Add(lblMetodoPago);
            groupBox2.Controls.Add(txtMonto);
            groupBox2.Controls.Add(lblMonto);
            groupBox2.Location = new Point(536, 28);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(437, 424);
            groupBox2.TabIndex = 24;
            groupBox2.TabStop = false;
            groupBox2.Text = "Registre el pago de la cita seleccionada:";
            // 
            // btnPagar
            // 
            btnPagar.Location = new Point(119, 234);
            btnPagar.Name = "btnPagar";
            btnPagar.Size = new Size(201, 29);
            btnPagar.TabIndex = 21;
            btnPagar.Text = "Registrar pago";
            btnPagar.UseVisualStyleBackColor = true;
            btnPagar.Click += btnPagar_Click;
            // 
            // cmbMetodoPago
            // 
            cmbMetodoPago.FormattingEnabled = true;
            cmbMetodoPago.Items.AddRange(new object[] { "Efectivo", "Tarjeta", "Transferencia" });
            cmbMetodoPago.Location = new Point(22, 156);
            cmbMetodoPago.Name = "cmbMetodoPago";
            cmbMetodoPago.Size = new Size(201, 28);
            cmbMetodoPago.TabIndex = 20;
            // 
            // lblMetodoPago
            // 
            lblMetodoPago.AutoSize = true;
            lblMetodoPago.Location = new Point(22, 114);
            lblMetodoPago.Name = "lblMetodoPago";
            lblMetodoPago.Size = new Size(127, 20);
            lblMetodoPago.TabIndex = 19;
            lblMetodoPago.Text = "Método de pago:";
            // 
            // txtMonto
            // 
            txtMonto.Location = new Point(22, 71);
            txtMonto.Name = "txtMonto";
            txtMonto.PlaceholderText = "Ej: 200";
            txtMonto.Size = new Size(201, 27);
            txtMonto.TabIndex = 18;
            txtMonto.Click += key;
            // 
            // lblMonto
            // 
            lblMonto.AutoSize = true;
            lblMonto.Location = new Point(22, 37);
            lblMonto.Name = "lblMonto";
            lblMonto.Size = new Size(59, 20);
            lblMonto.TabIndex = 16;
            lblMonto.Text = "Monto:";
            txtMonto.KeyPress += txtMonto_KeyPress;
            // 
            // frmAgenda
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(1033, 660);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(dgvCitas);
            Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = Color.Black;
            Name = "frmAgenda";
            Text = "Agenda";
            Load += frmAgenda_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCitas).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView dgvCitas;
        private Button btnAgendar;
        private Label lblComplete;
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
    }
}
