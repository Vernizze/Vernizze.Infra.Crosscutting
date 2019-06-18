using Vernizze.Infra.CrossCutting.Extensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Vernizze.Infra.CrossCutting.Validations
{
    public class StringAttributeValidation
            : ValidationAttribute
    {
        private bool _allowNullOrEmpty = false;
        private int? _maxLenght = null;
        private int? _minLenght = null;

        public bool AllowNullOrEmpty
        {
            get { return this._allowNullOrEmpty; }
            set { this._allowNullOrEmpty = value; }
        }

        public int MaxLenght
        {
            set { this._maxLenght = value; }
            get
            {
                if (this._maxLenght.IsNull())
                    return 0;
                else
                    return (int)this._maxLenght;
            }

        }

        public int MinLenght
        {
            set { this._minLenght = value; }
            get
            {
                if (this._minLenght.IsNull())
                    return 0;
                else
                    return (int)this._minLenght;
            }
            
        }

        public override bool IsValid(object value)
        {
            try
            {
                bool result = false;

                if (_allowNullOrEmpty && (value == null || string.IsNullOrEmpty(value.ToString()))) return true;

                result = !string.IsNullOrEmpty(value.ToString());

                if (!this._minLenght.IsNull())
                    result = result &&
                        (this._minLenght <= value.ToString().Length);

                if (!this._maxLenght.IsNull())
                    result = result &&
                            (this._maxLenght >= value.ToString().Length);

                //result = result && Regex.IsMatch(value.ToString(), "(?i)((select )|delete|update|create table|create database|drop|truncate)");

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
