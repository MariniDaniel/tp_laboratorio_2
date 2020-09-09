using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Metodo que va a realizar la operacion asignada.
        /// </summary>
        /// <param name="num1">primer numero </param>
        /// <param name="num2">segundo numero</param>
        /// <param name="operador">Recibe operador el cual se usara para realizar la operacion</param>
        /// <returns>retorna el resultado de la operacion elegida</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double retorno = 0;
            string miOperador;

            miOperador = ValidarOperador(operador);

            switch (miOperador)
            {
                case "+":
                    retorno = num1 + num2;
                    break;

                case "-":
                    retorno = num1 - num2;
                    break;

                case "*":
                    retorno = num1 * num2;
                    break;

                case "/":
                    retorno = num1 / num2;
                    break;

            }

            return retorno;


        }



        /// <summary>
        /// Metodo que va a validar si el operador recibido es correcto 
        /// </summary>
        /// <param name="operador"></param>
        /// <returns>Retorna el operador recibido si es correcto, si no lo es retorna "+"</returns>
        private static string ValidarOperador(string operador)
        {
            string retorno = operador;

            if (operador != "+" && operador != "-" && operador != "*" && operador != "/")
            {
                retorno = "+";
            }
            return retorno;
        }
















    }
}
