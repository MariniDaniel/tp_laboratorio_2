using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {

        #region Atributos

        private int legajo;

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor de Universitario por defecto
        /// </summary>
        public Universitario()
        {
                
        }

        /// <summary>
        /// Sobrecarga del constructor Universitario con 5 parametros que llama a la clase base
        /// </summary>
        /// <param name="legajo">legajo del universitario</param>
        /// <param name="nombre">nombre del universitario</param>
        /// <param name="apellido">apellido del universitario</param>
        /// <param name="dni">dni del universitario</param>
        /// <param name="nacionalidad">nacionalidad del universitario</param>
        public Universitario(int legajo,string nombre,string apellido,string dni, ENacionalidad nacionalidad):base(nombre,apellido,dni,nacionalidad)
        {
            this.legajo = legajo;
        }

        #endregion

        #region Sobrecargas


        /// <summary>
        /// Sobrecarga del operador == en la clase Universitario para saber si sus legajos y dni son iguales
        /// </summary>
        /// <param name="pg1">Universitario 1</param>
        /// <param name="pg2">Universitario 2</param>
        /// <returns>retorna true si son iguales y false si son distintos </returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool retorno = false;

            if (Object.Equals(pg1, null) == false && Object.Equals(pg2, null) == false)
            {

                if (pg1.Equals(pg2)&& pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI )
                {
                    retorno = true;
                }

            }
            else
            {
                if (Object.Equals(pg1, null) && Object.Equals(pg2, null))
                {
                    retorno = true;
                }
                else
                {
                    retorno = false;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Sobrecarga del operador != en la clase Universitario para saber si sus legajos y dni son distintos.
        /// </summary>
        /// <param name="pg1">Universitario 1</param>
        /// <param name="pg2">Universitario 2</param>
        /// <returns>retorna true si son distintos y false si son iguales</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1==pg2);
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Sobreescritura del metodo Equals en la clase Universitario para saber si son del mismo tipo
        /// </summary>
        /// <param name="obj">Objeto a comparar</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return this.GetType() == obj.GetType();
        }

        /// <summary>
        /// Muestra los datos de la clase
        /// </summary>
        /// <returns>retorna una cadena con los datos del Universitario</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder cadena = new StringBuilder();

            cadena.AppendLine(base.ToString());
            cadena.AppendFormat("LEGAJO NÚMERO: {0}\n",this.legajo);

            return cadena.ToString();
        }

        #endregion

        #region Abstract

        /// <summary>
        /// Metodo abstracto que va a ser usado en las subclases
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();

        #endregion

    }
}
