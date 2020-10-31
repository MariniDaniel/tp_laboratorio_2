using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Excepciones;
using Archivos;

namespace EntidadesInstanciables
{
    public class Universidad
    {

        #region Enumerados

        /// <summary>
        /// enumerado de tipo EClases
        /// </summary>
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }

        #endregion

        #region Atributos

        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        #endregion

        #region Propiedades

        /// <summary>
        /// propiedad que hace publica la lista de alumnos y la setea con el valor
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
        /// propiedad que hace publica la lista de instructores y la setea con el valor
        /// </summary>
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }

        /// <summary>
        /// propiedad que hace publica la lista de jornadas y la setea con el valor
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }

            set
            {
                this.jornada = value;
            }
        }

        /// <summary>
        /// Indexador de la lista jornada
        /// </summary>
        /// <param name="i">indice</param>
        /// <returns></returns>
        public Jornada this[int i]
        {
            get
            {
                return this.jornada[i];
            }
            set
            {
                this.jornada[i] = value;
            }


        }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto de Universidad que inicializa las listas
        /// </summary>
        public Universidad()
        {
            this.Alumnos = new List<Alumno>();
            this.Instructores = new List<Profesor>();
            this.Jornadas = new List<Jornada>();
        }

        #endregion

        #region Sobrecargas

        /// <summary>
        /// sobrecarga del operador == que valida si el alumno se encuentra en la universidad
        /// </summary>
        /// <param name="g">universidad 1</param>
        /// <param name="a">alumno</param>
        /// <returns>retorna true si el alumno se encuentra en la jornada y false si no</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
         
            bool retorno = false;

            foreach (Alumno item in g.Alumnos)
            {
                if (item == a)
                {
                    retorno = true;
                }
            }

            return retorno;
          
        }

        /// <summary>
        /// sobrecarga del operador != que valida si el alumno no se encuentra en la universidad
        /// </summary>
        /// <param name="g">alumno 1</param>
        /// <param name="a">universidad 1</param>
        /// <returns>retorna true si el alumno no se encuentra en la universidad y false si se encuentra</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// sobrecarga del operador == que valida si el profesor se encuentra en la universidad
        /// </summary>
        /// <param name="g">profesor 1</param>
        /// <param name="i">universidad 1</param>
        /// <returns>retorna true si el profesor se encuentra en la jornada y false si no</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool retorno = false;

            foreach (Profesor item in g.Instructores)
            {
                if (item == i)
                {
                    retorno = true;
                }
            }

            return retorno;
            
        }


        /// <summary>
        /// sobrecarga del operador != que valida si el profesor no se encuentra en la universidad
        /// </summary>
        /// <param name="g">profesor 1</param>
        /// <param name="i">universidad 1</param>
        /// <returns>retorna true si el profesor no se encuentra en la universidad y false si se encuentra</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// sobrecarga del == que buscar el primer profesor que da esa clase y lo retorna
        /// </summary>
        /// <param name="u">profesor 1</param>
        /// <param name="clase">clase 1</param>
        /// <returns>retorna un profesor que da la clase o una excepcion </returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            Profesor auxProfesor = null;
            bool flag = false;

            foreach (Profesor item in u.Instructores)
            {
                if (item == clase)
                {
                    auxProfesor = item;
                    flag = true;
                    break;
                }
            }

            if (flag == false)
            {
                throw new SinProfesorException();
            }

            return auxProfesor;
        }

        /// <summary>
        /// sobrecarga del != que buscar el primer profesor que no da esa clase y lo retorna
        /// </summary>
        /// <param name="u">universidad 1</param>
        /// <param name="clase">clase 1</param>
        /// <returns>retorna un profesor que no da esa clase</returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor auxProfesor = null;

            foreach (Profesor item in u.Instructores)
            {
                if (item != clase)
                {
                    auxProfesor = item;
                    break;
                }
            }
            return auxProfesor;
        }

        /// <summary>
        /// agrega una jornada a la universidad con la clase y el profesor que da esa clase
        /// </summary>
        /// <param name="g">universidad 1</param>
        /// <param name="clase">clase 1</param>
        /// <returns>retorna la nueva jornada</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Profesor auxInstructor=(g==clase);
       
            Jornada nuevaJornada = new Jornada(clase, auxInstructor);

            foreach (Alumno alumno in g.Alumnos)
            {
                if (alumno == clase)
                {
                    nuevaJornada += alumno;
                }
            }

            g.Jornadas.Add(nuevaJornada);

            return g;
        }

        /// <summary>
        /// Agrega un profesor a la universidad si este aun no se encuentra en ella
        /// </summary>
        /// <param name="u">universidad 1</param>
        /// <param name="a">alumno 1</param>
        /// <returns>retorna la universidad con el alumno cargado si se pudo guardar y la universidad sin cambiar si no se pudo</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {

            if (u!=a)
            {
                u.Alumnos.Add(a);
            }

            else
            {
                throw new AlumnoRepetidoException();
            }

            return u;

        }

        /// <summary>
        /// Agrega un profesor a la universidad si este aun no se encuentra en ella 
        /// </summary>
        /// <param name="u">universidad 1</param>
        /// <param name="i">profesor 1</param>
        /// <returns>retorna la universidad con el profesor cargado si se pudo guardar y la universidad sin cambiar si no se pudo</returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
            {
                u.Instructores.Add(i);
            }

            return u;
        }


        #endregion

        #region Metodos

        /// <summary>
        /// Metodo que muestra los datos de la Universidad
        /// </summary>
        /// <param name="uni">universidad a mostrar</param>
        /// <returns>retorna una cadena con los datos de la universidad</returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendLine("JORNADA:");

            foreach (Jornada item in uni.Jornadas)
            {
                cadena.AppendLine(item.ToString());

            }

            return cadena.ToString();
        }

        /// <summary>
        /// Metodo estatico para serializar los datos de Universidad y guardarlos en un archivo xml
        /// </summary>
        /// <param name="uni">universidad a guardar</param>
        /// <returns>retorna true si se pudo serializar y falso si no</returns>
        public static bool Guardar(Universidad uni)
        {
            bool retorno = false;

            Xml<Universidad> guardarXml = new Xml<Universidad>();

            retorno = guardarXml.Guardar(AppDomain.CurrentDomain.BaseDirectory + @"universidad.xml", uni);

            return retorno;
        }

        /// <summary>
        /// Metodo que deserializa un archivo xml de una universidad y lo guarda en otra variable de tipo universidad
        /// </summary>
        /// <returns>retorna la universidad deserializada</returns>
        public Universidad Leer()
        {

            Xml<Universidad> leerXml = new Xml<Universidad>();

            leerXml.Leer(AppDomain.CurrentDomain.BaseDirectory + @"universidad.xml", out Universidad auxUni);

            return auxUni;
        }

        /// <summary>
        /// Sobrescritura del metodo ToString
        /// </summary>
        /// <returns>retorna el mostrar datos de Universidad</returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }

        #endregion

    }
}
