using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        /// <summary>
        /// Excepcion de tipo archivo que muestra un mensaje de error y donde ocurrio la excepcion
        /// </summary>
        /// <param name="innerException">excepcion</param>
        public ArchivosException(Exception innerException) : base(innerException.Message)
        {

        }

    }
}
