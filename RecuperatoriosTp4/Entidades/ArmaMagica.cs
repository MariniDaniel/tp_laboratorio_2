using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ArmaMagica : Armas
    {
        #region Constructores

        /// <summary>
        /// Constructor
        /// </summary>
        public ArmaMagica()
        {

        }

        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        /// <param name="descripcion"></param>
        /// <param name="idProducto"></param>
        /// <param name="precio"></param>
        /// <param name="stock"></param>
        /// <param name="tipoArma"></param>
        public ArmaMagica(string descripcion, int idProducto, double precio, int stock, ETipo tipoArma) : base(descripcion, idProducto, precio, stock, tipoArma)
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
            sb.AppendLine("$+---------------------------------+$");
            sb.AppendLine("\nArma Magica - Conjuradoras");
            sb.AppendLine("$+---------------------------------+$");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("Esta Arma tipo magica es potente media distancia e invoca criaturas.");


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
