using System.Collections.Generic;
using System.Net;

namespace Vernizze.Infra.CrossCutting.DataObjects.Results
{
    public class OperationResultWithError : OperationResult
    {
        #region Variables

        private List<OperationError> _errors = new List<OperationError>();

        #endregion

        #region Constructors

        public OperationResultWithError(OperationError error)
        {
            this.errors.Clear();
            this.errors.Add(error);
        }

        public OperationResultWithError(OperationError error, string message)
        {
            this.message = message;
            this.errors.Clear();
            this.errors.Add(error);
        }

        public OperationResultWithError(List<OperationError> errors)
        {
            this.errors.Clear();
            this.errors.AddRange(errors);
            this.response_time = 0;
        }

        public OperationResultWithError(List<OperationError> errors, string message)
        {
            this.message = message;
            this.errors.Clear();
            this.errors.AddRange(errors);
        }

        public OperationResultWithError(OperationError error, string message, double responseTime)
        {
            this.message = message;
            this.response_time = responseTime;
            this.errors.Clear();
            this.errors.Add(error);
        }

        public OperationResultWithError(OperationError error, double responseTime)
        {
            this.errors.Clear();
            this.errors.Add(error);
            this.response_time = responseTime;
        }

        public OperationResultWithError(List<OperationError> errors, double responseTime)
        {
            this.errors.Clear();
            this.errors.AddRange(errors);
            this.response_time = responseTime;
        }

        public OperationResultWithError(List<OperationError> errors, string message, double responseTime)
        {
            this.errors.Clear();
            this.errors.AddRange(errors);
            this.response_time = responseTime;
        }

        public OperationResultWithError(HttpStatusCode httpStatusCode, OperationError error)
        {
            this.SetErrorDetails(error);
            this.status_code = httpStatusCode;
        }

        public OperationResultWithError(HttpStatusCode httpStatusCode, List<OperationError> errors)
        {
            this.SetErrorsDetailsList(errors);
            this.status_code = httpStatusCode;
        }

        public OperationResultWithError(HttpStatusCode httpStatusCode, OperationError error, double responseTime)
        {
            this.SetErrorDetails(error);
            this.response_time = responseTime;
            this.status_code = httpStatusCode;
        }

        public OperationResultWithError(HttpStatusCode httpStatusCode, List<OperationError> errors, double responseTime)
        {
            this.SetErrorsDetailsList(errors);
            this.response_time = responseTime;
            this.status_code = httpStatusCode;
        }

        #endregion

        #region Private methods

        private void SetErrorDetails(OperationError error)
        {
            this.errors.Clear();
            this.errors.Add(error);
        }

        private void SetErrorsDetailsList(List<OperationError> errors)
        {
            this.errors.Clear();
            this.errors.AddRange(errors);
        }

        #endregion

        #region Attributes

        public List<OperationError> errors
        {
            get { return this._errors; }
            set { this._errors = value; }
        }

        #endregion
    }

    public class OperationResultWithError<T>
        : OperationResult<T>
            where T : class, new()
    {
        #region Variables

        private List<OperationError> _errors = new List<OperationError>();

        #endregion

        #region Constructors

        public OperationResultWithError(OperationError error)
        {
            SetErrorDetails(error);
            this.response_time = 0;
        }

        public OperationResultWithError(OperationError error, string message)
        {
            SetErrorDetails(error);
            this.response_time = 0;
        }

        public OperationResultWithError(List<OperationError> errors)
        {
            SetErrorsDetailsList(errors);
            this.response_time = 0;
        }

        public OperationResultWithError(List<OperationError> errors, string message)
        {
            this.success = false;
            this.message = message;
            SetErrorsDetailsList(errors);
            this.response_time = 0;
        }

        public OperationResultWithError(OperationError error, double responseTime)
        {
            SetErrorDetails(error);
            this.response_time = responseTime;
        }

        public OperationResultWithError(OperationError error, string message, double responseTime)
        {
            this.success = false;
            this.message = message;
            SetErrorDetails(error);
            this.response_time = responseTime;
        }

        public OperationResultWithError(List<OperationError> errors, double responseTime)
        {
            this.SetErrorsDetailsList(errors);
            this.response_time = responseTime;
        }

        public OperationResultWithError(List<OperationError> errors, string message, double responseTime)
        {
            this.message = message;
            this.SetErrorsDetailsList(errors);
            this.response_time = responseTime;
        }

        public OperationResultWithError(HttpStatusCode httpStatusCode, OperationError error)
        {
            this.SetErrorDetails(error);
            this.status_code = httpStatusCode;
        }

        public OperationResultWithError(HttpStatusCode httpStatusCode, List<OperationError> errors)
        {
            this.SetErrorsDetailsList(errors);
            this.status_code = httpStatusCode;
        }

        public OperationResultWithError(HttpStatusCode httpStatusCode, OperationError error, double responseTime)
        {
            this.SetErrorDetails(error);
            this.response_time = responseTime;
            this.status_code = httpStatusCode;
        }

        public OperationResultWithError(HttpStatusCode httpStatusCode, List<OperationError> errors, double responseTime)
        {
            this.SetErrorsDetailsList(errors);
            this.response_time = responseTime;
            this.status_code = httpStatusCode;
        }

        #endregion

        #region Private methods

        private void SetErrorDetails(OperationError error)
        {
            this.errors.Clear();
            this.errors.Add(error);
        }

        private void SetErrorsDetailsList(List<OperationError> errors)
        {
            this.errors.Clear();
            this.errors.AddRange(errors);
        }

        #endregion

        #region Attributes

        public List<OperationError> errors
        {
            get { return this._errors; }
            set { this._errors = value; }
        }

        #endregion
    }


}
