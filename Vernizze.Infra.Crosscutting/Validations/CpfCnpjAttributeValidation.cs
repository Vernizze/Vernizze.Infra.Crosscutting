using System;
using System.ComponentModel.DataAnnotations;

using Vernizze.Infra.Crosscutting.DataObjects.Enums.Types;
using Vernizze.Infra.CrossCutting.Utils;

namespace Vernizze.Infra.CrossCutting.Validations
{
    public class CpfCnpjAttributeValidation
        : ValidationAttribute
    {
        private bool _allowNull = false;
        private TPessoa _pessoa_tipo = TPessoa.Undefined;

        public TPessoa PessoaTipo
        {
            get { return this._pessoa_tipo; }
            set { this._pessoa_tipo = value; }
        }

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
                    var result = false;

                    switch (this._pessoa_tipo)
                    {
                        case TPessoa.PessoaFisica:
                            result = StringUtils.ValidaCpf(value.ToString());
                            break;
                        case TPessoa.PessoaJuridica:
                            result = StringUtils.ValidaCnpj(value.ToString());
                            break;
                        default:
                            result = StringUtils.ValidaCpf(value.ToString()) || StringUtils.ValidaCnpj(value.ToString());
                            break;
                    }
                    
                    return result;
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
