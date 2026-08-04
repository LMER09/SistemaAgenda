namespace SistemaAgenda.UI
{
    partial class frmConsultarEstilistas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultarEstilistas));
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            btnBuscar = new Button();
            btnCerrar = new Button();
            dgvEstilistas = new DataGridView();
            lblNombre = new Label();
            lblApellido = new Label();
            lblTelefono = new Label();
            lblCorreo = new Label();
            lblCedula = new Label();
            lblEspecialidad = new Label();
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            txtTelefono = new TextBox();
            txtCorreo = new TextBox();
            txtCedula = new TextBox();
            txtEspecialidad = new TextBox();
            btnEditar = new Button();
            btnEliminar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvEstilistas).BeginInit();
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
            txtBuscar.PlaceholderText = "Nombre, apellido, especialidad o cédula";
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
            btnCerrar.Location = new Point(660, 20);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(94, 29);
            btnCerrar.TabIndex = 3;
            btnCerrar.Text = "❌ Cerrar";
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // dgvEstilistas
            // 
            dgvEstilistas.BackgroundColor = Color.LavenderBlush;
            dgvEstilistas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEstilistas.Location = new Point(38, 65);
            dgvEstilistas.Name = "dgvEstilistas";
            dgvEstilistas.ReadOnly = true;
            dgvEstilistas.RowHeadersWidth = 51;
            dgvEstilistas.Size = new Size(716, 220);
            dgvEstilistas.TabIndex = 4;
            dgvEstilistas.CellClick += dgvEstilistas_CellClick;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(38, 305);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(70, 20);
            lblNombre.TabIndex = 5;
            lblNombre.Text = "Nombre:";
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(38, 338);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(66, 20);
            lblApellido.TabIndex = 6;
            lblApellido.Text = "Apellido:";
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(38, 371);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(72, 20);
            lblTelefono.TabIndex = 7;
            lblTelefono.Text = "Teléfono:";
            // 
            // lblCorreo
            // 
            lblCorreo.AutoSize = true;
            lblCorreo.Location = new Point(400, 305);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(60, 20);
            lblCorreo.TabIndex = 8;
            lblCorreo.Text = "Correo:";
            // 
            // lblCedula
            // 
            lblCedula.AutoSize = true;
            lblCedula.Location = new Point(400, 338);
            lblCedula.Name = "lblCedula";
            lblCedula.Size = new Size(60, 20);
            lblCedula.TabIndex = 9;
            lblCedula.Text = "Cedula:";
            // 
            // lblEspecialidad
            // 
            lblEspecialidad.AutoSize = true;
            lblEspecialidad.Location = new Point(400, 371);
            lblEspecialidad.Name = "lblEspecialidad";
            lblEspecialidad.Size = new Size(97, 20);
            lblEspecialidad.TabIndex = 10;
            lblEspecialidad.Text = "Especialidad:";
            // 
            // txtNombre
            // 
            txtNombre.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombre.Location = new Point(140, 298);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(230, 27);
            txtNombre.TabIndex = 11;
            // 
            // txtApellido
            // 
            txtApellido.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtApellido.Location = new Point(140, 331);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(230, 27);
            txtApellido.TabIndex = 12;
            // 
            // txtTelefono
            // 
            txtTelefono.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTelefono.Location = new Point(140, 364);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(230, 27);
            txtTelefono.TabIndex = 13;
            // 
            // txtCorreo
            // 
            txtCorreo.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCorreo.Location = new Point(500, 298);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(254, 27);
            txtCorreo.TabIndex = 14;
            // 
            // txtCedula
            // 
            txtCedula.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCedula.Location = new Point(500, 331);
            txtCedula.Name = "txtCedula";
            txtCedula.Size = new Size(254, 27);
            txtCedula.TabIndex = 15;
            // 
            // txtEspecialidad
            // 
            txtEspecialidad.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEspecialidad.Location = new Point(500, 364);
            txtEspecialidad.Name = "txtEspecialidad";
            txtEspecialidad.Size = new Size(254, 27);
            txtEspecialidad.TabIndex = 16;
            // 
            // btnEditar
            // 
            btnEditar.BackColor = Color.DeepPink;
            btnEditar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEditar.ForeColor = Color.White;
            btnEditar.Location = new Point(38, 405);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(137, 40);
            btnEditar.TabIndex = 17;
            btnEditar.Text = "✏️ Editar";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.DeepPink;
            btnEliminar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(185, 405);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(137, 40);
            btnEliminar.TabIndex = 18;
            btnEliminar.Text = "🗑️ Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // frmConsultarEstilistas
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(792, 465);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(txtEspecialidad);
            Controls.Add(txtCedula);
            Controls.Add(txtCorreo);
            Controls.Add(txtTelefono);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            Controls.Add(lblEspecialidad);
            Controls.Add(lblCedula);
            Controls.Add(lblCorreo);
            Controls.Add(lblTelefono);
            Controls.Add(lblApellido);
            Controls.Add(lblNombre);
            Controls.Add(dgvEstilistas);
            Controls.Add(btnCerrar);
            Controls.Add(btnBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(lblBuscar);
            Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "frmConsultarEstilistas";
            Text = "Consulta de Estilistas";
            TransparencyKey = Color.FromArgb(255, 224, 192);
            Load += frmConsultarEstilistas_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEstilistas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblBuscar;
        private TextBox txtBuscar;
        private Button btnBuscar;
        private Button btnCerrar;
        private DataGridView dgvEstilistas;
        private Label lblNombre;
        private Label lblApellido;
        private Label lblTelefono;
        private Label lblCorreo;
        private Label lblCedula;
        private Label lblEspecialidad;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtTelefono;
        private TextBox txtCorreo;
        private TextBox txtCedula;
        private TextBox txtEspecialidad;
        private Button btnEditar;
        private Button btnEliminar;
    }
}