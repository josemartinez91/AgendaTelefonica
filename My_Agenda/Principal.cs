using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_Agenda
{
    public partial class Principal : Form
    {

        private int id;
        Agenda age = new Agenda();
        DataTable dt;
        public Principal()
        {
            InitializeComponent();
            restablecerControles();
            consultar();
            dgvAgenda.Columns["id"].Visible = false;
        }

        private void consultar()
        {
            dgvAgenda.DataSource = dt = age.consultar();
        }
        private void obtenerId()
        {
            id = Convert.ToInt32(dgvAgenda.CurrentRow.Cells["id"].Value);
        }
        private void obtenerDatos()
        {
            obtenerId();
            TxtNombre.Text = dgvAgenda.CurrentRow.Cells["nombre"].Value.ToString();
            TxtTelefono.Text = dgvAgenda.CurrentRow.Cells["telefono"].Value.ToString();
        }
        private void restablecerControles()
        {
            this.TxtNombre.Clear();
            this.TxtTelefono.Clear();
            this.TxtFiltrar.Clear();
            this.BtnEliminar.Enabled = false;
            this.BtnModificar.Enabled = false;
        }
        private void Principal_Load(object sender, EventArgs e)
        {

        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            bool rs = age.insertar(TxtNombre.Text, TxtTelefono.Text);
            if (rs)
            {
                MessageBox.Show("Registro insertado correctamente");
            }
            restablecerControles();
            consultar();
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            bool rs = age.actualizar(id, TxtNombre.Text, TxtTelefono.Text);
            if (rs)
            {
                MessageBox.Show("Registro actualizado correctamente");
                consultar();
            }
            restablecerControles();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult r =
                MessageBox.Show("Eliminar", "Esta seguro que desea Eliminar este registro?", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

            if(r== DialogResult.OK)
            {
                bool rs = age.eliminar(id);
                if (rs)
                {
                    MessageBox.Show("Registro eliminado correctamente");
                    consultar();
                }
                restablecerControles();
            }
        }

        private void TxtFiltrar_TextChanged(object sender, EventArgs e)
        {
            dt.DefaultView.RowFilter = $"Nombre LIKE'%{TxtFiltrar.Text}'";
        }

        private void dgvAgenda_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            restablecerControles();
            obtenerId();
            this.BtnEliminar.Enabled = true;
        }

        private void dgvAgenda_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            obtenerDatos();
            this.BtnEliminar.Enabled = false;
            this.BtnModificar.Enabled = true;
        }
    }
}
