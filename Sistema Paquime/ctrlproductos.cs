using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Paquime



{

    class ctrlproductos : conectar




    {



        public List<object> consulta(string dato)
        {
            MySqlDataReader reader;
            List<object> lista = new List<object>();
            string sql;

            if (dato == "")
            {
                sql = "SELECT id_producto, nombre, descripcion, categoria, precio, stock FROM productos ORDER BY nombre ASC";
                
            }
            else
            {
                sql = "SELECT id_producto, nombre, descripcion, categoria, precio, stock FROM productos WHERE id_producto LIKE '%"+dato+ "%' OR  nombre LIKE '%" + dato + "%' descripcion LIKE '%" + dato + "%' categoria LIKE '%" + dato + "%' precio LIKE '%" + dato + "%'  stock LIKE '%" + dato + "%' ORDER BY nombre ASC"; 
            }

            try
            {


                
                
                    string servidor = "localhost";
                    string bd = "comercial_paquime";
                    string usuario = "root";
                    string password = "";

                    string cadenaconexion = "database=" + bd + "; data source=" + servidor + "; user id=" + usuario + "; password=" + password + "";

                   
                MySqlConnection conexionbd = new MySqlConnection();
                conexionbd.ConnectionString = cadenaconexion;
                conexionbd.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexionbd);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    productos1 _producto = new productos1();
                    _producto.Id_producto = int.Parse(reader.GetString(0));
                    _producto.Nombre = reader.GetString(1);
                    _producto.Descripcion = reader[2].ToString();
                    _producto.Categoria = reader[3].ToString();
                    _producto.Precio = Double.Parse(reader[4].ToString());
                    _producto.Stock = int.Parse(reader.GetString(5));
                    lista.Add(_producto);

                }

            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return lista;

    }   }
}
