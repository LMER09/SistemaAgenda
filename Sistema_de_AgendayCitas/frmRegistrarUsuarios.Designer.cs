namespace SistemaAgenda.UI
{
    partial class frmRegistrarUsuarios
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
            lblUsuario = new Label();
            lblContrasenaActual = new Label();
            lblContrasena = new Label();
            lblConfirmarContrasena = new Label();
            txtUsuario = new TextBox();
            txtContrasenaActual = new TextBox();
            txtContrasena = new TextBox();
            txtConfirmarContrasena = new TextBox();
            lblAyudaContrasena = new Label();
            btnHabilitar = new Button();
            btnAgregar = new Button();
            btnCerrar = new Button();
            lblIngrese = new Label();
            lblResultado = new Label();
            picLogo = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(51, 94);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(66, 20);
            lblUsuario.TabIndex = 0;
            lblUsuario.Text = "Usuario:";
            // 
            // lblContrasenaActual
            // 
            lblContrasenaActual.AutoSize = true;
            lblContrasenaActual.Location = new Point(51, 127);
            lblContrasenaActual.Name = "lblContrasenaActual";
            lblContrasenaActual.Size = new Size(135, 20);
            lblContrasenaActual.TabIndex = 1;
            lblContrasenaActual.Text = "Contraseña actual:";
            lblContrasenaActual.Visible = false;
            // 
            // lblContrasena
            // 
            lblContrasena.AutoSize = true;
            lblContrasena.Location = new Point(51, 160);
            lblContrasena.Name = "lblContrasena";
            lblContrasena.Size = new Size(90, 20);
            lblContrasena.TabIndex = 2;
            lblContrasena.Text = "Contraseña:";
            // 
            // lblConfirmarContrasena
            // 
            lblConfirmarContrasena.AutoSize = true;
            lblConfirmarContrasena.Location = new Point(51, 193);
            lblConfirmarContrasena.Name = "lblConfirmarContrasena";
            lblConfirmarContrasena.Size = new Size(161, 20);
            lblConfirmarContrasena.TabIndex = 3;
            lblConfirmarContrasena.Text = "Confirmar contraseña:";
            // 
            // txtUsuario
            // 
            txtUsuario.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsuario.Location = new Point(230, 87);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.PlaceholderText = "Ej: mperez";
            txtUsuario.Size = new Size(300, 27);
            txtUsuario.TabIndex = 4;
            // 
            // txtContrasenaActual
            // 
            txtContrasenaActual.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtContrasenaActual.Location = new Point(230, 120);
            txtContrasenaActual.Name = "txtContrasenaActual";
            txtContrasenaActual.PasswordChar = '●';
            txtContrasenaActual.Size = new Size(300, 27);
            txtContrasenaActual.TabIndex = 5;
            txtContrasenaActual.Visible = false;
            // 
            // txtContrasena
            // 
            txtContrasena.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtContrasena.Location = new Point(230, 153);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.PasswordChar = '●';
            txtContrasena.Size = new Size(300, 27);
            txtContrasena.TabIndex = 6;
            // 
            // txtConfirmarContrasena
            // 
            txtConfirmarContrasena.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtConfirmarContrasena.Location = new Point(230, 186);
            txtConfirmarContrasena.Name = "txtConfirmarContrasena";
            txtConfirmarContrasena.PasswordChar = '●';
            txtConfirmarContrasena.Size = new Size(300, 27);
            txtConfirmarContrasena.TabIndex = 7;
            // 
            // lblAyudaContrasena
            // 
            lblAyudaContrasena.AutoSize = true;
            lblAyudaContrasena.Font = new Font("Segoe UI", 7.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblAyudaContrasena.ForeColor = Color.Gray;
            lblAyudaContrasena.Location = new Point(230, 216);
            lblAyudaContrasena.MaximumSize = new Size(400, 0);
            lblAyudaContrasena.Name = "lblAyudaContrasena";
            lblAyudaContrasena.Size = new Size(384, 34);
            lblAyudaContrasena.TabIndex = 8;
            lblAyudaContrasena.Text = "Deje \"Contraseña\" y \"Confirmar contraseña\" en blanco para no cambiarla. Si va a cambiarla, escriba primero su contraseña actual.";
            lblAyudaContrasena.Visible = false;
            // 
            // btnHabilitar
            // 
            btnHabilitar.BackColor = Color.DeepPink;
            btnHabilitar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHabilitar.ForeColor = Color.White;
            btnHabilitar.Location = new Point(51, 272);
            btnHabilitar.Name = "btnHabilitar";
            btnHabilitar.Size = new Size(195, 41);
            btnHabilitar.TabIndex = 9;
            btnHabilitar.Text = "🔓 Habilitar campos";
            btnHabilitar.UseVisualStyleBackColor = false;
            btnHabilitar.Click += btnHabilitar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.DeepPink;
            btnAgregar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAgregar.ForeColor = Color.White;
            btnAgregar.Location = new Point(252, 272);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(195, 41);
            btnAgregar.TabIndex = 10;
            btnAgregar.Text = "➕ Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.BackColor = Color.Gray;
            btnCerrar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCerrar.ForeColor = Color.White;
            btnCerrar.Location = new Point(464, 272);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(150, 41);
            btnCerrar.TabIndex = 11;
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
            lblIngrese.Size = new Size(184, 23);
            lblIngrese.TabIndex = 12;
            lblIngrese.Text = "Ingrese nuevo usuario:";
            // 
            // lblResultado
            // 
            lblResultado.AutoSize = true;
            lblResultado.Font = new Font("Segoe UI", 9.5F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblResultado.ForeColor = Color.DimGray;
            lblResultado.Location = new Point(51, 344);
            lblResultado.MaximumSize = new Size(650, 0);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(607, 42);
            lblResultado.TabIndex = 13;
            lblResultado.Text = "Los campos están deshabilitados. Presione \"Habilitar campos\" para ingresar un nuevo usuario.";
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
            // frmRegistrarUsuarios
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(760, 442);
            Controls.Add(picLogo);
            Controls.Add(lblResultado);
            Controls.Add(lblIngrese);
            Controls.Add(btnCerrar);
            Controls.Add(btnAgregar);
            Controls.Add(btnHabilitar);
            Controls.Add(lblAyudaContrasena);
            Controls.Add(txtConfirmarContrasena);
            Controls.Add(txtContrasena);
            Controls.Add(txtContrasenaActual);
            Controls.Add(txtUsuario);
            Controls.Add(lblConfirmarContrasena);
            Controls.Add(lblContrasena);
            Controls.Add(lblContrasenaActual);
            Controls.Add(lblUsuario);
            Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "frmRegistrarUsuarios";
            Text = "Registrar Usuario";
            TransparencyKey = Color.FromArgb(255, 224, 192);
            Load += frmRegistrarUsuarios_Load;
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblUsuario;
        private Label lblContrasenaActual;
        private Label lblContrasena;
        private Label lblConfirmarContrasena;
        private TextBox txtUsuario;
        private TextBox txtContrasenaActual;
        private TextBox txtContrasena;
        private TextBox txtConfirmarContrasena;
        private Label lblAyudaContrasena;
        private Button btnHabilitar;
        private Button btnAgregar;
        private Button btnCerrar;
        private Label lblIngrese;
        private Label lblResultado;
        private PictureBox picLogo;
    }
}