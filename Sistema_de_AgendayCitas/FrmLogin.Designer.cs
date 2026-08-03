namespace SistemaAgenda.UI
{
    partial class FrmLogin
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
            pnlHeader = new Panel();
            lblTitulo2 = new Label();
            lblTitulo = new Label();
            lblEmoji = new Label();
            lblUsuario = new Label();
            lblContra = new Label();
            txtUsuario = new TextBox();
            txtContra = new TextBox();
            button1 = new Button();
            lblAdvertencia = new Label();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.DeepPink;
            pnlHeader.Controls.Add(lblTitulo2);
            pnlHeader.Controls.Add(lblTitulo);
            pnlHeader.Controls.Add(lblEmoji);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.ForeColor = SystemColors.ControlLightLight;
            pnlHeader.ImeMode = ImeMode.NoControl;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(622, 125);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitulo2
            // 
            lblTitulo2.AutoSize = true;
            lblTitulo2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo2.Location = new Point(213, 92);
            lblTitulo2.Name = "lblTitulo2";
            lblTitulo2.Size = new Size(206, 20);
            lblTitulo2.TabIndex = 2;
            lblTitulo2.Text = "Iniciar sesión para continuar ";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.Transparent;
            lblTitulo.Location = new Point(198, 67);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(243, 25);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Sistema de Agenda y Citas ";
            // 
            // lblEmoji
            // 
            lblEmoji.AutoSize = true;
            lblEmoji.Font = new Font("Segoe UI Emoji", 25.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEmoji.ForeColor = SystemColors.ButtonHighlight;
            lblEmoji.Location = new Point(278, 9);
            lblEmoji.Name = "lblEmoji";
            lblEmoji.Size = new Size(85, 58);
            lblEmoji.TabIndex = 0;
            lblEmoji.Text = "🗓️";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsuario.Location = new Point(80, 140);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(62, 20);
            lblUsuario.TabIndex = 1;
            lblUsuario.Text = "Usuario";
            lblUsuario.Click += lblUsuario_Click;
            // 
            // lblContra
            // 
            lblContra.AutoSize = true;
            lblContra.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblContra.Location = new Point(80, 227);
            lblContra.Name = "lblContra";
            lblContra.Size = new Size(86, 20);
            lblContra.TabIndex = 2;
            lblContra.Text = "Contraseña";
            lblContra.Click += lblContra_Click;
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(80, 172);
            txtUsuario.Multiline = true;
            txtUsuario.Name = "txtUsuario";
            txtUsuario.PlaceholderText = "Ej: mbaez";
            txtUsuario.Size = new Size(438, 35);
            txtUsuario.TabIndex = 3;
            // 
            // txtContra
            // 
            txtContra.Location = new Point(80, 266);
            txtContra.Multiline = true;
            txtContra.Name = "txtContra";
            txtContra.PasswordChar = '●';
            txtContra.PlaceholderText = "●●●●●●●●";
            txtContra.Size = new Size(438, 35);
            txtContra.TabIndex = 4;
            txtContra.TextChanged += txtContra_TextChanged;
            // 
            // button1
            // 
            button1.BackColor = Color.DeepPink;
            button1.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(78, 323);
            button1.Name = "button1";
            button1.Size = new Size(443, 47);
            button1.TabIndex = 5;
            button1.Text = "Ingresar";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // lblAdvertencia
            // 
            lblAdvertencia.AutoSize = true;
            lblAdvertencia.ForeColor = Color.Red;
            lblAdvertencia.Location = new Point(170, 373);
            lblAdvertencia.Name = "lblAdvertencia";
            lblAdvertencia.Size = new Size(17, 20);
            lblAdvertencia.TabIndex = 6;
            lblAdvertencia.Text = "  ";
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(622, 515);
            Controls.Add(lblAdvertencia);
            Controls.Add(button1);
            Controls.Add(txtContra);
            Controls.Add(txtUsuario);
            Controls.Add(lblContra);
            Controls.Add(lblUsuario);
            Controls.Add(pnlHeader);
            ForeColor = SystemColors.ActiveCaptionText;
            Name = "FrmLogin";
            Text = "FrmLogin";
            Load += FrmLogin_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlHeader;
        private Label lblEmoji;
        private Label lblTitulo;
        private Label lblTitulo2;
        private Label lblUsuario;
        private Label lblContra;
        private TextBox txtUsuario;
        private TextBox txtContra;
        private Button button1;
        private Label lblAdvertencia;
    }
}