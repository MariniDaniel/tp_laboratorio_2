using System;

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
