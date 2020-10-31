using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;

namespace EntidadesInstanciables
{
    public class Jornada
    {

        #region Atributos

        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        #endregion

        #region Propiedades

        /// <summary>
        ///  Propiedad que hace publica la lista de alumnos y setea la lista con el valor pasado
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }

          set
            {
                this.alumnos = value;
            }
        }

        /// <summary>
        /// Propiedad que hace publico al enumerado y setea el dato con el valor pasado
        /// </summary>
        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }

            set
            {
                this.clase = value;
            }
        }

        /// <summary>
        /// Propiedad que hace publico al instructor y setea el dato con el valor pasado
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }

            set
            {
                this.instructor = value;
            }
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto de la Jornada que inicializa la lista de alumnos
        /// </summary>
        public Jornada()
        {
            this.Alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Sobrecarga del constructor de Jornada con 2 parametros que llama al por defecto
        /// </summary>
        /// <param name="clase">clase de la jornada</param>
        /// <param name="instructor">instructor de la jornada</param>
        public Jornada(Universidad.EClases clase, Profesor instructor):this()
        {
            this.Instructor = instructor;
            this.Clase = clase;

        }

        #endregion

        #region Metodos

        /// <summary>
        /// metodo estatico que guarda los datos de la jornada en un archivo de texto
        /// </summary>
        /// <param name="jornada">jornada a guardar</param>
        /// <returns>retorna true si se pudo guardar y false si no</returns>
        public static bool Guardar(Jornada jornada)
        {
            bool retorno = false;
          
            Texto guardarTexto = new Texto();

            retorno = guardarTexto.Guardar(AppDomain.CurrentDomain.BaseDirectory + @"Jornada.txt", jornada.ToString());

            return retorno;
        }

        /// <summary>
        /// metodo que lee los datos de un archivo 
        /// </summary>
        /// <returns>retorna true si se pudo leer y false si no</returns>
        public string Leer( )
        {

            string retorno="";
            Texto leerTexto = new Texto();

            leerTexto.Leer(AppDomain.CurrentDomain.BaseDirectory + @"Jornada.txt", out retorno);

            return retorno;
        }

        /// <summary>
        /// Sobrescritura del metodo ToString que muestra los datos de la jornada
        /// </summary>
        /// <returns>retorna una cadena con todos los datos de la jornada</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("CLASE DE {0} POR {1}",this.Clase,this.Instructor.ToString());
            sb.AppendLine("ALUMNOS: ");

            foreach (Alumno alumno in this.Alumnos)
            {
                sb.AppendLine(alumno.ToString());
            }

            sb.AppendLine("<---------------------------------------------------------------------------->");

            return sb.ToString();
        }

        #endregion

        #region Sobrecargas

        /// <summary>
        /// sobrecarga del operador == que valida si el alumno se encuentra en la jornada
        /// </summary>
        /// <param name="j">jornada 1</param>
        /// <param name="a">alumno 1</param>
        /// <returns>retorna true si el alumno se encuentra en la jornada y false si no</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool retorno = false;
            
            if (Object.Equals(j, null) == false && Object.Equals(a, null) == false)
            {

                foreach (Alumno alumno in j.alumnos)
                {
                    if (alumno == a)
                    {
                        retorno = true;
                        break;
                    }
                }          

            }

            return retorno;
        }

        /// <summary>
        /// sobrecarga del operador != que valida si el alumno no se encuentra en la jornada
        /// </summary>
        /// <param name="j">jornada 1</param>
        /// <param name="a">alumno 1</param>
        /// <returns>retorna true si el alumno no se encuentra en la jornada y false si se encuentra</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j==a);
        }

        /// <summary>
        /// metodo que agrega un alumno a la jornada si este no se encuentra en esta
        /// </summary>
        /// <param name="j">jornada 1</param>
        /// <param name="a">alumno 1</param>
        /// <returns>retorna la jornada con el alumno cargado si se pudo guardar y la jornada sin cambiar si no se pudo</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
          
            if (Object.Equals(j, null) == false && Object.Equals(a, null) == false)
            {
                if (j != a)
                {
                    j.alumnos.Add(a);
                  
                }
            }

            return j;
        }

        #endregion

    }
}
