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
            lblFechaReporte = new Label();
            btnExportarExcel = new Button();
            btnExportarPdf = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPagos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(42, 56);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(219, 25);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Total de ingresos del día:";
            // 
            // lblFechaReporte
            // 
            lblFechaReporte.AutoSize = true;
            lblFechaReporte.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblFechaReporte.ForeColor = Color.DimGray;
            lblFechaReporte.Location = new Point(42, 85);
            lblFechaReporte.Name = "lblFechaReporte";
            lblFechaReporte.Size = new Size(300, 20);
            lblFechaReporte.TabIndex = 18;
            lblFechaReporte.Text = "Reporte de hoy, dd/mm/aaaa";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotal.Location = new Point(42, 112);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(78, 23);
            lblTotal.TabIndex = 1;
            lblTotal.Text = "RD$ 0.00";
            // 
            // btnCorteDia
            // 
            btnCorteDia.BackColor = Color.DeepPink;
            btnCorteDia.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCorteDia.ForeColor = Color.White;
            btnCorteDia.Location = new Point(42, 154);
            btnCorteDia.Name = "btnCorteDia";
            btnCorteDia.Size = new Size(210, 46);
            btnCorteDia.TabIndex = 2;
            btnCorteDia.Text = "💰Cerrar corte del día";
            btnCorteDia.UseVisualStyleBackColor = false;
            btnCorteDia.Click += btnCorteDia_Click;
            // 
            // btnExportarExcel
            // 
            btnExportarExcel.BackColor = Color.SeaGreen;
            btnExportarExcel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExportarExcel.ForeColor = Color.White;
            btnExportarExcel.Location = new Point(42, 210);
            btnExportarExcel.Name = "btnExportarExcel";
            btnExportarExcel.Size = new Size(210, 46);
            btnExportarExcel.TabIndex = 19;
            btnExportarExcel.Text = "📊 Exportar a Excel";
            btnExportarExcel.UseVisualStyleBackColor = false;
            btnExportarExcel.Click += btnExportarExcel_Click;
            // 
            // btnExportarPdf
            // 
            btnExportarPdf.BackColor = Color.Firebrick;
            btnExportarPdf.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExportarPdf.ForeColor = Color.White;
            btnExportarPdf.Location = new Point(42, 266);
            btnExportarPdf.Name = "btnExportarPdf";
            btnExportarPdf.Size = new Size(210, 46);
            btnExportarPdf.TabIndex = 20;
            btnExportarPdf.Text = "📄 Exportar a PDF";
            btnExportarPdf.UseVisualStyleBackColor = false;
            btnExportarPdf.Click += btnExportarPdf_Click;
            // 
            // dgvPagos
            // 
            dgvPagos.AllowUserToAddRows = false;
            dgvPagos.BackgroundColor = Color.LavenderBlush;
            dgvPagos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPagos.Location = new Point(42, 330);
            dgvPagos.Name = "dgvPagos";
            dgvPagos.ReadOnly = true;
            dgvPagos.RowHeadersWidth = 51;
            dgvPagos.Size = new Size(677, 215);
            dgvPagos.TabIndex = 3;
            // 
            // picLogo
            // 
            picLogo.BackColor = Color.Transparent;
            picLogo.Image = (Image)resources.GetObject("picLogo.Image");
            picLogo.Location = new Point(470, -12);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(249, 245);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 17;
            picLogo.TabStop = false;
            // 
            // frmReportes
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(763, 580);
            Controls.Add(picLogo);
            Controls.Add(dgvPagos);
            Controls.Add(btnExportarPdf);
            Controls.Add(btnExportarExcel);
            Controls.Add(btnCorteDia);
            Controls.Add(lblTotal);
            Controls.Add(lblFechaReporte);
            Controls.Add(lblTitulo);
            Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Name = "frmReportes";
            Text = "Reportes";
            Load += FrmReportes_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPagos).EndInit();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }



        private Label lblTitulo;
        private Label lblFechaReporte;
        private Label lblTotal;
        private Button btnCorteDia;
        private Button btnExportarExcel;
        private Button btnExportarPdf;
        private DataGridView dgvPagos;
        private PictureBox picLogo;
    }
}