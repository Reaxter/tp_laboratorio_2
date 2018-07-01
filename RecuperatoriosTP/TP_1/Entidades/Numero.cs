using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero = 0;

        private string SetNumero
        {
            set { numero = ValidarNumero(value); }
        }
        public static string BinarioDecimal(string binario)
        {
            if (string.IsNullOrEmpty(binario))
                return "Valor Invalido";
            for (int i = 0; i < binario.Count(); i++)
            {
                if (binario[i] != '0' && binario[i] != '1')
                    return "Valor Invalido";
            }
            return Convert.ToInt64(binario, 2).ToString();
        }
        public static string DecimalBinario(double numero)
        {
            if (numero == double.NaN)
                return "Valor Invalido";
            return DecimalBinario(Convert.ToString(numero));
        }
        public static string DecimalBinario(string numero)
        {
            if (string.IsNullOrEmpty(numero) || numero.Count() > 16)
                return "Valor Invalido";
            for (int i = 0; i < numero.Count(); i++)
            {
                if (!(char.IsDigit(numero[i])))
                    return "Valor Invalido";
            }
            return Convert.ToString(Int64.Parse(numero), 2).ToString();
        }
        public Numero() : this(0)
        {
        }
        public Numero(double numero)
        {
            this.numero = numero;
        }
        public Numero(string strNumero)
        {
            SetNumero = strNumero;
        }
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }
        public static double operator /(Numero n1, Numero n2)
        {
            return n1.numero / n2.numero;
        }
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }
        private double ValidarNumero(string strNumero)
        {
            double numero;
            if (string.IsNullOrEmpty(strNumero) || !(double.TryParse(strNumero, out numero)))
                return 0;
            else
                return numero;
        }
    }
}
