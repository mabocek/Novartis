namespace BocekMatous.Component.Parameters
{
    public interface IParameterBuilder<TRow> where TRow : class
    {
        #region Public Methods

        /// <summary>
        ///     Builder for Parameter for property by value and name
        /// </summary>
        /// <param name="value"></param>
        /// <param name="nameOfParam"></param>
        /// <returns></returns>
        IParameterBuilder<TRow> ParamValue(object value, string nameOfParam);

        #endregion
    }
}