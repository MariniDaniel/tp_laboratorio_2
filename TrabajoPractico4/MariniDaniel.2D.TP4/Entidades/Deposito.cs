using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace Entidades
{
    public static class Deposito
    {


        static private List<Venta> ventas;

        #region Constructor

        /// <summary>
        /// Constructor de ventas
        /// </summary>
        static Deposito()
        {
            ventas = new List<Venta>();
        }

        #endregion

        #region Propiedades
        /// <summary>
        /// Retorna la lista de articulos cargada en la base de contenido
        /// </summary>
        public static List<Articulo> Articulos
        {
            get
            {
                List<Articulo> articulos = new List<Articulo>();
                ArticuloBaseDatos art = new ArticuloBaseDatos();

                return articulos = art.Leer();
            }

        }

        /// <summary>
        /// Get y set lista de ventas
        /// </summary>
        public static List<Venta> Ventas
        {
            get => ventas;

        }
        #endregion


        #region Metodos

        /// <summary>
        /// Guarda el listado de ventas en archivo XML
        /// </summary>
        /// <param name="ventas"></param>
        /// <returns>true si lo guardo, false caso contrario</returns>
        public static bool Guardar(List<Venta> ventas)
        {
            string ruta = String.Concat(AppDomain.CurrentDomain.BaseDirectory, "inventario.xml");

            Xml<List<Venta>> auxXML = new Xml<List<Venta>>();

            return auxXML.Guardar(ruta, ventas);
        }

        /// <summary>
        /// Lee el listado de ventas guardado en un archivo XML
        /// </summary>
        /// <returns>una lista de tipo List<Venta></returns>
        public static List<Venta> Leer()
        {
            List<Venta> contenido = new List<Venta>();

            string ruta = String.Concat(AppDomain.CurrentDomain.BaseDirectory, "inventario.xml");

            Xml<List<Venta>> auxXML = new Xml<List<Venta>>();

            auxXML.Leer(ruta, out contenido);

            return contenido;

        }

        /// <summary>
        /// muestra el listado de articulos cargados en la base de contenido
        /// </summary>
        /// <returns>los contenidos cargados</returns>
        public static string MostrarArticulos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Listado De articulos");
            sb.AppendLine("$*********************************************************$");

            foreach (Articulo item in Deposito.Articulos)
            {
                sb.AppendLine(item.ToString());
            }

            sb.AppendLine("$********************************************************$");

            return sb.ToString();
        }

        /// <summary>
        /// Genera un hardcone de ventas a traves de un trheads
        /// </summary>
        public static void GenerarVentas()
        {
            try
            {
                Venta venta01 = new Venta();
                venta01 += 1;
                venta01 += 2;
                venta01 += 3;
                venta01 += 4;
                if (Deposito.Ventas + venta01)
                {
                    Thread.Sleep(2500);
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine($"Se genero una nueva venta en {Thread.CurrentThread.Name} ticket Nro.: {venta01.NumeroDeTicket}");
                }
            }
            catch (VentasEx e)//por si explota algo dejo esto *si me acuerdo descomentarlo dani dek futuro acordate pls*
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                Venta venta02 = new Venta();
                venta02 += 1;
                venta02 += 2;
                venta02 += 3;
                venta02 += 4;
                if (Deposito.Ventas + venta02)
                {
                    Thread.Sleep(2500);
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine($"Se genero una nueva venta en {Thread.CurrentThread.Name} ticket Nro.: {venta02.NumeroDeTicket}");
                }

            }
            catch (VentasEx e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {

                Venta venta03 = new Venta();
                venta03 += 1;
                venta03 += 2;
                venta03 += 3;
                venta03 += 4;
                if (Deposito.Ventas + venta03)
                {
                    Thread.Sleep(2500);
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine($"Se genero una nueva venta en {Thread.CurrentThread.Name} ticket Nro.: {venta03.NumeroDeTicket}");
                }

            }
            catch (VentasEx e)
            {
                Console.WriteLine(e.Message);
            }

        }

        /// <summary>
        /// // Genera un hardcodeo de ventas a traves de un thread
        /// </summary>
        public static void GenerarVentasSegunda()
        {

            try
            {
                Venta venta01 = new Venta();
                venta01 += 1;
                venta01 += 2;
                venta01 += 3;
                venta01 += 4;
                if (Deposito.Ventas + venta01)
                {
                    Thread.Sleep(2500);
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"Se genero una nueva venta en {Thread.CurrentThread.Name} ticket Nro.: {venta01.NumeroDeTicket}");
                }
            }
            catch (VentasEx e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                Venta venta02 = new Venta();
                venta02 += 1;
                venta02 += 2;
                venta02 += 3;
                venta02 += 4;
                if (Deposito.Ventas + venta02)
                {
                    Thread.Sleep(2500);
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"Se genero una nueva venta en {Thread.CurrentThread.Name} ticket Nro.: {venta02.NumeroDeTicket}");
                }
            }
            catch (VentasEx e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {

                Venta venta03 = new Venta();
                venta03 += 1;
                venta03 += 2;
                venta03 += 3;
                venta03 += 4;
                if (Deposito.Ventas + venta03)
                {
                    Thread.Sleep(2500);
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"Se genero una nueva venta en {Thread.CurrentThread.Name} ticket Nro.: {venta03.NumeroDeTicket}");
                }
            }
            catch (VentasEx e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Agrega una nueva venta a la lista de Deposito
        /// </summary>
        /// <param name="venta"></param>
        /// <returns>true si se cargo, false caso contrario</returns>
        public static bool CargarVenta(Venta venta)
        {
            if (venta != null)
            {
                Deposito.ventas.Add(venta);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Descuenta del stock un articulo agregado a la venta
        /// </summary>
        /// <param name="venta"></param>
        /// <returns>true si se desconto, false caso contrario</returns>
        public static bool ModificarStock(Venta venta)
        {
            if (venta != null)
            {
                Articulo art;

                for (int i = 0; i < venta.Articulos.Count; i++)
                {
                    for (int j = 0; j < Deposito.Articulos.Count; j++)
                    {
                        if (venta.Articulos[i].Id == Deposito.Articulos[j].Id)
                        {
                            art = Deposito.Articulos[j];
                            art.Stock -= 1;
                            art.Modificar();
                            break;
                        }
                    }
                }

                return true;
            }

            return false;
        }
        #endregion
    }
}
