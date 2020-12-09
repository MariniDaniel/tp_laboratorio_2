using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class VentasEx : Exception
    {
        /// <summary>
        /// Constructor parametrizado de ventas
        /// </summary>
        /// <param name="mensaje"></param>
        public VentasEx(string mensaje) : base(mensaje)
        {

        }
    }
}
