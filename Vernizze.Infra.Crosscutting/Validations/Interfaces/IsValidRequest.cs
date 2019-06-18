using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Vernizze.Infra.CrossCutting.DataObjects.Results;

namespace Vernizze.Infra.CrossCutting.Validations.Interfaces
{
    public interface IsValidRequest<T>
    {
        OperationResult<List<ValidationResult>> IsValid(T obj, List<ValidationResult> validationResult);    
    }
}
