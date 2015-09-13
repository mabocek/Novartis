using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace BocekMatous.Component.Parameters
{
    public class ParameterRowBuilder<TRow> : IParameterRowBuilder<TRow> where TRow : class
    {
        #region Fields

        private readonly List<IParameter> _parameters;

        #endregion

        #region Constructors and Destructors

        public ParameterRowBuilder(ViewContext viewContext, List<IParameter> parameters)
        {
            _parameters = parameters;
        }

        #endregion

        #region IParameterRowBuilder<TRow>

        public IParameterRowBuilder<TRow> Param<TProperty>(Expression<Func<TRow, TProperty>> propertyExpression)
        {
            IParameter parameter = new Parameter<TRow>(ExpressionHelper.GetExpressionText(propertyExpression));
            _parameters.Add(parameter);
            return this;
        }

        public IParameterRowBuilder<TRow> Param<TProperty>(Expression<Func<TRow, TProperty>> propertyExpression, string nameOfParam)
        {
            IParameter parameter = new Parameter<TRow>();
            parameter.ParameterPropertyName(ExpressionHelper.GetExpressionText(propertyExpression), nameOfParam);
            _parameters.Add(parameter);
            return this;
        }

        public IParameterRowBuilder<TRow> ParamId(string nameOfParam)
        {
            IParameter parameter = new Parameter<TRow>(true, nameOfParam);
            _parameters.Add(parameter);
            return this;
        }

        public IParameterRowBuilder<TRow> ParamId()
        {
            IParameter parameter = new Parameter<TRow>(true);
            _parameters.Add(parameter);
            return this;
        }

        public IParameterRowBuilder<TRow> ParamRawString(string rawParamString)
        {
            IParameter parameter = new Parameter<TRow>();
            parameter.ParameterRawString(rawParamString);
            _parameters.Add(parameter);
            return this;
        }

        public IParameterRowBuilder<TRow> ParamValue(object value, string nameOfParam)
        {
            IParameter parameter = new Parameter<TRow>();
            parameter.ParameterValue(value, nameOfParam);
            _parameters.Add(parameter);
            return this;
        }

        public IParameterRowBuilder<TRow> ParamValues(IEnumerable<IParameter> parameters)
        {
            if (parameters != null && parameters.Any())
            {
                _parameters.AddRange(parameters.Select(p =>
                                                       {
                                                           IParameter param = new Parameter<TRow>();
                                                           param.ParameterValue(p.Value, p.ParameterName);
                                                           return param;
                                                       }));
            }
            return this;
        }

        #endregion
    }
}