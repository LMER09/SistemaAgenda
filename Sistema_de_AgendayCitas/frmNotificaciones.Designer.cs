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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lstNotificaciones = new ListView();
            colFecha = new ColumnHeader();
            colMensaje = new ColumnHeader();
            lblTitulo = new Label();
            btnLimpiar = new Button();
            SuspendLayout();
            // 
            // lstNotificaciones
            // 
            lstNotificaciones.Columns.AddRange(new ColumnHeader[] { colFecha, colMensaje });
            lstNotificaciones.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lstNotificaciones.FullRowSelect = true;
            lstNotificaciones.GridLines = true;
            lstNotificaciones.Location = new Point(24, 70);
            lstNotificaciones.Name = "lstNotificaciones";
            lstNotificaciones.Size = new Size(632, 380);
            lstNotificaciones.TabIndex = 0;
            lstNotificaciones.UseCompatibleStateImageBehavior = false;
            lstNotificaciones.View = View.Details;
            // 
            // colFecha
            // 
            colFecha.Text = "Fecha y hora";
            colFecha.Width = 180;
            // 
            // colMensaje
            // 
            colMensaje.Text = "Notificación";
            colMensaje.Width = 430;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.MediumVioletRed;
            lblTitulo.Location = new Point(24, 24);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(300, 32);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "🔔 Historial de notificaciones";
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.DeepPink;
            btnLimpiar.FlatStyle = FlatStyle.Popup;
            btnLimpiar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLimpiar.ForeColor = Color.White;
            btnLimpiar.Location = new Point(24, 460);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(200, 36);
            btnLimpiar.TabIndex = 2;
            btnLimpiar.Text = "🗑 Limpiar historial";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // frmNotificaciones
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(680, 520);
            Controls.Add(btnLimpiar);
            Controls.Add(lblTitulo);
            Controls.Add(lstNotificaciones);
            Name = "frmNotificaciones";
            Text = "Historial de notificaciones";
            StartPosition = FormStartPosition.CenterScreen;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView lstNotificaciones;
        private ColumnHeader colFecha;
        private ColumnHeader colMensaje;
        private Label lblTitulo;
        private Button btnLimpiar;
    }
}