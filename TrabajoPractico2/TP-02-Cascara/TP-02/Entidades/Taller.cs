using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public sealed class Taller
    {
        #region Atributos

        List<Vehiculo> vehiculos;
        int espacioDisponible;

        #endregion

        #region Enum de tipo
        public enum ETipo
        {
            Ciclomotor, Sedan, SUV, Todos
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor de taller, instancia la lista de vehiculo , en vehiculos
        /// </summary>
        private Taller()
        {
            this.vehiculos = new List<Vehiculo>();
        }

        /// <summary>
        /// Sobrecarga de constructor, Recibe el espacio disponible y lo pasa al atributo
        /// </summary>
        /// <param name="espacioDisponible"></param>
        public Taller(int espacioDisponible) : this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion

        #region Sobrecargas

        /// <summary>
        /// Sobrecarga de ToString, llamo a listar , le paso la lista y el tipo
        /// </summary>
        /// <returns>Devuelve un string con la lista de vehiculos </returns>
        public override string ToString()
        {
            return this.Listar(this, ETipo.Todos);
        }

        #endregion


        #region Métodos

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// Solo del tipo requerido
        /// </summary>
        /// <param name="taller">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns>Devuelve stringbuilder </returns>
        public string Listar(Taller taller, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", taller.vehiculos.Count, taller.espacioDisponible);
            sb.AppendLine("");
            foreach (Vehiculo v in taller.vehiculos)
            {
                switch (tipo)
                {
                    case ETipo.SUV:
                        if (v is Suv)
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        break;
                    case ETipo.Ciclomotor:
                        if (v is Ciclomotor)
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        break;
                    case ETipo.Sedan:
                        if (v is Sedan)
                        {

                            sb.AppendLine(v.Mostrar());
                        }
                        break;
                    default:
                        sb.AppendLine(v.Mostrar());
                        break;
                }
            }

            return sb.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="taller">Objeto donde se agregará el elemento</param>
        /// <param name="vehiculo">Objeto a agregar</param>
        /// <returns>Devuelve objeto de taller</returns>
        public static Taller operator +(Taller taller, Vehiculo vehiculo)
        {
            foreach (Vehiculo v in taller.vehiculos)
            {
                if (v == vehiculo)
                    return taller;
            }
            if (taller.vehiculos.Count < taller.espacioDisponible)
            {
                taller.vehiculos.Add(vehiculo);
            }
            return taller;
        }

        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="taller">Objeto donde se quitará el elemento</param>
        /// <param name="vehiculo">Objeto a quitar</param>
        /// <returns></returns>
        public static Taller operator -(Taller taller, Vehiculo vehiculo)
        {
            foreach (Vehiculo v in taller.vehiculos)
            {
                if (v == vehiculo)
                {
                    taller.vehiculos.Remove(vehiculo);
                    break;
                }
            }

            return taller;
        }
        #endregion
    }
}
