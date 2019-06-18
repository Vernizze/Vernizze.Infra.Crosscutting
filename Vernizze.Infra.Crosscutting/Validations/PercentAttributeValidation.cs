using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Vernizze.Infra.Crosscutting.DataObjects.DataTypes;

namespace Vernizze.Infra.CrossCutting.Validations
{
    public enum TPercentValueLenght
    {
        Default = 2,
        One = 1,
        Ten = 2,
        Hundred = 3,
        Thousand = 4,
        TenThousand = 5,
        HundredThousand = 6,
        Million = 7,
        TenMillion = 8,
        HundredMillion = 9,
    }
    public class PercentAttributeValidation
        : ValidationAttribute
    {
        private TPercentValueLenght _percentLeght = TPercentValueLenght.Default;
        private bool _allowNull = false;
        private bool _allowZero = false;
        private bool _allowNegative = true;

        public TPercentValueLenght PercentValueLenght
        {
            get { return this._percentLeght; }
            set { this._percentLeght = value; }
        }

        public bool AllowNull
        {
            get { return this._allowNull; }
            set { this._allowNull = value; }
        }

        public bool AllowZero
        {
            get { return this._allowZero; }
            set { this._allowZero = value; }
        }

        public bool AllowNegative
        {
            get { return this._allowNegative; }
            set { this._allowNegative = value; }
        }

        public override bool IsValid(object value)
        {
            try
            {
                bool result = false;

                if (value == null)
                {
                    result = this._allowNull;
                }
                else
                {
                    if (Percent.IsValid(value.ToString()))
                    {
                        Percent valueDecimal = value.ToString();

                        result = ((valueDecimal.Value >= 0) || ((valueDecimal.Value < 0) && (this._allowNegative)));

                        result = result && (valueDecimal.Value > 0) ||
                                            ((valueDecimal.Value == 0) && (this._allowZero));

                        var culture_ptbr = new CultureInfo("pt-Br");

                        var separador = culture_ptbr.NumberFormat.CurrencyDecimalSeparator;

                        var valueWithSemicolon = valueDecimal.IniValue.Split(separador[0]);

                        if (valueWithSemicolon.Length > 1)
                        {
                            var valueBeforeSemicolon = valueWithSemicolon[0].ToString();
                            var valueAfterSemicolon = valueWithSemicolon[1].ToString();

                            result = result && (valueBeforeSemicolon.Length <= this._percentLeght.GetHashCode());
                        }
                        else
                        {
                            result = result && (valueDecimal.ToString().Length <= this._percentLeght.GetHashCode());
                        }
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                var error = ex.Message;

                return false;
            }
        }
    }
}
