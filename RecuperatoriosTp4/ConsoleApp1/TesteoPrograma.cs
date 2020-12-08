using System;
using System.Threading;
using Entidades;
using Excepciones;

namespace ClaseDeTest
{
    public class TesteoPrograma
    {
        static void Main(string[] args)
        {
            Console.Title = "Marini.Daniel.2D.TP4";

            // a= Arma
            //ARMAS MAGICAS
            ArmaMagica a1 = new ArmaMagica("Rayo De Zeus", 1, 1000, 100, Armas.ETipo.armaMagica);
            ArmaMagica a2 = new ArmaMagica("Arrasador de tormentas", 2, 1500, 86, Armas.ETipo.armaMagica);
            ArmaMagica a3 = new ArmaMagica("Baston De Baron", 3, 900, 25, Armas.ETipo.armaMagica);
            ArmaMagica a4 = new ArmaMagica("PALO NIVEL 1", 4, 50, 70, Armas.ETipo.armaMagica);
            ArmaMagica a5 = new ArmaMagica("ARMA ESPIRITUAL", 5, 1000, 45, Armas.ETipo.armaMagica);

            //ARMAS A DISTANCIA
            ArmaADistancia a6 = new ArmaADistancia("Arco de Artemis", 6, 500, 57, Armas.ETipo.armaADistancia);
            ArmaADistancia a7 = new ArmaADistancia("Gomera Castigadora", 7, 70, 6, Armas.ETipo.armaADistancia);
            ArmaADistancia a8 = new ArmaADistancia("Ballesta", 8, 200, 43, Armas.ETipo.armaADistancia);
            ArmaADistancia a9 = new ArmaADistancia("ARCO DIVINO", 9, 2000, 67, Armas.ETipo.armaADistancia);
            ArmaADistancia a10 = new ArmaADistancia("BEST BOW LVL50", 10, 2500, 243, Armas.ETipo.armaADistancia);

            //ARMAS CUERPO A CUERPO
            ArmaCuerpoACuerpo a11 = new ArmaCuerpoACuerpo("Espada De Ares", 11, 10000, 243, Armas.ETipo.armaCuerpoACuerpo);
            ArmaCuerpoACuerpo a12 = new ArmaCuerpoACuerpo("Escudo 300 ", 12, 6000, 12, Armas.ETipo.armaCuerpoACuerpo);
            ArmaCuerpoACuerpo a13 = new ArmaCuerpoACuerpo("Dagas De Kratos", 13, 15000, 65, Armas.ETipo.armaCuerpoACuerpo);


            Venta venta = new Venta();

            Thread hilo1 = new Thread(Armeria.GenerarVentas);
            Thread hilo2 = new Thread(Armeria.GenerarVentasSegunda);

            try
            {
                Console.WriteLine("\nBIENVENIDO ARMERIA VULCANO");
                Console.WriteLine("\nSE CARGAN Armas!:");
                Console.WriteLine();

                //5 ARMA MAGICAS
                if (Armeria.Armas + a1)
                    Console.WriteLine($"Arma: {a1.Stock} cargado con exito");
                if (Armeria.Armas + a2)
                    Console.WriteLine($"Arma: {a2.Stock} cargado con exito");
                if (Armeria.Armas + a3)
                    Console.WriteLine($"Arma: {a3.Stock} cargado con exito");
                if (Armeria.Armas + a4)
                    Console.WriteLine($"Arma: {a4.Stock} cargado con exito");
                if (Armeria.Armas + a5)
                    Console.WriteLine($"Arma: {a5.Stock} cargado con exito");

                //5 ARMA A DISTANCIA
                if (Armeria.Armas + a6)
                    Console.WriteLine($"Arma: {a6.Stock} cargado con exito");
                if (Armeria.Armas + a7)
                    Console.WriteLine($"Arma: {a7.Stock} cargado con exito");
                if (Armeria.Armas + a8)
                    Console.WriteLine($"Arma: {a8.Stock} cargado con exito");
                if (Armeria.Armas + a9)
                    Console.WriteLine($"Arma: {a9.Stock} cargado con exito");
                if (Armeria.Armas + a10)

                    //3 ARMA CUERPO A CUERPO
                    Console.WriteLine($"Arma: {a10.Stock} cargado con exito");
                if (Armeria.Armas + a11)
                    Console.WriteLine($"Arma: {a11.Stock} cargado con exito");
                if (Armeria.Armas + a12)
                    Console.WriteLine($"Arma: {a12.Stock} cargado con exito");
                if (Armeria.Armas + a13)
                    Console.WriteLine($"Arma: {a13.Stock} cargado con exito");
            }
            catch (ArmasEx e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Toque Cualquier Tecla Para Seguir!");
            Console.ReadKey();
            Console.Clear();

            try
            {
                Console.WriteLine("\nSe Muestran por pantalla las Armas cargados en BD:");
                Console.WriteLine();
                Console.WriteLine(Armeria.MostrarArticulos());
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

                if (Armeria.Armas + a1)
                    Console.WriteLine($"Arma: {a1.Stock} cargado con exito");

            }
            catch (ArmasEx e)
            {

                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Toque Cualquier Tecla Para Seguir!");
            Console.ReadKey();
            Console.Clear();

            try
            {
                Console.WriteLine("\nSE AGREGAN ARMAS A LA VENTA:");
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

                if (Armeria.Ventas + venta)
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

                Console.WriteLine(Armeria.MostrarArticulos());
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

                Console.WriteLine($"Stock total: {Armeria.Armas.StockTotal()}");
                Console.WriteLine($"Acumulado de ventas: ${Armeria.Ventas.VentasTotales()}");

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
                if (Armeria.Guardar(Armeria.Ventas))
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
