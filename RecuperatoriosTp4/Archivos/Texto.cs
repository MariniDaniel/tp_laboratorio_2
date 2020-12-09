using Excepciones;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public class Texto
    {

        /// <summary>
        /// Lee archivos de texto
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="contenido"></param>
        /// <returns>true si lee correctamente, false lo contrario</returns>
        public bool Leer(string archivo, out string contenido)
        {
            try
            {
                contenido = String.Empty;

                if (File.Exists(archivo))
                {
                    using (StreamReader reader = new StreamReader(archivo))
                    {
                        contenido = reader.ReadToEnd();
                        return true;
                    }
                }
            }
            catch (Exception)
            {

                throw new ArchivosEx("Error al intentar leer el archivo de texto!!");
            }

            return false;
        }




        /// <summary>
        /// Guarda el archivo en formato texto
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="contenido"></param>
        /// <returns>true si guardo correctamente, false lo contrario</returns>
        public bool Guardar(string archivo, string contenido)
        {
            try
            {

                if (!String.IsNullOrEmpty(archivo) && !String.IsNullOrEmpty(contenido))
                {
                    using (StreamWriter writer = new StreamWriter(archivo, false))
                    {
                        writer.WriteLine(contenido);
                    }

                    return true;
                }
            }
            catch (Exception)
            {

                throw new ArchivosEx("Error al intentar guardar su archivo de texto!!!");
            }

            return false;
        }


    }
}
