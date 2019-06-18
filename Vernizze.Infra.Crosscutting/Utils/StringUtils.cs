using System;
using System.Globalization;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace Vernizze.Infra.CrossCutting.Utils
{
    public static class StringUtils
    {
        public static bool IsNumeric(this string value)
        {
            var result = true;

            foreach (var chr in value)
            {
                result = result && Char.IsNumber(chr);
            }

            return result;
        }

        public static bool IsMoney(this string value)
        {
            var cultureinfo_ptbr = new CultureInfo("pt-Br");
            var result = true;

            foreach (var chr in value)
            {
                result = result &&
                    (Char.IsNumber(chr)
                    &&
                    (chr.Equals(cultureinfo_ptbr.NumberFormat.NumberDecimalSeparator.ToCharArray()[0])));
            }

            return result;
        }

        public static string OnlyNumeric(this string value)
        {
            var result = string.Empty;

            if (!string.IsNullOrEmpty(value))
            {
                foreach (var chr in value)
                {
                    if (Char.IsNumber(chr))
                        result = string.Concat(result, chr);
                }
            }
            else
            {
                result = "0";
            }

            return result;
        }

        public static bool ValidaCpf(string cpf)
        {
            var result = false;

            var valueString = Regex.Replace(cpf, "[^0-9]+", "");

            if (!Regex.IsMatch(valueString, "(^0+$|^1+$|^2+$|^3+$|^4+$|^5+$|^6+$|^7+$|^8+$|^9+$)", RegexOptions.Multiline))
            {
                if (valueString.Length == 11)
                {
                    var cpf_array = new int[11];

                    for (int i = 0; i < 11; i++)
                    {
                        cpf_array[i] = int.Parse(valueString[i].ToString());
                    }

                    result = ValidaCpf(cpf_array);
                }
            }

            return result;
        }

        private static bool ValidaCpf(int[] a)
        {
            int x = 0;
            int result = 0;
            int sum = 0;
            int dgverif1 = 0;
            int dgverif2 = 0;
            bool valido = false;

            for (int i = 0, j = 10; i <= 8; i++, j--)
            {
                x = Convert.ToInt32(a[i]) * j;

                sum += x;
            }

            result = sum % 11;

            if (result < 2)
            {
                dgverif1 = 0;
            }
            else
            {
                dgverif1 = (11 - result);
            }

            sum = 0;
            result = 0;
            x = 0;

            for (int i = 0, j = 11; i <= 9; i++, j--)
            {
                x = Convert.ToInt32(a[i]) * j;

                sum += x;
            }

            result = sum % 11;

            if (result < 2)
            {
                dgverif2 = 0;
            }
            else
            {
                dgverif2 = (11 - result);
            }

            valido = ((a[9] == dgverif1) && (a[10] == dgverif2));

            return valido;
        }

        public static bool ValidaCnpj(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;

            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

            if (cnpj.Length != 14)
                return false;

            tempCnpj = cnpj.Substring(0, 12);

            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();

            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cnpj.EndsWith(digito);
        }

        public static bool ValidaIpV4(string value)
        {
            var result = false;

            if (IPAddress.TryParse(value, out IPAddress ip))
                result = ip.AddressFamily == AddressFamily.InterNetwork;

            return result;
        }

        public static bool ValidaIpV6(string value)
        {
            var result = false;

            if (IPAddress.TryParse(value, out IPAddress ip))
                result = ip.AddressFamily == AddressFamily.InterNetworkV6;

            return result;
        }
    }
}