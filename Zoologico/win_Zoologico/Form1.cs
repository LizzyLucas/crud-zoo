using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dll_Zoologico;

namespace win_Zoologico
{
    public partial class frmEspecies : Form
    {
        public frmEspecies()
        {
            InitializeComponent();
        }

        private void frmEspecies_Load(object sender, EventArgs e)
        {
            Especie es = new Especie();
            dgvEspecies.DataSource = es.consultar();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Especie es = new Especie();
            dgvEspecies.DataSource = es.consultar();
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            Especie es = new Especie();
            es.Nombre = txtNombre.Text;
            if (es.agregar())
            {
                MessageBox.Show("Especie añadida", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvEspecies.DataSource = es.consultar();

            }
            else
                MessageBox.Show("La especie no fue añadida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Especie es = new Especie();
            es.Id = byte.Parse(txtId.Text);

            if(MessageBox.Show("Are you sure?", "CONFIRMAMCIÓN", MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                if (es.Eliminar())
                {
                    MessageBox.Show("Especie eliminada", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvEspecies.DataSource = es.consultar();

                }
                else
                    MessageBox.Show("La especie no fue eliminada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Especie es = new Especie();
            es.Id = byte.Parse(txtId.Text);

          dgvEspecies.DataSource = es.buscarxID();

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Especie es = new Especie();
            es.Nombre = txtNombre.Text;
            es.Id = byte.Parse(txtId.Text);
            if (es.actualizar())
            {
                MessageBox.Show("Especie actualizada", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvEspecies.DataSource = es.consultar();

            }
            else
                MessageBox.Show("La especie no fue aactualizada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
