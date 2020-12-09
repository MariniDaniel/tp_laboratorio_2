using Excepciones;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Entidades
{
 

    public class ArmasBaseDatos
    {

        private protected SqlConnection sqlConexion;
        private protected SqlCommand sqlComando;

        #region Constructores


        /// <summary>
        /// Constructor base de datos
        /// </summary>
        public ArmasBaseDatos()
        {
            sqlConexion = new SqlConnection();
            sqlConexion.ConnectionString = "Data Source=.\\sqlexpress; Initial Catalog=TrabajoPracticoN4; Integrated Security=True;";

            sqlComando = new SqlCommand();
            sqlComando.Connection = sqlConexion;
            sqlComando.CommandType = CommandType.Text;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Ejecuta ExecuteNonQuery en la sqlConexion SQL
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>True si se ejecuto, false de lo contrario</returns>
        public bool EjecutarNonQuery(string sql)
        {
            bool ejecuto = false;
            try
            {
                sqlComando.CommandText = sql;

                sqlConexion.Open();

                sqlComando.ExecuteNonQuery();

                ejecuto = true;
            }
            catch (Exception e)
            {
                ejecuto = false;
                throw new ArchivosEx("Error al intentar trabajar en la base de datos", e);
            }
            finally
            {
                sqlConexion.Close();
            }

            return ejecuto;
        }

        /// <summary>
        /// Inserta un Articulo a la base de datos
        /// </summary>
        /// <param name="art"></param>
        /// <returns>True si se guardo, false caso contrario</returns>
        public bool InsertarArma(Armas art)
        {
            string sql = "Insert into armas(nombre,idArma,precio,stock,tipoArma) " +
                "values(@auxNombre, @auxID, @auxPrecio, @auxStock, @auxTipo)";

            sqlComando.Parameters.Add(new SqlParameter("@auxNombre", art.Nombre));
            sqlComando.Parameters.Add(new SqlParameter("@auxID", art.Id));
            sqlComando.Parameters.Add(new SqlParameter("@auxPrecio", art.Precio));
            sqlComando.Parameters.Add(new SqlParameter("@auxStock", art.Stock));
            sqlComando.Parameters.Add(new SqlParameter("@auxTipo", art.Tipo.ToString()));

            return EjecutarNonQuery(sql);
        }

        /// <summary>
        /// Se Modifica un Articulo de la base de datos
        /// </summary>
        /// <param name="art"></param>
        /// <returns>True si se modifico, false lo contrario :D</returns>
        public bool ModificarArma(Armas art)
        {
            string sql = "Update Armas Set nombre = @auxNombre, idArma = @auxID, " +
                "precio = @auxPrecio, stock = @auxStock, tipoArma = @auxTipo where idArma = @auxID";

            sqlComando.Parameters.Add(new SqlParameter("@auxNombre", art.Nombre));
            sqlComando.Parameters.Add(new SqlParameter("@auxID", art.Id));
            sqlComando.Parameters.Add(new SqlParameter("@auxPrecio", art.Precio));
            sqlComando.Parameters.Add(new SqlParameter("@auxStock", art.Stock));
            sqlComando.Parameters.Add(new SqlParameter("@auxTipo", art.Tipo.ToString()));

            return EjecutarNonQuery(sql);
        }

        /// <summary>
        /// Se Elimina una Arma de la base de datos
        /// </summary>
        /// <param name="art"></param>
        /// <returns>true si se elimino, false lo contrario</returns>
        public bool EliminarArma(Armas art)
        {
            string sql = "Delete armas where id = @auxID";

            sqlComando.Parameters.Add(new SqlParameter("@auxID", art.Id));

            return EjecutarNonQuery(sql);
        }

        /// <summary>
        /// Se Trae el listado de armas guardados en la base de datos de sql
        /// </summary>
        /// <returns>Lista de armas</returns>
        public List<Armas> Leer()
        {
            List<Armas> articulos = new List<Armas>();

            try
            {
                sqlComando.CommandText = "Select * from Armas";//se elecciona todo de armas

                sqlConexion.Open();

                SqlDataReader reader = sqlComando.ExecuteReader();

                while (reader.Read())
                {
                    string tipo = reader["tipoArma"].ToString();
                    if (tipo == "armaMagica")//Se pregunta para separar los tipos
                    {
                        articulos.Add(new ArmaMagica(reader["nombre"].ToString(), int.Parse(reader["idArma"].ToString()),
                        double.Parse(reader["Precio"].ToString()), int.Parse(reader["stock"].ToString()), Armas.ETipo.armaMagica));

                    }//semiperecedero
                    else if (tipo == "armaCuerpoACuerpo")
                    {
                        articulos.Add(new ArmaCuerpoACuerpo(reader["nombre"].ToString(), int.Parse(reader["idArma"].ToString()),
                        double.Parse(reader["Precio"].ToString()), int.Parse(reader["stock"].ToString()), Armas.ETipo.armaCuerpoACuerpo));
                    }
                    else//No perecederos
                    {
                        articulos.Add(new ArmaADistancia(reader["nombre"].ToString(), int.Parse(reader["idArma"].ToString()),
                        double.Parse(reader["Precio"].ToString()), int.Parse(reader["stock"].ToString()), Armas.ETipo.armaADistancia));

                    }


                }

                reader.Close();
            }
            catch (Exception e)
            {

                throw new ArchivosEx("Falla al leer la base de datos!!!", e);

            }
            finally
            {
                sqlConexion.Close();//cierro conexion 
            }

            return articulos;
        }

        /// <summary>
        /// Se Trae una Arma de la base de datos selecciona por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Objeto de tipo articulo</returns>
        public Armas LeerPorID(int id)
        {
            Armas art = null;

            try
            {
                sqlComando.CommandText = "Select * from armas where id = " + id.ToString();

                sqlConexion.Open();

                SqlDataReader reader = sqlComando.ExecuteReader();

                while (reader.Read())
                {
                    string tipo = reader["tipoArma"].ToString();

                    if (tipo == "armaMagica")
                    {
                        art = new ArmaMagica(reader["nombre"].ToString(), id,
                        double.Parse(reader["Precio"].ToString()), int.Parse(reader["stock"].ToString()), Armas.ETipo.armaMagica);

                    }
                    else if (tipo == "armaCuerpoACuerpo")
                    {
                        art = new ArmaCuerpoACuerpo(reader["nombre"].ToString(), id,
                        double.Parse(reader["Precio"].ToString()), int.Parse(reader["stock"].ToString()), Armas.ETipo.armaCuerpoACuerpo);
                    }
                    else
                    {
                        art = new ArmaADistancia(reader["nombre"].ToString(), id,
                        double.Parse(reader["Precio"].ToString()), int.Parse(reader["stock"].ToString()), Armas.ETipo.armaADistancia);
                    }
                }


                reader.Close();
            }
            catch (Exception e)
            {
                throw new ArchivosEx("Falla al leer la base de datos!!!!", e);
            }
            finally
            {
                sqlConexion.Close();//aca tambien lo cierro en todos los finally
            }

            return art;
        }
        #endregion
    }
}
