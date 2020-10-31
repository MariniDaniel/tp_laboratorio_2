using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public interface IArchivo <T>
    {
        /// <summary>
        /// Metodo de interfaz para guardar datos
        /// </summary>
        /// <param name="archivo">direccion del archivo (path)</param>
        /// <param name="datos">datos a guardar</param>
        /// <returns>true si guarda los datos , false si no</returns>
        bool Guardar(string archivo, T datos);

        /// <summary>
        /// Metodo de interfaz para leer datos
        /// </summary>
        /// <param name="archivo">direccion del archivo (path)</param>
        /// <param name="datos">cadena en donde se guardan los datos leidos</param>
        /// <returns>true si pudo leer , false si no</returns>
        bool Leer(string archivo, out T datos);       
    }
}
