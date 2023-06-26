using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Paquime
{
    public partial class Reportes : Form
    {
        public Reportes()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Form prod = new Productos();
            prod.Show();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            Form prov = new Proveedores();
            prov.Show();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Form comp = new Compras();
            comp.Show();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            Form repprod = new reportproductos();
            repprod.Show();
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            Form rprov = new reporteproveedores();
           rprov.Show();
        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {
            Form rcomp = new reportescompras();
            rcomp.Show();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            reportventas rvns = new reportventas();
            rvns.Show();
        }
    }
}
