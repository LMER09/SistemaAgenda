namespace SistemaAgenda.UI
{
    partial class frmEstilistas
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
            lblNombre = new Label();
            lblApellido = new Label();
            lblTelefono = new Label();
            lblCorreo = new Label();
            lblEspecialidad = new Label();
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            txtTelefono = new TextBox();
            txtCorreo = new TextBox();
            txtEspecialidad = new TextBox();
            btnAgregar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            dgvEstilistas = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvEstilistas).BeginInit();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(63, 50);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(67, 20);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre:";
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(63, 90);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(66, 20);
            lblApellido.TabIndex = 1;
            lblApellido.Text = "Apellido:";
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(63, 130);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(70, 20);
            lblTelefono.TabIndex = 2;
            lblTelefono.Text = "Teléfono:";
            // 
            // lblCorreo
            // 
            lblCorreo.AutoSize = true;
            lblCorreo.Location = new Point(63, 170);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(57, 20);
            lblCorreo.TabIndex = 3;
            lblCorreo.Text = "Correo:";
            // 
            // lblEspecialidad
            // 
            lblEspecialidad.AutoSize = true;
            lblEspecialidad.Location = new Point(63, 210);
            lblEspecialidad.Name = "lblEspecialidad";
            lblEspecialidad.Size = new Size(100, 20);
            lblEspecialidad.TabIndex = 4;
            lblEspecialidad.Text = "Especialidad:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(180, 43);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(353, 27);
            txtNombre.TabIndex = 5;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(180, 83);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(353, 27);
            txtApellido.TabIndex = 6;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(180, 123);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(353, 27);
            txtTelefono.TabIndex = 7;
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(180, 163);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(353, 27);
            txtCorreo.TabIndex = 8;
            // 
            // txtEspecialidad
            // 
            txtEspecialidad.Location = new Point(180, 203);
            txtEspecialidad.Name = "txtEspecialidad";
            txtEspecialidad.Size = new Size(353, 27);
            txtEspecialidad.TabIndex = 9;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(63, 260);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(94, 29);
            btnAgregar.TabIndex = 10;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(220, 260);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(94, 29);
            btnEditar.TabIndex = 11;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(403, 260);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(94, 29);
            btnEliminar.TabIndex = 12;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // dgvEstilistas
            // 
            dgvEstilistas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEstilistas.Location = new Point(37, 320);
            dgvEstilistas.Name = "dgvEstilistas";
            dgvEstilistas.RowHeadersWidth = 51;
            dgvEstilistas.Size = new Size(659, 152);
            dgvEstilistas.TabIndex = 13;
            dgvEstilistas.CellClick += dgvEstilistas_CellClick;
            // 
            // frmEstilistas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 514);
            Controls.Add(dgvEstilistas);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(btnAgregar);
            Controls.Add(txtEspecialidad);
            Controls.Add(txtCorreo);
            Controls.Add(txtTelefono);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            Controls.Add(lblEspecialidad);
            Controls.Add(lblCorreo);
            Controls.Add(lblTelefono);
            Controls.Add(lblApellido);
            Controls.Add(lblNombre);
            Name = "frmEstilistas";
            Text = "Estilistas";
            Load += FrmEstilistas_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEstilistas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblNombre;
        private Label lblApellido;
        private Label lblTelefono;
        private Label lblCorreo;
        private Label lblEspecialidad;

        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtTelefono;
        private TextBox txtCorreo;
        private TextBox txtEspecialidad;

        private Button btnAgregar;
        private Button btnEditar;
        private Button btnEliminar;
        private DataGridView dgvEstilistas;
    }
}