namespace SistemaAgenda.UI
{
    partial class frmConsultarClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultarClientes));
            dgvClientes = new DataGridView();
            picLogo = new PictureBox();
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            btnCerrar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            // 
            // dgvClientes
            // 
            dgvClientes.BackgroundColor = Color.LavenderBlush;
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Location = new Point(38, 226);
            dgvClientes.Name = "dgvClientes";
            dgvClientes.RowHeadersWidth = 51;
            dgvClientes.Size = new Size(667, 284);
            dgvClientes.TabIndex = 11;
            dgvClientes.CellContentClick += dgvClientes_CellContentClick;
            // 
            // picLogo
            // 
            picLogo.BackColor = Color.Transparent;
            picLogo.Image = (Image)resources.GetObject("picLogo.Image");
            picLogo.Location = new Point(511, 12);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(209, 176);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 17;
            picLogo.TabStop = false;
            picLogo.Click += picLogo_Click;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Location = new Point(85, 63);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(54, 20);
            lblBuscar.TabIndex = 18;
            lblBuscar.Text = "Buscar";
            lblBuscar.Click += lblBuscar_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(156, 59);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(177, 27);
            txtBuscar.TabIndex = 19;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // btnCerrar
            // 
            btnCerrar.BackColor = Color.DeepPink;
            btnCerrar.FlatStyle = FlatStyle.Popup;
            btnCerrar.Location = new Point(360, 59);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(94, 29);
            btnCerrar.TabIndex = 20;
            btnCerrar.Text = "❌ Cerrar";
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click_1;
            // 
            // frmConsultarClientes
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(742, 523);
            Controls.Add(btnCerrar);
            Controls.Add(txtBuscar);
            Controls.Add(lblBuscar);
            Controls.Add(picLogo);
            Controls.Add(dgvClientes);
            Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "frmConsultarClientes";
            Text = "Clientes";
            TransparencyKey = Color.FromArgb(255, 224, 192);
            Load += frmConsultarClientes_Load;
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dgvClientes;
        private PictureBox picLogo;
        private Label lblBuscar;
        private TextBox txtBuscar;
        private Button btnCerrar;
    }
}