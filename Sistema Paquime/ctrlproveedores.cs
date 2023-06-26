using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Sistema_Paquime
{
    class ctrlproveedores : conectar
    {
        



            public List<object> consulta(string dato)
            {
                MySqlDataReader reader;
                List<object> lista = new List<object>();
                string sql;

                if (dato == "")
                {
                    sql = "SELECT id_proveedor, nombre, direccion, telefono, codigopostal, ciudad, Email, RFC FROM proveedores ORDER BY nombre ASC";

                }
                else
                {
                    sql = "SELECT id_proveedor, nombre, direccion, telefono, codigopostal, ciudad, Email, RFC FROM proveedores WHERE id_proveedores LIKE '%" + dato + "%' OR  nombre LIKE '%" + dato + "%' direccion LIKE '%" + dato + "%' telefono LIKE '%" + dato + "%' codigopostal LIKE '%" + dato + "%'  ciudad LIKE '%" + dato + "%'  Email LIKE '%" + dato + "%'  RFC LIKE '%" + dato + "%' ORDER BY nombre ASC";
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
                        provedores1 _provedores = new provedores1();
                        _provedores.Id_proveedores = int.Parse(reader.GetString(0));
                        _provedores.Nombre = reader.GetString(1);
                        _provedores.Direccion = reader[2].ToString();
                        _provedores.Telefono = int.Parse(reader[3].ToString());
                        _provedores.CP = int.Parse(reader[4].ToString());
                    _provedores.Ciudad = reader.GetString(5);
                        _provedores.email= reader.GetString(6);
                    _provedores.rfc = reader.GetString(7);
                    lista.Add(_provedores);

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
            // 
            // ctrlproveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "ctrlproveedores";
            this.Load += new System.EventHandler(this.Ctrlproveedores_Load);
            this.ResumeLayout(false);

        }

        private void Ctrlproveedores_Load(object sender, EventArgs e)
        {

        }
    }   
}
