using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Paquime
{
    class validar
    {
        public static void solonumeros(KeyPressEventArgs lol)
        {
            if(char.IsDigit(lol.KeyChar))
            {
                lol.Handled = false;
            }

            else if (char. IsSeparator(lol.KeyChar))
            {
                lol.Handled = false;
            }

            else if (char.IsControl(lol.KeyChar))
            {
                lol.Handled = false;
            }

            else
            {
                lol.Handled = true;
                MessageBox.Show("solo numeros");
            }
        }

    }
}
