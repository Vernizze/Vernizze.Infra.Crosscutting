using Vernizze.Infra.CrossCutting.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Vernizze.Infra.CrossCutting.Validations
{
    public class BooleanAttributeValidation
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
                
                if (value.IsNull())
                {
                    result = this._allowNull;
                }
                else
                {
                    result = value.ToString().IsBoolean();
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
