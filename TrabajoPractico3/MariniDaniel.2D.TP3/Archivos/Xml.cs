using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {


        /// <summary>
        /// Implementacion del metodo Guardar de la interfaz IArchivo
        /// </summary>
        /// <param name="archivo">direccion del archivo (path)</param>
        /// <param name="datos">datos a serializar</param>
        /// <returns></returns>
        public bool Guardar(string archivo, T datos)
        {
            bool retorno = false;

            try
            {
                XmlSerializer nuevoXml = new XmlSerializer(typeof(T));

                using (XmlTextWriter newTextWriter = new XmlTextWriter(archivo, Encoding.UTF8))
                {
                    nuevoXml.Serialize(newTextWriter, datos);
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
        /// <param name="datos">datos a deserializar</param>
        /// <returns></returns>
        public bool Leer(string archivo, out T datos)
        {
            datos = default(T);
            bool retorno = false;

            try
            {

                XmlSerializer nuevoXml = new XmlSerializer(typeof(T));

                using (XmlTextReader newTextReader = new XmlTextReader(archivo))
                {
                    datos = (T)nuevoXml.Deserialize(newTextReader);
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
