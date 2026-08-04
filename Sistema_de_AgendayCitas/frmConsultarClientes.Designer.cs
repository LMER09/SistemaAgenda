namespace SistemaAgenda.UI
{
    partial class frmConsultarClientes
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
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            btnBuscar = new Button();
            btnCerrar = new Button();
            dgvClientes = new DataGridView();
            btnEditar = new Button();
            btnEliminar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            SuspendLayout();
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Location = new Point(38, 25);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(54, 20);
            lblBuscar.TabIndex = 0;
            lblBuscar.Text = "Buscar:";
            // 
            // txtBuscar
            // 
            txtBuscar.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscar.Location = new Point(100, 21);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Nombre, apellido o cédula";
            txtBuscar.Size = new Size(260, 27);
            txtBuscar.TabIndex = 1;
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.DeepPink;
            btnBuscar.ForeColor = Color.White;
            btnBuscar.Location = new Point(370, 20);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(110, 29);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "🔍 Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.BackColor = Color.DeepPink;
            btnCerrar.FlatStyle = FlatStyle.Popup;
            btnCerrar.ForeColor = Color.White;
            btnCerrar.Location = new Point(553, 20);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(94, 29);
            btnCerrar.TabIndex = 3;
            btnCerrar.Text = "❌ Cerrar";
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // dgvClientes
            // 
            dgvClientes.BackgroundColor = Color.LavenderBlush;
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Location = new Point(38, 65);
            dgvClientes.Name = "dgvClientes";
            dgvClientes.ReadOnly = true;
            dgvClientes.RowHeadersWidth = 51;
            dgvClientes.Size = new Size(609, 320);
            dgvClientes.TabIndex = 4;
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
            // frmConsultarClientes
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(685, 465);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(dgvClientes);
            Controls.Add(btnCerrar);
            Controls.Add(btnBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(lblBuscar);
            Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "frmConsultarClientes";
            Text = "Consulta de Clientes";
            Load += frmConsultarClientes_Load;
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblBuscar;
        private TextBox txtBuscar;
        private Button btnBuscar;
        private Button btnCerrar;
        private DataGridView dgvClientes;
        private Button btnEditar;
        private Button btnEliminar;
    }
}