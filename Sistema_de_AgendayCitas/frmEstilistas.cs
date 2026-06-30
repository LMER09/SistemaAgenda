using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using SistemaAgenda.Negocios;
using SistemaAgenda.Datos;

namespace SistemaAgenda.UI
{
    public partial class frmEstilistas : Form
    {
        private EstilistaBLL estilistaBLL = new EstilistaBLL();

        public frmEstilistas()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtEspecialidad.Clear();
            txtNombre.Focus();
        }

        private void CargarEstilistas()
        {
            dgvEstilistas.DataSource = null;
            dgvEstilistas.DataSource = estilistaBLL.ObtenerTodos();
        }

        private void FrmEstilistas_Load(object sender, EventArgs e)
        {
            CargarEstilistas();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Estilista estilista = new Estilista();

            estilista.Nombre = txtNombre.Text;
            estilista.Apellido = txtApellido.Text;
            estilista.Telefono = txtTelefono.Text;
            estilista.Correo = txtCorreo.Text;
            estilista.Especialidad = txtEspecialidad.Text;

            MessageBox.Show(estilistaBLL.Registrar(estilista));

            CargarEstilistas();
            Limpiar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvEstilistas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un estilista.");
                return;
            }

            Estilista estilista = new Estilista();
            estilista.Id = Convert.ToInt32(dgvEstilistas.CurrentRow.Cells["Id"].Value);
            estilista.Nombre = txtNombre.Text;
            estilista.Apellido = txtApellido.Text;
            estilista.Telefono = txtTelefono.Text;
            estilista.Correo = txtCorreo.Text;
            estilista.Especialidad = txtEspecialidad.Text;

            MessageBox.Show(estilistaBLL.Actualizar(estilista));

            CargarEstilistas();
            Limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvEstilistas.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvEstilistas.CurrentRow.Cells["Id"].Value);

                MessageBox.Show(estilistaBLL.Eliminar(id));

                CargarEstilistas();
                Limpiar();
            }
            else
            {
                MessageBox.Show("Seleccione un estilista.");
            }
        }

        private void dgvEstilistas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtNombre.Text = dgvEstilistas.CurrentRow.Cells["Nombre"].Value.ToString();
                txtApellido.Text = dgvEstilistas.CurrentRow.Cells["Apellido"].Value.ToString();
                txtTelefono.Text = dgvEstilistas.CurrentRow.Cells["Telefono"].Value.ToString();
                txtCorreo.Text = dgvEstilistas.CurrentRow.Cells["Correo"].Value.ToString();
                txtEspecialidad.Text = dgvEstilistas.CurrentRow.Cells["Especialidad"].Value.ToString();
            }
        }

        
    }
}
