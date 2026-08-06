using Microsoft.Data.SqlClient;
using SistemaAgenda.Datos;
using SistemaAgenda.Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaAgenda.UI
{
    public partial class FrmLogin : Form
    {
        private readonly UsuariosBLL UsuariosBLL = new UsuariosBLL();
        public FrmLogin()
        {
            InitializeComponent();
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            lblAdvertencia.Visible = false;

            string usuario = txtUsuario.Text.Trim();
            string contrasena = txtContra.Text;

            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contrasena))
            {
                MostrarError("Debe ingresar usuario y contraseña.");
                return;
            }

            try
            {
                button1.Enabled = false; // evita doble-click mientras se valida contra la BD

                bool credencialesValidas = await UsuariosBLL.ValidarCredencialesAsync(usuario, contrasena);

                if (credencialesValidas)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MostrarError("Usuario o contraseña incorrectos.");
                }
            }
            catch (Exception ex)
            {
                MostrarError("Error al validar: " + ex.Message);
            }
            finally
            {
                button1.Enabled = true;
            }
        }

        private void MostrarError(string mensaje)
        {
            lblAdvertencia.Text = mensaje;
            lblAdvertencia.Visible = true;
            txtContra.Clear();
            txtContra.Focus();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void lblUsuario_Click(object sender, EventArgs e)
        {

        }

        private void lblContra_Click(object sender, EventArgs e)
        {

        }

        private void txtContra_TextChanged(object sender, EventArgs e)
        {

        }

        private void pnlHeader_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}