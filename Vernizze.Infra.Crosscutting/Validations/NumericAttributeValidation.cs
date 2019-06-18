using System;
using System.ComponentModel.DataAnnotations;

namespace Vernizze.Infra.CrossCutting.Validations
{
    public class NumericAttributeValidation 
        : ValidationAttribute
    {
        private bool _minValueDefined = false;
        private int _minValue = 0;
        private bool _maxValueDefined = false;
        private int _maxValue = 0;
        private bool _allowNull = false;
        private bool _allowZero = true;
        private bool _allowNegative = true;

        public int MinValue
        {
            get { return this._minValue; }
            set
            {
                this._minValueDefined = true;
                this._minValue = value;
            }
        }

        public int MaxValue
        {
            get { return this._maxValue; }
            set
            {
                this._maxValueDefined = true;
                this._maxValue = value;
            }
        }

        public bool AllowNull
        {
            get { return this._allowNull; }
            set { this._allowNull = value; }
        }

        public bool AllowNegative
        {
            get { return this._allowNegative; }
            set { this._allowNegative = value; }
        }

        public bool AllowZero
        {
            get { return this._allowZero; }
            set { this._allowZero = value; }
        }

        public override bool IsValid(object value)
        {
            try
            {
                bool result = false;
                decimal valueDecimal = 0;

                if (value == null)
                {
                    result = this._allowNull;
                }
                else
                {
                    if (decimal.TryParse(value.ToString(), out valueDecimal))
                    {
                        result = ((valueDecimal >= 0) || ((valueDecimal < 0) && (this._allowNegative)));

                        result = result &&
                                (((valueDecimal > 0) || (valueDecimal < 0)) || ((valueDecimal == 0) && (this._allowZero)));

                        result = result &&
                                ((!this._minValueDefined) || ((this._minValueDefined) && (this._minValue <= valueDecimal)))
                                &&
                                ((!this._maxValueDefined) || ((this._maxValueDefined) && (this._maxValue >= valueDecimal)))
                                ;
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
