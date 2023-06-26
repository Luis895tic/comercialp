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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        string conexion = "server=localhost; database=comercial_paquime; uid=root; password=;";
            
        private void Btniniciar_Click(object sender, EventArgs e)
        {
            string query = "select * FROM login WHERE usuario= '" + txtusuario.Text + "' AND password= '" + txtcontrasena.Text + "'";
            MySqlConnection databaseconection = new MySqlConnection(conexion);
            MySqlCommand comanddatabase = new MySqlCommand(query, databaseconection);
            comanddatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                databaseconection.Open();
                reader = comanddatabase.ExecuteReader();

                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        MessageBox.Show("Accediendo");
                        ventas ven = new ventas();
                        ven.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("error, intenta de nuevo");
                }
                databaseconection.Close();
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

    }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void Btncancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
