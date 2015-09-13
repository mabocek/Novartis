using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using BocekMatous.Component.Data;
using BocekMatous.Component.Parameters;
using JetBrains.Annotations;

namespace BocekMatous.Component.Grid.Columns.Bounds
{
    /// <summary>
    ///     trida sloupce gridu
    /// </summary>
    /// <typeparam name="TRow"></typeparam>
    public class ColumnBound<TRow> : IColumnBound<TRow> where TRow : class
    {
        #region Fields

        private readonly ColumnBoundOptions _boundOptions;
        private readonly ColumnOptions _columnOptions;
        private readonly IGrid<TRow> _grid;
        private readonly List<IParameter> _parameters;
        private readonly ViewContext _viewContext;
        private string _actionName;
        private AjaxCallOptions _ajaxCallOptions;
        private string _controllerName;
        private bool _isIdentificator;
        private string _javascriptCallValue;
        private EnumLinkType _linkType;
        private string _url;
        private bool _newWindow;

        #endregion

        #region Constructors and Destructors

        public ColumnBound(ViewContext viewContext, string name, IGrid<TRow> grid)
        {
            _viewContext = viewContext;
            _grid = grid;
            _boundOptions = new ColumnBoundOptions();
            _columnOptions = new ColumnOptions();
            _boundOptions.PropertyName = name;
            _columnOptions.Title(name);
            _columnOptions.SortName(name);
            _ajaxCallOptions = new AjaxCallOptions();
            _parameters = new List<IParameter>();
        }

        #endregion

        #region Properties

        public string ActionName
        {
            get { return _actionName; }
        }

        public IAjaxCallOptions AjaxCallOptions
        {
            get { return _ajaxCallOptions; }
        }

        public ColumnBoundOptions BoundOptions
        {
            get { return _boundOptions; }
        }

        public ColumnOptions ColumnOptions
        {
            get { return _columnOptions; }
        }

        public string ControllerName
        {
            get { return _controllerName; }
        }

        public bool IsIdentificator
        {
            get { return _isIdentificator; }
        }

        public string JavascriptCallValue
        {
            get { return _javascriptCallValue; }
        }

        public EnumLinkType LinkType
        {
            get { return _linkType; }
        }

        public bool OpenInNewWindow { get { return _newWindow; } }

        public IEnumerable<IParameter> Parameters
        {
            get { return _parameters; }
        }

        public string Url { get { return _url; } }

        public ViewContext ViewContext
        {
            get { return _viewContext; }
        }

        internal AjaxCallOptions AjaxCallOptionsValue
        {
            get { return _ajaxCallOptions; }
            set { _ajaxCallOptions = value; }
        }

        #endregion

        #region Public Methods

        public ColumnBound<TRow> Alignment(EnumGridColumnAlignment alignment)
        {
            _columnOptions.Alignment(alignment);
            return this;
        }

        #endregion

        #region IColumnBound<TRow>

        public IColumnBound<TRow> ActionLink(
            [AspMvcAction] string actionName,
            Action<IParameterRowBuilder<TRow>> parameterBuilder)
        {
            _actionName = actionName;
            var builder = new ParameterRowBuilder<TRow>(_viewContext, _parameters);
            parameterBuilder(builder);
            _linkType = EnumLinkType.Link;
            return this;
        }

        public IColumnBound<TRow> ActionLink(
            [AspMvcAction] string actionName,
            [AspMvcController] string controllerName,
            Action<IParameterRowBuilder<TRow>> parameterBuilder)
        {
            _actionName = actionName;
            _controllerName = controllerName;
            var builder = new ParameterRowBuilder<TRow>(_viewContext, _parameters);
            parameterBuilder(builder);
            _linkType = EnumLinkType.Link;
            return this;
        }

        public IColumnBound<TRow> ActionLink(
            [AspMvcAction] string actionName,
            [AspMvcController] string controllerName)
        {
            _actionName = actionName;
            _controllerName = controllerName;
            _linkType = EnumLinkType.Link;
            return this;
        }

        public IAjaxCallOptions AjaxCall(
            [AspMvcAction] string actionName,
            Action<IParameterRowBuilder<TRow>> parameterBuilder)
        {
            _actionName = actionName;
            var builder = new ParameterRowBuilder<TRow>(_viewContext, _parameters);
            parameterBuilder(builder);
            _linkType = EnumLinkType.Ajax;
            return AjaxCallOptionsValue;
        }

        public IAjaxCallOptions AjaxCall(
            [AspMvcAction] string actionName,
            [AspMvcController] string controllerName,
            Action<IParameterRowBuilder<TRow>> parameterBuilder)
        {
            _actionName = actionName;
            _controllerName = controllerName;
            var builder = new ParameterRowBuilder<TRow>(_viewContext, _parameters);
            parameterBuilder(builder);
            _linkType = EnumLinkType.Ajax;
            return AjaxCallOptionsValue;
        }

