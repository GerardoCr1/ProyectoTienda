using System;
using System.Windows.Forms;

namespace Presentaciones.tienda
{
    public class Program
    {
        [STAThread]
        static void Main()
        {
            Application.Run(new FrmProductos());
        }
    }
}
