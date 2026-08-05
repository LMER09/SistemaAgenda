namespace SistemaAgenda.UI
{
    partial class frmConsultarCitas
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
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            btnBuscar = new Button();
            btnVerTodas = new Button();
            btnCerrar = new Button();
            calCitas = new MonthCalendar();
            dgvCitas = new DataGridView();
            btnCancelar = new Button();
            btnReprogramar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCitas).BeginInit();
            SuspendLayout();
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Location = new Point(38, 25);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(59, 20);
            lblBuscar.TabIndex = 0;
            lblBuscar.Text = "Buscar:";
            // 
            // txtBuscar
            // 
            txtBuscar.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscar.Location = new Point(103, 22);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Cliente, servicio, estilista o estado";
            txtBuscar.Size = new Size(271, 27);
            txtBuscar.TabIndex = 1;
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.DeepPink;
            btnBuscar.ForeColor = Color.White;
            btnBuscar.Location = new Point(394, 12);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(174, 45);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "🔍 Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnVerTodas
            // 
            btnVerTodas.BackColor = Color.Gray;
            btnVerTodas.ForeColor = Color.White;
            btnVerTodas.Location = new Point(600, 12);
            btnVerTodas.Name = "btnVerTodas";
            btnVerTodas.Size = new Size(174, 45);
            btnVerTodas.TabIndex = 3;
            btnVerTodas.Text = "Ver todas";
            btnVerTodas.UseVisualStyleBackColor = false;
            btnVerTodas.Click += btnVerTodas_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.BackColor = Color.DeepPink;
            btnCerrar.ForeColor = Color.White;
            btnCerrar.Location = new Point(804, 13);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(174, 45);
            btnCerrar.TabIndex = 4;
            btnCerrar.Text = "❌ Cerrar";
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // calCitas
            // 
            calCitas.Location = new Point(38, 75);
            calCitas.Name = "calCitas";
            calCitas.TabIndex = 5;
            calCitas.DateChanged += calCitas_DateChanged;
            // 
            // dgvCitas
            // 
            dgvCitas.BackgroundColor = Color.LavenderBlush;
            dgvCitas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCitas.Location = new Point(329, 75);
            dgvCitas.Name = "dgvCitas";
            dgvCitas.ReadOnly = true;
            dgvCitas.RowHeadersWidth = 51;
            dgvCitas.Size = new Size(649, 300);
            dgvCitas.TabIndex = 6;
            dgvCitas.CellFormatting += dgvCitas_CellFormatting;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.DeepPink;
            btnCancelar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(646, 390);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(207, 43);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = "🚫 Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnReprogramar
            // 
            btnReprogramar.BackColor = Color.DeepPink;
            btnReprogramar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReprogramar.ForeColor = Color.White;
            btnReprogramar.Location = new Point(420, 390);
            btnReprogramar.Name = "btnReprogramar";
            btnReprogramar.Size = new Size(207, 43);
            btnReprogramar.TabIndex = 8;
            btnReprogramar.Text = "🔁 Reprogramar / Editar";
            btnReprogramar.UseVisualStyleBackColor = false;
            btnReprogramar.Click += btnReprogramar_Click;
            // 
            // frmConsultarCitas
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(1008, 445);
            Controls.Add(btnReprogramar);
            Controls.Add(btnCancelar);
            Controls.Add(dgvCitas);
            Controls.Add(calCitas);
            Controls.Add(btnCerrar);
            Controls.Add(btnVerTodas);
            Controls.Add(btnBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(lblBuscar);
            Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "frmConsultarCitas";
            Text = "Consulta de Citas";
            Load += frmConsultarCitas_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCitas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private Label lblBuscar;
        private TextBox txtBuscar;
        private Button btnBuscar;
        private Button btnVerTodas;
        private Button btnCerrar;
        private MonthCalendar calCitas;
        private DataGridView dgvCitas;
        private Button btnCancelar;
        private Button btnReprogramar;
    }
}