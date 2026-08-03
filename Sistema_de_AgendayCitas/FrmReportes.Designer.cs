namespace SistemaAgenda.UI
{
    partial class frmReportes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportes));
            lblTitulo = new Label();
            lblTotal = new Label();
            btnCorteDia = new Button();
            dgvPagos = new DataGridView();
            picLogo = new PictureBox();
            grpResumen = new GroupBox();
            lblResumenCitasHoy = new Label();
            lblResumenCitasHoyValor = new Label();
            lblResumenIngresosHoy = new Label();
            lblResumenIngresosHoyValor = new Label();
            lblResumenProximaCita = new Label();
            lblResumenProximaCitaValor = new Label();
            btnNotificaciones = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPagos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            grpResumen.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(746, 504);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(259, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Total de ingresos del día:";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotal.Location = new Point(746, 551);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(100, 30);
            lblTotal.TabIndex = 1;
            lblTotal.Text = "RD$ 0.00";
            // 
            // btnCorteDia
            // 
            btnCorteDia.BackColor = Color.DeepPink;
            btnCorteDia.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCorteDia.ForeColor = Color.White;
            btnCorteDia.Location = new Point(746, 602);
            btnCorteDia.Name = "btnCorteDia";
            btnCorteDia.Size = new Size(210, 46);
            btnCorteDia.TabIndex = 2;
            btnCorteDia.Text = "💰Cerrar corte del día";
            btnCorteDia.UseVisualStyleBackColor = false;
            btnCorteDia.Click += btnCorteDia_Click;
            // 
            // dgvPagos
            // 
            dgvPagos.AllowUserToAddRows = false;
            dgvPagos.BackgroundColor = Color.LavenderBlush;
            dgvPagos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPagos.Location = new Point(26, 450);
            dgvPagos.Name = "dgvPagos";
            dgvPagos.ReadOnly = true;
            dgvPagos.RowHeadersWidth = 51;
            dgvPagos.Size = new Size(693, 215);
            dgvPagos.TabIndex = 3;
            // 
            // picLogo
            // 
            picLogo.BackColor = Color.Transparent;
            picLogo.Image = (Image)resources.GetObject("picLogo.Image");
            picLogo.Location = new Point(698, 34);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(316, 323);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 17;
            picLogo.TabStop = false;
            // 
            // grpResumen
            // 
            grpResumen.Controls.Add(lblResumenCitasHoy);
            grpResumen.Controls.Add(lblResumenCitasHoyValor);
            grpResumen.Controls.Add(lblResumenIngresosHoy);
            grpResumen.Controls.Add(lblResumenIngresosHoyValor);
            grpResumen.Controls.Add(lblResumenProximaCita);
            grpResumen.Controls.Add(lblResumenProximaCitaValor);
            grpResumen.FlatStyle = FlatStyle.Flat;
            grpResumen.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpResumen.ForeColor = Color.MediumVioletRed;
            grpResumen.Location = new Point(26, 35);
            grpResumen.Name = "grpResumen";
            grpResumen.Size = new Size(321, 322);
            grpResumen.TabIndex = 18;
            grpResumen.TabStop = false;
            grpResumen.Text = "📊 Resumen de hoy";
            // 
            // lblResumenCitasHoy
            // 
            lblResumenCitasHoy.AutoSize = true;
            lblResumenCitasHoy.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblResumenCitasHoy.ForeColor = Color.DimGray;
            lblResumenCitasHoy.Location = new Point(18, 43);
            lblResumenCitasHoy.Name = "lblResumenCitasHoy";
            lblResumenCitasHoy.Size = new Size(110, 25);
            lblResumenCitasHoy.TabIndex = 0;
            lblResumenCitasHoy.Text = "Citas de hoy";
            // 
            // lblResumenCitasHoyValor
            // 
            lblResumenCitasHoyValor.AutoSize = true;
            lblResumenCitasHoyValor.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblResumenCitasHoyValor.ForeColor = Color.MediumVioletRed;
            lblResumenCitasHoyValor.Location = new Point(18, 68);
            lblResumenCitasHoyValor.Name = "lblResumenCitasHoyValor";
            lblResumenCitasHoyValor.Size = new Size(46, 54);
            lblResumenCitasHoyValor.TabIndex = 1;
            lblResumenCitasHoyValor.Text = "0";
            lblResumenCitasHoyValor.Click += lblResumenCitasHoyValor_Click;
            // 
            // lblResumenIngresosHoy
            // 
            lblResumenIngresosHoy.AutoSize = true;
            lblResumenIngresosHoy.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblResumenIngresosHoy.ForeColor = Color.DimGray;
            lblResumenIngresosHoy.Location = new Point(18, 130);
            lblResumenIngresosHoy.Name = "lblResumenIngresosHoy";
            lblResumenIngresosHoy.Size = new Size(140, 25);
            lblResumenIngresosHoy.TabIndex = 2;
            lblResumenIngresosHoy.Text = "Ingresos de hoy";
            // 
            // lblResumenIngresosHoyValor
            // 
            lblResumenIngresosHoyValor.AutoSize = true;
            lblResumenIngresosHoyValor.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblResumenIngresosHoyValor.ForeColor = Color.MediumVioletRed;
            lblResumenIngresosHoyValor.Location = new Point(18, 155);
            lblResumenIngresosHoyValor.Name = "lblResumenIngresosHoyValor";
            lblResumenIngresosHoyValor.Size = new Size(125, 54);
            lblResumenIngresosHoyValor.TabIndex = 3;
            lblResumenIngresosHoyValor.Text = "RD$0";
            // 
            // lblResumenProximaCita
            // 
            lblResumenProximaCita.AutoSize = true;
            lblResumenProximaCita.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblResumenProximaCita.ForeColor = Color.DimGray;
            lblResumenProximaCita.Location = new Point(18, 209);
            lblResumenProximaCita.Name = "lblResumenProximaCita";
            lblResumenProximaCita.Size = new Size(192, 25);
            lblResumenProximaCita.TabIndex = 4;
            lblResumenProximaCita.Text = "Próxima cita pendiente";
            // 
            // lblResumenProximaCitaValor
            // 
            lblResumenProximaCitaValor.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblResumenProximaCitaValor.ForeColor = Color.MediumVioletRed;
            lblResumenProximaCitaValor.Location = new Point(18, 240);
            lblResumenProximaCitaValor.Name = "lblResumenProximaCitaValor";
            lblResumenProximaCitaValor.Size = new Size(234, 65);
            lblResumenProximaCitaValor.TabIndex = 5;
            lblResumenProximaCitaValor.Text = "No hay citas pendientes";
            lblResumenProximaCitaValor.Click += lblResumenProximaCitaValor_Click;
            // 
            // btnNotificaciones
            // 
            btnNotificaciones.BackColor = Color.DeepPink;
            btnNotificaciones.FlatStyle = FlatStyle.Popup;
            btnNotificaciones.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNotificaciones.ForeColor = Color.LavenderBlush;
            btnNotificaciones.Location = new Point(26, 369);
            btnNotificaciones.Name = "btnNotificaciones";
            btnNotificaciones.Size = new Size(321, 40);
            btnNotificaciones.TabIndex = 19;
            btnNotificaciones.Text = "🔔 Ver notificaciones";
            btnNotificaciones.UseVisualStyleBackColor = false;
            btnNotificaciones.Click += btnNotificaciones_Click;
            // 
            // frmReportes
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(1026, 664);
            Controls.Add(grpResumen);
            Controls.Add(btnNotificaciones);
            Controls.Add(picLogo);
            Controls.Add(dgvPagos);
            Controls.Add(btnCorteDia);
            Controls.Add(lblTotal);
            Controls.Add(lblTitulo);
            Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Name = "frmReportes";
            Text = "Reportes";
            Load += FrmReportes_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPagos).EndInit();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            grpResumen.ResumeLayout(false);
            grpResumen.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }



        private Label lblTitulo;
        private Label lblTotal;
        private Button btnCorteDia;
        private DataGridView dgvPagos;
        private PictureBox picLogo;
        private GroupBox grpResumen;
        private Label lblResumenCitasHoy;
        private Label lblResumenCitasHoyValor;
        private Label lblResumenIngresosHoy;
        private Label lblResumenIngresosHoyValor;
        private Label lblResumenProximaCita;
        private Label lblResumenProximaCitaValor;
        private Button btnNotificaciones;
    }
}