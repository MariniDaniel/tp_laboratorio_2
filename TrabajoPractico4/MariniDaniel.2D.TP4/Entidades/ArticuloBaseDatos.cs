﻿using Excepciones;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Entidades
{
    public class ArticuloBaseDatos
    {
        private protected SqlConnection sqlConexion;
        private protected SqlCommand sqlComando;



        #region Constructores


        /// <summary>
        /// Constructor base de datos
        /// </summary>
        public ArticuloBaseDatos()
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
        public bool InsertarProducto(Articulo art)
        {
            string sql = "Insert into articulos(nombre,idArticulo,precio,stock,tipoArticulo) " +
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
        public bool ModificarProducto(Articulo art)
        {
            string sql = "Update articulos Set nombre = @auxNombre, idArticulo = @auxID, " +
                "precio = @auxPrecio, stock = @auxStock, tipoArticulo = @auxTipo where idArticulo = @auxID";

            sqlComando.Parameters.Add(new SqlParameter("@auxNombre", art.Nombre));
            sqlComando.Parameters.Add(new SqlParameter("@auxID", art.Id));
            sqlComando.Parameters.Add(new SqlParameter("@auxPrecio", art.Precio));
            sqlComando.Parameters.Add(new SqlParameter("@auxStock", art.Stock));
            sqlComando.Parameters.Add(new SqlParameter("@auxTipo", art.Tipo.ToString()));

            return EjecutarNonQuery(sql);
        }

        /// <summary>
        /// Se Elimina un articulo de la base de datos
        /// </summary>
        /// <param name="art"></param>
        /// <returns>true si se elimino, false lo contrario</returns>
        public bool EliminarArticulo(Articulo art)
        {
            string sql = "Delete articulos where id = @auxID";

            sqlComando.Parameters.Add(new SqlParameter("@auxID", art.Id));

            return EjecutarNonQuery(sql);
        }

        /// <summary>
        /// Se Trae el listado de articulos guardados en la base de datos de sql
        /// </summary>
        /// <returns>Lista de articulos</returns>
        public List<Articulo> Leer()
        {
            List<Articulo> articulos = new List<Articulo>();

            try
            {
                sqlComando.CommandText = "Select * from articulos";//se elecciona todo de articulos

                sqlConexion.Open();

                SqlDataReader reader = sqlComando.ExecuteReader();

                while (reader.Read())
                {
                    string tipo = reader["tipoArticulo"].ToString();               
                    if (tipo == "perecedero")//Se pregunta para separar los tipos
                    {
                        articulos.Add(new AlimentoPerecedero(reader["nombre"].ToString(), int.Parse(reader["idArticulo"].ToString()),
                        double.Parse(reader["Precio"].ToString()), int.Parse(reader["stock"].ToString()), Articulo.ETipo.perecedero));

                    }//semiperecedero
                    else if (tipo =="semiPerecedero")
                    {
                        articulos.Add(new AlimentoSemiPerecederos(reader["nombre"].ToString(), int.Parse(reader["idArticulo"].ToString()),
                        double.Parse(reader["Precio"].ToString()), int.Parse(reader["stock"].ToString()), Articulo.ETipo.semiPerecedero));
                    }
                    else//No perecederos
                    {
                        articulos.Add(new AlimentoNoPerecedero(reader["nombre"].ToString(), int.Parse(reader["idArticulo"].ToString()),
                        double.Parse(reader["Precio"].ToString()), int.Parse(reader["stock"].ToString()), Articulo.ETipo.noPerecedero));

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
        /// Se Trae un articulo de la base de datos selecciona por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Objeto de tipo articulo</returns>
        public Articulo LeerPorID(int id)
        {
            Articulo art = null;

            try
            {
                sqlComando.CommandText = "Select * from articulos where id = " + id.ToString();

                sqlConexion.Open();

                SqlDataReader reader = sqlComando.ExecuteReader();

                while (reader.Read())
                {
                    string tipo = reader["tipoArticulo"].ToString();

                    if (tipo == "perecedero")
                    {
                        art = new AlimentoPerecedero(reader["nombre"].ToString(), id,
                        double.Parse(reader["Precio"].ToString()), int.Parse(reader["stock"].ToString()), Articulo.ETipo.perecedero);

                    }
                    else if (tipo == "semiPerecedero")
                    {
                        art = new AlimentoPerecedero(reader["nombre"].ToString(), id,
                        double.Parse(reader["Precio"].ToString()), int.Parse(reader["stock"].ToString()), Articulo.ETipo.semiPerecedero);
                    }
                    else
                    {
                        art = new AlimentoNoPerecedero(reader["nombre"].ToString(), id,
                        double.Parse(reader["Precio"].ToString()), int.Parse(reader["stock"].ToString()), Articulo.ETipo.noPerecedero);
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
