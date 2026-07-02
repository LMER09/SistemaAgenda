namespace SistemaAgenda.UI
{
    partial class frmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            btnAgendar = new Button();
            btnClientes = new Button();
            btnReportes = new Button();
            btnServicios = new Button();
            btnEstilistas = new Button();
            lblGestion = new Label();
            lblElija = new Label();
            picLogo = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            // 
            // btnAgendar
            // 
            btnAgendar.BackColor = Color.DeepPink;
            btnAgendar.BackgroundImageLayout = ImageLayout.Center;
            btnAgendar.FlatStyle = FlatStyle.Popup;
            btnAgendar.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAgendar.ForeColor = Color.LavenderBlush;
            btnAgendar.ImageAlign = ContentAlignment.TopLeft;
            btnAgendar.Location = new Point(341, 198);
            btnAgendar.Name = "btnAgendar";
            btnAgendar.Size = new Size(273, 48);
            btnAgendar.TabIndex = 1;
            btnAgendar.Text = "Agendar Cita y Pagar Cita";
            btnAgendar.UseVisualStyleBackColor = false;
            btnAgendar.Click += btnAgenda_Click;
            // 
            // btnClientes
            // 
            btnClientes.BackColor = Color.DeepPink;
            btnClientes.BackgroundImageLayout = ImageLayout.Center;
            btnClientes.FlatStyle = FlatStyle.Popup;
            btnClientes.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClientes.ForeColor = Color.LavenderBlush;
            btnClientes.Location = new Point(341, 266);
            btnClientes.Name = "btnClientes";
            btnClientes.Size = new Size(273, 48);
            btnClientes.TabIndex = 2;
            btnClientes.Text = "Clientes";
            btnClientes.UseVisualStyleBackColor = false;
            btnClientes.Click += btnClientes_Click;
            // 
            // btnReportes
            // 
            btnReportes.BackColor = Color.DeepPink;
            btnReportes.BackgroundImageLayout = ImageLayout.Center;
            btnReportes.FlatStyle = FlatStyle.Popup;
            btnReportes.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReportes.ForeColor = Color.LavenderBlush;
            btnReportes.Location = new Point(341, 472);
            btnReportes.Name = "btnReportes";
            btnReportes.Size = new Size(273, 48);
            btnReportes.TabIndex = 3;
            btnReportes.Text = "Reportes";
            btnReportes.UseVisualStyleBackColor = false;
            btnReportes.Click += btnReportes_Click;
            // 
            // btnServicios
            // 
            btnServicios.BackColor = Color.DeepPink;
            btnServicios.BackgroundImageLayout = ImageLayout.Center;
            btnServicios.FlatStyle = FlatStyle.Popup;
            btnServicios.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnServicios.ForeColor = Color.LavenderBlush;
            btnServicios.Location = new Point(341, 335);
            btnServicios.Name = "btnServicios";
            btnServicios.Size = new Size(273, 48);
            btnServicios.TabIndex = 4;
            btnServicios.Text = "Servicios";
            btnServicios.UseVisualStyleBackColor = false;
            btnServicios.Click += btnServicios_Click;
            // 
            // btnEstilistas
            // 
            btnEstilistas.BackColor = Color.DeepPink;
            btnEstilistas.FlatStyle = FlatStyle.Popup;
            btnEstilistas.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEstilistas.ForeColor = Color.LavenderBlush;
            btnEstilistas.Location = new Point(341, 404);
            btnEstilistas.Name = "btnEstilistas";
            btnEstilistas.Size = new Size(273, 48);
            btnEstilistas.TabIndex = 5;
            btnEstilistas.Text = "Estilistas";
            btnEstilistas.UseVisualStyleBackColor = false;
            btnEstilistas.Click += btnEstilistas_Click;
            // 
            // lblGestion
            // 
            lblGestion.AutoSize = true;
            lblGestion.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGestion.ForeColor = Color.MediumVioletRed;
            lblGestion.Location = new Point(141, 57);
            lblGestion.Name = "lblGestion";
            lblGestion.Size = new Size(672, 50);
            lblGestion.TabIndex = 6;
            lblGestion.Text = "Gestión de citas para salón de belleza";
            // 
            // lblElija
            // 
            lblElija.AutoSize = true;
            lblElija.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblElija.ForeColor = Color.DarkGray;
            lblElija.Location = new Point(315, 124);
            lblElija.Name = "lblElija";
            lblElija.Size = new Size(329, 25);
            lblElija.TabIndex = 7;
            lblElija.Text = "Seleccione una opción para continuar";
            // 
            // picLogo
            // 
            picLogo.BackColor = Color.Transparent;
            picLogo.Image = (Image)resources.GetObject("picLogo.Image");
            picLogo.Location = new Point(629, 188);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(383, 426);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 8;
            picLogo.TabStop = false;
            // 
            // frmPrincipal
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1024, 596);
            Controls.Add(picLogo);
            Controls.Add(lblElija);
            Controls.Add(lblGestion);
            Controls.Add(btnEstilistas);
            Controls.Add(btnServicios);
            Controls.Add(btnReportes);
            Controls.Add(btnClientes);
            Controls.Add(btnAgendar);
            Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = Color.LavenderBlush;
            Name = "frmPrincipal";
            Text = "Sistema de Agenda y Citas";
            Load += frmPrincipal_Load;
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion


        private Button btnAgendar;
        private Button btnClientes;
        private Button btnReportes;
        private Button btnServicios;
        private Button btnEstilistas;
        private Label lblGestion;
        private Label lblElija;
        private PictureBox picLogo;
    }
}