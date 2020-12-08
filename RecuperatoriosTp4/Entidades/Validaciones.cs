using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Validaciones
    {

        /// <summary>
        /// Valida si un numero es menor a 0
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>true si es menor, false caso contrario</returns>
        public static bool ValidarNegativos(double numero)
        {
            if (numero < 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
