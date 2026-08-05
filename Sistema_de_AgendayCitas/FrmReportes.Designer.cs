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
            dtpDesde = new DateTimePicker();
            lblaFiltro = new Label();
            btnExcel = new Button();
            btnPDF = new Button();
            panelFiltros = new Panel();
            lblHasta = new Label();
            lblDesde = new Label();
            dtpHasta = new DateTimePicker();
            lblFecha = new Label();
            panelResumen = new Panel();
            lblCantidadCitas = new Label();
            lblTituloCantidad = new Label();
            lblTituloTotal = new Label();
            lblHorarioDetalle = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvPagos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            panelFiltros.SuspendLayout();
            panelResumen.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lblTitulo.Location = new Point(378, 22);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(268, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "REPORTE DE INGRESOS";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotal.Location = new Point(17, 36);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(78, 23);
            lblTotal.TabIndex = 1;
            lblTotal.Text = "RD$ 0.00";
            lblTotal.Click += lblTotal_Click;
            // 
            // btnCorteDia
            // 
            btnCorteDia.BackColor = Color.DeepPink;
            btnCorteDia.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCorteDia.ForeColor = Color.White;
            btnCorteDia.Location = new Point(17, 153);
            btnCorteDia.Name = "btnCorteDia";
            btnCorteDia.Size = new Size(162, 35);
            btnCorteDia.TabIndex = 2;
            btnCorteDia.Text = "💰Generar reporte";
            btnCorteDia.UseVisualStyleBackColor = false;
            btnCorteDia.Click += btnCorteDia_Click;
            // 
            // dgvPagos
            // 
            dgvPagos.AllowUserToAddRows = false;
            dgvPagos.BackgroundColor = Color.LavenderBlush;
            dgvPagos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPagos.Location = new Point(42, 378);
            dgvPagos.Name = "dgvPagos";
            dgvPagos.ReadOnly = true;
            dgvPagos.RowHeadersWidth = 51;
            dgvPagos.Size = new Size(889, 137);
            dgvPagos.TabIndex = 3;
            // 
            // picLogo
            // 
            picLogo.BackColor = Color.Transparent;
            picLogo.Image = (Image)resources.GetObject("picLogo.Image");
            picLogo.Location = new Point(711, 59);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(207, 166);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 17;
            picLogo.TabStop = false;
            // 
            // dtpDesde
            // 
            dtpDesde.Format = DateTimePickerFormat.Short;
            dtpDesde.Location = new Point(17, 102);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new Size(99, 27);
            dtpDesde.TabIndex = 18;
            dtpDesde.ValueChanged += dtpFechaReporte_ValueChanged;
            // 
            // lblaFiltro
            // 
            lblaFiltro.AutoSize = true;
            lblaFiltro.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lblaFiltro.ForeColor = Color.DeepPink;
            lblaFiltro.Location = new Point(114, 0);
            lblaFiltro.Name = "lblaFiltro";
            lblaFiltro.Size = new Size(65, 25);
            lblaFiltro.TabIndex = 19;
            lblaFiltro.Text = "Filtros";
            // 
            // btnExcel
            // 
            btnExcel.BackColor = Color.DeepPink;
            btnExcel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExcel.ForeColor = Color.White;
            btnExcel.Location = new Point(513, 539);
            btnExcel.Name = "btnExcel";
            btnExcel.Size = new Size(210, 46);
            btnExcel.TabIndex = 21;
            btnExcel.Text = "Exportar Excel";
            btnExcel.UseVisualStyleBackColor = false;
            btnExcel.Click += btnExcel_Click;
            // 
            // btnPDF
            // 
            btnPDF.BackColor = Color.DeepPink;
            btnPDF.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPDF.ForeColor = Color.White;
            btnPDF.Location = new Point(235, 539);
            btnPDF.Name = "btnPDF";
            btnPDF.Size = new Size(210, 46);
            btnPDF.TabIndex = 22;
            btnPDF.Text = "Exportar PDF";
            btnPDF.UseVisualStyleBackColor = false;
            btnPDF.Click += btnPDF_Click;
            // 
            // panelFiltros
            // 
            panelFiltros.BorderStyle = BorderStyle.FixedSingle;
            panelFiltros.Controls.Add(lblHasta);
            panelFiltros.Controls.Add(lblDesde);
            panelFiltros.Controls.Add(dtpHasta);
            panelFiltros.Controls.Add(lblFecha);
            panelFiltros.Controls.Add(btnCorteDia);
            panelFiltros.Controls.Add(lblaFiltro);
            panelFiltros.Controls.Add(dtpDesde);
            panelFiltros.Location = new Point(42, 59);
            panelFiltros.Name = "panelFiltros";
            panelFiltros.Size = new Size(304, 196);
            panelFiltros.TabIndex = 23;
            // 
            // lblHasta
            // 
            lblHasta.AutoSize = true;
            lblHasta.Location = new Point(168, 73);
            lblHasta.Name = "lblHasta";
            lblHasta.Size = new Size(55, 20);
            lblHasta.TabIndex = 26;
            lblHasta.Text = "Hasta: ";
            lblHasta.Click += lblHasta_Click;
            // 
            // lblDesde
            // 
            lblDesde.AutoSize = true;
            lblDesde.Location = new Point(32, 72);
            lblDesde.Name = "lblDesde";
            lblDesde.Size = new Size(59, 20);
            lblDesde.TabIndex = 24;
            lblDesde.Text = "Desde: ";
            lblDesde.Click += lblDesde_Click;
            // 
            // dtpHasta
            // 
            dtpHasta.Format = DateTimePickerFormat.Short;
            dtpHasta.Location = new Point(151, 102);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(99, 27);
            dtpHasta.TabIndex = 25;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(17, 39);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(129, 20);
            lblFecha.TabIndex = 24;
            lblFecha.Text = "Fecha de reporte:";
            // 
            // panelResumen
            // 
            panelResumen.BorderStyle = BorderStyle.FixedSingle;
            panelResumen.Controls.Add(lblCantidadCitas);
            panelResumen.Controls.Add(lblTituloCantidad);
            panelResumen.Controls.Add(lblTituloTotal);
            panelResumen.Controls.Add(lblTotal);
            panelResumen.Location = new Point(42, 277);
            panelResumen.Name = "panelResumen";
            panelResumen.Size = new Size(617, 73);
            panelResumen.TabIndex = 24;
            // 
            // lblCantidadCitas
            // 
            lblCantidadCitas.AutoSize = true;
            lblCantidadCitas.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCantidadCitas.Location = new Point(439, 32);
            lblCantidadCitas.Name = "lblCantidadCitas";
            lblCantidadCitas.Size = new Size(19, 23);
            lblCantidadCitas.TabIndex = 3;
            lblCantidadCitas.Text = "0";
            // 
            // lblTituloCantidad
            // 
            lblTituloCantidad.AutoSize = true;
            lblTituloCantidad.Font = new Font("Segoe UI Semibold", 8.2F, FontStyle.Bold);
            lblTituloCantidad.ForeColor = Color.DeepPink;
            lblTituloCantidad.Location = new Point(391, 13);
            lblTituloCantidad.Name = "lblTituloCantidad";
            lblTituloCantidad.Size = new Size(124, 19);
            lblTituloCantidad.TabIndex = 2;
            lblTituloCantidad.Text = "Cantidad de citas: ";
            // 
            // lblTituloTotal
            // 
            lblTituloTotal.AutoSize = true;
            lblTituloTotal.Font = new Font("Segoe UI Semibold", 8.2F, FontStyle.Bold);
            lblTituloTotal.ForeColor = Color.DeepPink;
            lblTituloTotal.Location = new Point(17, 13);
            lblTituloTotal.Name = "lblTituloTotal";
            lblTituloTotal.Size = new Size(93, 19);
            lblTituloTotal.TabIndex = 0;
            lblTituloTotal.Text = "Total del dia: ";
            // 
            // lblHorarioDetalle
            // 
            lblHorarioDetalle.AutoSize = true;
            lblHorarioDetalle.Font = new Font("Segoe UI", 9.5F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblHorarioDetalle.ForeColor = Color.DimGray;
            lblHorarioDetalle.Location = new Point(701, 245);
            lblHorarioDetalle.MaximumSize = new Size(629, 0);
            lblHorarioDetalle.Name = "lblHorarioDetalle";
            lblHorarioDetalle.Size = new Size(230, 21);
            lblHorarioDetalle.TabIndex = 25;
            lblHorarioDetalle.Text = "Tu belleza, nuestro compromiso";
            // 
            // frmReportes
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(972, 614);
            Controls.Add(lblHorarioDetalle);
            Controls.Add(panelResumen);
            Controls.Add(panelFiltros);
            Controls.Add(btnPDF);
            Controls.Add(btnExcel);
            Controls.Add(picLogo);
            Controls.Add(dgvPagos);
            Controls.Add(lblTitulo);
            Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Name = "frmReportes";
            Text = "Reportes";
            Load += FrmReportes_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPagos).EndInit();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            panelFiltros.ResumeLayout(false);
            panelFiltros.PerformLayout();
            panelResumen.ResumeLayout(false);
            panelResumen.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }



        private Label lblTitulo;
        private Label lblTotal;
        private Button btnCorteDia;
        private DataGridView dgvPagos;
        private PictureBox picLogo;
        private DateTimePicker dtpDesde;
        private Label lblaFiltro;
        private Button btnExcel;
        private Button btnPDF;
        private Panel panelFiltros;
        private Label lblFecha;
        private Label lblHasta;
        private Label lblDesde;
        private DateTimePicker dtpHasta;
        private Panel panelResumen;
        private Label lblTituloTotal;
        private Label lblCantidadCitas;
        private Label lblTituloCantidad;
        private Label lblHorarioDetalle;
    }
}