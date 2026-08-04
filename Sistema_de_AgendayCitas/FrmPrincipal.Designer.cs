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
            lblGestion = new Label();
            picLogo = new PictureBox();
            menuStrip1 = new MenuStrip();
            entradaToolStripMenuItem = new ToolStripMenuItem();
            clientesToolStripMenuItem = new ToolStripMenuItem();
            serviciosToolStripMenuItem = new ToolStripMenuItem();
            estilistaToolStripMenuItem = new ToolStripMenuItem();
            agendarCitaToolStripMenuItem = new ToolStripMenuItem();
            registrarPagoToolStripMenuItem = new ToolStripMenuItem();
            registrarUsuarioToolStripMenuItem = new ToolStripMenuItem();
            consultaToolStripMenuItem = new ToolStripMenuItem();
            verClienteToolStripMenuItem = new ToolStripMenuItem();
            verEstilistaToolStripMenuItem = new ToolStripMenuItem();
            verServicioToolStripMenuItem = new ToolStripMenuItem();
            reportesToolStripMenuItem = new ToolStripMenuItem();
            reportesToolStripMenuItem1 = new ToolStripMenuItem();
            verPagosToolStripMenuItem = new ToolStripMenuItem();
            verUsuariosToolStripMenuItem = new ToolStripMenuItem();
            sistemaToolStripMenuItem = new ToolStripMenuItem();
            acercaDeToolStripMenuItem = new ToolStripMenuItem();
            salirToolStripMenuItem = new ToolStripMenuItem();
            lblElija = new Label();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // lblGestion
            // 
            lblGestion.AutoSize = true;
            lblGestion.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGestion.ForeColor = Color.MediumVioletRed;
            lblGestion.Location = new Point(343, 439);
            lblGestion.Name = "lblGestion";
            lblGestion.Size = new Size(468, 50);
            lblGestion.TabIndex = 6;
            lblGestion.Text = "Sistema de agenda y citas";
            // 
            // picLogo
            // 
            picLogo.BackColor = Color.Transparent;
            picLogo.Image = (Image)resources.GetObject("picLogo.Image");
            picLogo.Location = new Point(322, 51);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(514, 371);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 8;
            picLogo.TabStop = false;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.LavenderBlush;
            menuStrip1.Font = new Font("Segoe UI", 12F);
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { entradaToolStripMenuItem, consultaToolStripMenuItem, sistemaToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(12, 8, 0, 8);
            menuStrip1.RenderMode = ToolStripRenderMode.Professional;
            menuStrip1.Size = new Size(1155, 48);
            menuStrip1.TabIndex = 9;
            menuStrip1.Text = "menuStrip1";
            // 
            // entradaToolStripMenuItem
            // 
            entradaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { agendarCitaToolStripMenuItem, registrarPagoToolStripMenuItem, clientesToolStripMenuItem, serviciosToolStripMenuItem, estilistaToolStripMenuItem, registrarUsuarioToolStripMenuItem });
            entradaToolStripMenuItem.Margin = new Padding(0, 0, 30, 0);
            entradaToolStripMenuItem.Name = "entradaToolStripMenuItem";
            entradaToolStripMenuItem.Size = new Size(93, 32);
            entradaToolStripMenuItem.Text = "Entrada";
            // 
            // clientesToolStripMenuItem
            // 
            clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            clientesToolStripMenuItem.Size = new Size(279, 32);
            clientesToolStripMenuItem.Text = "👤 Clientes";
            clientesToolStripMenuItem.Click += btnClientes_Click;
            // 
            // serviciosToolStripMenuItem
            // 
            serviciosToolStripMenuItem.Name = "serviciosToolStripMenuItem";
            serviciosToolStripMenuItem.Size = new Size(279, 32);
            serviciosToolStripMenuItem.Text = "✂️ Estilista";
            serviciosToolStripMenuItem.Click += btnEstilistas_Click;
            // 
            // estilistaToolStripMenuItem
            // 
            estilistaToolStripMenuItem.Name = "estilistaToolStripMenuItem";
            estilistaToolStripMenuItem.Size = new Size(279, 32);
            estilistaToolStripMenuItem.Text = "💄 Servicio";
            estilistaToolStripMenuItem.Click += btnServicios_Click;
            // 
            // agendarCitaToolStripMenuItem
            // 
            agendarCitaToolStripMenuItem.Name = "agendarCitaToolStripMenuItem";
            agendarCitaToolStripMenuItem.Size = new Size(279, 32);
            agendarCitaToolStripMenuItem.Text = "📅 Agendar Cita";
            agendarCitaToolStripMenuItem.Click += btnAgenda_Click;
            // 
            // registrarPagoToolStripMenuItem
            // 
            registrarPagoToolStripMenuItem.Name = "registrarPagoToolStripMenuItem";
            registrarPagoToolStripMenuItem.Size = new Size(279, 32);
            registrarPagoToolStripMenuItem.Text = "💰 Registrar Pago";
            registrarPagoToolStripMenuItem.Click += registrarPagoToolStripMenuItem_Click;
            // 
            // registrarUsuarioToolStripMenuItem
            // 
            registrarUsuarioToolStripMenuItem.Name = "registrarUsuarioToolStripMenuItem";
            registrarUsuarioToolStripMenuItem.Size = new Size(279, 32);
            registrarUsuarioToolStripMenuItem.Text = "👤 Registrar Usuario";
            registrarUsuarioToolStripMenuItem.Click += registrarUsuarioToolStripMenuItem_Click;
            // 
            // consultaToolStripMenuItem
            // 
            consultaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { reportesToolStripMenuItem, verClienteToolStripMenuItem, verEstilistaToolStripMenuItem, verServicioToolStripMenuItem, verUsuariosToolStripMenuItem, verPagosToolStripMenuItem, reportesToolStripMenuItem1 });
            consultaToolStripMenuItem.Margin = new Padding(0, 0, 30, 0);
            consultaToolStripMenuItem.Name = "consultaToolStripMenuItem";
            consultaToolStripMenuItem.Size = new Size(102, 32);
            consultaToolStripMenuItem.Text = "Consulta";
            // 
            // verClienteToolStripMenuItem
            // 
            verClienteToolStripMenuItem.Name = "verClienteToolStripMenuItem";
            verClienteToolStripMenuItem.Size = new Size(291, 32);
            verClienteToolStripMenuItem.Text = "👥 Ver Clientes";
            verClienteToolStripMenuItem.Click += verClienteToolStripMenuItem_Click;
            // 
            // verEstilistaToolStripMenuItem
            // 
            verEstilistaToolStripMenuItem.Name = "verEstilistaToolStripMenuItem";
            verEstilistaToolStripMenuItem.Size = new Size(291, 32);
            verEstilistaToolStripMenuItem.Text = "💇‍♀️ Ver Estilistas";
            verEstilistaToolStripMenuItem.Click += verEstilistaToolStripMenuItem_Click;
            // 
            // verServicioToolStripMenuItem
            // 
            verServicioToolStripMenuItem.Name = "verServicioToolStripMenuItem";
            verServicioToolStripMenuItem.Size = new Size(291, 32);
            verServicioToolStripMenuItem.Text = "📋 Ver Servicios";
            verServicioToolStripMenuItem.Click += verServicioToolStripMenuItem_Click;
            // 
            // reportesToolStripMenuItem
            // 
            reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            reportesToolStripMenuItem.Size = new Size(291, 32);
            reportesToolStripMenuItem.Text = "🗓️ Ver Citas / Agenda";
            reportesToolStripMenuItem.Click += reportesToolStripMenuItem_Click;
            // 
            // reportesToolStripMenuItem1
            // 
            reportesToolStripMenuItem1.Name = "reportesToolStripMenuItem1";
            reportesToolStripMenuItem1.Size = new Size(291, 32);
            reportesToolStripMenuItem1.Text = "📊 Reportes";
            reportesToolStripMenuItem1.Click += reportesToolStripMenuItem1_Click;
            // 
            // verPagosToolStripMenuItem
            // 
            verPagosToolStripMenuItem.Name = "verPagosToolStripMenuItem";
            verPagosToolStripMenuItem.Size = new Size(291, 32);
            verPagosToolStripMenuItem.Text = "💵 Ver Pagos";
            verPagosToolStripMenuItem.Click += verPagosToolStripMenuItem_Click;
            // 
            // verUsuariosToolStripMenuItem
            // 
            verUsuariosToolStripMenuItem.Name = "verUsuariosToolStripMenuItem";
            verUsuariosToolStripMenuItem.Size = new Size(291, 32);
            verUsuariosToolStripMenuItem.Text = "🔑 Ver Usuarios";
            verUsuariosToolStripMenuItem.Click += verUsuariosToolStripMenuItem_Click;
            // 
            // sistemaToolStripMenuItem
            // 
            sistemaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { acercaDeToolStripMenuItem, salirToolStripMenuItem });
            sistemaToolStripMenuItem.Margin = new Padding(0, 0, 30, 0);
            sistemaToolStripMenuItem.Name = "sistemaToolStripMenuItem";
            sistemaToolStripMenuItem.Size = new Size(94, 32);
            sistemaToolStripMenuItem.Text = "Sistema";
            // 
            // acercaDeToolStripMenuItem
            // 
            acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            acercaDeToolStripMenuItem.Size = new Size(224, 32);
            acercaDeToolStripMenuItem.Text = "⚙️ Sistema";
            acercaDeToolStripMenuItem.Click += acercaDeToolStripMenuItem_Click;
            // 
            // salirToolStripMenuItem
            // 
            salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            salirToolStripMenuItem.Size = new Size(224, 32);
            salirToolStripMenuItem.Text = "🚪  Salir";
            salirToolStripMenuItem.Click += salirToolStripMenuItem_Click;
            // 
            // lblElija
            // 
            lblElija.AutoSize = true;
            lblElija.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblElija.ForeColor = Color.DarkGray;
            lblElija.Location = new Point(406, 489);
            lblElija.Name = "lblElija";
            lblElija.Size = new Size(333, 25);
            lblElija.TabIndex = 7;
            lblElija.Text = "Gestion de citas para salon de belleza";
            lblElija.Click += lblElija_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.LavenderBlush;
            panel1.Location = new Point(-33, 529);
            panel1.Name = "panel1";
            panel1.Size = new Size(1200, 100);
            panel1.TabIndex = 10;
            // 
            // frmPrincipal
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1155, 611);
            Controls.Add(panel1);
            Controls.Add(picLogo);
            Controls.Add(lblElija);
            Controls.Add(lblGestion);
            Controls.Add(menuStrip1);
            Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = Color.DeepPink;
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(608, 337);
            Name = "frmPrincipal";
            Text = "Sistema de Agenda y Citas";
            Load += frmPrincipal_Load;
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblGestion;
        private PictureBox picLogo;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem entradaToolStripMenuItem;
        private ToolStripMenuItem consultaToolStripMenuItem;
        private ToolStripMenuItem clientesToolStripMenuItem;
        private ToolStripMenuItem serviciosToolStripMenuItem;
        private ToolStripMenuItem estilistaToolStripMenuItem;
        private ToolStripMenuItem agendarCitaToolStripMenuItem;
        private ToolStripMenuItem registrarPagoToolStripMenuItem;
        private ToolStripMenuItem registrarUsuarioToolStripMenuItem;
        private ToolStripMenuItem verClienteToolStripMenuItem;
        private ToolStripMenuItem verEstilistaToolStripMenuItem;
        private ToolStripMenuItem verServicioToolStripMenuItem;
        private ToolStripMenuItem sistemaToolStripMenuItem;
        private ToolStripMenuItem reportesToolStripMenuItem;
        private ToolStripMenuItem verPagosToolStripMenuItem;
        private ToolStripMenuItem verUsuariosToolStripMenuItem;
        private ToolStripMenuItem acercaDeToolStripMenuItem;
        private ToolStripMenuItem salirToolStripMenuItem;
        private Label lblElija;
        private ToolStripMenuItem reportesToolStripMenuItem1;
        private Panel panel1;
    }
}