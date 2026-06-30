namespace SistemaAgenda.UI
{
    partial class frmAgenda
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cmbClientes = new ComboBox();
            cmbServicios = new ComboBox();
            cmbEstilistas = new ComboBox();
            lblClientes = new Label();
            lblServicios = new Label();
            lblEstilistas = new Label();
            dtpFecha = new DateTimePicker();
            dtpHora = new DateTimePicker();
            dgvCitas = new DataGridView();
            btnAgendar = new Button();
            btnCancelar = new Button();
            btnReprogramar = new Button();
            btnActualizarLista = new Button();
            lblFecha = new Label();
            lblHora = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvCitas).BeginInit();
            SuspendLayout();
            // 
            // cmbClientes
            // 
            cmbClientes.FormattingEnabled = true;
            cmbClientes.Location = new Point(53, 94);
            cmbClientes.Name = "cmbClientes";
            cmbClientes.Size = new Size(151, 28);
            cmbClientes.TabIndex = 0;
            // 
            // cmbServicios
            // 
            cmbServicios.FormattingEnabled = true;
            cmbServicios.Location = new Point(256, 94);
            cmbServicios.Name = "cmbServicios";
            cmbServicios.Size = new Size(151, 28);
            cmbServicios.TabIndex = 1;
            // 
            // cmbEstilistas
            // 
            cmbEstilistas.FormattingEnabled = true;
            cmbEstilistas.Location = new Point(471, 94);
            cmbEstilistas.Name = "cmbEstilistas";
            cmbEstilistas.Size = new Size(151, 28);
            cmbEstilistas.TabIndex = 2;
            // 
            // lblClientes
            // 
            lblClientes.AutoSize = true;
            lblClientes.Location = new Point(51, 61);
            lblClientes.Name = "lblClientes";
            lblClientes.Size = new Size(61, 20);
            lblClientes.TabIndex = 3;
            lblClientes.Text = "Clientes";
            // 
            // lblServicios
            // 
            lblServicios.AutoSize = true;
            lblServicios.Location = new Point(256, 61);
            lblServicios.Name = "lblServicios";
            lblServicios.Size = new Size(67, 20);
            lblServicios.TabIndex = 4;
            lblServicios.Text = "Servicios";
            // 
            // lblEstilistas
            // 
            lblEstilistas.AutoSize = true;
            lblEstilistas.Location = new Point(471, 61);
            lblEstilistas.Name = "lblEstilistas";
            lblEstilistas.Size = new Size(65, 20);
            lblEstilistas.TabIndex = 5;
            lblEstilistas.Text = "Estilistas";
            // 
            // dtpFecha
            // 
            dtpFecha.Location = new Point(53, 178);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(250, 27);
            dtpFecha.TabIndex = 6;
            // 
            // dtpHora
            // 
            dtpHora.Format = DateTimePickerFormat.Time;
            dtpHora.Location = new Point(335, 178);
            dtpHora.Name = "dtpHora";
            dtpHora.ShowUpDown = true;
            dtpHora.Size = new Size(287, 27);
            dtpHora.TabIndex = 7;
            // 
            // dgvCitas
            // 
            dgvCitas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCitas.Location = new Point(51, 305);
            dgvCitas.Name = "dgvCitas";
            dgvCitas.RowHeadersWidth = 51;
            dgvCitas.Size = new Size(571, 95);
            dgvCitas.TabIndex = 8;
            // 
            // btnAgendar
            // 
            btnAgendar.Location = new Point(53, 248);
            btnAgendar.Name = "btnAgendar";
            btnAgendar.Size = new Size(94, 29);
            btnAgendar.TabIndex = 9;
            btnAgendar.Text = "Agendar";
            btnAgendar.UseVisualStyleBackColor = true;
            btnAgendar.Click += btnAgendar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(190, 248);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 29);
            btnCancelar.TabIndex = 10;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnReprogramar
            // 
            btnReprogramar.Location = new Point(335, 248);
            btnReprogramar.Name = "btnReprogramar";
            btnReprogramar.Size = new Size(120, 29);
            btnReprogramar.TabIndex = 11;
            btnReprogramar.Text = "Reprogramar";
            btnReprogramar.UseVisualStyleBackColor = true;
            btnReprogramar.Click += btnReprogramar_Click;
            // 
            // btnActualizarLista
            // 
            btnActualizarLista.Location = new Point(497, 248);
            btnActualizarLista.Name = "btnActualizarLista";
            btnActualizarLista.Size = new Size(125, 29);
            btnActualizarLista.TabIndex = 12;
            btnActualizarLista.Text = "Actualizar lista";
            btnActualizarLista.UseVisualStyleBackColor = true;
            btnActualizarLista.Click += btnActualizarLista_Click;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(53, 144);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(50, 20);
            lblFecha.TabIndex = 13;
            lblFecha.Text = "Fecha:";
            // 
            // lblHora
            // 
            lblHora.AutoSize = true;
            lblHora.Location = new Point(335, 144);
            lblHora.Name = "lblHora";
            lblHora.Size = new Size(45, 20);
            lblHora.TabIndex = 14;
            lblHora.Text = "Hora:";
            // 
            // frmAgenda
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblHora);
            Controls.Add(lblFecha);
            Controls.Add(btnActualizarLista);
            Controls.Add(btnReprogramar);
            Controls.Add(btnCancelar);
            Controls.Add(btnAgendar);
            Controls.Add(dgvCitas);
            Controls.Add(dtpHora);
            Controls.Add(dtpFecha);
            Controls.Add(lblEstilistas);
            Controls.Add(lblServicios);
            Controls.Add(lblClientes);
            Controls.Add(cmbEstilistas);
            Controls.Add(cmbServicios);
            Controls.Add(cmbClientes);
            Name = "frmAgenda";
            Text = "Agenda";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCitas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbClientes;
        private ComboBox cmbServicios;
        private ComboBox cmbEstilistas;
        private Label lblClientes;
        private Label lblServicios;
        private Label lblEstilistas;
        private DateTimePicker dtpFecha;
        private DateTimePicker dtpHora;
        private DataGridView dgvCitas;
        private Button btnAgendar;
        private Button btnCancelar;
        private Button btnReprogramar;
        private Button btnActualizarLista;
        private Label lblFecha;
        private Label lblHora;
    }
}
