using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {

        private string mensajeBase;

        /// <summary>
        /// Excepcion de tipo dni invalido que muestra un mensaje de error
        /// </summary>
        public DniInvalidoException():base("El dni no tiene el formato correcto")
        {
            
        }


        /// <summary>
        /// Excepcion de tipo dni invalido que muestra un mensaje de de tipo InnerException
        /// </summary>
        /// <param name="e">excepcion</param>
        public DniInvalidoException(Exception e):base(e.InnerException.Message)
        {

        }


        /// <summary>
        /// Excepcion de tipo dni invalido que muestra un mensaje por parametro
        /// </summary>
        /// <param name="message">mensaje</param>
        public DniInvalidoException(string message):base(message)
        {
            this.mensajeBase = message;
        }

        /// <summary>
        /// Excepcion de tipo dni invalido que muestra un mensaje por parametro y una Excepcion
        /// </summary>
        /// <param name="message">mensaje</param>
        /// <param name="e">excepcion</param>
        public DniInvalidoException(string message, Exception e):base(message,e.InnerException)
        {

        }

    }
}
