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
    public partial class ventas : Form
    {
        public ventas()
        {
            InitializeComponent();
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



        private void Ventas_Load(object sender, EventArgs e)
        {
            lbfecha.Text = DateTime.Today.Day.ToString() + "/" + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Year.ToString();
            //dataGridView1.AllowUserToAddRows = false;
        }
        string[,] listacompra = new string[200, 8];
        int fila = 0;



        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            Form prod = new Productos();
            prod.Show();
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            Form prov = new Proveedores();
            prov.Show();
        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {
            Form com = new Compras();
            com.Show();
        }
        public bool requerido(string entrada)
        {
            return (string.IsNullOrWhiteSpace(entrada));
        }


        private void Btnagregar_Click(object sender, EventArgs e)
        {
            if (requerido(txtcantidad.Text))
            {
                MessageBox.Show("lléne todos los campos");
            }
            string producto = txtproducto.Text;
            string nombre = txtnombre.Text;
            string precio = txtprecio.Text;



            try
            {
                if (txtproducto.Text != "" && txtcantidad.Text != "")
                {
                    listacompra[fila, 0] = txtproducto.Text;
                    listacompra[fila, 1] = txtnombre.Text;
                    listacompra[fila, 2] = txtprecio.Text;
                    listacompra[fila, 3] = txtcantidad.Text;
                    listacompra[fila, 4] = (float.Parse(txtcantidad.Text) * float.Parse(txtprecio.Text)).ToString();
                    listacompra[fila, 5] = lbfecha.Text;


                    dataGridView1.Rows.Add(listacompra[fila, 0], listacompra[fila, 1], listacompra[fila, 2], listacompra[fila, 3], listacompra[fila, 4], listacompra[fila, 5]);
                    txtproducto.Text = txtnombre.Text = txtprecio.Text = txtcantidad.Text = "";

                    txtproducto.Focus();
                }



            }
            catch
            {

            }

            costoapagar();



        }

        public void costoapagar()
        {
            double costototal = 0;
            int conteo = 0;

            conteo = dataGridView1.RowCount;
            // for (int i = 0; i < conteo; i++)
            // {
            //    txttotal.Text = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
            //  }
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                costototal += Convert.ToDouble(row.Cells[4].Value);
            }
            txttotal.Text = Convert.ToString(costototal);
            //txttotal.Text = costototal.ToString();
        }

        private void Txtdevolucion_TextChanged(object sender, EventArgs e)
        {

        }

        private void Txtefectivo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtdevolucion.Text = (float.Parse(txtefectivo.Text) - float.Parse(txttotal.Text)).ToString();
            }

            catch
            {
                txtdevolucion.Text = 0.ToString();
            }
        }

        private void Btnvender_Click(object sender, EventArgs e)
        {
            MySqlConnection conexion = new MySqlConnection("server=localhost; database=comercial_paquime; uid=root; password=;");




            MySqlCommand agregar = new MySqlCommand("INSERT INTO ventas VALUES(?producto,?nombre,?precio,?cantidad,?subtotal,?fecha)", conexion);
            conexion.Open();



            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    agregar.Parameters.Clear();

                    agregar.Parameters.Add("?producto", MySqlDbType.Int16).Value = Convert.ToString(row.Cells["column1"].Value);
                    agregar.Parameters.Add("?nombre", MySqlDbType.VarChar).Value = Convert.ToString(row.Cells["column2"].Value);
                    agregar.Parameters.Add("?precio", MySqlDbType.VarChar).Value = Convert.ToString(row.Cells["column3"].Value);
                    agregar.Parameters.Add("?cantidad", MySqlDbType.VarChar).Value = Convert.ToString(row.Cells["column4"].Value);
                    agregar.Parameters.Add("?subtotal", MySqlDbType.VarChar).Value = Convert.ToString(row.Cells["column5"].Value);
                    agregar.Parameters.Add("?fecha", MySqlDbType.VarChar).Value = Convert.ToString(row.Cells["column6"].Value);

                    agregar.ExecuteNonQuery();


                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("venta realizada");
                conexion.Close();
            }

            for (int fila = 0; fila < dataGridView1.Rows.Count - 1; fila++)
            {
                conexion.Open();
                string cif = "SELECT stock FROM productos WHERE id_producto=" + dataGridView1.Rows[fila].Cells[0].Value.ToString() + "";
                MySqlCommand cmd = new MySqlCommand(cif, conexion);
                int contador = Convert.ToInt32(cmd.ExecuteScalar());
                //MessageBox.Show("" + contador);



                
                int valor = Convert.ToInt32(dataGridView1.Rows[fila].Cells[3].Value.ToString());
                int resultado = contador - valor;
                //MessageBox.Show("" + resultado);

                string query2 = "UPDATE productos set stock=" + resultado + " where id_producto=" + dataGridView1.Rows[fila].Cells[0].Value.ToString() + "";

                MySqlCommand cmd2 = new MySqlCommand(query2, conexion);
                cmd2.ExecuteNonQuery();
                conexion.Close();
            }



            limpiar();


        }

        private void limpiar()
        {
            txtefectivo.Text="";
            txtdevolucion.Text = "";
            txttotal.Text = "";
            dataGridView1.DataSource = null;
        }

        private void PictureBox5_Click(object sender, EventArgs e)
        {
            Form rep = new Reportes();
            rep.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            costoapagar();
        }

        private void Txtproducto_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            MySqlConnection conexion = new MySqlConnection("server=localhost; database=comercial_paquime; uid=root; password=;");

            conexion.Open();
            MySqlCommand comando = new MySqlCommand();
            comando.Connection = conexion;
            comando.CommandText = ("SELECT * FROM productos WHERE id_producto = " + txtproducto.Text + " ");

            MySqlDataReader registro = comando.ExecuteReader();

            if (registro.Read() == true)
            {
                txtnombre.Text = registro["nombre"].ToString();
                txtprecio.Text = registro["precio"].ToString();
                txtnombre.Text = Convert.ToString(registro["nombre"]);
            }

            else
            {
                MessageBox.Show("el registro no existe");
            }
            conexion.Close();
        }

        private void Txtcantidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void Txtcantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.solonumeros(e);
        }

        private void Txtefectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.solonumeros(e);
        }

        private void Txtprecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.solonumeros(e);
        }
    }
}
