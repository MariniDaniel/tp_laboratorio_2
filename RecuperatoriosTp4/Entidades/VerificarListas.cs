using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class VerificarListas
    {
        /// <summary>
        /// Calcula el stock total de Armas contenidos en una lista (stock total)
        /// </summary>
        /// <param name="listaArticulos"></param>
        /// <returns>el acumulado de la variable stock</returns>
        public static int StockTotal(this List<Armas> listaArticulos)
        {
            int acumuladorStock = 0;

            foreach (Armas articulo in listaArticulos)
            {
                acumuladorStock += articulo.Stock;
            }

            return acumuladorStock;
        } 



        /// <summary>
        /// Calcula el monto total de ventas obtenidas en un listado de tipo Venta
        /// </summary>
        /// <param name="listaVentas"></param>
        /// <returns>acumulo de ventas</returns>
        public static double VentasTotales(this List<Venta> listaVentas)
        {
            double montoAcumulado = 0;

            foreach (Venta venta in listaVentas)
            {
                montoAcumulado += venta.MontoTotal;
            }

            return montoAcumulado;
        }
    }
}
