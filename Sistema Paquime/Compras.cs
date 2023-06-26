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
using MySql.Data;

namespace Sistema_Paquime
{
    public partial class Compras : Form
    {
        public Compras()
        {
            InitializeComponent();

            
          //cargarTabla("");

            cargarprovedor();
            cargarproducto();
            getlistpersonal();
            
            
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

        private void Compras_Load(object sender, EventArgs e)
        {

            getlistpersonal();
        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
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

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            Form prov = new Proveedores();
            prov.Show();
        }

        private void PictureBox5_Click(object sender, EventArgs e)
        {
            ventas vns = new ventas();
            vns.Show();
        }

        private void Btnagregar_Click(object sender, EventArgs e)
        {
            
            string nombre = cmbxprove.SelectedValue.ToString();
            string gnombre = cmbproducto.SelectedValue.ToString();
            {

                
                string compra = txtcompra.Text;
                string producto = cmbproducto.Text;
                string onombre = txtnombre.Text;
                string proveedor = cmbxprove.Text;
                string fecha = dateTimePicker1.Text;
                string cantidad = txtcantidad.Text;
                string costo = txtcosto.Text;
                

                string sql = "INSERT INTO compras (id_compra, id_producto, nombre, proveedor, fecha, cantidad, costo) values ('" + compra + "','" + producto + "','" + onombre + "','" + proveedor + "', '" + fecha + "', '" + cantidad + "', '" + costo + "')";

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

           

            for (int fila = 0; fila < dgv.Rows.Count - 1; fila++)
            {
                MySqlConnection conexion = new MySqlConnection("server=localhost; database=comercial_paquime; uid=root; password=;");
                conexion.Open();
                string cif = "SELECT stock FROM productos WHERE id_producto=" + dgv.Rows[fila].Cells["id_producto"].Value.ToString() + "" ;
                MySqlCommand cmd = new MySqlCommand(cif, conexion);
                int contador = Convert.ToInt32(cmd.ExecuteScalar());
                MessageBox.Show("" + contador);




                int valor = Convert.ToInt32(dgv.Rows[fila].Cells["cantidad"].Value.ToString());
                int resultado = contador + valor;
                MessageBox.Show("" + resultado);

                string query2 = "UPDATE productos set stock=" + resultado + " where id_producto=" + dgv.Rows[fila].Cells["id_producto"].Value.ToString() + "";

                MySqlCommand cmd2 = new MySqlCommand(query2, conexion);
                cmd2.ExecuteNonQuery();
                conexion.Close();
            }
        }

        private void Btneliminar_Click(object sender, EventArgs e)
        {
            string compra = txtcompra.Text;


            string sql = "DELETE FROM compras WHERE id_compra= '" + compra + "'";

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

        private void Txtlimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }
        
            private void limpiar()
            {
                txtcompra.Text = "";
                cmbxprove.Text = "";
                dateTimePicker1.Text = "";
                txtcantidad.Text = "";
                txtcosto.Text = "";
                  txtnombre.Text = "";
                cmbproducto.Text = "";
                
            }


        private void cargarTabla(string dato)
        {
            List<compras1> lista = new List<compras1>();
            ctrlcompras ctrlcompras = new ctrlcompras();
            dgv.DataSource = ctrlcompras.consulta(dato);
            
        }

        private void Dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
           
        }
        private void cargarprovedor()
        {
            cmbxprove.DataSource = null;
            cmbxprove.Items.Clear();
            string sql = "Select nombre FROM proveedores ORDER BY nombre ASC";

            MySqlConnection conexionbd = conectar.Conexion();
            conexionbd.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionbd);
                MySqlDataAdapter data = new MySqlDataAdapter(comando);
                DataTable dt = new DataTable();
                data.Fill(dt);

                cmbxprove.DisplayMember = "nombre";
                cmbxprove.DataSource = dt;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("error al cargar" + ex.Message);
            }
            finally
            {
                conexionbd.Close();

            }
        }

        private void cargarproducto()
        {
            cmbproducto.DataSource = null;
            cmbproducto.Items.Clear();
            string sql = "Select id_producto FROM productos ORDER BY nombre ASC";

            MySqlConnection conexionbd = conectar.Conexion();
            conexionbd.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionbd);
                MySqlDataAdapter data = new MySqlDataAdapter(comando);
                DataTable dt = new DataTable();
                data.Fill(dt);

                cmbproducto.DisplayMember = "id_producto";
                cmbproducto.DataSource = dt;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("error al cargar" + ex.Message);
            }
            finally
            {
                conexionbd.Close();

            }

            MySqlConnection conexion = new MySqlConnection("server=localhost; database=comercial_paquime; uid=root; password=;");

            conexion.Open();
            MySqlCommand comand = new MySqlCommand();
            comand.Connection = conexion;
            comand.CommandText = ("SELECT * FROM productos WHERE id_producto = " + cmbproducto.Text + " ");

            MySqlDataReader registro = comand.ExecuteReader();

            if (registro.Read() == true)
            {
                txtnombre.Text = registro["nombre"].ToString();
                
                
            }

            else
            {
                MessageBox.Show("el registro no existe");
            }
            conexion.Close();
        }

        private void Btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void getlistpersonal()
        {
            MySqlConnection conexion = new MySqlConnection("server=localhost; database=comercial_paquime; uid=root; password=;");
            try
            {

                
                conexion.Open();
                MySqlCommand comando = new MySqlCommand();
                comando.Connection = conexion;
                comando.CommandText = ("select * from compras");
                MySqlDataAdapter adaptar = new MySqlDataAdapter();
                adaptar.SelectCommand = comando;
                DataTable tabla = new DataTable();
                adaptar.Fill(tabla);
                dgv.DataSource = tabla;
                conexion.Close();
                
                
                         
                
            }

            catch(MySqlException m)
            {
                MessageBox.Show(m.Message);
            }


        }

        private void Txtcompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.solonumeros(e);
        }

        private void Txtcantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.solonumeros(e);
        }

        private void Txtcosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.solonumeros(e);
        }

        private void Txtnombre_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection conexion = new MySqlConnection("server=localhost; database=comercial_paquime; uid=root; password=;");

            conexion.Open();
            MySqlCommand comand = new MySqlCommand();
            comand.Connection = conexion;
            comand.CommandText = ("SELECT * FROM productos WHERE id_producto = " + cmbproducto.Text + " ");

            MySqlDataReader registro = comand.ExecuteReader();

            if (registro.Read() == true)
            {
                txtnombre.Text = registro["nombre"].ToString();


            }

            else
            {
                MessageBox.Show("el registro no existe");
            }
            conexion.Close();
        }
    }
   
}
