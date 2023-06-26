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
    public partial class Productos : Form
    {
        public Productos()
        {
            InitializeComponent();
            cargarTabla("");
            cargarcategorias();
            cargarproveedores();
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








        private void Productos_Load(object sender, EventArgs e)
        {
            cargarTabla("");
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            Reportes mn = new Reportes();
            mn.Show();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            Reportes mn = new Reportes();
            mn.Show();
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            Form prov = new Proveedores();
            prov.Show();
        }

        private void PictureBox5_Click(object sender, EventArgs e)
        {
            Form comp = new Compras();
            comp.Show();
        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {
            ventas vns = new ventas();
            vns.Show();
        }

        private void Button1_Click(object sender, EventArgs e)  
        {
            if (requerido(txtpoducto.Text))
            {
                MessageBox.Show("lléne todos los campos");
            }
            if (requerido(txtnombre.Text))
            {
                MessageBox.Show("lléne todos los campos");
            }
            if (requerido(txtdescripcion.Text))
            {
                MessageBox.Show("lléne todos los campos");
            }
            if (requerido(cmbocategoria.Text))
            {
                MessageBox.Show("lléne todos los campos");
            }
            if (requerido(txtprecio.Text))
            {
                MessageBox.Show("lléne todos los campos");
            }
            if (requerido(comboprov.Text))
            {
                MessageBox.Show("lléne todos los campos");
            }
            if (requerido(txtstock.Text))
            {
                MessageBox.Show("lléne todos los campos");
            }




            string categoria = cmbocategoria.SelectedValue.ToString();
            string nombre = comboprov.SelectedValue.ToString();


            string producto = txtpoducto.Text;
            string inombre = txtnombre.Text;
            string descripcion = txtdescripcion.Text;
            string icategoria = cmbocategoria.Text;
            double precio = double.Parse(txtprecio.Text);
            string proveedor = comboprov.Text;
            int stock = int.Parse(txtstock.Text);

            string sql = "INSERT INTO productos (id_producto,nombre,descripcion, precio,stock, categoria) values ('" + producto + "', '" + inombre + "', '" + descripcion + "', '" + precio + "', '" + stock + "', '"+icategoria +"')";
            
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

        private void Btnactualizar_Click(object sender, EventArgs e)
        {
            string producto = txtpoducto.Text;
            string nombre = txtnombre.Text;
            string descripcion = txtdescripcion.Text;
            string categoria = cmbocategoria.Text;
            double precio = double.Parse(txtprecio.Text);
            string proveedor = comboprov.Text;
            int stock = int.Parse(txtstock.Text);

            string sql = "UPDATE productos SET id_producto= '" + producto + "', nombre='" + nombre + "',descripcion='" + descripcion + "', precio='" + precio + "' WHERE stock='" + stock + "'";

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
            string producto = txtpoducto.Text;


            string sql = "DELETE FROM productos WHERE id_producto= '" + producto + "'";

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
            txtpoducto.Text = "";
            txtnombre.Text = "";
            txtdescripcion.Text = "";
            cmbocategoria.Text = "";
            txtprecio.Text = "";
            txtstock.Text = "";
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void cargarTabla(string dato)
        {
            List<productos1> lista = new List<productos1>();
          
            ctrlproductos ctrlproductos = new ctrlproductos();
            dataGridView1.DataSource = ctrlproductos.consulta(dato);
        }

        private void Cmbocategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void cargarcategorias()
        {
            cmbocategoria.DataSource = null;
            cmbocategoria.Items.Clear();
            string sql = "Select categoria FROM productos ORDER BY nombre ASC";

            MySqlConnection conexionbd = conectar.Conexion();
            conexionbd.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionbd);
                MySqlDataAdapter data = new MySqlDataAdapter(comando);
                DataTable dt = new DataTable();
                data.Fill(dt);

                cmbocategoria.DisplayMember = "categoria";
                cmbocategoria.DataSource = dt;
            }
            catch(MySqlException ex)
            {
                MessageBox.Show("error al cargar" + ex.Message);
            }
            finally
            {
                conexionbd.Close();

            }
        }

        private void Comboprov_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void cargarproveedores()
        {
            comboprov.DataSource = null;
            comboprov.Items.Clear();
            string sql = "Select nombre FROM proveedores ORDER BY nombre ASC";

            MySqlConnection conexionbd = conectar.Conexion();
            conexionbd.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionbd);
                MySqlDataAdapter data = new MySqlDataAdapter(comando);
                DataTable dt = new DataTable();
                data.Fill(dt);

                comboprov.DisplayMember = "nombre";
                comboprov.DataSource = dt;
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

        private void Btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Txtpoducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.solonumeros(e);
        }

        private void Txtprecio_TextChanged(object sender, EventArgs e)
        {

        }

        private void Txtprecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.solonumeros(e);
        }

        private void Txtstock_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.solonumeros(e);
        }

        public bool requerido(string entrada)
        {
            return (string.IsNullOrWhiteSpace(entrada));
        }

        private void Txtpoducto_TextChanged(object sender, EventArgs e)
        {
            
        }
    }   
}   
    
    
