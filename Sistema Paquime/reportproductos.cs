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
using Microsoft.Reporting.WinForms;

namespace Sistema_Paquime
{
    public partial class reportproductos : conectar
    {

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
        public reportproductos()
        {
            InitializeComponent();
        }

        private void Reportproductos_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            this.reportViewer2.RefreshReport();
        }

        private void ReportViewer1_Load(object sender, EventArgs e)
        {
                MySqlConnection conexion = new MySqlConnection("server = localhost; database = comercial_paquime; uid = root; password = ;");
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM productos", conexion);
            da.Fill(dt);

            reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rp = new ReportDataSource("DataSet1", dt);
            reportViewer1.LocalReport.DataSources.Add(rp);
            reportViewer1.RefreshReport();

        }
    }
}
