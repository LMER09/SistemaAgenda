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
            lblElijaS = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvServicios).BeginInit();
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
            lblResultado.ForeColor = Color.Crimson;
            lblResultado.Location = new Point(40, 233);
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
            btnAgregar.Location = new Point(40, 288);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(106, 29);
            btnAgregar.TabIndex = 7;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(169, 288);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(106, 29);
            btnEditar.TabIndex = 8;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(311, 288);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(106, 29);
            btnEliminar.TabIndex = 9;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnCalcular
            // 
            btnCalcular.Location = new Point(436, 288);
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
            dgvServicios.Location = new Point(40, 345);
            dgvServicios.Name = "dgvServicios";
            dgvServicios.ReadOnly = true;
            dgvServicios.RowHeadersWidth = 51;
            dgvServicios.Size = new Size(554, 127);
            dgvServicios.TabIndex = 11;
            dgvServicios.CellClick += dgvServicios_CellClick;
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
            // frmServicios
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(679, 497);
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
    }
}