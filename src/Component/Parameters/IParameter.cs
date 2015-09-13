namespace BocekMatous.Component.Parameters
{
    public interface IParameter
    {
        #region Properties

        string ParameterName { get; }

        string PropertyName { get; }

        bool UseKey { get; }
        object Value { get; }

        /// <summary>
        ///  Raw parameters for direct insert 
        /// </summary>
        string ParameterRawValue { get; }

        #endregion

        #region Public Methods

        void ParameterPropertyName(string propertyName, string parameterName);

        #pragma warning disable 1570
        /// <summary>
        ///     Raw parameters for direct insert
        /// </summary>
        /// <param name="rawParamString">Raw string - i.e. workflowId=42&workflowUcastnikId=1</param>
#pragma warning restore 1570
        void ParameterRawString(string rawParamString);

        void ParameterValue(object value, string parameterName);

        #endregion
    }
}