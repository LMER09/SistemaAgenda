namespace SistemaAgenda.UI
{
    partial class frmRegistrarClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistrarClientes));
            lblNombre = new Label();
            lblApellido = new Label();
            lblTelefono = new Label();
            lblCorreo = new Label();
            lblCedula = new Label();
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            txtTelefono = new TextBox();
            txtCorreo = new TextBox();
            txtCedula = new TextBox();
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
            // txtNombre
            // 
            txtNombre.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombre.Location = new Point(162, 87);
            txtNombre.Name = "txtNombre";
            txtNombre.PlaceholderText = "Ej: Luzmairy";
            txtNombre.Size = new Size(357, 27);
            txtNombre.TabIndex = 5;
            txtNombre.KeyPress += txtNombre_KeyPress;
            // 
            // txtApellido
            // 
            txtApellido.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtApellido.Location = new Point(162, 120);
            txtApellido.Name = "txtApellido";
            txtApellido.PlaceholderText = "Ej: Rodriguez";
            txtApellido.Size = new Size(357, 27);
            txtApellido.TabIndex = 6;
            txtApellido.KeyPress += txtApellido_KeyPress;
            // 
            // txtTelefono
            // 
            txtTelefono.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTelefono.Location = new Point(162, 153);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.PlaceholderText = "Ej: 000-000-0000";
            txtTelefono.Size = new Size(357, 27);
            txtTelefono.TabIndex = 7;
            txtTelefono.TextChanged += txtTelefono_TextChanged;
            txtTelefono.KeyPress += txtTelefono_KeyPress;
            // 
            // txtCorreo
            // 
            txtCorreo.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCorreo.Location = new Point(162, 186);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.PlaceholderText = "Ej: luz17@gmail.com";
            txtCorreo.Size = new Size(357, 27);
            txtCorreo.TabIndex = 8;
            // 
            // txtCedula
            // 
            txtCedula.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCedula.Location = new Point(162, 219);
            txtCedula.Name = "txtCedula";
            txtCedula.PlaceholderText = "Ej: 001-1234567-8";
            txtCedula.Size = new Size(357, 27);
            txtCedula.TabIndex = 9;
            txtCedula.TextChanged += txtCedula_TextChanged;
            txtCedula.KeyPress += txtCedula_KeyPress;
            // 
            // btnHabilitar
            // 
            btnHabilitar.BackColor = Color.DeepPink;
            btnHabilitar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHabilitar.ForeColor = Color.White;
            btnHabilitar.Location = new Point(51, 278);
            btnHabilitar.Name = "btnHabilitar";
            btnHabilitar.Size = new Size(195, 43);
            btnHabilitar.TabIndex = 10;
            btnHabilitar.Text = "🔓 Habilitar campos";
            btnHabilitar.UseVisualStyleBackColor = false;
            btnHabilitar.Click += btnHabilitar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.DeepPink;
            btnAgregar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAgregar.ForeColor = Color.White;
            btnAgregar.Location = new Point(254, 278);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(195, 43);
            btnAgregar.TabIndex = 11;
            btnAgregar.Text = "➕ Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.BackColor = Color.Gray;
            btnCerrar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCerrar.ForeColor = Color.White;
            btnCerrar.Location = new Point(457, 278);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(150, 43);
            btnCerrar.TabIndex = 18;
            btnCerrar.Text = "❌ Cerrar";
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // lblIngrese
            // 
            lblIngrese.AutoSize = true;
            lblIngrese.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblIngrese.Location = new Point(51, 47);
            lblIngrese.Name = "lblIngrese";
            lblIngrese.Size = new Size(178, 23);
            lblIngrese.TabIndex = 12;
            lblIngrese.Text = "Ingrese nuevo cliente:";
            // 
            // lblResultado
            // 
            lblResultado.AutoSize = true;
            lblResultado.Font = new Font("Segoe UI", 9.5F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblResultado.ForeColor = Color.DimGray;
            lblResultado.Location = new Point(51, 344);
            lblResultado.MaximumSize = new Size(680, 0);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(655, 21);
            lblResultado.TabIndex = 13;
            lblResultado.Text = "Los campos están deshabilitados. Presione \"Habilitar campos\" para ingresar un nuevo cliente.";
            // 
            // picLogo
            // 
            picLogo.BackColor = Color.Transparent;
            picLogo.Image = (Image)resources.GetObject("picLogo.Image");
            picLogo.Location = new Point(538, 9);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(242, 245);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 14;
            picLogo.TabStop = false;
            // 
            // frmRegistrarClientes
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(801, 400);
            Controls.Add(picLogo);
            Controls.Add(lblResultado);
            Controls.Add(lblIngrese);
            Controls.Add(btnCerrar);
            Controls.Add(btnAgregar);
            Controls.Add(btnHabilitar);
            Controls.Add(txtCedula);
            Controls.Add(txtCorreo);
            Controls.Add(txtTelefono);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            Controls.Add(lblCedula);
            Controls.Add(lblCorreo);
            Controls.Add(lblTelefono);
            Controls.Add(lblApellido);
            Controls.Add(lblNombre);
            Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "frmRegistrarClientes";
            Text = "Registro de Clientes";
            TransparencyKey = Color.FromArgb(255, 224, 192);
            Load += frmRegistrarClientes_Load;
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
        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtTelefono;
        private TextBox txtCorreo;
        private TextBox txtCedula;
        private Button btnHabilitar;
        private Button btnAgregar;
        private Button btnCerrar;
        private Label lblIngrese;
        private Label lblResultado;
        private PictureBox picLogo;
    }
}