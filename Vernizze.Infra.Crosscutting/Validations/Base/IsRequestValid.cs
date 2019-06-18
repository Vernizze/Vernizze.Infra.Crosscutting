using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Vernizze.Infra.CrossCutting.DataObjects.Results;
using Vernizze.Infra.CrossCutting.Libraries.Benchmark;
using Vernizze.Infra.CrossCutting.Validations.Interfaces;

namespace Vernizze.Infra.CrossCutting.Validations.Base
{
    public abstract class IsRequestValid<T>
    {
        #region Variables

        private IsValidRequest<T> _domainValid;

        #endregion

        #region Constructors

        public IsRequestValid(IsValidRequest<T> domainValid)
        {
            this._domainValid = domainValid;
        }

        #endregion

        #region Methods

        public virtual OperationResult IsValid(T obj)
        {
            var validation_result = new List<ValidationResult>();
            OperationResult result = null;

            using (var benchmark = TimeCounter.Instance)
            {
                var validationResult = ModelValidation.TryValidateObjectRecursive(obj, validation_result);

                validationResult = validationResult && _domainValid.IsValid(obj, validation_result).success;

                if (validationResult)
                {
                    result = new OperationResult(validationResult, string.Empty, benchmark.ResponseTime);
                }
                else
                {
                    var validationErrors = new List<OperationError>();

                    validation_result.ForEach(e =>
                    {
                        validationErrors.Add(new OperationError
                        (
                            nameof(T),
                            string.Join(" ", e.MemberNames),
                            string.Empty,
                            e.ErrorMessage)
                        );
                    });

                    result = new OperationResultWithError
                    (
                        validationErrors,
                        benchmark.ResponseTime
                    );
                }
            }

            return result;
        }

        #endregion
    }
}
