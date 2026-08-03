namespace SistemaAgenda.UI
{
    partial class frmServicios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmServicios));
            lblTipo = new Label();
            lblPrecio = new Label();
            lblDuracion = new Label();
            lblResultado = new Label();
            cmbTipo = new ComboBox();
            txtPrecio = new TextBox();
            txtDuracion = new TextBox();
            btnAgregar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            btnCalcular = new Button();
            dgvServicios = new DataGridView();
            lblElijaS = new Label();
            btnLimpiar = new Button();
            picLogo = new PictureBox();
            txtBuscar = new TextBox();
            lblBuscar = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvServicios).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            // 
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.Location = new Point(40, 109);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(123, 20);
            lblTipo.TabIndex = 0;
            lblTipo.Text = "Tipo de Servicio:";
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Location = new Point(40, 142);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(56, 20);
            lblPrecio.TabIndex = 1;
            lblPrecio.Text = "Precio:";
            // 
            // lblDuracion
            // 
            lblDuracion.AutoSize = true;
            lblDuracion.Location = new Point(40, 175);
            lblDuracion.Name = "lblDuracion";
            lblDuracion.Size = new Size(116, 20);
            lblDuracion.TabIndex = 2;
            lblDuracion.Text = "Duración (min):";
            // 
            // lblResultado
            // 
            lblResultado.AutoSize = true;
            lblResultado.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblResultado.ForeColor = Color.DeepPink;
            lblResultado.Location = new Point(40, 227);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(156, 20);
            lblResultado.TabIndex = 3;
            lblResultado.Text = "Calculo del servicio:";
            // 
            // cmbTipo
            // 
            cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipo.FormattingEnabled = true;
            cmbTipo.Items.AddRange(new object[] { "Cabello", "Uñas", "Spa" });
            cmbTipo.Location = new Point(179, 101);
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Size = new Size(178, 28);
            cmbTipo.TabIndex = 4;
            // 
            // txtPrecio
            // 
            txtPrecio.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPrecio.Location = new Point(179, 135);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.PlaceholderText = "Ej: 300";
            txtPrecio.Size = new Size(178, 27);
            txtPrecio.TabIndex = 5;
            txtPrecio.KeyPress += txtPrecio_KeyPress;
            // 
            // txtDuracion
            // 
            txtDuracion.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDuracion.Location = new Point(179, 168);
            txtDuracion.Name = "txtDuracion";
            txtDuracion.PlaceholderText = "Ej: 60";
            txtDuracion.Size = new Size(178, 27);
            txtDuracion.TabIndex = 6;
            txtDuracion.KeyPress += txtDuracion_KeyPress;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.DeepPink;
            btnAgregar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAgregar.ForeColor = Color.White;
            btnAgregar.Location = new Point(40, 290);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(164, 43);
            btnAgregar.TabIndex = 7;
            btnAgregar.Text = "➕Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEditar
            // 
            btnEditar.BackColor = Color.DeepPink;
            btnEditar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEditar.ForeColor = Color.White;
            btnEditar.Location = new Point(40, 339);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(164, 43);
            btnEditar.TabIndex = 8;
            btnEditar.Text = "✏️ Editar";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.DeepPink;
            btnEliminar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(226, 339);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(164, 43);
            btnEliminar.TabIndex = 9;
            btnEliminar.Text = "🗑️ Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnCalcular
            // 
            btnCalcular.BackColor = Color.DeepPink;
            btnCalcular.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCalcular.ForeColor = Color.White;
            btnCalcular.Location = new Point(226, 290);
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Size = new Size(164, 43);
            btnCalcular.TabIndex = 10;
            btnCalcular.Text = "💲 Calcular";
            btnCalcular.UseVisualStyleBackColor = false;
            btnCalcular.Click += btnCalcular_Click;
            // 
            // dgvServicios
            // 
            dgvServicios.AllowUserToAddRows = false;
            dgvServicios.BackgroundColor = Color.LavenderBlush;
            dgvServicios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvServicios.Location = new Point(40, 438);
            dgvServicios.Name = "dgvServicios";
            dgvServicios.ReadOnly = true;
            dgvServicios.RowHeadersWidth = 51;
            dgvServicios.Size = new Size(554, 182);
            dgvServicios.TabIndex = 11;
            dgvServicios.CellClick += dgvServicios_CellClick;
            // 
            // txtBuscar
            // 
            txtBuscar.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscar.Location = new Point(155, 403);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Tipo de servicio...";
            txtBuscar.Size = new Size(202, 27);
            txtBuscar.TabIndex = 19;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Location = new Point(40, 406);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(76, 20);
            lblBuscar.TabIndex = 20;
            lblBuscar.Text = "🔍 Buscar:";
            // 
            // lblElijaS
            // 
            lblElijaS.AutoSize = true;
            lblElijaS.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblElijaS.Location = new Point(40, 39);
            lblElijaS.Name = "lblElijaS";
            lblElijaS.Size = new Size(365, 23);
            lblElijaS.TabIndex = 12;
            lblElijaS.Text = "Elija un servicio, precio y duracion del servicio:";
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.DeepPink;
            btnLimpiar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLimpiar.ForeColor = Color.White;
            btnLimpiar.Location = new Point(409, 290);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(164, 43);
            btnLimpiar.TabIndex = 13;
            btnLimpiar.Text = "\U0001f9f9Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // picLogo
            // 
            picLogo.BackColor = Color.Transparent;
            picLogo.Image = (Image)resources.GetObject("picLogo.Image");
            picLogo.Location = new Point(409, 39);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(202, 201);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 18;
            picLogo.TabStop = false;
            // 
            // frmServicios
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(655, 632);
            Controls.Add(lblBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(picLogo);
            Controls.Add(btnLimpiar);
            Controls.Add(lblElijaS);
            Controls.Add(dgvServicios);
            Controls.Add(btnCalcular);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(btnAgregar);
            Controls.Add(txtDuracion);
            Controls.Add(txtPrecio);
            Controls.Add(cmbTipo);
            Controls.Add(lblResultado);
            Controls.Add(lblDuracion);
            Controls.Add(lblPrecio);
            Controls.Add(lblTipo);
            Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Name = "frmServicios";
            Text = "Servicios";
            Load += FrmServicios_Load;
            ((System.ComponentModel.ISupportInitialize)dgvServicios).EndInit();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTipo;
        private Label lblPrecio;
        private Label lblDuracion;
        private Label lblResultado;
        private ComboBox cmbTipo;
        private TextBox txtPrecio;
        private TextBox txtDuracion;
        private Button btnAgregar;
        private Button btnEditar;
        private Button btnEliminar;
        private Button btnCalcular;
        private DataGridView dgvServicios;
        private Label lblElijaS;
        private Button btnLimpiar;
        private PictureBox picLogo;
        private TextBox txtBuscar;
        private Label lblBuscar;
    }
}