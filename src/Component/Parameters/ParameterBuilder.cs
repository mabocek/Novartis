using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace BocekMatous.Component.Parameters
{
    public class ParameterBuilder<TRow> : IParameterBuilder<TRow> where TRow : class
    {
        #region Fields

        private readonly List<IParameter> _parameters;

        #endregion

        //private readonly OuterCommand<TRow> _outerCommand;

        #region Constructors and Destructors

        public ParameterBuilder(ViewContext viewContext, List<IParameter> parameters)
        {
            _parameters = parameters;
        }

        #endregion

        //public ParameterBuilder(ViewContext viewContext, OuterCommand<TRow> outerCommand, List<IParameter> parameters)
        //{
        //    _parameters = parameters;
        //    _outerCommand = outerCommand;
        //}

        #region Public Methods

        public IParameterBuilder<TRow> Param<TProperty>(Expression<Func<TRow, TProperty>> propertyExpression)
        {
            IParameter parameter = new Parameter<TRow>(ExpressionHelper.GetExpressionText(propertyExpression));
            _parameters.Add(parameter);
            return this;
        }

        public IParameterBuilder<TRow> Param<TProperty>(Expression<Func<TRow, TProperty>> propertyExpression, string nameOfParam)
        {
            IParameter parameter = new Parameter<TRow>();
            parameter.ParameterPropertyName(nameOfParam, ExpressionHelper.GetExpressionText(propertyExpression));
            _parameters.Add(parameter);
            return this;
        }

        public IParameterBuilder<TRow> ParamId(string nameOfParam)
        {
            IParameter parameter = new Parameter<TRow>(true, nameOfParam);
            _parameters.Add(parameter);
            return this;
        }

        public IParameterBuilder<TRow> ParamId()
        {
            IParameter parameter = new Parameter<TRow>(true);
            _parameters.Add(parameter);
            return this;
        }

        #endregion

        #region IParameterBuilder<TRow>

        public IParameterBuilder<TRow> ParamValue(object value, string nameOfParam)
        {
            IParameter parameter = new Parameter<TRow>();
            parameter.ParameterValue(value, nameOfParam);
            _parameters.Add(parameter);
            return this;
        }

        #endregion
    }
}