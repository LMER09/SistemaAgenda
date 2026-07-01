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
            lblNombre.Location = new Point(38, 91);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(70, 20);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre:";
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(38, 131);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(70, 20);
            lblApellido.TabIndex = 1;
            lblApellido.Text = "Apellido:";
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(38, 165);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(72, 20);
            lblTelefono.TabIndex = 2;
            lblTelefono.Text = "Teléfono:";
            txtTelefono.KeyPress += txtTelefono_KeyPress;
            // 
            // lblCorreo
            // 
            lblCorreo.AutoSize = true;
            lblCorreo.Location = new Point(38, 198);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(60, 20);
            lblCorreo.TabIndex = 3;
            lblCorreo.Text = "Correo:";
            // 
            // lblEspecialidad
            // 
            lblEspecialidad.AutoSize = true;
            lblEspecialidad.Location = new Point(38, 231);
            lblEspecialidad.Name = "lblEspecialidad";
            lblEspecialidad.Size = new Size(97, 20);
            lblEspecialidad.TabIndex = 4;
            lblEspecialidad.Text = "Especialidad:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(202, 91);
            txtNombre.Name = "txtNombre";
            txtNombre.PlaceholderText = "Ej: Maria";
            txtNombre.Size = new Size(397, 27);
            txtNombre.TabIndex = 5;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(202, 124);
            txtApellido.Name = "txtApellido";
            txtApellido.PlaceholderText = "Ej: Cedano";
            txtApellido.Size = new Size(397, 27);
            txtApellido.TabIndex = 6;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(202, 158);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.PlaceholderText = "Ej: 000-000-0000";
            txtTelefono.Size = new Size(397, 27);
            txtTelefono.TabIndex = 7;
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(202, 191);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.PlaceholderText = "Ej: Maria@gmail.com";
            txtCorreo.Size = new Size(397, 27);
            txtCorreo.TabIndex = 8;
            // 
            // txtEspecialidad
            // 
            txtEspecialidad.Location = new Point(202, 224);
            txtEspecialidad.Name = "txtEspecialidad";
            txtEspecialidad.PlaceholderText = "Ej: Cortes de pelo";
            txtEspecialidad.Size = new Size(397, 27);
            txtEspecialidad.TabIndex = 9;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(84, 280);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(204, 29);
            btnAgregar.TabIndex = 10;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(380, 280);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(204, 29);
            btnEditar.TabIndex = 11;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(648, 280);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(204, 29);
            btnEliminar.TabIndex = 12;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // dgvEstilistas
            // 
            dgvEstilistas.BackgroundColor = Color.OldLace;
            dgvEstilistas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEstilistas.Location = new Point(38, 330);
            dgvEstilistas.Name = "dgvEstilistas";
            dgvEstilistas.RowHeadersWidth = 51;
            dgvEstilistas.Size = new Size(896, 152);
            dgvEstilistas.TabIndex = 13;
            dgvEstilistas.CellClick += dgvEstilistas_CellClick;
            // 
            // frmEstilistas
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(986, 514);
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
            Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
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