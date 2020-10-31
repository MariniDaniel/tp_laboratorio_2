using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Alumno:Universitario
    {
         
        #region Enumerados

        /// <summary>
        /// Enumerado de tipo EEstadoCuenta
        /// </summary>
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }

        #endregion

        #region Atributos

        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor de Alumno por defecto
        /// </summary>
        public Alumno()
        {

        }

        /// <summary>
        /// sobrecarga del constructor de Alumno con 6 parametros que llama a la clase base
        /// </summary>
        /// <param name="id">id del alumno</param>
        /// <param name="nombre">nombre del alumno</param>
        /// <param name="apellido">apellido del alumno</param>
        /// <param name="dni">dni del alumno</param>
        /// <param name="nacionalidad">nacionalidad del alumno</param>
        /// <param name="claseQueToma">clase que toma el alumno</param>
        public Alumno(int id,string nombre,string apellido,string dni, ENacionalidad nacionalidad,Universidad.EClases claseQueToma):base(id,nombre,apellido,dni,nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// sobrecarga del constructor de Alumno con 7 parametros que llama al constructor de 6 parametros
        /// </summary>
        /// <param name="id">id del alumno</param>
        /// <param name="nombre">nombre del alumno</param>
        /// <param name="apellido">apellido del alumno</param>
        /// <param name="dni">dni del alumno</param>
        /// <param name="nacionalidad">nacionalidad del alumno</param>
        /// <param name="claseQueToma">clase que toma el alumno</param>
        /// <param name="estadoCuenta">estado de cuenta del alumno</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma,EEstadoCuenta estadoCuenta):this(id,nombre,apellido,dni,nacionalidad,claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        #endregion

        #region Sobrecargas

        /// <summary>
        /// Sobrecarga del operador == en la clase Alumno para saber si sus clases y estado de cuenta son iguales
        /// </summary>
        /// <param name="a">Alumno 1</param>
        /// <param name="clase">Clase</param>
        /// <returns>retorna true si son iguales y false si son distintos</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            bool retorno = false;

            if (Object.Equals(a, null) == false)
            {

                if (a.estadoCuenta != EEstadoCuenta.Deudor && a.claseQueToma == clase)
                {
                    retorno = true;
                }

            }                  
                else
                {
                    retorno = false;
                }
             
            return retorno;
        }

        /// <summary>
        /// Sobrecarga del operador != en la clase Alumno para saber si sus clases y estado de cuenta son distintos
        /// </summary>
        /// <param name="a">Alumno 1</param>
        /// <param name="clase">Clase</param>
        /// <returns>retorna true si son distintos y false si son iguales</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            bool retorno = false;

            if (a.claseQueToma != clase)
            {
                retorno = true;
            }

            return retorno;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Muestra los datos del alumno
        /// </summary>
        /// <returns>retorna una cadena que muestra los datos del Alumno</returns>
        protected override string MostrarDatos()
        {
            StringBuilder cadena = new StringBuilder();

            cadena.AppendLine(base.MostrarDatos());
            cadena.AppendFormat("ESTADO DE CUENTA: {0}\n",this.estadoCuenta);
            cadena.AppendLine(this.ParticiparEnClase());

            return cadena.ToString();
        }


        /// <summary>
        /// Sobrescritura del metodo ToString que llama al metodo MostrarDatos
        /// </summary>
        /// <returns>retorna el metodo MostrarDatos</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// sobrescritura del metodo ParticiparEnClase de la clase base que muestra la clase que toma el alumno
        /// </summary>
        /// <returns>retorna la clase que toma el alumno</returns>
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASE DE " + this.claseQueToma;
        }

        #endregion

    }
}
