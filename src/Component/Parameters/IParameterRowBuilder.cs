using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BocekMatous.Component.Parameters
{
    /// <summary>
    ///     Builder for Parameters
    /// </summary>
    /// <typeparam name="TRow"></typeparam>
    public interface IParameterRowBuilder<TRow> where TRow : class
    {
        #region Public Methods

        /// <summary>
        ///     Builder for Parameter for property by expression
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="propertyExpression"></param>
        IParameterRowBuilder<TRow> Param<TProperty>(Expression<Func<TRow, TProperty>> propertyExpression);

        /// <summary>
        ///     Builder for Parameter for property by expression and custom name
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="propertyExpression"></param>
        /// <param name="nameOfParam"></param>
        IParameterRowBuilder<TRow> Param<TProperty>(Expression<Func<TRow, TProperty>> propertyExpression, string nameOfParam);

        /// <summary>
        ///     Gets default key parameter from row
        /// </summary>
        IParameterRowBuilder<TRow> ParamId();

        /// <summary>
        ///     Gets default key parameter from row with custom name
        /// </summary>
        /// <param name="nameOfParam">Name of parameter</param>
        IParameterRowBuilder<TRow> ParamId(string nameOfParam);

        /// <summary>
        ///     Builder for Parameter for property by value and name
        /// </summary>
        /// <param name="value"></param>
        /// <param name="nameOfParam"></param>
        IParameterRowBuilder<TRow> ParamValue(object value, string nameOfParam);

        /// <summary>
        /// Adds list of value parameters
        /// </summary>
        /// <param name="parameters">Value Parameters</param>
        IParameterRowBuilder<TRow> ParamValues(IEnumerable<IParameter> parameters);

        /// <summary>
        /// Adds list of value parameters
        /// </summary>
#pragma warning disable 1570
        /// <param name="rawParamString">Raw string - i.e. workflowId=42&workflowUcastnikId=1</param>
#pragma warning restore 1570
        IParameterRowBuilder<TRow> ParamRawString(string rawParamString);

        #endregion
    }
}