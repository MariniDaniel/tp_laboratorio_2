using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class AlimentoPerecedero : Articulo
    {
        #region Constructores

        /// <summary>
        /// Constructor
        /// </summary>
        public AlimentoPerecedero()
        {

        }

        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        /// <param name="descripcion"></param>
        /// <param name="idProducto"></param>
        /// <param name="precio"></param>
        /// <param name="stock"></param>
        /// <param name="tipoProducto"></param>
        public AlimentoPerecedero(string descripcion, int idProducto, double precio, int stock, ETipo tipoProducto) : base(descripcion, idProducto, precio, stock, tipoProducto)
        {

        }
        #endregion

        #region Metodos
        /// <summary>
        /// override del metodo Mostrar
        /// </summary>
        /// <returns>todos los datos cargados en el objeto</returns>
        protected override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("\nPRODUCTO PERECEDERO");
            sb.AppendLine("--------------------------------------------------------------");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("Recuerde que este producto debe conservarse a baja temperatura");


            return sb.ToString();
        }

        /// <summary>
        /// override del metodo ToString
        /// </summary>
        /// <returns>los datos cargaddos en el metodo Mostrar</returns>
        public override string ToString()
        {
            return this.Mostrar();
        }
        #endregion
    }
}
