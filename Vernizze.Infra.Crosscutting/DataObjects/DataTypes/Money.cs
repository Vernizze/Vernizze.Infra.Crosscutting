using System;
using Vernizze.Infra.CrossCutting.Extensions;
using Vernizze.Infra.CrossCutting.Utils;

namespace Vernizze.Infra.CrossCutting.DataObjects.DataTypes
{
    public struct Money
    {
        #region Variables

        public readonly string IniValue;
        public readonly decimal? Value;

        #endregion

        #region Atributes

        public string StringValue { get; private set; }

        #endregion

        #region Constructors

        public Money(string value)
            : this()
        {
            var valor = 0M;

            this.IniValue = value;

            if (!this.IsValid())
                throw new Exception($"Valor inválido: {value} - Formato Esperado: ######0,0000");

            this.StringValue = string.Format("{0:#,0.00}", this.Value);

            if (decimal.TryParse(value, out valor))
                this.Value = valor;
        }

        public Money(decimal value)
            : this()
        {
            if (!this.IsValid())
                throw new Exception($"Valor inválido: {value} - Formato Esperado: ######0,0000");

            this.Value = value;

            this.IniValue = value.ToString();

            this.StringValue = string.Format("{0:#,0.0000}", this.Value);
        }

        #endregion

        #region Methods

        #region Operator

        public static implicit operator Money(string value)
        {
            return new Money(value);
        }

        public static implicit operator Money(decimal value)
        {
            return new Money(value);
        }

        #endregion

        public bool IsEmpty()
        {
            return 0.Equals(this.Value);
        }

        public bool IsNull()
        {
            return this.Value.IsNull();
        }
        public bool IsValid()
        {
            return IsValid(this.IniValue);
        }

        #endregion

        #region Static methods

        public static bool IsValid(string value)
        {
            var result = true;

            if (!string.IsNullOrEmpty(value))
            {
                result = ValidateLenght(value);
                result = result && ValidateSeparator(value);
            }

            return result;
        }

        private static bool ValidateLenght(string value)
        {
            var result = false;

            result = (value.Length > 3) && (value.Length < 15);

            return result;
        }

        private static bool ValidateSeparator(string value)
        {
            var separadorAtual = value.Substring(value.Length - 3)
                                      .Substring(0, 1);

            return ','.Equals(separadorAtual);
        }

        private static decimal? Converte(string value)
        {
            var valor_decimal = string.Empty;
            var valor_inteiro = string.Empty;
            decimal? result = null;

            if (!string.IsNullOrEmpty(value))
            {
                var currency_parts = value.Split(',');

                if (currency_parts.Length > 0)
                {
                    valor_inteiro = currency_parts[0];
                }
                else if (currency_parts.Length > 1)
                {
                    valor_decimal = currency_parts[1];
                }

                valor_decimal = valor_decimal.OnlyNumeric();
                valor_inteiro = valor_inteiro.OnlyNumeric();

                result = decimal.Parse(valor_inteiro) + (decimal.Parse(valor_decimal) / 100);
            }

            return result;
        }

        #endregion
    }
}
