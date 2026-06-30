using Sistema_de_AgendayCitas;
using System;
using System.Windows.Forms;

namespace SistemaAgenda.UI
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }
        private void btnAgenda_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmAgenda());
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmClientes());
        }

        private void btnServicios_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmServicios());
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmReportes());
        }
        private void AbrirFormulario(Form formulario)
        {
            formulario.Show();
        }
    }
}
