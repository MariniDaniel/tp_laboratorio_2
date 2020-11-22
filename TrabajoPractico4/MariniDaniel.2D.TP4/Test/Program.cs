using System;
using System.Collections.Generic;
using System.Threading;
using Entidades;
using Excepciones;

namespace ClaseDeTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Marini.Daniel.2D.TP4";

            // a= articulo
            //Articulos Perecederos
            AlimentoPerecedero a1 = new AlimentoPerecedero("Chocolate", 1, 10.15, 100, Articulo.ETipo.perecedero);
            AlimentoPerecedero a2 = new AlimentoPerecedero("Ricota", 2, 90.65, 86, Articulo.ETipo.perecedero);
            AlimentoPerecedero a3 = new AlimentoPerecedero("Hamburguesas", 3, 150.00, 25, Articulo.ETipo.perecedero);
            AlimentoPerecedero a4 = new AlimentoPerecedero("Leche", 4, 40.15, 70, Articulo.ETipo.perecedero);
            AlimentoPerecedero a5 = new AlimentoPerecedero("Milanesa", 5, 78.25, 45, Articulo.ETipo.perecedero);

            //Articulos No Perecederos
            AlimentoNoPerecedero a6 = new AlimentoNoPerecedero("Atun", 6, 160.20, 57, Articulo.ETipo.noPerecedero);
            AlimentoNoPerecedero a7 = new AlimentoNoPerecedero("Choclo En Lata", 7, 110.20, 6, Articulo.ETipo.noPerecedero);
            AlimentoNoPerecedero a8 = new AlimentoNoPerecedero("Garbanzos", 8, 23.00, 43, Articulo.ETipo.noPerecedero);
            AlimentoNoPerecedero a9 = new AlimentoNoPerecedero("Leche En Polvo", 9, 260.00, 67, Articulo.ETipo.noPerecedero);
            AlimentoNoPerecedero a10 = new AlimentoNoPerecedero("Azucar", 10, 50.99, 243, Articulo.ETipo.noPerecedero);

            //Articulos Semi-Perecederos
            AlimentoSemiPerecederos a11 = new AlimentoSemiPerecederos("Almendras", 11, 160, 243, Articulo.ETipo.semiPerecedero);
            AlimentoSemiPerecederos a12 = new AlimentoSemiPerecederos("Gramineas", 12, 15, 12, Articulo.ETipo.semiPerecedero);
            AlimentoSemiPerecederos a13 = new AlimentoSemiPerecederos("Batatas", 13, 70, 65, Articulo.ETipo.semiPerecedero);


            Venta venta = new Venta();

            Thread hilo1 = new Thread(Deposito.GenerarVentas);
            Thread hilo2 = new Thread(Deposito.GenerarVentasSegunda);

            try
            {
                Console.WriteLine("\nSE CARGAN Articulos!:");
                Console.WriteLine();

                //5 Articulos Perecederos
                if (Deposito.Articulos + a1)
                    Console.WriteLine($"Producto: {a1.Stock} cargado con exito");
                if (Deposito.Articulos + a2)
                    Console.WriteLine($"Producto: {a2.Stock} cargado con exito");
                if (Deposito.Articulos + a3)
                    Console.WriteLine($"Producto: {a3.Stock} cargado con exito");
                if (Deposito.Articulos + a4)
                    Console.WriteLine($"Producto: {a4.Stock} cargado con exito");
                if (Deposito.Articulos + a5)
                    Console.WriteLine($"Producto: {a5.Stock} cargado con exito");

                //5 Articulos No Perecederos
                if (Deposito.Articulos + a6)
                    Console.WriteLine($"Producto: {a6.Stock} cargado con exito");
                if (Deposito.Articulos + a7)
                    Console.WriteLine($"Producto: {a7.Stock} cargado con exito");
                if (Deposito.Articulos + a8)
                    Console.WriteLine($"Producto: {a8.Stock} cargado con exito");
                if (Deposito.Articulos + a9)
                    Console.WriteLine($"Producto: {a9.Stock} cargado con exito");
                if (Deposito.Articulos + a10)

                //3 Articulos SemiPerecederos
                    Console.WriteLine($"Producto: {a10.Stock} cargado con exito");
                if (Deposito.Articulos + a11)
                    Console.WriteLine($"Producto: {a11.Stock} cargado con exito");
                if (Deposito.Articulos + a12)
                    Console.WriteLine($"Producto: {a12.Stock} cargado con exito");
                if (Deposito.Articulos + a13)
                    Console.WriteLine($"Producto: {a13.Stock} cargado con exito");
            }
            catch (ArticulosEx e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Toque Cualquier Tecla Para Seguir!");
            Console.ReadKey();
            Console.Clear();

            try
            {
                Console.WriteLine("\nSe Muestran por pantalla los Articulos cargados en BD:");
                Console.WriteLine();
                Console.WriteLine(Deposito.MostrarArticulos());
            }
            catch (ArchivosEx e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.InnerException.Message);
            }

            Console.WriteLine("Toque Cualquier Tecla Para Seguir!");
            Console.ReadKey();
            Console.Clear();

            try
            {
                Console.WriteLine("\nSe Intenta Cargar Otra Vez! a1:");
                Console.WriteLine();

                if (Deposito.Articulos + a1)
                    Console.WriteLine($"Articulo: {a1.Stock} cargado con exito");

            }
            catch (ArticulosEx e)
            {

                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Toque Cualquier Tecla Para Seguir!");
            Console.ReadKey();
            Console.Clear();

            try
            {
                Console.WriteLine("\nSE AGREGAN ARTICULOS A LA VENTA:");
                Console.WriteLine();

                venta += 1;
                venta += 2;
                venta += 3;
                venta += 4;
                venta += 5;

            }
            catch (VentasEx e)
            {

                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Toque Cualquier Tecla Para Seguir!");
            Console.ReadKey();
            Console.Clear();

            try
            {
                Console.WriteLine("\nSe intenta cargar ID = 27 inexistente: ");
                Console.WriteLine();

                venta += 27;

            }
            catch (VentasEx e)
            {

                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Toque Cualquier Tecla Para Seguir!");
            Console.ReadKey();
            Console.Clear();

            try
            {
                Console.WriteLine("\nSE CIERRA LA VENTA (Esto hace que se guarde el ticket en txt):");
                Console.WriteLine();

                if (Deposito.Ventas + venta)
                    Console.WriteLine($"Venta guardada con exito. Ticket Nro: {venta.NumeroDeTicket}");

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);

            }

            Console.WriteLine("Toque Cualquier Tecla Para Seguir!");
            Console.ReadKey();
            Console.Clear();

            try
            {
                hilo1.Name = "Punto de venta 1";
                hilo2.Name = "Punto de venta 2";

                Console.WriteLine("SE GENERAN VENTAS DESDE DOS HILOS DIFERENTES");

                hilo1.Start();
                hilo2.Start();
                Thread.Sleep(8000);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }

          

            Console.WriteLine("Toque Cualquier Tecla Para Seguir!");
            Console.ReadKey();
            Console.Clear();

            try
            {
                Console.WriteLine("\nSE IMPRIME EL LISTADO DE ARTICULOS PARA VERIFICAR QUE BAJO EL STOCK DE LOS ARTICULOS VENDIDOS: ");
                Console.WriteLine();

                Console.WriteLine(Deposito.MostrarArticulos());
            }
            catch (ArchivosEx e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.InnerException.Message);
            }

            Console.WriteLine("Toque Cualquier Tecla Para Seguir!");
            Console.ReadKey();
            Console.Clear();

            try
            {
                Console.WriteLine("\nLOS METODOS DE EXTENSION CALCULAN EL STOCK TOTAL CONTENIDO EN LA BASE DE DATOS Y LA SUMATORIA DE MONTOS TOTALES DEL LISTADO DE VENTAS");
                Console.WriteLine();

                Console.WriteLine($"Stock total: {Deposito.Articulos.StockTotal()}");
                Console.WriteLine($"Acumulado de ventas: ${Deposito.Ventas.VentasTotales()}");

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Toque Cualquier Tecla Para Seguir!");
            Console.ReadKey();
            Console.Clear();

            try
            {
                Console.WriteLine("\nSE GUARDA EL LISTADO DE VENTAS EN UN ARCHIVO XML");
                Console.WriteLine();
                if (Deposito.Guardar(Deposito.Ventas))
                    Console.WriteLine("Guardado con exito");

            }
            catch (ArchivosEx e)
            {

                Console.WriteLine(e.Message);
                Console.WriteLine(e.InnerException.Message);
            }

            Console.WriteLine("Toque Cualquier Tecla Para Seguir!,ESTE ES LA ULTIMA VEZ!!");
            Console.WriteLine("Hasta la proxima!Vuelva prontos");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
