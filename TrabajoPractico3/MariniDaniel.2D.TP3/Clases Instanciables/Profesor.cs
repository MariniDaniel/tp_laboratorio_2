using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public class Profesor : Universitario
    {

        #region Atributos

        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor de Profesor por defecto
        /// </summary>
        public Profesor()
        {
        }

        /// <summary>
        /// Constructor de clase de Profesor que inicializa el atributo random
        /// </summary>
        static Profesor()
        {
            Profesor.random = new Random();
        }

        /// <summary>
        /// Sobrecarga del constructor de Profesor con 5 parametros
        /// </summary>
        /// <param name="id">id del Profesor</param>
        /// <param name="nombre">nombre del profesor</param>
        /// <param name="apellido">apellido del profesor</param>
        /// <param name="dni">dni del profesor</param>
        /// <param name="nacionalidad">nacionalidad del profesor</param>
        public Profesor(int id,string nombre,string apellido,string dni, ENacionalidad nacionalidad):base(id,nombre,apellido,dni,nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();

        }

        #endregion

        #region Metodos

        /// <summary>
        /// metodo que asigna dos enumerados de tipo EClase random a la lista de tipo queue 
        /// </summary>
        private void _randomClases()
        {

            for (int i = 0; i < 2; i++)
            {
                clasesDelDia.Enqueue((Universidad.EClases)random.Next(4));
            }

        }

        /// <summary>
        /// muestra los datos del Profesor
        /// </summary>
        /// <returns>retorna una cadena con los datos del Profesor</returns>
        protected override string MostrarDatos()
        {
            StringBuilder cadena = new StringBuilder();

            cadena.Append(base.MostrarDatos());
            cadena.AppendLine(this.ParticiparEnClase());

            return cadena.ToString();
        }

        /// <summary>
        /// Sobrescritura del metodo ParticiparEnClase que muestra las clases del dia
        /// </summary>
        /// <returns>retorna una cadena que muestra las clases del dia</returns>
        protected override string ParticiparEnClase()
        {
       
            StringBuilder cadena = new StringBuilder();

            cadena.AppendLine("CLASES DEL DIA: ");

            foreach (Universidad.EClases item in clasesDelDia)
            {
                cadena.AppendLine(item.ToString());
            }

            return cadena.ToString();
        
        }

        /// <summary>
        /// Sobreescritura del metodo ToString que llama al metodo MostrarDatos
        /// </summary>
        /// <returns>retorna el metodo MostrarDatos</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion

        #region Sobrecargas

        /// <summary>
        /// Sobrecarga del operador == que valida si la clase pasada la da el profesor pasado
        /// </summary>
        /// <param name="i">Profesor 1</param>
        /// <param name="clase">clase 1</param>
        /// <returns>retorna true si la contiene y false si no la contiene</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool retorno = false;

            if (Object.Equals(i, null) == false)
            {

                if (i.clasesDelDia.Contains(clase))
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
        /// Sobrecarga del operador 1= que valida si la clase pasada no la da el profesor pasado
        /// </summary>
        /// <param name="i">Profesor 1</param>
        /// <param name="clase">clase 1</param>
        /// <returns>retorna true si no la contiene y false si la contiene</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

       #endregion

    }
}
