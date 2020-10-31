using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {

        /// <summary>
        /// Implementacion del metodo Guardar de la interfaz IArchivo
        /// </summary>
        /// <param name="archivo">direccion del archivo (path)</param>
        /// <param name="datos">datos a leer</param>
        /// <returns>true si pudo Guardar , false si no</returns>
        public bool Guardar(string archivo, string datos)
        {
            bool retorno = false;

            try
            {

                using (StreamWriter nuevoTexto = new StreamWriter(archivo))
                {
                    nuevoTexto.Write(datos);
                    retorno = true;

                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

            return retorno;
        }


        /// <summary>
        /// Implementacion del metodo Leer de la interfaz IArchivo
        /// </summary>
        /// <param name="archivo">direccion del archivo (path)</param>
        /// <param name="datos">datos a guardar</param>
        /// <returns>true si pudo leer , false si no</returns>
        public bool Leer(string archivo, out string datos)
        {
            bool retorno = false;

            try
            {
                using (StreamReader nuevoTexto = new StreamReader(archivo))
                {

                    datos = nuevoTexto.ReadToEnd();
                    retorno = true;
                }

            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

            return retorno;
        }
    }
}
