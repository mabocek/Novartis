using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using BocekMatous.Component.Parameters;
using JetBrains.Annotations;

namespace BocekMatous.Component
{
    public static class ComponentUtils
    {
        #region Public Methods

        public static MvcHtmlString ClientIdFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression)
        {
            return ClientIdFor(htmlHelper.ViewContext, expression);
        }

        public static MvcHtmlString ClientIdFor<TModel, TProperty>(
            this ViewContext viewContext,
            Expression<Func<TModel, TProperty>> expression)
        {
            return MvcHtmlString.Create(
                viewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(
                    ExpressionHelper.GetExpressionText(expression)));
        }

        /// <summary>
        ///     Generates random identificator of element based on prefix and type
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="type"></param>
        /// <returns>System.String</returns>
        public static string GenerateControlId(string prefix, Type type)
        {
            Contract.Requires<ArgumentException>(type != null);
            return prefix + type.Name + Guid.NewGuid().ToString("N");
        }

        /// <summary>
        ///     Generates url based on action name and optionally by controller name if current requestContext contains controller
        /// </summary>
        /// <param name="actionName">jmeno action</param>
        /// <param name="controllerName">jmeno controlleru</param>
        /// <returns>url</returns>
        public static string GenerateUrl(
            [AspMvcAction] string actionName,
            [AspMvcController] string controllerName = "")
        {
            if (!string.IsNullOrEmpty(actionName))
            {
                RequestContext requestContext = ((MvcHandler) HttpContext.Current.CurrentHandler) != null && ((MvcHandler) HttpContext.Current.CurrentHandler).RequestContext != null ? ((MvcHandler) HttpContext.Current.CurrentHandler).RequestContext : null;
                if (requestContext != null)
                {
                    if (string.IsNullOrEmpty(controllerName))
                    {
                        controllerName = requestContext.RouteData.Values["controller"] as string;
                    }

                    VirtualPathData virtualPathData = RouteTable.Routes.GetVirtualPath(requestContext, new RouteValueDictionary
                        (
                        new
                        {
                            controller = controllerName,
                            action = actionName
                        }
                        ));
                    return virtualPathData != null ? virtualPathData.VirtualPath : null;
                }
            }
            return null;
        }

        public static string GeneratetSimpleParametersUrl(IEnumerable<IParameter> parameters)
        {
            List<string> outputParameters = new List<string>();
            foreach (IParameter parameter in parameters)
            {
                outputParameters.Add(String.Format(@"{0}={1}", parameter.ParameterName, parameter.Value));
            }
            return outputParameters.Any() ? "?" + string.Join("&", outputParameters) : String.Empty;
        }

        #endregion
    }
}