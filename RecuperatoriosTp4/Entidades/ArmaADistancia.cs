using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ArmaADistancia :Armas
    {
        #region Constructores

        /// <summary>
        /// Constructor De Arma
        /// </summary>
        public ArmaADistancia()
        {

        }

        /// <summary>
        /// Constructor parametrizado de Arma
        /// </summary>
        /// <param name="descripcion"></param>
        /// <param name="idProducto"></param>
        /// <param name="precio"></param>
        /// <param name="stock"></param>
        /// <param name="tipoArma"></param>
        public ArmaADistancia(string descripcion, int idProducto, double precio, int stock, ETipo tipoArma) : base(descripcion, idProducto, precio, stock, tipoArma)
        {

        }

        #endregion

        #region Metodos

        /// <summary>
        /// override del metodo Mostrar de ArmaADistancia
        /// </summary>
        /// <returns>todos los datos del objeto</returns>
        protected override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("$+---------------------------------+$");
            sb.AppendLine("\nArma A Distancia ");
            sb.AppendLine("$+---------------------------------+$");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("Esta Arma se utiliza para pelear a distancias largas.");


            return sb.ToString();
        }

        /// <summary>
        /// override del metodo ToString
        /// </summary>
        /// <returns>los datos del metodo mostrar</returns>
        public override string ToString()
        {
            return this.Mostrar();
        }
        #endregion
    }
}
