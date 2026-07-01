namespace SistemaAgenda.UI
{
    partial class frmClientes
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
            lblNombre = new Label();
            lblApellido = new Label();
            lblTelefono = new Label();
            lblCorreo = new Label();
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            txtTelefono = new TextBox();
            txtCorreo = new TextBox();
            btnAgregar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            dgvClientes = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(51, 117);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(70, 20);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre:";
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(51, 150);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(66, 20);
            lblApellido.TabIndex = 1;
            lblApellido.Text = "Apellido";
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(51, 183);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(72, 20);
            lblTelefono.TabIndex = 2;
            lblTelefono.Text = "Teléfono:";
            // 
            // lblCorreo
            // 
            lblCorreo.AutoSize = true;
            lblCorreo.Location = new Point(51, 216);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(60, 20);
            lblCorreo.TabIndex = 3;
            lblCorreo.Text = "Correo:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(162, 114);
            txtNombre.Name = "txtNombre";
            txtNombre.PlaceholderText = "Ej: Luzmairy";
            txtNombre.Size = new Size(357, 27);
            txtNombre.TabIndex = 4;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(162, 147);
            txtApellido.Name = "txtApellido";
            txtApellido.PlaceholderText = "Ej: Rodriguez";
            txtApellido.Size = new Size(357, 27);
            txtApellido.TabIndex = 5;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(162, 180);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.PlaceholderText = "Ej: 829-275-3580";
            txtTelefono.Size = new Size(357, 27);
            txtTelefono.TabIndex = 6;
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(162, 213);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.PlaceholderText = "Ej: luz17@gmail.com";
            txtCorreo.Size = new Size(357, 27);
            txtCorreo.TabIndex = 7;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(102, 277);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(236, 29);
            btnAgregar.TabIndex = 8;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(390, 277);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(233, 29);
            btnEditar.TabIndex = 9;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(686, 277);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(233, 29);
            btnEliminar.TabIndex = 10;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // dgvClientes
            // 
            dgvClientes.BackgroundColor = Color.OldLace;
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Location = new Point(51, 329);
            dgvClientes.Name = "dgvClientes";
            dgvClientes.RowHeadersWidth = 51;
            dgvClientes.Size = new Size(922, 151);
            dgvClientes.TabIndex = 11;
            dgvClientes.CellClick += dgvClientes_CellClick;
            // 
            // frmClientes
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(1041, 535);
            Controls.Add(dgvClientes);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(btnAgregar);
            Controls.Add(txtCorreo);
            Controls.Add(txtTelefono);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            Controls.Add(lblCorreo);
            Controls.Add(lblTelefono);
            Controls.Add(lblApellido);
            Controls.Add(lblNombre);
            Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "frmClientes";
            Text = "Clientes";
            TransparencyKey = Color.FromArgb(255, 224, 192);
            Load += FrmClientes_Load;
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNombre;
        private Label lblApellido;
        private Label lblTelefono;
        private Label lblCorreo;

        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtTelefono;
        private TextBox txtCorreo;

        private Button btnAgregar;
        private Button btnEditar;
        private Button btnEliminar;
        private DataGridView dgvClientes;
    }
}