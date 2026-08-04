namespace SistemaAgenda.UI
{
    partial class frmConsultarEstilistas
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
            dgvEstilistas = new DataGridView();
            btnEditar = new Button();
            btnEliminar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvEstilistas).BeginInit();
            SuspendLayout();
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Location = new Point(38, 36);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(59, 20);
            lblBuscar.TabIndex = 0;
            lblBuscar.Text = "Buscar:";
            // 
            // txtBuscar
            // 
            txtBuscar.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscar.Location = new Point(103, 29);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Nombre, apellido, especialidad o cédula";
            txtBuscar.Size = new Size(314, 27);
            txtBuscar.TabIndex = 1;
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.DeepPink;
            btnBuscar.ForeColor = Color.White;
            btnBuscar.Location = new Point(423, 20);
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
            btnCerrar.Location = new Point(548, 20);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(119, 45);
            btnCerrar.TabIndex = 3;
            btnCerrar.Text = "❌ Cerrar";
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // dgvEstilistas
            // 
            dgvEstilistas.BackgroundColor = Color.LavenderBlush;
            dgvEstilistas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEstilistas.Location = new Point(38, 71);
            dgvEstilistas.Name = "dgvEstilistas";
            dgvEstilistas.ReadOnly = true;
            dgvEstilistas.RowHeadersWidth = 51;
            dgvEstilistas.Size = new Size(629, 320);
            dgvEstilistas.TabIndex = 4;
            // 
            // btnEditar
            // 
            btnEditar.BackColor = Color.DeepPink;
            btnEditar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEditar.ForeColor = Color.White;
            btnEditar.Location = new Point(38, 400);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(150, 43);
            btnEditar.TabIndex = 5;
            btnEditar.Text = "✏️ Editar";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.DeepPink;
            btnEliminar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(200, 400);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(150, 43);
            btnEliminar.TabIndex = 6;
            btnEliminar.Text = "🗑️ Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // frmConsultarEstilistas
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(705, 465);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(dgvEstilistas);
            Controls.Add(btnCerrar);
            Controls.Add(btnBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(lblBuscar);
            Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "frmConsultarEstilistas";
            Text = "Consulta de Estilistas";
            Load += frmConsultarEstilistas_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEstilistas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblBuscar;
        private TextBox txtBuscar;
        private Button btnBuscar;
        private Button btnCerrar;
        private DataGridView dgvEstilistas;
        private Button btnEditar;
        private Button btnEliminar;
    }
}