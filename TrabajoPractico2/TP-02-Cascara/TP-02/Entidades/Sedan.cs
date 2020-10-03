using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{
    public class Sedan : Vehiculo
    {

        #region EnumTipo

        /// <summary>
        /// Enum de tipo.
        /// </summary>
        public enum ETipo 
        { 
            CuatroPuertas, CincoPuertas 
        }

        #endregion
  
        ETipo tipo;

        #region Constructores
        /// <summary>
        /// Constructor de Sedan, Setea cuatroPuertas si no se pasa.
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color): base(chasis, marca, color)
        {
            this.tipo = ETipo.CuatroPuertas;
        }

        /// <summary>
        /// Sobrecarga de Constructor de Sedan con parametro de Tipo.
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        /// <param name="tipo"></param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color,ETipo tipo) : this(marca,chasis,color)
        {
            this.tipo = tipo;
        }

        #endregion


        #region Propiedad
        /// <summary>
        /// Propiedad solo lectura,devuelve tamaño mediano.
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }
        #endregion

        #region Metodo

        /// <summary>
        /// Override de Mostrar ,muestra atributos de Sedan
        /// </summary>
        /// <returns> Devuelve el objeto stringbuilder con todos los datos.  </returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SEDAN");
            sb.AppendLine(base.Mostrar());

            sb.AppendFormat("TAMAÑO : {0}\n", this.Tamanio);
            sb.AppendLine("TIPO : " + this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
