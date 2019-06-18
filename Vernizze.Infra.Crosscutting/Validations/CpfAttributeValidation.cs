using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

using Vernizze.Infra.CrossCutting.Utils;

namespace Vernizze.Infra.CrossCutting.Validations
{
    public class CpfAttributeValidation 
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
                    return StringUtils.ValidaCpf(value.ToString());
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