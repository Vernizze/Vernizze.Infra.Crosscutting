using System;
using System.ComponentModel.DataAnnotations;

using Vernizze.Infra.CrossCutting.Utils;

namespace Vernizze.Infra.CrossCutting.Validations
{
    public class CnpjAttributeValidation
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
                if (value == null)
                {
                    return this._allowNull;
                }
                else
                {
                    return StringUtils.ValidaCnpj(value.ToString());
                }
            }
            catch (Exception ex)
            {
                var error = ex.Message;

                return false;
            }
        }
    }
}
