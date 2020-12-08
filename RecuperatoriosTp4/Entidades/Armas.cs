using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    [Serializable]//Funciona para indicar que se serializa esta clase.
    [XmlInclude(typeof(ArmaMagica))]
    [XmlInclude(typeof(ArmaADistancia))]
    [XmlInclude(typeof(ArmaCuerpoACuerpo))]


    public abstract class Armas
    {
        string nombre;
        int idArma;
        int stock;
        double precio;

        ETipo tipoArma;

        /// <summary>
        /// Enumerado con todos los tipos de armas .
        /// </summary>
        public enum ETipo
        {
            armaADistancia,
            armaMagica,
            armaCuerpoACuerpo
        }


        #region Constructores


        /// <summary>
        /// Constructor de Arma
        /// </summary>
        public Armas()
        {


        }
        /// <summary>
        /// Constructor de tipo Arma ,crea los objetos de este mismo
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="idArticulo"></param>
        /// <param name="precio"></param>
        /// <param name="stock"></param>
        /// <param name="tipoArma"></param>
        public Armas(string nombre, int idArticulo, double precio, int stock, ETipo tipoArma) : this()
        {
            this.Nombre = nombre;
            this.Id = idArticulo;
            this.Precio = precio;
            this.Stock = stock;
            this.tipoArma = tipoArma;
        }
        #endregion

        #region Properties


        /// <summary>
        /// Get y Set de Nombre
        /// </summary>
        public string Nombre
        {
            get { return this.nombre; }

            set
            {
                this.nombre = value;

                if (String.IsNullOrEmpty(value))
                {
                    this.nombre = "No Cargado";
                }
            }
        }

        /// <summary>
        /// Get y Set de ID
        /// </summary>
        public int Id
        {
            get { return this.idArma; }

            set
            {
                this.idArma = value;

                if (Validaciones.ValidarNegativos(value))
                {
                    this.idArma = 0;
                }
            }
        }

        /// <summary>
        /// Get y Set de Precio
        /// </summary>
        public double Precio
        {
            get { return this.precio; }

            set
            {
                this.precio = value;

                if (Validaciones.ValidarNegativos(value))
                {
                    this.precio = 0;
                }
            }

        }

        /// <summary>
        /// Get y Set De Stock
        /// </summary>
        public int Stock
        {
            get { return this.stock; }

            set
            {
                this.stock = value;

                if (Validaciones.ValidarNegativos(value))
                {
                    this.stock = 0;
                }
            }
        }

        /// <summary>
        /// Get y Set de Tipo Arma
        /// </summary>
        public ETipo Tipo
        {
            get
            {
                return this.tipoArma;
            }

            set
            {
                this.tipoArma = value;
            }
        }
        #endregion

        #region Sobrecarga de operadores

        /// <summary>
        /// Verifica si un arma encuentra cargada en la lista
        /// </summary>
        /// <param name="armas"></param>
        /// <param name="auxArma"></param>
        /// <returns>true si lo encuentra, false caso contrario</returns>
        public static bool operator ==(List<Armas> armas, Armas auxArma)
        {

            foreach (Armas item in armas)
            {
                if (item.idArma == auxArma.idArma)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Verifica si un arma encuentra cargada en la lista
        /// </summary>
        /// <param name="armas"></param>
        /// <param name="auxArma"></param>
        /// <returns>true si no lo encuentra, false caso contrario</returns>
        public static bool operator !=(List<Armas> armas, Armas auxArma)
        {
            return !(armas == auxArma);
        }

        /// <summary>
        /// Verifica si una arna no esta cargado en la base de datos y lo agrega.
        /// </summary>
        /// <param name="armas"></param>
        /// <param name="auxArma"></param>
        /// <returns>true si logra cargar el articulo, si ya se encontraba en la lista lanza articulosEx/returns>
        public static bool operator +(List<Armas> armas, Armas auxArma)
        {

            if (armas != auxArma)
            {
                auxArma.Guardar();

                return true;
            }
            else
            {
                throw new ArmasEx("Esta Arma fue anteriormente cargado a la base de datos, solo se updatearan los datos!!");
            }

        }

        /// <summary>
        /// Verifica si una arna no esta cargado en la base de datos y lo elimino
        /// </summary>
        /// <param name="armas"></param>
        /// <param name="auxArma"></param>
        /// <returns>el objeto de tipo Armeria con la Arma borrada, si no se encontraba en la lista lanza articulosEx</returns>
        public static bool operator -(List<Armas> armas, Armas auxArma)
        {
            if (armas == auxArma)
            {
                auxArma.Eliminar();

                return true;
            }
            else
            {
                throw new ArmasEx("Esta Arma no se encuentra ingresada en la base de datos!!!");
            }


        }

        #endregion

        #region Metodos


        /// <summary>
        /// Override del metodo mostrar
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Mostrar();
        }

        /// <summary>
        /// Genera un Stringbuilder con los datos de las Armas
        /// </summary>
        /// <returns></returns>
        protected virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Nombre: {this.nombre}");
            sb.AppendLine($"Stock: {this.stock.ToString()}");
            sb.AppendLine($"ID Producto: {this.idArma.ToString()}");
            sb.AppendLine(String.Format("Precio: ${0: #,###.00}", this.precio));

            return sb.ToString();
        }


        /// <summary>
        /// Inserta el objeto Arma en la base de datos
        /// </summary>
        /// <returns>True si se inserto, false caso contrario</returns>
        public bool Guardar()
        {
            ArmasBaseDatos arma = new ArmasBaseDatos();
            return arma.InsertarArma(this);
        }

        /// <summary>
        /// Modificar el objeto Arma en la base de datos
        /// </summary>
        /// <returns>True si se modifico, false caso contrario</returns>
        public bool Modificar()
        {
            ArmasBaseDatos arma = new ArmasBaseDatos();
            return arma.ModificarArma(this);
        }


        /// <summary>
        /// Eliminar el objeto Arma de la base de datos
        /// </summary>
        /// <returns>True si se elimino, false caso contrario</returns>
        public bool Eliminar()
        {
            ArmasBaseDatos arma = new ArmasBaseDatos();
            return arma.EliminarArma(this);
        }


        #endregion
    }
}
