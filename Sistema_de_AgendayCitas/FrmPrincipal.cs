using Sistema_de_AgendayCitas;
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
        private void btnAgenda_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmAgenda());
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmClientes());
        }

        private void btnServicios_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmServicios());
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmReportes());
        }
        private void btnEstilistas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmEstilistas());
        }
        private void AbrirFormulario(Form formulario)
        {
            formulario.Show();
        }

    }
}
