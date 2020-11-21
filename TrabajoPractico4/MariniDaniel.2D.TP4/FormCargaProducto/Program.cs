using System;
using System.Windows.Forms;

namespace FormCargaProducto
{
    static class Program
    {
        /// <summary>
        /// Entrada principal para el TP4 :D.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmArticulo());
        }
    }
}
