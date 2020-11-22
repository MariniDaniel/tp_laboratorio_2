using System.Text;

namespace Entidades
{
    public class AlimentoNoPerecedero : Articulo
    {


        #region Constructores

        /// <summary>
        /// Constructor De Alimentos
        /// </summary>
        public AlimentoNoPerecedero()
        {

        }

        /// <summary>
        /// Constructor parametrizado de Alimentos
        /// </summary>
        /// <param name="descripcion"></param>
        /// <param name="idProducto"></param>
        /// <param name="precio"></param>
        /// <param name="stock"></param>
        /// <param name="tipoProducto"></param>
        public AlimentoNoPerecedero(string descripcion, int idProducto, double precio, int stock, ETipo tipoProducto) : base(descripcion, idProducto, precio, stock, tipoProducto)
        {

        }

        #endregion

        #region Metodos
        /// <summary>
        /// override del metodo Mostrar
        /// </summary>
        /// <returns>todos los datos del objeto</returns>
        protected override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("\nARTICULO NO PERECEDERO");
            sb.AppendLine("$-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+$");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("Este Articulo Se Puede Conservar en cualquier ambiente.");


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
