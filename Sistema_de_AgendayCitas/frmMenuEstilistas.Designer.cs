namespace SistemaAgenda.UI
{
    partial class frmMenuClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenuClientes));
            lblOpcion = new Label();
            btnRegistrar = new Button();
            btnConsultar = new Button();
            picLogo = new PictureBox();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            // 
            // lblOpcion
            // 
            lblOpcion.AutoSize = true;
            lblOpcion.BackColor = SystemColors.Control;
            lblOpcion.Font = new Font("Segoe UI", 14F);
            lblOpcion.ForeColor = Color.Black;
            lblOpcion.Location = new Point(28, 39);
            lblOpcion.Name = "lblOpcion";
            lblOpcion.Size = new Size(255, 32);
            lblOpcion.TabIndex = 0;
            lblOpcion.Text = "Seleccione una opción";
            // 
            // btnRegistrar
            // 
            btnRegistrar.BackColor = Color.DeepPink;
            btnRegistrar.Location = new Point(12, 140);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(152, 45);
            btnRegistrar.TabIndex = 1;
            btnRegistrar.Text = "\U0001fa77 Registrar cliente";
            btnRegistrar.UseVisualStyleBackColor = false;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // btnConsultar
            // 
            btnConsultar.BackColor = Color.DeepPink;
            btnConsultar.Location = new Point(164, 140);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(153, 45);
            btnConsultar.TabIndex = 2;
            btnConsultar.Text = "\U0001fa77Consultar cliente";
            btnConsultar.UseVisualStyleBackColor = false;
            btnConsultar.Click += btnConsultar_Click;
            // 
            // picLogo
            // 
            picLogo.BackColor = Color.Transparent;
            picLogo.Image = (Image)resources.GetObject("picLogo.Image");
            picLogo.Location = new Point(323, 39);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(192, 166);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 17;
            picLogo.TabStop = false;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.DeepPink;
            btnCancelar.Location = new Point(365, 226);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(96, 38);
            btnCancelar.TabIndex = 18;
            btnCancelar.Text = "X Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // frmMenuClientes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(533, 285);
            Controls.Add(btnCancelar);
            Controls.Add(picLogo);
            Controls.Add(btnConsultar);
            Controls.Add(btnRegistrar);
            Controls.Add(lblOpcion);
            ForeColor = Color.White;
            Name = "frmMenuClientes";
            Text = "Clientes";
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblOpcion;
        private Button btnRegistrar;
        private Button btnConsultar;
        private PictureBox picLogo;
        private Button btnCancelar;
    }
}