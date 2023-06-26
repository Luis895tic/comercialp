using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;




namespace Sistema_Paquime
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
         
        private void Button1_Click(object sender, EventArgs e)

        {
            try
            {
               MySqlConnection conexion = new MySqlConnection("server= localhost; database= comercial_paquime; uid= root; password=;");
                conexion.Open();
                MessageBox.Show("conexion exitosa");
                Login lg = new Login();
                lg.Show();
                this.Hide();
            }
            catch (Exception error)
            {
                MessageBox.Show("ocurrio un error" + error.Message);
            }

        }
    }
}
