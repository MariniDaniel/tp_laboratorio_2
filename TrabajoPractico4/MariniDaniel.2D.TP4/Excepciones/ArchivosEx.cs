using System;

namespace Excepciones
{
    public class ArchivosEx : Exception
    {


        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        /// <param name="mensaje"></param>
        public ArchivosEx(string mensaje) : base (mensaje)
        {

        }

        /// <summary>
        /// Constructor parametrizado con 2 parametros
        /// </summary> 
        /// <param name="mensaje"></param>
        /// <param name="innerException"></param>
        public ArchivosEx(string mensaje, Exception innerException) : base(mensaje, innerException)
        {

        }
    }
}
