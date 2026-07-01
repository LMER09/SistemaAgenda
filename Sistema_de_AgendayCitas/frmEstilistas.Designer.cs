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
            lblIngrese = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvEstilistas).BeginInit();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(38, 87);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(70, 20);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre:";
            txtNombre.KeyPress += txtNombre_KeyPress;
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(38, 124);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(70, 20);
            lblApellido.TabIndex = 1;
            lblApellido.Text = "Apellido:";
            txtApellido.KeyPress += txtApellido_KeyPress;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(38, 157);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(72, 20);
            lblTelefono.TabIndex = 2;
            lblTelefono.Text = "Teléfono:";
            // 
            // lblCorreo
            // 
            lblCorreo.AutoSize = true;
            lblCorreo.Location = new Point(38, 190);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(60, 20);
            lblCorreo.TabIndex = 3;
            lblCorreo.Text = "Correo:";
            // 
            // lblEspecialidad
            // 
            lblEspecialidad.AutoSize = true;
            lblEspecialidad.Location = new Point(38, 223);
            lblEspecialidad.Name = "lblEspecialidad";
            lblEspecialidad.Size = new Size(97, 20);
            lblEspecialidad.TabIndex = 4;
            lblEspecialidad.Text = "Especialidad:";
            // 
            // txtNombre
            // 
            txtNombre.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombre.ForeColor = SystemColors.ActiveCaptionText;
            txtNombre.Location = new Point(157, 80);
            txtNombre.Name = "txtNombre";
            txtNombre.PlaceholderText = "Ej: Maria";
            txtNombre.Size = new Size(397, 27);
            txtNombre.TabIndex = 5;
            // 
            // txtApellido
            // 
            txtApellido.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtApellido.Location = new Point(157, 117);
            txtApellido.Name = "txtApellido";
            txtApellido.PlaceholderText = "Ej: Cedano";
            txtApellido.Size = new Size(397, 27);
            txtApellido.TabIndex = 6;
            // 
            // txtTelefono
            // 
            txtTelefono.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTelefono.Location = new Point(157, 150);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.PlaceholderText = "Ej: 000-000-0000";
            txtTelefono.Size = new Size(397, 27);
            txtTelefono.TabIndex = 7;
            txtTelefono.KeyPress += txtTelefono_KeyPress;
            // 
            // txtCorreo
            // 
            txtCorreo.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCorreo.Location = new Point(157, 183);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.PlaceholderText = "Ej: Maria@gmail.com";
            txtCorreo.Size = new Size(397, 27);
            txtCorreo.TabIndex = 8;
            // 
            // txtEspecialidad
            // 
            txtEspecialidad.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEspecialidad.Location = new Point(157, 216);
            txtEspecialidad.Name = "txtEspecialidad";
            txtEspecialidad.PlaceholderText = "Ej: Cortes de pelo";
            txtEspecialidad.Size = new Size(397, 27);
            txtEspecialidad.TabIndex = 9;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(89, 280);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(182, 29);
            btnAgregar.TabIndex = 10;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(337, 280);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(182, 29);
            btnEditar.TabIndex = 11;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(584, 280);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(182, 29);
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
            dgvEstilistas.Size = new Size(798, 152);
            dgvEstilistas.TabIndex = 13;
            dgvEstilistas.CellClick += dgvEstilistas_CellClick;
            // 
            // lblIngrese
            // 
            lblIngrese.AutoSize = true;
            lblIngrese.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblIngrese.Location = new Point(38, 25);
            lblIngrese.Name = "lblIngrese";
            lblIngrese.Size = new Size(184, 23);
            lblIngrese.TabIndex = 14;
            lblIngrese.Text = "Ingrese nuevo estilista:";
            // 
            // frmEstilistas
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(875, 514);
            Controls.Add(lblIngrese);
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
        private Label lblIngrese;
    }
}