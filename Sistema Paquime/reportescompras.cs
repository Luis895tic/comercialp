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
    public partial class reportescompras : Form
    {
        public reportescompras()
        {
            InitializeComponent();
        }

        private void Reportescompras_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void ReportViewer1_Load(object sender, EventArgs e)
        {
            MySqlConnection conexion = new MySqlConnection("server = localhost; database = comercial_paquime; uid = root; password = ;");
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM compras", conexion);
            da.Fill(dt);

            reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rp = new ReportDataSource("DataSet1", dt);
            reportViewer1.LocalReport.DataSources.Add(rp);
            reportViewer1.RefreshReport();
        }
    }
}