        public IAjaxCallOptions AjaxCall(
            [AspMvcAction] string actionName,
            [AspMvcController] string controllerName)
        {
            _actionName = actionName;
            _controllerName = controllerName;
            _linkType = EnumLinkType.Ajax;
            return AjaxCallOptionsValue;
        }

        public IColumnBound<TRow> AlignCenter()
        {
            _columnOptions.Alignment(EnumGridColumnAlignment.Center);
            return this;
        }

        public IColumnBound<TRow> AlignJustify()
        {
            _columnOptions.Alignment(EnumGridColumnAlignment.Justify);
            return this;
        }

        public IColumnBound<TRow> AlignLeft()
        {
            _columnOptions.Alignment(EnumGridColumnAlignment.Left);
            return this;
        }

        public IColumnBound<TRow> AlignRight()
        {
            _columnOptions.Alignment(EnumGridColumnAlignment.Right);
            return this;
        }

        public IColumnBound<TRow> CheckBox()
        {
            _boundOptions.Checkbox = true;
            _columnOptions.Alignment(EnumGridColumnAlignment.Center);
            return this;
        }

        public IColumnBound<TRow> ColumnCssClass(string cssClass)
        {
            _columnOptions.ColumnCssClass(cssClass);
            return this;
        }

        public IColumnBound<TRow> Date()
        {
            _boundOptions.Date = true;
            return this;
        }

        public IColumnBound<TRow> DateTime()
        {
            _boundOptions.DateTime = true;
            return this;
        }

        public IColumnBound<TRow> DateTimeSeconds()
        {
            _boundOptions.DateTimeSeconds = true;
            return this;
        }

        public IColumnBound<TRow> ExternalLink(string url, bool openInCurrentWindow = false)
        {
            _url = url;
            _newWindow = !openInCurrentWindow;
            _linkType = EnumLinkType.ExternalLink;
            return this;
        }

        public IColumnBound<TRow> ExternalLink(string url, Action<IParameterRowBuilder<TRow>> parameterBuilder, bool openInCurrentWindow = false)
        {
            _url = url;
            _newWindow = !openInCurrentWindow;
            var builder = new ParameterRowBuilder<TRow>(_viewContext, _parameters);
            parameterBuilder(builder);
            _linkType = EnumLinkType.ExternalLink;
            return this;
        }

        public IColumnBound<TRow> Frozen(bool frozen = true)
        {
            _columnOptions.Frozen(frozen);
            return this;
        }

        public IColumnBound<TRow> Hide(bool hide = true)
        {
            _columnOptions.Hide(hide);
            return this;
        }

        public IColumnBound<TRow> Id()
        {
            _isIdentificator = true;
            return this;
        }

        public IColumnBound<TRow> JavascriptCall(string callback)
        {
            _javascriptCallValue = callback;
            _linkType = EnumLinkType.JsAction;
            return this;
        }

        public IColumnBound<TRow> JavascriptCall(string callback, Action<IParameterRowBuilder<TRow>> parameterBuilder)
        {
            _javascriptCallValue = callback;
            var builder = new ParameterRowBuilder<TRow>(_viewContext, _parameters);
            _linkType = EnumLinkType.JsActionParam;
            parameterBuilder(builder);
            return this;
        }

        public IColumnBound<TRow> Sortable(bool sort = true)
        {
            _columnOptions.Sortable(sort);
            return this;
        }

        public IColumnBound<TRow> Time()
        {
            _boundOptions.Time = true;
            return this;
        }

        public IColumnBound<TRow> TimeSeconds()
        {
            _boundOptions.TimeSeconds = true;
            return this;
        }

        public IColumnBound<TRow> Title(string title)
        {
            _columnOptions.Title(title);
            return this;
        }

        public IColumnBound<TRow> Width(int width)
        {
            _columnOptions.Width(width);
            return this;
        }

        public IColumnBound<TRow> WidthMin(int widthMin)
        {
            _columnOptions.WidthMin(widthMin);
            return this;
        }

        #endregion
    }

    public class ColumnBound<TRow, TProperty> : ColumnBound<TRow> where TRow : class
    {
        #region Fields

        private readonly Expression<Func<TRow, TProperty>> _propertyExpression;

        #endregion

        #region Constructors and Destructors

        public ColumnBound(ViewContext viewContext, Expression<Func<TRow, TProperty>> propertyExpression, IGrid<TRow> grid)
            : base(viewContext, ExpressionHelper.GetExpressionText(propertyExpression), grid)
        {
            _propertyExpression = propertyExpression;

            if (typeof (TProperty) == typeof (bool))
            {
                CheckBox();
            }
            else if (typeof (TProperty) == typeof (DateTime) || typeof (TProperty) == typeof (DateTime?))
            {
                Date();
            }
        }

        #endregion

        #region Properties

        public Expression<Func<TRow, TProperty>> PropertyExpression
        {
            get { return _propertyExpression; }
        }

        #endregion
    }
}