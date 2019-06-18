using System;
using System.ComponentModel.DataAnnotations;

namespace Vernizze.Infra.CrossCutting.Validations
{
    public class GuidAttributeValidation
            : ValidationAttribute
    {
        private bool _allowNullOrEmpty = false;

        public bool AllowNullOrEmpty
        {
            get { return this._allowNullOrEmpty; }
            set { this._allowNullOrEmpty = value; }
        }

        public override bool IsValid(object value)
        {
            try
            {
                Guid guid = Guid.Empty;
                bool result = false;

                if (_allowNullOrEmpty && (value == null || string.IsNullOrEmpty(value.ToString()))) return true;

                result = Guid.TryParse(value.ToString(), out guid);
                result = result && (value.ToString() != Guid.Empty.ToString());

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
