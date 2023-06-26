using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Paquime
{
    class productos1
    {
        private int id_producto;
        private string nombre;
        private string descripcion;
        private string categoria;
        private double precio;
        private int stock;

        public int Id_producto { get => id_producto; set => id_producto = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Categoria { get => categoria; set => categoria = value; }
        public double Precio { get => precio; set => precio = value; }
        public int Stock { get => stock; set => stock = value; }
    }
}
