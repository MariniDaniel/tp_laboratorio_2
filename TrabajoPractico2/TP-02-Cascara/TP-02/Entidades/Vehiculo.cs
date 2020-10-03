using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{

    public abstract class Vehiculo
    {
        #region Enumerados 

        /// <summary>
        /// Enumerado de marcas
        /// </summary>
        public enum EMarca
        {
            Chevrolet, Ford, Renault, Toyota, BMW, Honda, HarleyDavidson
        }

        /// <summary>
        /// Enumerado de tamaños
        /// </summary>
        public enum ETamanio
        {
            Chico, Mediano, Grande
        }

        #endregion

        #region Atributos

        EMarca marca;
        string chasis;
        ConsoleColor color;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor de vehiculo
        /// </summary>
        /// <param name="chasis"></param>
        /// <param name="marca"></param>
        /// <param name="color"></param>
        protected Vehiculo(string chasis, EMarca marca, ConsoleColor color)
        {
            this.marca = marca;
            this.chasis = chasis;
            this.color = color;
        }

        #endregion

        #region Propiedad

        /// <summary>
        /// Retornara el tamañao, Solo lectura
        /// </summary>
        protected abstract ETamanio Tamanio { get; }

        #endregion

        #region Metodos

        /// <summary>
        /// Publica todos los datos del Vehiculo.
        /// </summary>
        /// <returns> Retorna un string con los datos del vehiculo </returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }

        /// <summary>
        /// Override de Mostrar ,muestra todos los atributos de vehiculo
        /// </summary>
        /// <returns> Devuelve el objeto stringbuilder con todos los datos.</returns>
        public static explicit operator string(Vehiculo p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("CHASIS: {0}\r\n", p.chasis);
            sb.AppendFormat("MARCA : {0}\r\n", p.marca.ToString());
            sb.AppendFormat("COLOR : {0}\r\n", p.color.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        #endregion


        #region SobreCargas de Operadores

        /// <summary>
        /// Comparo dos vehiculos para ver si poseen el mismo chasis
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns>Devuelve true si es el mismo Chasis</returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return (v1.chasis == v2.chasis);
        }

        /// <summary>
        /// Comparo dos vehiculos para ver si poseen diferente chasis
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns>Devuelve true si no es el mismo chasis</returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2);
        }

        #endregion
    }
}
