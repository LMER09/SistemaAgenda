namespace SistemaAgenda.UI
{
    partial class frmConsultarPagos
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
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            btnBuscar = new Button();
            btnCerrar = new Button();
            dgvPagos = new DataGridView();
            btnEliminar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPagos).BeginInit();
            SuspendLayout();
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Location = new Point(38, 37);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(59, 20);
            lblBuscar.TabIndex = 0;
            lblBuscar.Text = "Buscar:";
            // 
            // txtBuscar
            // 
            txtBuscar.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscar.Location = new Point(121, 30);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Cliente, servicio o método de pago";
            txtBuscar.Size = new Size(348, 27);
            txtBuscar.TabIndex = 1;
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.DeepPink;
            btnBuscar.ForeColor = Color.White;
            btnBuscar.Location = new Point(490, 21);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(119, 45);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "🔍 Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.BackColor = Color.DeepPink;
            btnCerrar.ForeColor = Color.White;
            btnCerrar.Location = new Point(635, 21);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(119, 45);
            btnCerrar.TabIndex = 3;
            btnCerrar.Text = "❌ Cerrar";
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // dgvPagos
            // 
            dgvPagos.BackgroundColor = Color.LavenderBlush;
            dgvPagos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPagos.Location = new Point(38, 74);
            dgvPagos.Name = "dgvPagos";
            dgvPagos.ReadOnly = true;
            dgvPagos.RowHeadersWidth = 51;
            dgvPagos.Size = new Size(716, 300);
            dgvPagos.TabIndex = 4;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.DeepPink;
            btnEliminar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(38, 388);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(150, 40);
            btnEliminar.TabIndex = 5;
            btnEliminar.Text = "🗑️ Eliminar pago";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // frmConsultarPagos
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(792, 440);
            Controls.Add(btnEliminar);
            Controls.Add(dgvPagos);
            Controls.Add(btnCerrar);
            Controls.Add(btnBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(lblBuscar);
            Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "frmConsultarPagos";
            Text = "Consulta de Pagos";
            Load += frmConsultarPagos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPagos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblBuscar;
        private TextBox txtBuscar;
        private Button btnBuscar;
        private Button btnCerrar;
        private DataGridView dgvPagos;
        private Button btnEliminar;
    }
}