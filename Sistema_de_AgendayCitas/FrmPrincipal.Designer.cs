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
            consultaToolStripMenuItem = new ToolStripMenuItem();
            verClienteToolStripMenuItem = new ToolStripMenuItem();
            verEstilistaToolStripMenuItem = new ToolStripMenuItem();
            verServicioToolStripMenuItem = new ToolStripMenuItem();
            reportesToolStripMenuItem = new ToolStripMenuItem();
            reportesToolStripMenuItem1 = new ToolStripMenuItem();
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
            lblGestion.Location = new Point(351, 425);
            lblGestion.Name = "lblGestion";
            lblGestion.Size = new Size(468, 50);
            lblGestion.TabIndex = 6;
            lblGestion.Text = "Sistema de agenda y citas";
            // 
            // picLogo
            // 
            picLogo.BackColor = Color.Transparent;
            picLogo.Image = (Image)resources.GetObject("picLogo.Image");
            picLogo.Location = new Point(443, 142);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(276, 271);
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
            entradaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { clientesToolStripMenuItem, serviciosToolStripMenuItem, estilistaToolStripMenuItem, agendarCitaToolStripMenuItem });
            entradaToolStripMenuItem.Margin = new Padding(0, 0, 30, 0);
            entradaToolStripMenuItem.Name = "entradaToolStripMenuItem";
            entradaToolStripMenuItem.Size = new Size(93, 32);
            entradaToolStripMenuItem.Text = "Entrada";
            // 
            // clientesToolStripMenuItem
            // 
            clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            clientesToolStripMenuItem.Size = new Size(244, 32);
            clientesToolStripMenuItem.Text = "👤 Clientes";
            clientesToolStripMenuItem.Click += btnClientes_Click;
            // 
            // serviciosToolStripMenuItem
            // 
            serviciosToolStripMenuItem.Name = "serviciosToolStripMenuItem";
            serviciosToolStripMenuItem.Size = new Size(244, 32);
            serviciosToolStripMenuItem.Text = "✂️ Estilista";
            serviciosToolStripMenuItem.Click += btnEstilistas_Click;
            // 
            // estilistaToolStripMenuItem
            // 
            estilistaToolStripMenuItem.Name = "estilistaToolStripMenuItem";
            estilistaToolStripMenuItem.Size = new Size(244, 32);
            estilistaToolStripMenuItem.Text = "💄 Servicio";
            estilistaToolStripMenuItem.Click += btnServicios_Click;
            // 
            // agendarCitaToolStripMenuItem
            // 
            agendarCitaToolStripMenuItem.Name = "agendarCitaToolStripMenuItem";
            agendarCitaToolStripMenuItem.Size = new Size(244, 32);
            agendarCitaToolStripMenuItem.Text = "📅 Agendar Cita";
            agendarCitaToolStripMenuItem.Click += btnAgenda_Click;
            // 
            // consultaToolStripMenuItem
            // 
            consultaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { verClienteToolStripMenuItem, verEstilistaToolStripMenuItem, verServicioToolStripMenuItem, reportesToolStripMenuItem, reportesToolStripMenuItem1 });
            consultaToolStripMenuItem.Margin = new Padding(0, 0, 30, 0);
            consultaToolStripMenuItem.Name = "consultaToolStripMenuItem";
            consultaToolStripMenuItem.Size = new Size(102, 32);
            consultaToolStripMenuItem.Text = "Consulta";
            // 
            // verClienteToolStripMenuItem
            // 
            verClienteToolStripMenuItem.Name = "verClienteToolStripMenuItem";
            verClienteToolStripMenuItem.Size = new Size(285, 32);
            verClienteToolStripMenuItem.Text = "👥 Ver clientes";
            verClienteToolStripMenuItem.Click += verClienteToolStripMenuItem_Click;
            // 
            // verEstilistaToolStripMenuItem
            // 
            verEstilistaToolStripMenuItem.Name = "verEstilistaToolStripMenuItem";
            verEstilistaToolStripMenuItem.Size = new Size(285, 32);
            verEstilistaToolStripMenuItem.Text = "💇‍♀️ Ver estilistas";
            verEstilistaToolStripMenuItem.Click += verEstilistaToolStripMenuItem_Click;
            // 
            // verServicioToolStripMenuItem
            // 
            verServicioToolStripMenuItem.Name = "verServicioToolStripMenuItem";
            verServicioToolStripMenuItem.Size = new Size(285, 32);
            verServicioToolStripMenuItem.Text = "📋 Ver servicios";
            verServicioToolStripMenuItem.Click += verServicioToolStripMenuItem_Click;
            // 
            // reportesToolStripMenuItem
            // 
            reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            reportesToolStripMenuItem.Size = new Size(285, 32);
            reportesToolStripMenuItem.Text = "🗓️ Ver citas / agenda";
            reportesToolStripMenuItem.Click += reportesToolStripMenuItem_Click;
            // 
            // reportesToolStripMenuItem1
            // 
            reportesToolStripMenuItem1.Name = "reportesToolStripMenuItem1";
            reportesToolStripMenuItem1.Size = new Size(285, 32);
            reportesToolStripMenuItem1.Text = "📊 Reportes";
            reportesToolStripMenuItem1.Click += reportesToolStripMenuItem1_Click;
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
            acercaDeToolStripMenuItem.Size = new Size(198, 32);
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
            lblElija.Location = new Point(419, 489);
            lblElija.Name = "lblElija";
            lblElija.Size = new Size(333, 25);
            lblElija.TabIndex = 7;
            lblElija.Text = "Gestion de citas para salon de belleza";
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
        private ToolStripMenuItem verClienteToolStripMenuItem;
        private ToolStripMenuItem verEstilistaToolStripMenuItem;
        private ToolStripMenuItem verServicioToolStripMenuItem;
        private ToolStripMenuItem sistemaToolStripMenuItem;
        private ToolStripMenuItem reportesToolStripMenuItem;
        private ToolStripMenuItem acercaDeToolStripMenuItem;
        private ToolStripMenuItem salirToolStripMenuItem;
        private Label lblElija;
        private ToolStripMenuItem reportesToolStripMenuItem1;
        private Panel panel1;
    }
}