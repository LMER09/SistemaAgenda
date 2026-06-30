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
            btnAgenda = new Button();
            btnClientes = new Button();
            btnReportes = new Button();
            btnServicios = new Button();
            btnEstilistas = new Button();
            SuspendLayout();
            // 
            // btnAgenda
            // 
            btnAgenda.Location = new Point(73, 97);
            btnAgenda.Name = "btnAgenda";
            btnAgenda.Size = new Size(94, 29);
            btnAgenda.TabIndex = 1;
            btnAgenda.Text = "Agenda";
            btnAgenda.UseVisualStyleBackColor = true;
            btnAgenda.Click += btnAgenda_Click;
            // 
            // btnClientes
            // 
            btnClientes.Location = new Point(73, 167);
            btnClientes.Name = "btnClientes";
            btnClientes.Size = new Size(94, 29);
            btnClientes.TabIndex = 2;
            btnClientes.Text = "Clientes";
            btnClientes.UseVisualStyleBackColor = true;
            btnClientes.Click += btnClientes_Click;
            // 
            // btnReportes
            // 
            btnReportes.Location = new Point(273, 167);
            btnReportes.Name = "btnReportes";
            btnReportes.Size = new Size(94, 29);
            btnReportes.TabIndex = 3;
            btnReportes.Text = "Reportes";
            btnReportes.UseVisualStyleBackColor = true;
            btnReportes.Click += btnReportes_Click;
            // 
            // btnServicios
            // 
            btnServicios.Location = new Point(273, 97);
            btnServicios.Name = "btnServicios";
            btnServicios.Size = new Size(94, 29);
            btnServicios.TabIndex = 4;
            btnServicios.Text = "Servicios";
            btnServicios.UseVisualStyleBackColor = true;
            btnServicios.Click += btnServicios_Click;
            // 
            // btnEstilistas
            // 
            btnEstilistas.Location = new Point(73, 240);
            btnEstilistas.Name = "btnEstilistas";
            btnEstilistas.Size = new Size(94, 29);
            btnEstilistas.TabIndex = 5;
            btnEstilistas.Text = "Estilistas";
            btnEstilistas.UseVisualStyleBackColor = true;
            btnEstilistas.Click += btnEstilistas_Click;
            // 
            // frmPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(681, 334);
            Controls.Add(btnEstilistas);
            Controls.Add(btnServicios);
            Controls.Add(btnReportes);
            Controls.Add(btnClientes);
            Controls.Add(btnAgenda);
            Name = "frmPrincipal";
            Text = "Principal";
            ResumeLayout(false);
        }

        #endregion


        private Button btnAgenda;
        private Button btnClientes;
        private Button btnReportes;
        private Button btnServicios;
        private Button btnEstilistas;
    }
}