namespace BocekMatous.Component.Parameters
{
    public class Parameter : IParameter
    {
        #region Fields

        private readonly bool _useKey;
        private string _parameterName;
        private string _propertyName;
        private object _value;
        private string _rawStringParameter;

        #endregion

        #region Constructors and Destructors

        public Parameter(bool useKey)
        {
            _useKey = useKey;
        }

        public Parameter(bool useKey, string parameterName)
            : this(useKey)
        {
            _parameterName = parameterName;
        }

        public Parameter(string propertyName)
        {
            _propertyName = propertyName;
        }

        public Parameter(bool check, object value, string parameterName)
        {
            _parameterName = parameterName;
            _value = value;
        }

        #endregion

        #region Properties

        public string ParameterName
        {
            get { return _parameterName; }
        }

        public string PropertyName
        {
            get { return _propertyName; }
        }

        public bool UseKey
        {
            get { return _useKey; }
        }

        public object Value
        {
            get { return _value; }
        }

        public string ParameterRawValue
        {
            get { return _rawStringParameter; }
        }

        #endregion

        #region IParameter

        public void ParameterPropertyName(string propertyName, string parameterName)
        {
            _parameterName = parameterName;
            _propertyName = propertyName;
        }

        public void ParameterValue(object value, string parameterName)
        {
            _parameterName = parameterName;
            _value = value;
        }

#pragma warning disable 1570
        /// <summary>
        ///     Raw parameters for direct insert
        /// </summary>
        /// <param name="rawParamString">Raw string - i.e. workflowId=42&workflowUcastnikId=1</param>
#pragma warning restore 1570
        public void ParameterRawString(string rawParamString)
        {
            _rawStringParameter = rawParamString;
        }

        #endregion
    }

    public class Parameter<TRow> : IParameter where TRow : class
    {
        #region Fields

        private readonly bool _useKey;
        private string _parameterName;
        private string _propertyName;
        private object _value;
        private string _rawStringParameter;

        #endregion

        #region Constructors and Destructors

        public Parameter()
        {
        }

        public Parameter(bool useKey)
        {
            _useKey = useKey;
        }

        public Parameter(bool useKey, string parameterName) : this(useKey)
        {
            _parameterName = parameterName;
        }

        public Parameter(string propertyName)
        {
            _propertyName = propertyName;
        }

        #endregion

        #region Properties

        public string ParameterName
        {
            get { return _parameterName; }
        }

        public string PropertyName
        {
            get { return _propertyName; }
        }

        public string ParameterRawValue
        {
            get { return _rawStringParameter; }
        }

        public bool UseKey
        {
            get { return _useKey; }
        }

        public object Value
        {
            get { return _value; }
        }

        #endregion

        #region IParameter

        public void ParameterPropertyName(string propertyName, string parameterName)
        {
            _parameterName = parameterName;
            _propertyName = propertyName;
        }

        public void ParameterValue(object value, string parameterName)
        {
            _parameterName = parameterName;
            _value = value;
        }

#pragma warning disable 1570
        /// <summary>
        ///     Raw parameters for direct insert
        /// </summary>
        /// <param name="rawParamString">Raw string - i.e. workflowId=42&workflowUcastnikId=1</param>
#pragma warning restore 1570
        public void ParameterRawString(string rawParamString)
        {
            _rawStringParameter = rawParamString;
        }

        #endregion
    }
}