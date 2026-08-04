namespace SistemaAgenda.UI
{
    partial class frmMenuEstilista
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenuEstilista));
            btnCancelar = new Button();
            picLogo = new PictureBox();
            btnConsultar = new Button();
            btnRegistrar = new Button();
            lblOpcion = new Label();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.DeepPink;
            btnCancelar.Location = new Point(409, 227);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(96, 38);
            btnCancelar.TabIndex = 23;
            btnCancelar.Text = "X Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // picLogo
            // 
            picLogo.BackColor = Color.Transparent;
            picLogo.Image = (Image)resources.GetObject("picLogo.Image");
            picLogo.Location = new Point(365, 14);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(192, 166);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 22;
            picLogo.TabStop = false;
            // 
            // btnConsultar
            // 
            btnConsultar.BackColor = Color.DeepPink;
            btnConsultar.Location = new Point(173, 135);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(153, 45);
            btnConsultar.TabIndex = 21;
            btnConsultar.Text = "\U0001fa77Consultar cliente";
            btnConsultar.UseVisualStyleBackColor = false;
            // 
            // btnRegistrar
            // 
            btnRegistrar.BackColor = Color.DeepPink;
            btnRegistrar.Location = new Point(21, 135);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(152, 45);
            btnRegistrar.TabIndex = 20;
            btnRegistrar.Text = "\U0001fa77 Registrar cliente";
            btnRegistrar.UseVisualStyleBackColor = false;
            // 
            // lblOpcion
            // 
            lblOpcion.AutoSize = true;
            lblOpcion.BackColor = SystemColors.Control;
            lblOpcion.Font = new Font("Segoe UI", 14F);
            lblOpcion.ForeColor = Color.Black;
            lblOpcion.Location = new Point(37, 34);
            lblOpcion.Name = "lblOpcion";
            lblOpcion.Size = new Size(255, 32);
            lblOpcion.TabIndex = 19;
            lblOpcion.Text = "Seleccione una opción";
            // 
            // frmMenuEstilista
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(662, 381);
            Controls.Add(btnCancelar);
            Controls.Add(picLogo);
            Controls.Add(btnConsultar);
            Controls.Add(btnRegistrar);
            Controls.Add(lblOpcion);
            Name = "frmMenuEstilista";
            Text = "frmMenuEstilista";
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelar;
        private PictureBox picLogo;
        private Button btnConsultar;
        private Button btnRegistrar;
        private Label lblOpcion;
    }
}