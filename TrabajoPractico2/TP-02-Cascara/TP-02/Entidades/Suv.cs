using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Suv : Vehiculo
    {
        #region Constructor

        /// <summary>
        /// Constuctor de Sedan.
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Suv(EMarca marca, string chasis, ConsoleColor color): base(chasis, marca, color)
        {

        }

        #endregion


        #region Propiedades
        /// <summary>
        /// Propiedad solo lectura,devuelve tamaño Grande.
        /// </summary>
        protected override ETamanio Tamanio
        {
            get { return ETamanio.Grande; }
        }

        #endregion


        #region Metodo
        /// <summary>
        /// Override de Mostrar ,muestra atributos de SUV
        /// </summary>
        /// <returns> Devuelve el objeto stringbuilder con todos los datos.  </returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SUV");

            sb.AppendLine(base.Mostrar());

            sb.AppendFormat("TAMAÑO : {0}", this.Tamanio);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();

        }
            #endregion

    }
}
