namespace Vernizze.Infra.CrossCutting.DataObjects.Results
{
    public class OperationError
    {
        #region Variables

        private string _objectName = string.Empty;
        private string _methodName = string.Empty;
        private string _attributeName = string.Empty;
        private string _errorDescription = string.Empty;

        #endregion

        #region Constructors

        public OperationError() { }

        public OperationError(string objectName, string attributeName, string methodName, string errorDescription)
        {
            this._objectName = objectName;
            this._methodName = methodName;
            this._attributeName = attributeName;
            this._errorDescription = errorDescription;
        }

        #endregion

        #region Attributes

        public string object_name
        {
            get { return this._objectName; }
            set { this._objectName = value; }
        }

        public string method_name
        {
            get { return this._methodName; }
            set { this._methodName = value; }
        }

        public string attribute_name
        {
            get { return this._attributeName; }
            set { this._attributeName = value; }
        }

        public string error_description
        {
            get { return this._errorDescription; }
            set { this._errorDescription = value; }
        }

        #endregion
    }
}
