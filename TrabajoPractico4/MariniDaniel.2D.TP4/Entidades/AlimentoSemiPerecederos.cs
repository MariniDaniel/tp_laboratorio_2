﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class AlimentoSemiPerecederos : Articulo
    {

        #region Constructores

        /// <summary>
        /// Constructor
        /// </summary>
        public AlimentoSemiPerecederos()
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
        public AlimentoSemiPerecederos(string descripcion, int idProducto, double precio, int stock, ETipo tipoProducto) : base(descripcion, idProducto, precio, stock, tipoProducto)
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
            sb.AppendLine("\nArticulo Semi-Pedecederos");
            sb.AppendLine("$-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+$");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("Se debe conservar con buena humedad y calidad microbiana");


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