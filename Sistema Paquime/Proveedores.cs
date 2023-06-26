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
    public partial class Proveedores : Form 
    {
        public Proveedores()
        {
            InitializeComponent();
            cargarTabla("");
        }
        public static MySqlConnection conexion()
        {
            string servidor = "localhost";
            string bd = "comercial_paquime";
            string usuario = "root";
            string password = "";

            string cadenaconexion = "database=" + bd + "; data source=" + servidor + "; user id=" + usuario + "; password=" + password + "";

            try
            {
                MySqlConnection conexionbd = new MySqlConnection(cadenaconexion);
                return conexionbd;
            }

            catch (MySqlException ex)
            {
                Console.WriteLine("error:" + ex.Message);
                return null;
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Reportes mn = new Reportes();
            mn.Show();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            Reportes mn = new Reportes();
            mn.Show();
        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {
            Form prod = new Productos();
            prod.Show();
        }

        private void PictureBox5_Click(object sender, EventArgs e)
        {
            Form comp = new Compras();
            comp.Show();
        }

        private void PictureBox6_Click(object sender, EventArgs e)
        {
            ventas vns = new ventas();
            vns.Show();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void cargarTabla(string dato)
        {
            List<provedores1> lista = new List<provedores1>();

            ctrlproveedores ctrlprovedores = new ctrlproveedores();
            dataGridView1.DataSource = ctrlprovedores.consulta(dato);
        }

        private void Btnagregar_Click(object sender, EventArgs e)
        {
            string proveedores = txtprovedores.Text;
            string nombre = txtnombre.Text;
            string direccion = txtdireccion.Text;
            string telefono = txttelefono.Text;
            string codigop = txtcp.Text;
            string ciudad = txtciudad.Text;
            string email = txtmail.Text;
            string rfc = txtrfc.Text;


            string sql = "INSERT INTO proveedores (nombre,direccion, telefono, codigopostal, ciudad, Email, RFC) values ( '" + nombre + "', '" + direccion + "', '" + telefono + "', '" + codigop + "',  '" + ciudad + "', '" + email + "', '" + rfc + "' )";

            MySqlConnection conexionbd = conexion();
            conexionbd.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionbd);
                comando.ExecuteNonQuery();
                MessageBox.Show("registro guardado");
                limpiar();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("error" + ex.Message);
            }
            finally
            {
                conexionbd.Close();
            }
        }

        private void Btnmodificar_Click(object sender, EventArgs e)
        {
            string proveedores = txtprovedores.Text;
            string nombre = txtnombre.Text;
            string direccion = txtdireccion.Text;
            string telefono = txttelefono.Text;
            double codigop = double.Parse(txtcp.Text);
            string ciudad = txtciudad.Text;
            string email = txtmail.Text;
            string rfc = txtrfc.Text;


            string sql = "UPDATE proveedores SET id_proveedor=  '" + proveedores + "',nombre= '" + nombre + "' ,direccion= '" + direccion + "' , telefono= '" + telefono + "', codigopostal= '" + codigop + "', ciudad= '" + ciudad + "', Email= '" + email + "'  RFC= '" + rfc + "' WHERE 1" ; 

            MySqlConnection conexionbd = conexion();
            conexionbd.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionbd);
                comando.ExecuteNonQuery();
                MessageBox.Show("registro modificado");
                limpiar();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("error" + ex.Message);
            }
            finally
            {
                conexionbd.Close();
            }
        }

        private void Btneliminar_Click(object sender, EventArgs e)
        {
            string nombre = txtnombre.Text;


            string sql = "DELETE FROM proveedores WHERE nombre= '" + nombre + "'";

            MySqlConnection conexionbd = conexion();
            conexionbd.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionbd);
                comando.ExecuteNonQuery();
                MessageBox.Show("registro eliminado");
                limpiar();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("error" + ex.Message);
            }
            finally
            {
                conexionbd.Close();
            }
        }

        private void Btnlimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }
        private void limpiar()
        {
            txtprovedores.Text = "";
            txtnombre.Text = "";
            txtdireccion.Text = "";
            txttelefono.Text = "";
            txtcp.Text = "";
            txtciudad.Text = "";
            txtmail.Text = "";
            txtrfc.Text = "";

        }

        private void Btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Proveedores_Load(object sender, EventArgs e)
        {

        }

        private void getlistpersonal()
        {
            MySqlConnection conexion = new MySqlConnection("server=localhost; database=comercial_paquime; uid=root; password=;");
            try
            {


                conexion.Open();
                MySqlCommand comando = new MySqlCommand();
                comando.Connection = conexion;
                comando.CommandText = ("select * from proveedores");
                MySqlDataAdapter adaptar = new MySqlDataAdapter();
                adaptar.SelectCommand = comando;
                DataTable tabla = new DataTable();
                adaptar.Fill(tabla);
                dataGridView1.DataSource = tabla;
                conexion.Close();












            }

            catch (MySqlException m)
            {
                MessageBox.Show(m.Message);
            }


        }

        private void Txtprovedores_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.solonumeros(e);
        }

        private void Txttelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.solonumeros(e);
        }

        private void Txtcp_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.solonumeros(e);
        }
    }
    
    
}

