using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double numero = 0;
            switch (ValidarOperador(operador))
            {
                case "-":
                    numero = num1 - num2;
                    break;
                case "*":
                    numero = num1 * num2;
                    break;
                case "/":
                    numero = num1 / num2;
                    break;
                case "+":
                    numero = num1 + num2;
                    break;
            }
            return numero;
        }
        private static string ValidarOperador(string operador)
        {
            if (operador == null)
                return "+";
            if (operador != "+" && operador != "-" && operador != "/" && operador != "*")
                return "+";
            return operador;
        }
    }
}
