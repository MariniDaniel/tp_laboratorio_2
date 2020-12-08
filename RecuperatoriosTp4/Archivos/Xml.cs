using Excepciones;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
    public class Xml<T>: IArchivo<T>
    {


        

        /// <summary>
        /// Lee archivos de texto
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="contenido"></param>
        /// <returns>true si lee correctamente, false lo contrario</returns>
        public bool Leer(string archivo, out T contenido)
        {
            contenido = default(T);

            try
            {
                if (File.Exists(archivo))
                {
                    using (XmlTextReader reader = new XmlTextReader(archivo))
                    {
                        XmlSerializer xmlSer = new XmlSerializer(typeof(T));

                        contenido = (T)xmlSer.Deserialize(reader);

                        return true;
                    }
                }
            }
            catch (Exception)
            {

                throw new ArchivosEx("Error al leer archivo xml!!!!");
            }

            return false;
        }

        /// <summary>
        /// Guarda el archivo en formato XML
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="contenido"></param>
        /// <returns>true si guardo correctamente, false lo contrario</returns>
        public bool Guardar(string archivo, T contenido)
        {
            try
            {
                if (archivo != null)
                {
                    using (XmlTextWriter writer = new XmlTextWriter(archivo, Encoding.UTF8))
                    {
                        XmlSerializer xmlSer = new XmlSerializer(typeof(T));

                        xmlSer.Serialize(writer, contenido);

                        return true;
                    }
                }
            }
            catch (Exception e)
            {

                throw new ArchivosEx("Error al guardar archivo xml!!!!", e);
            }

            return false;
        }

    }
}
