namespace SistemaAgenda.UI
{
    partial class frmNotificaciones
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
            lblTitulo = new Label();
            dgvNotificaciones = new DataGridView();
            lblVacio = new Label();
            btnActualizar = new Button();
            btnCerrar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvNotificaciones).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.MediumVioletRed;
            lblTitulo.Location = new Point(30, 25);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(260, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "🔔 Historial de notificaciones";
            // 
            // dgvNotificaciones
            // 
            dgvNotificaciones.BackgroundColor = Color.LavenderBlush;
            dgvNotificaciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNotificaciones.Location = new Point(30, 70);
            dgvNotificaciones.Name = "dgvNotificaciones";
            dgvNotificaciones.ReadOnly = true;
            dgvNotificaciones.RowHeadersWidth = 51;
            dgvNotificaciones.Size = new Size(600, 320);
            dgvNotificaciones.TabIndex = 1;
            // 
            // lblVacio
            // 
            lblVacio.AutoSize = true;
            lblVacio.Font = new Font("Segoe UI", 9.5F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblVacio.ForeColor = Color.Gray;
            lblVacio.Location = new Point(30, 100);
            lblVacio.Name = "lblVacio";
            lblVacio.Size = new Size(320, 20);
            lblVacio.TabIndex = 2;
            lblVacio.Text = "No hay notificaciones registradas todavía.";
            lblVacio.Visible = false;
            // 
            // btnActualizar
            // 
            btnActualizar.BackColor = Color.DeepPink;
            btnActualizar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnActualizar.ForeColor = Color.White;
            btnActualizar.Location = new Point(30, 400);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(150, 40);
            btnActualizar.TabIndex = 3;
            btnActualizar.Text = "🔄 Actualizar";
            btnActualizar.UseVisualStyleBackColor = false;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.BackColor = Color.Gray;
            btnCerrar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCerrar.ForeColor = Color.White;
            btnCerrar.Location = new Point(480, 400);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(150, 40);
            btnCerrar.TabIndex = 4;
            btnCerrar.Text = "❌ Cerrar";
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // frmNotificaciones
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(660, 465);
            Controls.Add(btnCerrar);
            Controls.Add(btnActualizar);
            Controls.Add(lblVacio);
            Controls.Add(dgvNotificaciones);
            Controls.Add(lblTitulo);
            Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "frmNotificaciones";
            Text = "Notificaciones";
            Load += frmNotificaciones_Load;
            ((System.ComponentModel.ISupportInitialize)dgvNotificaciones).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTitulo;
        private DataGridView dgvNotificaciones;
        private Label lblVacio;
        private Button btnActualizar;
        private Button btnCerrar;
    }
}