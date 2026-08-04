using System;
using System.Windows.Forms;

namespace SistemaAgenda.UI
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        // Método para abrir cualquier formulario
        private void AbrirFormulario(Form formulario)
        {
            formulario.ShowDialog();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            this.Hide();
            using (FrmLogin login = new FrmLogin())
            {
                if (login.ShowDialog() == DialogResult.OK)
                    this.Show();
                else
                    Application.Exit();
            }
        }

        // ======================================
        // ENTRADA
        // ======================================

        private void btnAgenda_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmAgenda());
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmRegistrarClientes());
        }

        private void btnServicios_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmServicios());
        }

        private void btnEstilistas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmEstilistas());
        }

        // ======================================
        // CONSULTA
        // ======================================

        private void verClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmConsultarClientes());
        }

        private void verEstilistaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Módulo de consulta de estilistas en desarrollo.",
                "Sistema",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void verServicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Módulo de consulta de servicios en desarrollo.",
                "Sistema",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Módulo de consulta de citas en desarrollo.",
                "Sistema",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void reportesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmReportes());
        }

        // ======================================
        // SISTEMA
        // ======================================

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
     "Sistema de Agenda y Citas\n\n" +
     "Versión 1.0\n\n" +
     "Desarrollado por:\n" +
     "• Novaly Pujols\n" +
     "• Luzmairy Espiritusanto\n" +
     "• Juan Manuel Contreras\n" +
     "• Mercy Báez 4\n\n" +
     "• Sebastian vargas\n\n" +
     "Proyecto Final\n" +
     "Ingeniería en Software\n\n" +
     "Universidad Central del Este (UCE)",
     "Acerca del sistema",
     MessageBoxButtons.OK,
     MessageBoxIcon.Information);
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show(
                "¿Desea salir del sistema?",
                "Salir",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}