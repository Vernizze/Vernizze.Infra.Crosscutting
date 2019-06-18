using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

using Vernizze.Infra.CrossCutting.Extensions;

namespace Vernizze.Infra.CrossCutting.Validations.Base
{
    public class ModelValidation
    {
        public static bool TryValidateObjectRecursive<T>(T obj, List<ValidationResult> results)
        {
            try
            {
                bool result = false;

                if (obj.IsNull())
                {
                    var error = new ValidationResult("Requisição enviada está nula.");

                    if (results.IsNull())
                    {
                        results = new List<ValidationResult>() { error };
                    }
                    else
                    {
                        results.Add(error);
                    }
                }
                else
                {
                    var context = new ValidationContext(obj, null, null);

                    result = Validator.TryValidateObject(obj, context, results, true);

                    if (obj.GetType() == typeof(DateTime))
                    {
                        return result;
                    }

                    var properties = obj.GetType().GetProperties().Where(prop => prop.CanRead).ToList();

                    foreach (var property in properties)
                    {
                        var value = obj.GetType().GetProperty(property.Name).GetValue(obj, null);

                        if (value == null) continue;

                        var asEnumerable = value as IEnumerable;

                        if (asEnumerable != null)
                        {
                            foreach (var enumObj in asEnumerable)
                            {
                                result = TryValidateObjectRecursive(enumObj, results) && result;
                            }
                        }
                        else
                        {
                            result = TryValidateObjectRecursive(value, results) && result;
                        }
                    }
                }

                return result;
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // Variable is declared but never used
            {

                throw;
            }

        }
    }
}
