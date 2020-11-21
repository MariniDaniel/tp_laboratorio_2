using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Excepciones;

namespace Entidades
{



    [Serializable]//Indico que puedo serializar esta clase ,no se podra heredar
    [XmlInclude(typeof(AlimentoPerecedero))]
    [XmlInclude(typeof(AlimentoNoPerecedero))]

    public abstract class Articulo
    {
        string nombre;
        int idArticulo;
        int stock;
        double precio;

        ETipo tipoArticulo;

        /// <summary>
        /// Enumerado con tipos de articulos .
        /// </summary>
        public enum ETipo
        {
            noPerecedero,
            perecedero,
        }


        #region Constructores


        /// <summary>
        /// Constructor de Articulo
        /// </summary>
        public Articulo()
        {


        }
        /// <summary>
        /// Constructor de tipo Articulo,crea los objetos de este mismo
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="idArticulo"></param>
        /// <param name="precio"></param>
        /// <param name="stock"></param>
        /// <param name="tipoProducto"></param>
        public Articulo(string nombre, int idArticulo, double precio, int stock, ETipo tipoProducto) : this()
        {
            this.Nombre = nombre;
            this.Id = idArticulo;
            this.Precio = precio;
            this.Stock = stock;
            this.tipoArticulo = tipoProducto;
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
            get { return this.idArticulo; }

            set
            {
                this.idArticulo = value;

                if (Validaciones.ValidarNegativos(value))
                {
                    this.idArticulo = 0;
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
        /// Get y Set de Tipo Articulo
        /// </summary>
        public ETipo Tipo
        {
            get
            {
                return this.tipoArticulo;
            }

            set
            {
                this.tipoArticulo = value;
            }
        }
        #endregion

        #region Sobrecarga de operadores

        /// <summary>
        /// Verifica si un articulo se encuentra cargado en la lista
        /// </summary>
        /// <param name="articulos"></param>
        /// <param name="auxArticulo"></param>
        /// <returns>true si lo encuentra, false caso contrario</returns>
        public static bool operator ==(List<Articulo> articulos, Articulo auxArticulo)
        {

            foreach (Articulo item in articulos)
            {
                if (item.idArticulo == auxArticulo.idArticulo)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Verifica si un articulo no se encuentra cargado en la lista
        /// </summary>
        /// <param name="articulos"></param>
        /// <param name="auxArticulo"></param>
        /// <returns>true si no lo encuentra, false caso contrario</returns>
        public static bool operator !=(List<Articulo> articulos, Articulo auxArticulo)
        {
            return !(articulos == auxArticulo);
        }

        /// <summary>
        /// Verifica si un articulo no esta cargado en la base de datos y lo agrega.
        /// </summary>
        /// <param name="articulos"></param>
        /// <param name="auxArticulo"></param>
        /// <returns>true si logra cargar el articulo, si ya se encontraba en la lista lanza articulosEx/returns>
        public static bool operator +(List<Articulo> articulos, Articulo auxArticulo)
        {

            if (articulos != auxArticulo)
            {
                auxArticulo.Guardar();

                return true;
            }
            else
            {
                throw new ArticulosEx("Articulo anteriormente cargado a la base de datos, solo se updatearan los datos!!");
            }

        }

        /// <summary>
        /// Verifica si un articulo no esta cargado en la base de datos y lo elimino
        /// </summary>
        /// <param name="articulos"></param>
        /// <param name="auxArticulo"></param>
        /// <returns>el objeto de tipo Deposito con el articulo borrado, si no se encontraba en la lista lanza articulosEx</returns>
        public static bool operator -(List<Articulo> productos, Articulo auxProducto)
        {
            if (productos == auxProducto)
            {
                auxProducto.Eliminar();

                return true;
            }
            else
            {
                throw new ArticulosEx("Este articulo no se encuentra ingresado en la base de datos!!!");
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
        /// Genera un Stringbuilder con los datos del Articulo
        /// </summary>
        /// <returns></returns>
        protected virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Nombre: {this.nombre}");
            sb.AppendLine($"Stock: {this.stock.ToString()}");
            sb.AppendLine($"ID Producto: {this.idArticulo.ToString()}");
            sb.AppendLine(String.Format("Precio: ${0: #,###.00}", this.precio));

            return sb.ToString();
        }


        /// <summary>
        /// Inserta el objeto Articulo en la base de datos
        /// </summary>
        /// <returns>True si se inserto, false caso contrario</returns>
        public bool Guardar()
        {
            ArticuloBaseDatos articulo = new ArticuloBaseDatos();
            return articulo.InsertarProducto(this);
        }

        /// <summary>
        /// Modificar el objeto articulo en la base de datos
        /// </summary>
        /// <returns>True si se modifico, false caso contrario</returns>
        public bool Modificar()
        {
            ArticuloBaseDatos articulo = new ArticuloBaseDatos();
            return articulo.ModificarProducto(this);
        }


        /// <summary>
        /// Eliminar el objeto articulo de la base de datos
        /// </summary>
        /// <returns>True si se elimino, false caso contrario</returns>
        public bool Eliminar()
        {
            ArticuloBaseDatos articulo = new ArticuloBaseDatos();
            return articulo.EliminarArticulo(this);
        }


        #endregion
    }
}
