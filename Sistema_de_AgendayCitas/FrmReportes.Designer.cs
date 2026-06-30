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
            lblTitulo = new Label();
            lblTotal = new Label();
            btnCorteDia = new Button();
            dgvPagos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvPagos).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(37, 30);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(180, 20);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Total de ingresos del día:";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(37, 60);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(0, 20);
            lblTotal.TabIndex = 1;
            lblTotal.Text = "RD$ 0.00";
            // 
            // btnCorteDia
            // 
            btnCorteDia.Location = new Point(37, 100);
            btnCorteDia.Name = "btnCorteDia";
            btnCorteDia.Size = new Size(160, 29);
            btnCorteDia.TabIndex = 2;
            btnCorteDia.Text = "Cerrar corte del día";
            btnCorteDia.UseVisualStyleBackColor = true;
            btnCorteDia.Click += btnCorteDia_Click;
            // 
            // dgvPagos
            // 
            dgvPagos.AllowUserToAddRows = false;
            dgvPagos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPagos.Location = new Point(37, 150);
            dgvPagos.Name = "dgvPagos";
            dgvPagos.ReadOnly = true;
            dgvPagos.RowHeadersWidth = 51;
            dgvPagos.Size = new Size(700, 250);
            dgvPagos.TabIndex = 3;
            // 
            // frmReportes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvPagos);
            Controls.Add(btnCorteDia);
            Controls.Add(lblTotal);
            Controls.Add(lblTitulo);
            Name = "frmReportes";
            Text = "Reportes";
            Load += FrmReportes_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPagos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

       

        private Label lblTitulo;
        private Label lblTotal;
        private Button btnCorteDia;
        private DataGridView dgvPagos;
    }
}