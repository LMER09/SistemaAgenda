namespace SistemaAgenda.UI
{
    partial class frmPrincipal
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
            btnAgendar = new Button();
            btnClientes = new Button();
            btnReportes = new Button();
            btnServicios = new Button();
            btnEstilistas = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnAgendar
            // 
            btnAgendar.BackColor = Color.DeepPink;
            btnAgendar.BackgroundImageLayout = ImageLayout.Center;
            btnAgendar.FlatStyle = FlatStyle.Popup;
            btnAgendar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAgendar.ForeColor = Color.LavenderBlush;
            btnAgendar.Location = new Point(338, 127);
            btnAgendar.Name = "btnAgendar";
            btnAgendar.Size = new Size(106, 29);
            btnAgendar.TabIndex = 1;
            btnAgendar.Text = "Agendar";
            btnAgendar.UseVisualStyleBackColor = false;
            btnAgendar.Click += btnAgenda_Click;
            // 
            // btnClientes
            // 
            btnClientes.BackColor = Color.DeepPink;
            btnClientes.BackgroundImageLayout = ImageLayout.Center;
            btnClientes.FlatStyle = FlatStyle.Popup;
            btnClientes.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClientes.ForeColor = Color.LavenderBlush;
            btnClientes.Location = new Point(338, 242);
            btnClientes.Name = "btnClientes";
            btnClientes.Size = new Size(106, 29);
            btnClientes.TabIndex = 2;
            btnClientes.Text = "Clientes";
            btnClientes.UseVisualStyleBackColor = false;
            btnClientes.Click += btnClientes_Click;
            // 
            // btnReportes
            // 
            btnReportes.BackColor = Color.DeepPink;
            btnReportes.BackgroundImageLayout = ImageLayout.Center;
            btnReportes.FlatStyle = FlatStyle.Popup;
            btnReportes.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReportes.ForeColor = Color.LavenderBlush;
            btnReportes.Location = new Point(338, 360);
            btnReportes.Name = "btnReportes";
            btnReportes.Size = new Size(106, 29);
            btnReportes.TabIndex = 3;
            btnReportes.Text = "Reportes";
            btnReportes.UseVisualStyleBackColor = false;
            btnReportes.Click += btnReportes_Click;
            // 
            // btnServicios
            // 
            btnServicios.BackColor = Color.DeepPink;
            btnServicios.BackgroundImageLayout = ImageLayout.Center;
            btnServicios.FlatStyle = FlatStyle.Popup;
            btnServicios.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnServicios.ForeColor = Color.LavenderBlush;
            btnServicios.Location = new Point(338, 186);
            btnServicios.Name = "btnServicios";
            btnServicios.Size = new Size(106, 29);
            btnServicios.TabIndex = 4;
            btnServicios.Text = "Servicios";
            btnServicios.UseVisualStyleBackColor = false;
            btnServicios.Click += btnServicios_Click;
            // 
            // btnEstilistas
            // 
            btnEstilistas.BackColor = Color.DeepPink;
            btnEstilistas.FlatStyle = FlatStyle.Popup;
            btnEstilistas.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEstilistas.ForeColor = Color.LavenderBlush;
            btnEstilistas.Location = new Point(338, 300);
            btnEstilistas.Name = "btnEstilistas";
            btnEstilistas.Size = new Size(106, 29);
            btnEstilistas.TabIndex = 5;
            btnEstilistas.Text = "Estilistas";
            btnEstilistas.UseVisualStyleBackColor = false;
            btnEstilistas.Click += btnEstilistas_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.MediumVioletRed;
            label1.Location = new Point(312, 51);
            label1.Name = "label1";
            label1.Size = new Size(187, 20);
            label1.TabIndex = 6;
            label1.Text = "Sistema de Agenda y Citas";
            // 
            // frmPrincipal
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(849, 442);
            Controls.Add(label1);
            Controls.Add(btnEstilistas);
            Controls.Add(btnServicios);
            Controls.Add(btnReportes);
            Controls.Add(btnClientes);
            Controls.Add(btnAgendar);
            Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = Color.LavenderBlush;
            Name = "frmPrincipal";
            Text = "Principal";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion


        private Button btnAgendar;
        private Button btnClientes;
        private Button btnReportes;
        private Button btnServicios;
        private Button btnEstilistas;
        private Label label1;
    }
}