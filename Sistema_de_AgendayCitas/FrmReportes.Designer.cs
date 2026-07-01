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
            lblTitulo.Location = new Point(42, 93);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(178, 20);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Total de ingresos del día:";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(42, 134);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(69, 20);
            lblTotal.TabIndex = 1;
            lblTotal.Text = "RD$ 0.00";
            // 
            // btnCorteDia
            // 
            btnCorteDia.Location = new Point(42, 168);
            btnCorteDia.Name = "btnCorteDia";
            btnCorteDia.Size = new Size(180, 29);
            btnCorteDia.TabIndex = 2;
            btnCorteDia.Text = "Cerrar corte del día";
            btnCorteDia.UseVisualStyleBackColor = true;
            btnCorteDia.Click += btnCorteDia_Click;
            // 
            // dgvPagos
            // 
            dgvPagos.AllowUserToAddRows = false;
            dgvPagos.BackgroundColor = Color.OldLace;
            dgvPagos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPagos.Location = new Point(42, 222);
            dgvPagos.Name = "dgvPagos";
            dgvPagos.ReadOnly = true;
            dgvPagos.RowHeadersWidth = 51;
            dgvPagos.Size = new Size(719, 196);
            dgvPagos.TabIndex = 3;
            // 
            // frmReportes
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(856, 450);
            Controls.Add(dgvPagos);
            Controls.Add(btnCorteDia);
            Controls.Add(lblTotal);
            Controls.Add(lblTitulo);
            Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
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