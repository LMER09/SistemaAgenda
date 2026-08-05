namespace SistemaAgenda.UI
{
    partial class frmRegistrarPago
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistrarPago));
            lblCita = new Label();
            lblMonto = new Label();
            lblMetodoPago = new Label();
            cmbCita = new ComboBox();
            txtMonto = new TextBox();
            lblAyudaMonto = new Label();
            cmbMetodoPago = new ComboBox();
            btnHabilitar = new Button();
            btnRegistrar = new Button();
            btnCerrar = new Button();
            lblTitulo = new Label();
            lblResultado = new Label();
            picLogo = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            // 
            // lblCita
            // 
            lblCita.AutoSize = true;
            lblCita.Location = new Point(51, 94);
            lblCita.Name = "lblCita";
            lblCita.Size = new Size(45, 20);
            lblCita.TabIndex = 0;
            lblCita.Text = "Cita:";
            // 
            // lblMonto
            // 
            lblMonto.AutoSize = true;
            lblMonto.Location = new Point(51, 165);
            lblMonto.Name = "lblMonto";
            lblMonto.Size = new Size(58, 20);
            lblMonto.TabIndex = 1;
            lblMonto.Text = "Monto:";
            // 
            // lblMetodoPago
            // 
            lblMetodoPago.AutoSize = true;
            lblMetodoPago.Location = new Point(51, 250);
            lblMetodoPago.Name = "lblMetodoPago";
            lblMetodoPago.Size = new Size(130, 20);
            lblMetodoPago.TabIndex = 2;
            lblMetodoPago.Text = "Método de pago:";
            // 
            // cmbCita
            // 
            cmbCita.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCita.FormattingEnabled = true;
            cmbCita.Location = new Point(51, 120);
            cmbCita.Name = "cmbCita";
            cmbCita.Size = new Size(650, 28);
            cmbCita.TabIndex = 3;
            cmbCita.SelectedIndexChanged += cmbCita_SelectedIndexChanged;
            // 
            // txtMonto
            // 
            txtMonto.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMonto.Location = new Point(162, 158);
            txtMonto.Name = "txtMonto";
            txtMonto.PlaceholderText = "Ej: 500.00";
            txtMonto.Size = new Size(250, 27);
            txtMonto.TabIndex = 4;
            txtMonto.KeyPress += txtMonto_KeyPress;
            // 
            // lblAyudaMonto
            // 
            lblAyudaMonto.AutoSize = true;
            lblAyudaMonto.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblAyudaMonto.ForeColor = Color.Gray;
            lblAyudaMonto.Location = new Point(51, 188);
            lblAyudaMonto.MaximumSize = new Size(650, 0);
            lblAyudaMonto.Name = "lblAyudaMonto";
            lblAyudaMonto.Size = new Size(500, 17);
            lblAyudaMonto.TabIndex = 12;
            lblAyudaMonto.Text = "💡 El monto se sugiere según el precio del servicio, pero puede cambiarlo si el cliente pagó un monto distinto.";
            // 
            // cmbMetodoPago
            // 
            cmbMetodoPago.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMetodoPago.FormattingEnabled = true;
            cmbMetodoPago.Items.AddRange(new object[] { "Efectivo", "Tarjeta", "Transferencia" });
            cmbMetodoPago.Location = new Point(187, 247);
            cmbMetodoPago.Name = "cmbMetodoPago";
            cmbMetodoPago.Size = new Size(225, 28);
            cmbMetodoPago.TabIndex = 5;
            // 
            // btnHabilitar
            // 
            btnHabilitar.BackColor = Color.DeepPink;
            btnHabilitar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHabilitar.ForeColor = Color.White;
            btnHabilitar.Location = new Point(51, 300);
            btnHabilitar.Name = "btnHabilitar";
            btnHabilitar.Size = new Size(195, 43);
            btnHabilitar.TabIndex = 6;
            btnHabilitar.Text = "🔓 Habilitar campos";
            btnHabilitar.UseVisualStyleBackColor = false;
            btnHabilitar.Click += btnHabilitar_Click;
            // 
            // btnRegistrar
            // 
            btnRegistrar.BackColor = Color.DeepPink;
            btnRegistrar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRegistrar.ForeColor = Color.White;
            btnRegistrar.Location = new Point(254, 300);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(195, 43);
            btnRegistrar.TabIndex = 7;
            btnRegistrar.Text = "💲 Registrar pago";
            btnRegistrar.UseVisualStyleBackColor = false;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.BackColor = Color.Gray;
            btnCerrar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCerrar.ForeColor = Color.White;
            btnCerrar.Location = new Point(457, 300);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(150, 43);
            btnCerrar.TabIndex = 8;
            btnCerrar.Text = "❌ Cerrar";
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(51, 47);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(178, 23);
            lblTitulo.TabIndex = 9;
            lblTitulo.Text = "Registrar pago de cita:";
            // 
            // lblResultado
            // 
            lblResultado.AutoSize = true;
            lblResultado.Font = new Font("Segoe UI", 9.5F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblResultado.ForeColor = Color.DimGray;
            lblResultado.Location = new Point(51, 366);
            lblResultado.MaximumSize = new Size(650, 0);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(468, 20);
            lblResultado.TabIndex = 10;
            lblResultado.Text = "Los campos están deshabilitados. Presione \"Habilitar campos\" para registrar un pago.";
            // 
            // picLogo
            // 
            picLogo.BackColor = Color.Transparent;
            picLogo.Image = (Image)resources.GetObject("picLogo.Image");
            picLogo.Location = new Point(560, 30);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(1, 1);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 11;
            picLogo.TabStop = false;
            picLogo.Visible = false;
            // 
            // frmRegistrarPago
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(760, 435);
            Controls.Add(picLogo);
            Controls.Add(lblResultado);
            Controls.Add(lblTitulo);
            Controls.Add(btnCerrar);
            Controls.Add(btnRegistrar);
            Controls.Add(btnHabilitar);
            Controls.Add(cmbMetodoPago);
            Controls.Add(lblAyudaMonto);
            Controls.Add(txtMonto);
            Controls.Add(cmbCita);
            Controls.Add(lblMetodoPago);
            Controls.Add(lblMonto);
            Controls.Add(lblCita);
            Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "frmRegistrarPago";
            Text = "Registrar Pago";
            TransparencyKey = Color.FromArgb(255, 224, 192);
            Load += FrmRegistrarPago_Load;
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblCita;
        private Label lblMonto;
        private Label lblMetodoPago;
        private ComboBox cmbCita;
        private TextBox txtMonto;
        private Label lblAyudaMonto;
        private ComboBox cmbMetodoPago;
        private Button btnHabilitar;
        private Button btnRegistrar;
        private Button btnCerrar;
        private Label lblTitulo;
        private Label lblResultado;
        private PictureBox picLogo;
    }
}