using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        #region Enumerados

        /// <summary>
        /// Enumerado de tipo ENacionalidad
        /// </summary>
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        #endregion

        #region Atributos

        private int dni;
        private string nombre;
        private string apellido;
        private ENacionalidad nacionalidad;

        #endregion

        #region Propiedades

        /// <summary>
        /// Propiedad que hace publico el apellido y setea el dato una vez validado
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = this.ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Propiedad que hace publico el dni y setea el dato una vez validado
        /// </summary>
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = this.ValidarDni(this.nacionalidad,value);
            }
        }

        /// <summary>
        /// Propiedad que hace publica la nacionalidad y la setea con el valor pasado
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }

        /// <summary>
        /// Propiedad que hace publico el nombre y lo setea con el valor pasado
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = this.ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// recibe el valor del dni en formato cadena para despues validarlo y setearlo
        /// </summary>
        public string StringToDNI
        {
            set
            {
                this.dni = this.ValidarDni(this.nacionalidad, value);
            }        

        }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor de Persona por defecto
        /// </summary>
        public Persona()
        {

        }

        /// <summary>
        /// Sobrecarga del constructor Persona con 3 parametros
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            
            this.Apellido = apellido;
            this.Nombre = nombre;
            this.Nacionalidad = nacionalidad;

        }

        /// <summary>
        /// Sobrecarga del constructor Persona con 4 parametros
        /// </summary>
        /// <param name="nombre">nombre de la persona</param>
        /// <param name="apellido">apellido de la persona</param>
        /// <param name="dni">dni de la persona</param>
        /// <param name="nacionalidad">nacionalidad de la persona</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad):this(nombre,apellido,nacionalidad)
        {
            this.DNI = dni;

        }

        /// <summary>
        /// Sobrecarga del constructor Persona con 4 parametros y el dni en formato string
        /// </summary>
        /// <param name="nombre">nombre de la persona</param>
        /// <param name="apellido">apellido de la persona</param>
        /// <param name="dni">dni de la persona en formato string</param>
        /// <param name="nacionalidad">nacionalidad de la persona</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        #endregion

        #region  Metodos

        /// <summary>
        /// Sobreescritura del metodo ToString que muestara los atributos de la clase
        /// </summary>
        /// <returns>Retorna una cadena con los datos de la persona</returns>
        public override string ToString()
        {
            StringBuilder cadena = new StringBuilder();

            cadena.AppendFormat("NOMBRE COMPLETO: {0},{1}\n",this.Nombre,this.Apellido);
            cadena.AppendFormat("NACIONALIDAD: {0}\n",this.Nacionalidad);
           
            return cadena.ToString();
        }

        #endregion

        #region Validaciones

        /// <summary>
        /// Sobrecarga del metodo ValidarDni
        /// </summary>
        /// <param name="nacionalidad">nacionalidad de la persona a validar</param>
        /// <param name="dato">dato a validar</param>
        /// <returns>retorna el dni si la validacion fue correcta y una exepcion si no lo fue</returns>
        private int ValidarDni(ENacionalidad nacionalidad,int dato)
        {
            return ValidarDni(nacionalidad,dato.ToString());
        }


        /// <summary>
        ///Valida el formato del dni y que sea correcto dependiendo la nacionalidad de cada persona
        /// </summary>
        /// <param name="nacionalidad">nacionalidad de la persona a validar</param>
        /// <param name="dato">dato a validar en formato string</param>
        /// <returns>retorna el dni si la validacion fue correcta y una exepcion si no lo fue</returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int retorno=0;
            int dni;

            if (Int32.TryParse(dato,out dni) && dato.Length <= 8 && dato.Length >= 1)
            {
                if (dni >= 1 && dni <= 89999999 && nacionalidad == ENacionalidad.Argentino)
                {
                    retorno = dni;
                }
               else if (dni >= 90000000 && dni <= 99999999 && nacionalidad == ENacionalidad.Extranjero)
                {
                    retorno = dni;
                }
                else
                {
                    throw new NacionalidadInvalidaException();
                }

            }
            else
            {
                throw new DniInvalidoException();
            }

            return retorno;

        }


        /// <summary>
        /// Valida que los nombres sean cadenas con caracteres válidos para nombre
        /// </summary>
        /// <param name="dato">dato a validar en formato string</param>
        /// <returns>retorna el nombre si la validacion fue correcta y una cadena vacia si no lo fue</returns>
        private string ValidarNombreApellido(string dato)
        {
        
            bool flag=false;     

            foreach (char c in dato)
            {
                if (!Char.IsLetter(c))
                {

                    flag = true;
                    break;
               }
            }

            if (flag)
            {
                dato = "";
            }

            return dato;
        }

        #endregion

    }
}
