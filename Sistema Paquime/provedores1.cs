using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Paquime
{
    class provedores1
    {
        private int id_proveedores;
        private string nombre;
        private string direccion;
        private int telefono;
        private int codigopostal;
        private string ciudad;
        private string Email;
        private string RFC;

        public int Id_proveedores { get => id_proveedores; set => id_proveedores = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public int Telefono { get => telefono; set => telefono = value; }
        public int CP { get => codigopostal; set => codigopostal = value; }
        public string Ciudad { get => ciudad; set => ciudad = value; }
        public string email { get => Email; set => Email = value; }
        public string rfc { get => RFC; set => RFC = value; }
    }
}
