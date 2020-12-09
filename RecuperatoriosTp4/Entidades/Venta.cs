using Archivos;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{

    public delegate bool VentasDelegado(Venta venta);

    public class Venta

    {
        private List<Armas> armas;
        private string numeroDeTicket;
        private double montoTotal;

        public static event VentasDelegado delVentas;

        #region Constructores

        /// <summary>
        /// Constructor estatico. enlaza con el delegado
        /// </summary>
        static Venta()
        {
            delVentas += VerificarMontoTotal;
            delVentas += Armeria.ModificarStock;
            delVentas += ImprimirTicket;
            delVentas += Armeria.CargarVenta;
        }


        /// <summary>
        /// Constructor , seteo el ticket en 0
        /// </summary>
        public Venta()
        {
            numeroDeTicket = "0";

            armas = new List<Armas>();

            montoTotal = 0;
        }

        #endregion

        #region Propiedades

        /// <summary>
        /// Get y Set de lista de armas
        /// </summary>
        public List<Armas> Armas
        {
            get => armas;
            set => armas = value;
        }

        /// <summary>
        /// Get y set de numero de ticket
        /// </summary>
        public string NumeroDeTicket
        {
            get => numeroDeTicket;
            set => numeroDeTicket = value;
        }

        /// <summary>
        /// Get y Set de monto total a pagar
        /// </summary>
        public double MontoTotal
        {
            get => montoTotal;
            set => montoTotal = value;
        }


        #endregion

        #region Metodos


        /// <summary>
        /// imprime un ticket en formato txt
        /// </summary>
        /// <param name="venta"></param>
        /// <returns>true si imprimio el ticket, caso contrario false</returns>
        public static bool ImprimirTicket(Venta venta)
        {
            string ticket = DateTime.Now.ToString("ddMMyyHHmmss");
            string ruta;

            venta.numeroDeTicket = ticket;

            if (Thread.CurrentThread.Name == "Punto de venta 2")
            {
                venta.numeroDeTicket += "_02";
            }
            else
            {
                venta.numeroDeTicket += "_01";
            }

            ruta = AppDomain.CurrentDomain.BaseDirectory + venta.numeroDeTicket;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Ticket Nro: {venta.numeroDeTicket}");
            foreach (Armas item in venta.armas)
            {
                sb.AppendLine(String.Format("Nombre: {0} Precio: ${1: #,###.00}", item.Nombre, item.Precio));
            }

            sb.AppendLine(String.Format("Monto total: ${0: #,###.00}", venta.montoTotal));
            sb.AppendLine("<-------------------------------------------->");

            Texto texto = new Texto();

            return texto.Guardar(ruta, sb.ToString());
        }

        /// <summary>
        /// lee un ticket guardado en formato txt
        /// </summary>
        /// <param name="ruta"></param>
        /// <returns>los datos guardados</returns>
        public static string LeerTXT(string ruta)
        {
            string datos;

            Texto auxTexto = new Texto();

            auxTexto.Leer(ruta, out datos);

            return datos;
        }

        /// <summary>
        /// Calcula y asigna el valor del monto total de una venta
        /// </summary>
        /// <param name="venta"></param>
        /// <returns>true si se se efectua la carga, false caso contrario</returns>
        public static bool VerificarMontoTotal(Venta venta)
        {
            if (venta != null)
            {
                foreach (Armas item in venta.armas)
                {
                    venta.montoTotal += item.Precio;
                }

                return true;
            }

            return false;
        }

        #endregion

        #region Sobrecargas


        /// <summary>
        /// agrega un nueva Arma a la venta a traves de id. verifica anteriormente que exista stock suficiente.
        /// </summary>
        /// <param name="venta"></param>
        /// <param name="id"></param>
        /// <returns>objeto venta con el arma cargada. si no puede cargados lanza VentasEx</returns>
        public static Venta operator +(Venta venta, int id)
        {
            Armas art = (venta == id);

            if (art != null && art.Stock > 0)
            {
                art.Stock = 1;
                venta.armas.Add(art);

            }
            else
            {
                throw new VentasEx("No se pudo ingresar el Arma a la lista. verificar el ID o si hay stock!!");
            }

            return venta;
        }

        /// <summary>
        /// Verifica a traves del id indicado si la Arma existe en la base de datos
        /// </summary>
        /// <param name="venta"></param>
        /// <param name="id"></param>
        /// <returns>si el Arma solicitada, si no existe lo devuelve en null</returns>
        public static Armas operator ==(Venta venta, int id)
        {
            Armas art = null;

            foreach (var item in Armeria.Armas)
            {
                if (item.Id == id)
                {
                    art = item;
                    break;
                }
            }

            return art;
        }

        /// <summary>
        /// retorna la primer Arma que no coincida con el id indicado
        /// </summary>
        /// <param name="venta"></param>
        /// <param name="id"></param>
        /// <returns>objeto de tipo arma</returns>
        public static Armas operator !=(Venta venta, int id)
        {
            Armas artic = null;

            foreach (var item in Armeria.Armas)
            {
                if (item.Id != id)
                {
                    artic = item;
                    break;
                }
            }

            return artic;
        }

        /// <summary>
        /// Carga una nueva venta a la lista. Descuenta del stock los armas comprados e imprime el ticket de compra en formato txt
        /// </summary>
        /// <param name="listaVentas"></param>
        /// <param name="v"></param>
        /// <returns>true si se cargo la venta, false caso contrario</returns>
        public static bool operator +(List<Venta> listaVentas, Venta v)
        {
            if (listaVentas != v)
            {
                delVentas(v);

                return true;
            }
            else
            {
                throw new VentasEx("Esta venta ya se encuentra cerrada");
            }
        }


        /// <summary>
        /// Verifica si una venta ya esta cargada a la lista de ventas
        /// </summary>
        /// <param name="listaVentas"></param>
        /// <param name="v"></param>
        /// <returns>true si esta cargada, false caso contrario</returns>
        public static bool operator ==(List<Venta> listaVentas, Venta v)
        {
            foreach (Venta item in listaVentas)
            {
                if (item.NumeroDeTicket == v.NumeroDeTicket)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Verifica si una venta no esta cargada a la lista de ventas
        /// </summary>
        /// <param name="listaVentas"></param>
        /// <param name="v"></param>
        /// <returns>true si no esta cargada, false caso contrario</returns>
        public static bool operator !=(List<Venta> listaVentas, Venta v)
        {
            return !(listaVentas == v);
        }




        #endregion
    }
}
