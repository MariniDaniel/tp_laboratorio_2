using System;

namespace Excepciones
{
    public class ArticulosEx : Exception
    {

        /// <summary>
        /// Constructor parametrizado de articulo
        /// </summary>
        /// <param name="mensaje"></param>
        public ArticulosEx(string mensaje) : base(mensaje)
        {

        }
    }
}
