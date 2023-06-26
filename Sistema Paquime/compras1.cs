using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Paquime
{
    class compras1
    {
        private int id_compra;
        private double fecha;
        private double cantidad;
        private double costo;

        public int Id_compra { get => id_compra; set => id_compra = value; }
        public double Fecha { get => fecha; set => fecha = value; }
        public double Cantidad { get => cantidad; set => cantidad = value; }
        public double Costo { get => costo; set => costo = value; }
    }
}
