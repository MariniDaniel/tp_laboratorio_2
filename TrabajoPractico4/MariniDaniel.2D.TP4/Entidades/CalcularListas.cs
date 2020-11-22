using Entidades;

namespace System.Collections.Generic
{
    public static class ListExtension
    {


        /// <summary>
        /// Calcula el stock total de articulos contenidos en una lista (stock total)
        /// </summary>
        /// <param name="listaArticulos"></param>
        /// <returns>el acumulado de la variable stock</returns>
        public static int StockTotal(this List<Articulo> listaArticulos)
        {
            int acumuladorStock = 0;

            foreach (Articulo articulo in listaArticulos)
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
