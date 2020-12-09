using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArmasEx : Exception
    {
        /// <summary>
        /// Constructor parametrizado de Armas
        /// </summary>
        /// <param name="mensaje"></param>
        public ArmasEx(string mensaje) : base(mensaje)
        {

        }
    }
}
