using System;
using System.ComponentModel.DataAnnotations;

namespace Vernizze.Infra.CrossCutting.Validations
{
    public class DateTimeAttributeValidation 
        : ValidationAttribute
    {
        private bool _allowNull = false;

        public bool AllowNull
        {
            get { return this._allowNull; }
            set { this._allowNull = value; }
        }

        public override bool IsValid(object value)
        {
            try
            {
                bool result = false;
                DateTime valueDateTime = new DateTime();

                if (value == null)
                {
                    result = this._allowNull;
                }
                else
                {
                    result = DateTime.TryParse(value.ToString(), out valueDateTime);
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
