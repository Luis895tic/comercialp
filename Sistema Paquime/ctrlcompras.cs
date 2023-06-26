using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Sistema_Paquime
{
    class ctrlcompras : conectar
    {
          



       public List<object> consulta(string dato)
        {
            MySqlDataReader reader;
            List<object> lista = new List<object>();
            string sql;

            if (dato == "")
            {
                sql = "SELECT id_compra, fecha, cantidad, costo FROM compras ORDER BY nombre ASC";

            }
            else
            {
               sql = "SELECT id_compra, fecha, cantidad, costo FROM compras WHERE id_compra LIKE '%" + dato + "%' OR  fecha LIKE '%" + dato + "%' cantidad LIKE '%" + dato + "%' costo LIKE '%" + dato + "%' ORDER BY nombre ASC";
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
                    compras1 _compra = new compras1();
                   _compra.Id_compra = int.Parse(reader.GetString(0));
                    
                    _compra.Fecha = double.Parse(reader[1].ToString());
                   _compra.Cantidad = double.Parse(reader[2].ToString());
                    _compra.Costo = double.Parse(reader[3].ToString());
                     lista.Add(_compra);
                    

                }

            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
                
            }
            return lista;

        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
             
             //ctrlcompras
             
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "ctrlcompras";
            this.Load += new System.EventHandler(this.Ctrlcompras_Load);
            this.ResumeLayout(false);

        }

        private void Ctrlcompras_Load(object sender, EventArgs e)
        {

        }
    }
}

