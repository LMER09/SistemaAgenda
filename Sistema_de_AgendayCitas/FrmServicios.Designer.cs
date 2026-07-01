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
            ((System.ComponentModel.ISupportInitialize)dgvServicios).BeginInit();
            SuspendLayout();
            // 
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.Location = new Point(71, 114);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(123, 20);
            lblTipo.TabIndex = 0;
            lblTipo.Text = "Tipo de Servicio:";
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Location = new Point(71, 154);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(56, 20);
            lblPrecio.TabIndex = 1;
            lblPrecio.Text = "Precio:";
            txtPrecio.KeyPress += txtPrecio_KeyPress;
            // 
            // lblDuracion
            // 
            lblDuracion.AutoSize = true;
            lblDuracion.Location = new Point(71, 190);
            lblDuracion.Name = "lblDuracion";
            lblDuracion.Size = new Size(116, 20);
            lblDuracion.TabIndex = 2;
            lblDuracion.Text = "Duración (min):";
            txtDuracion.KeyPress += txtDuracion_KeyPress;
            // 
            // lblResultado
            // 
            lblResultado.AutoSize = true;
            lblResultado.Location = new Point(412, 114);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(23, 20);
            lblResultado.TabIndex = 3;
            lblResultado.Text = "\"\"";
            // 
            // cmbTipo
            // 
            cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipo.FormattingEnabled = true;
            cmbTipo.Items.AddRange(new object[] { "Cabello", "Uñas", "Spa" });
            cmbTipo.Location = new Point(216, 106);
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Size = new Size(178, 28);
            cmbTipo.TabIndex = 4;
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(216, 147);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.PlaceholderText = "Ej: 300";
            txtPrecio.Size = new Size(140, 27);
            txtPrecio.TabIndex = 5;
            // 
            // txtDuracion
            // 
            txtDuracion.Location = new Point(216, 183);
            txtDuracion.Name = "txtDuracion";
            txtDuracion.PlaceholderText = "Ej: 60";
            txtDuracion.Size = new Size(140, 27);
            txtDuracion.TabIndex = 6;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(71, 244);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(106, 29);
            btnAgregar.TabIndex = 7;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(251, 244);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(106, 29);
            btnEditar.TabIndex = 8;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(412, 244);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(106, 29);
            btnEliminar.TabIndex = 9;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnCalcular
            // 
            btnCalcular.Location = new Point(583, 244);
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Size = new Size(112, 29);
            btnCalcular.TabIndex = 10;
            btnCalcular.Text = "Calcular precio/duracion";
            btnCalcular.UseVisualStyleBackColor = true;
            btnCalcular.Click += btnCalcular_Click;
            // 
            // dgvServicios
            // 
            dgvServicios.AllowUserToAddRows = false;
            dgvServicios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvServicios.Location = new Point(71, 292);
            dgvServicios.Name = "dgvServicios";
            dgvServicios.ReadOnly = true;
            dgvServicios.RowHeadersWidth = 51;
            dgvServicios.Size = new Size(624, 127);
            dgvServicios.TabIndex = 11;
            dgvServicios.CellClick += dgvServicios_CellClick;
            // 
            // frmServicios
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(763, 450);
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
    }
}