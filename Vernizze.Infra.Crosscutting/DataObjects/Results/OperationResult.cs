using System.Collections.Generic;
using System.Net;

namespace Vernizze.Infra.CrossCutting.DataObjects.Results
{
    public class OperationResult
    {
        #region Constructors

        public OperationResult() { }

        public OperationResult(bool success)
        {
            this.success = success;
            this.message = string.Empty;
            this.response_time = 0;
        }

        public OperationResult(bool success, string message)
        {
            this.success = success;
            this.message = message;
            this.response_time = 0;
        }

        public OperationResult(bool success, string message, string url)
        {
            this.success = success;
            this.message = message;
            this.response_time = 0;
        }

        public OperationResult(bool success, string message, double responseTime)
        {
            this.success = success;
            this.message = message;
            this.response_time = responseTime;
        }

        #endregion

        #region Attributes

        public bool success { get; set; }

        public HttpStatusCode status_code { get; set; }

        public string message { get; set; }

        public double response_time { get; set; }

        #endregion
    }

    public class OperationResult<T> : OperationResult where T : class, new()
    {
        #region Constructors

        public OperationResult() { }

        public OperationResult(T resultObject)
            : base(true)
        {
            this.result_object = resultObject;
            this.results_qtty = 0;
        }

        public OperationResult(bool sucess, T resultObject)
            : base(sucess)
        {
            this.result_object = resultObject;
            this.results_qtty = 0;
        }

        public OperationResult(bool sucess, T resultObject, int resultsQtty)
            : base(sucess)
        {
            this.result_object = resultObject;
            this.results_qtty = resultsQtty;
        }

        public OperationResult(bool success, string message, T resultObject)
            : base(success, message)
        {
            this.result_object = resultObject;
            this.results_qtty = 0;
        }

        public OperationResult(bool success, string message, T resultObject, int resultsQtty)
            : base(success, message)
        {
            this.result_object = resultObject;
            this.results_qtty = resultsQtty;
        }

        #endregion

        #region Attributes

        public T result_object { get; set; }

        public int results_qtty { get; set; }

        #endregion
    }

    public class OperationResultLegacyWithError : OperationResult
    {
        private List<OperationError> _errors = new List<OperationError>();

        #region Constructors

        public OperationResultLegacyWithError()
        {
            this.success = false;
        }

        public OperationResultLegacyWithError(OperationError error)
        {
            this.success = false;
            this.message = "Error";
            this.errors.Clear();
            this.errors.Add(error);
            this.response_time = 0;
            this.status_code = HttpStatusCode.InternalServerError;
        }

        public OperationResultLegacyWithError(OperationError error, string message)
        {
            this.success = false;
            this.message = message;
            this.errors.Clear();
            this.errors.Add(error);
            this.response_time = 0;
            this.status_code = HttpStatusCode.InternalServerError;
        }

        public OperationResultLegacyWithError(List<OperationError> errors)
        {
            this.success = false;
            this.message = "Error";
            this.errors.Clear();
            this.errors.AddRange(errors);
            this.response_time = 0;
            this.status_code = HttpStatusCode.InternalServerError;
        }

        public OperationResultLegacyWithError(List<OperationError> errors, string message)
        {
            this.success = false;
            this.message = message;
            this.errors.Clear();
            this.errors.AddRange(errors);
            this.response_time = 0;
            this.status_code = HttpStatusCode.InternalServerError;
        }

        public OperationResultLegacyWithError(OperationError error, string message, double responseTime)
        {
            this.success = false;
            this.message = message;
            this.errors.Clear();
            this.errors.Add(error);
            this.response_time = responseTime;
            this.status_code = HttpStatusCode.InternalServerError;
        }

        public OperationResultLegacyWithError(OperationError error, double responseTime)
        {
            this.success = false;
            this.message = "Error";
            this.errors.Clear();
            this.errors.Add(error);
            this.response_time = responseTime;
            this.status_code = HttpStatusCode.InternalServerError;
        }

        public OperationResultLegacyWithError(List<OperationError> errors, double responseTime)
        {
            this.success = false;
            this.message = "Error";
            this.errors.Clear();
            this.errors.AddRange(errors);
            this.response_time = responseTime;
            this.status_code = HttpStatusCode.InternalServerError;
        }

        public OperationResultLegacyWithError(List<OperationError> errors, string message, double responseTime)
        {
            this.success = false;
            this.message = message;
            this.errors.Clear();
            this.errors.AddRange(errors);
            this.response_time = responseTime;
            this.status_code = HttpStatusCode.InternalServerError;
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

    public class OperationResultLegacyWithError<T>
        : OperationResult<T>
            where T : class, new()
    {
        private List<OperationError> _errors = new List<OperationError>();

        #region Constructors

        public OperationResultLegacyWithError()
        {
            this.success = false;
        }

        public OperationResultLegacyWithError(OperationError error)
        {
            this.success = false;
            this.message = "Error";
            this.errors.Clear();
            this.errors.Add(error);
            this.response_time = 0;
        }

        public OperationResultLegacyWithError(OperationError error, string message)
        {
            this.success = false;
            this.message = message;
            this.errors.Clear();
            this.errors.Add(error);
            this.response_time = 0;
        }

        public OperationResultLegacyWithError(List<OperationError> errors)
        {
            this.success = false;
            this.message = "Error";
            this.errors.Clear();
            this.errors.AddRange(errors);
            this.response_time = 0;
        }

        public OperationResultLegacyWithError(List<OperationError> errors, string message)
        {
            this.success = false;
            this.message = message;
            this.errors.Clear();
            this.errors.AddRange(errors);
            this.response_time = 0;
        }

        public OperationResultLegacyWithError(OperationError error, double responseTime)
        {
            this.success = false;
            this.message = "Error";
            this.errors.Clear();
            this.errors.Add(error);
            this.response_time = responseTime;
        }

        public OperationResultLegacyWithError(OperationError error, string message, double responseTime)
        {
            this.success = false;
            this.message = message;
            this.errors.Clear();
            this.errors.Add(error);
            this.response_time = responseTime;
        }

        public OperationResultLegacyWithError(List<OperationError> errors, double responseTime)
        {
            this.success = false;
            this.message = "Error";
            this.errors.Clear();
            this.errors.AddRange(errors);
            this.response_time = responseTime;
        }

        public OperationResultLegacyWithError(List<OperationError> errors, string message, double responseTime)
        {
            this.success = false;
            this.message = message;
            this.errors.Clear();
            this.errors.AddRange(errors);
            this.response_time = responseTime;
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
