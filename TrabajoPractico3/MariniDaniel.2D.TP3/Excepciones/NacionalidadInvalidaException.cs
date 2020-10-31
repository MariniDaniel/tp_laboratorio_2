using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {

        /// <summary>
        ///  Excepcion de tipo nacionaliad invalidad que muestra un mensaje de error y donde ocurrio la excepcion
        /// </summary>
        public NacionalidadInvalidaException() : base("La nacionalidad no coincide con el número de DNI")
        {

        }

        /// <summary>
        /// Excepcion de tipo nacionaliad invalidad que muestra un mensaje
        /// </summary>
        /// <param name="mensaje">mensaje a mostrar</param>
        public NacionalidadInvalidaException(string mensaje) : base(mensaje)
        {

        }
        
    }
}
