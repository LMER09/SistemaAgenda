namespace SistemaAgenda.UI
{
    partial class frmRegistrarServicios
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
            lblTipo = new Label();
            lblSubtipo = new Label();
            lblPrecio = new Label();
            lblDuracion = new Label();
            cmbTipo = new ComboBox();
            cmbSubtipo = new ComboBox();
            txtPrecio = new TextBox();
            txtDuracion = new TextBox();
            btnHabilitar = new Button();
            btnAgregar = new Button();
            btnCalcular = new Button();
            btnCerrar = new Button();
            lblIngrese = new Label();
            lblResultado = new Label();
            picLogo = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            // 
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.Location = new Point(40, 94);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(123, 20);
            lblTipo.TabIndex = 0;
            lblTipo.Text = "Tipo de Servicio:";
            // 
            // lblSubtipo
            // 
            lblSubtipo.AutoSize = true;
            lblSubtipo.Location = new Point(40, 127);
            lblSubtipo.Name = "lblSubtipo";
            lblSubtipo.Size = new Size(66, 20);
            lblSubtipo.TabIndex = 1;
            lblSubtipo.Text = "Subtipo:";
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Location = new Point(40, 160);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(56, 20);
            lblPrecio.TabIndex = 2;
            lblPrecio.Text = "Precio:";
            // 
            // lblDuracion
            // 
            lblDuracion.AutoSize = true;
            lblDuracion.Location = new Point(40, 193);
            lblDuracion.Name = "lblDuracion";
            lblDuracion.Size = new Size(116, 20);
            lblDuracion.TabIndex = 3;
            lblDuracion.Text = "Duración (min):";
            // 
            // cmbTipo
            // 
            cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipo.FormattingEnabled = true;
            cmbTipo.Items.AddRange(new object[] { "Cabello", "Uñas", "Spa" });
            cmbTipo.Location = new Point(179, 86);
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Size = new Size(220, 28);
            cmbTipo.TabIndex = 4;
            cmbTipo.SelectedIndexChanged += cmbTipo_SelectedIndexChanged;
            // 
            // cmbSubtipo
            // 
            cmbSubtipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSubtipo.FormattingEnabled = true;
            cmbSubtipo.Location = new Point(179, 120);
            cmbSubtipo.Name = "cmbSubtipo";
            cmbSubtipo.Size = new Size(220, 28);
            cmbSubtipo.TabIndex = 5;
            // 
            // txtPrecio
            // 
            txtPrecio.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPrecio.Location = new Point(179, 153);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.PlaceholderText = "Ej: 300";
            txtPrecio.Size = new Size(220, 27);
            txtPrecio.TabIndex = 6;
            txtPrecio.KeyPress += txtPrecio_KeyPress;
            // 
            // txtDuracion
            // 
            txtDuracion.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDuracion.Location = new Point(179, 186);
            txtDuracion.Name = "txtDuracion";
            txtDuracion.PlaceholderText = "Ej: 60";
            txtDuracion.Size = new Size(220, 27);
            txtDuracion.TabIndex = 7;
            txtDuracion.KeyPress += txtDuracion_KeyPress;
            // 
            // btnHabilitar
            // 
            btnHabilitar.BackColor = Color.DeepPink;
            btnHabilitar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHabilitar.ForeColor = Color.White;
            btnHabilitar.Location = new Point(40, 235);
            btnHabilitar.Name = "btnHabilitar";
            btnHabilitar.Size = new Size(180, 43);
            btnHabilitar.TabIndex = 8;
            btnHabilitar.Text = "🔓 Habilitar campos";
            btnHabilitar.UseVisualStyleBackColor = false;
            btnHabilitar.Click += btnHabilitar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.DeepPink;
            btnAgregar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAgregar.ForeColor = Color.White;
            btnAgregar.Location = new Point(226, 235);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(150, 43);
            btnAgregar.TabIndex = 9;
            btnAgregar.Text = "➕ Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnCalcular
            // 
            btnCalcular.BackColor = Color.DeepPink;
            btnCalcular.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCalcular.ForeColor = Color.White;
            btnCalcular.Location = new Point(382, 235);
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Size = new Size(150, 43);
            btnCalcular.TabIndex = 10;
            btnCalcular.Text = "💲 Calcular";
            btnCalcular.UseVisualStyleBackColor = false;
            btnCalcular.Click += btnCalcular_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.BackColor = Color.Gray;
            btnCerrar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCerrar.ForeColor = Color.White;
            btnCerrar.Location = new Point(538, 235);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(150, 43);
            btnCerrar.TabIndex = 11;
            btnCerrar.Text = "❌ Cerrar";
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // lblIngrese
            // 
            lblIngrese.AutoSize = true;
            lblIngrese.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblIngrese.Location = new Point(40, 39);
            lblIngrese.Name = "lblIngrese";
            lblIngrese.Size = new Size(186, 23);
            lblIngrese.TabIndex = 12;
            lblIngrese.Text = "Ingrese nuevo servicio:";
            // 
            // lblResultado
            // 
            lblResultado.AutoSize = true;
            lblResultado.Font = new Font("Segoe UI", 9.5F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblResultado.ForeColor = Color.DimGray;
            lblResultado.Location = new Point(40, 301);
            lblResultado.MaximumSize = new Size(650, 0);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(607, 42);
            lblResultado.TabIndex = 13;
            lblResultado.Text = "Los campos están deshabilitados. Presione \"Habilitar campos\" para ingresar un nuevo servicio.";
            // 
            // picLogo
            // 
            picLogo.BackColor = Color.Transparent;
            picLogo.Location = new Point(560, 30);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(1, 1);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 14;
            picLogo.TabStop = false;
            picLogo.Visible = false;
            // 
            // frmRegistrarServicios
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(720, 383);
            Controls.Add(picLogo);
            Controls.Add(lblResultado);
            Controls.Add(lblIngrese);
            Controls.Add(btnCerrar);
            Controls.Add(btnCalcular);
            Controls.Add(btnAgregar);
            Controls.Add(btnHabilitar);
            Controls.Add(txtDuracion);
            Controls.Add(txtPrecio);
            Controls.Add(cmbSubtipo);
            Controls.Add(cmbTipo);
            Controls.Add(lblDuracion);
            Controls.Add(lblPrecio);
            Controls.Add(lblSubtipo);
            Controls.Add(lblTipo);
            Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "frmRegistrarServicios";
            Text = "Registro de Servicios";
            TransparencyKey = Color.FromArgb(255, 224, 192);
            Load += frmRegistrarServicios_Load;
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTipo;
        private Label lblSubtipo;
        private Label lblPrecio;
        private Label lblDuracion;
        private ComboBox cmbTipo;
        private ComboBox cmbSubtipo;
        private TextBox txtPrecio;
        private TextBox txtDuracion;
        private Button btnHabilitar;
        private Button btnAgregar;
        private Button btnCalcular;
        private Button btnCerrar;
        private Label lblIngrese;
        private Label lblResultado;
        private PictureBox picLogo;
    }
}