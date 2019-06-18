using System;
using System.ComponentModel.DataAnnotations;

namespace Vernizze.Infra.CrossCutting.Validations
{
    public class IpAttributeValidation
        : ValidationAttribute
    {
        private bool _allowNull = false;
        private bool _ipv4_allowed = true;
        private bool _ipv6_allowed = true;

        public bool AllowNull
        {
            get { return this._allowNull; }
            set { this._allowNull = value; }
        }

        public bool Ipv4_Allowed
        {
            get { return this._ipv4_allowed; }
            set { this._ipv4_allowed = value; }
        }

        public bool Ipv6_Allowed
        {
            get { return this._ipv6_allowed; }
            set { this._ipv6_allowed = value; }
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
                    if (this._ipv4_allowed)
                        result = Utils.StringUtils.ValidaIpV4(value.ToString());

                    if (this._ipv6_allowed)
                        result = result || Utils.StringUtils.ValidaIpV6(value.ToString());
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
