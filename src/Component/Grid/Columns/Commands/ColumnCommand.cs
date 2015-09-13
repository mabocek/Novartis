using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using BocekMatous.Component.Data;
using BocekMatous.Component.Parameters;
using BocekMatous.Component.Popup;
using JetBrains.Annotations;

namespace BocekMatous.Component.Grid.Columns.Commands
{
    public class ColumnCommand<TRow> : IColumnCommand<TRow> where TRow : class
    {
        #region Fields

        private readonly EnumCommandType _commandType;
        private readonly IGrid<TRow> _grid;
        private readonly CommandOptions _options;
        private readonly List<IParameter> _parameters;
        private readonly PopupOptions<TRow> _popupOptions;
        private readonly ViewContext _viewContext;
        private string _actionName;
        private AjaxCallOptions _ajaxCallOptions;
        private string _controllerName;
        private string _disabledIfPopupNotificationText;
        private string _disabledIfPopupNotificationTitle;
        private string _javascriptCallValue;
        private string _javascriptOnPopupClose;
        private EnumLinkType _linkType;
        private bool _newWindow;
        private bool _reloadGridAfterExecution;
        private bool _reloadGridAfterPopupCancelClose;
        private string _url;
        private bool _usePopup;

        #endregion

        #region Constructors and Destructors

        public ColumnCommand(ViewContext viewContext, IGrid<TRow> grid)
        {
            _viewContext = viewContext;
            _grid = grid;
            _options = new CommandOptions();
            _ajaxCallOptions = new AjaxCallOptions();
            _parameters = new List<IParameter>();
            _popupOptions = new PopupOptions<TRow>();
            _popupOptions.DisplayParameters = new List<IParameter>();
        }

        public ColumnCommand(ViewContext viewContext, IGrid<TRow> grid, EnumLinkType linkType) : this(viewContext, grid)
        {
            _linkType = linkType;
        }

        public ColumnCommand(ViewContext viewContext, string name)
        {
            _viewContext = viewContext;
            _options = new CommandOptions();
            _options.Title = name;
            _parameters = new List<IParameter>();
            _popupOptions = new PopupOptions<TRow>();
            _popupOptions.DisplayParameters = new List<IParameter>();
        }

        public ColumnCommand(ViewContext viewContext, string name, EnumLinkType linkType) : this(viewContext, name)
        {
            _linkType = linkType;
        }

        public ColumnCommand(ViewContext viewContext, IGrid<TRow> grid, EnumCommandType commandType) : this(viewContext, grid)
        {
            _options = new CommandOptions();
            _commandType = commandType;
        }

        public ColumnCommand(ViewContext viewContext, IGrid<TRow> grid, EnumCommandType commandType, EnumLinkType linkType) :
            this(viewContext, grid, commandType)
        {
            _linkType = linkType;
        }

        public ColumnCommand(ViewContext viewContext, string name, IGrid<TRow> grid, EnumCommandType commandType)
            : this(viewContext, grid, commandType)
        {
            _options.Title = name;
        }

        public ColumnCommand(ViewContext viewContext, string name, IGrid<TRow> grid, EnumLinkType linkType)
            : this(viewContext, grid)
        {
            _linkType = linkType;
            _options.Title = name;
        }

        public ColumnCommand(ViewContext viewContext, string name, IGrid<TRow> grid, EnumCommandType commandType, EnumLinkType linkType) : this(viewContext, grid, commandType, linkType)
        {
            _options.Title = name;
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

        public EnumCommandType CommandType
        {
            get { return _commandType; }
        }

        public string ControllerName
        {
            get { return _controllerName; }
        }

        public string DisabledIfPopupNotificationText
        {
            get { return _disabledIfPopupNotificationText; }
        }

        public string DisabledIfPopupNotificationTitle
        {
            get { return _disabledIfPopupNotificationTitle; }
        }

        public string JavascriptCallValue
        {
            get { return _javascriptCallValue; }
        }

        public string JavascriptOnPopupClose
        {
            get { return _javascriptOnPopupClose; }
        }

        public EnumLinkType LinkType
        {
            get { return _linkType; }
        }

        public bool OpenInNewWindow
        {
            get { return _newWindow; }
        }

        public CommandOptions Options
        {
            get { return _options; }
        }

        public IEnumerable<IParameter> Parameters
        {
            get { return _parameters; }
        }

        public PopupOptions<TRow> PopupOptions
        {
            get { return _popupOptions; }
        }

        public bool ReloadGridAfterExecution
        {
            get { return _reloadGridAfterExecution; }
        }

        public bool ReloadGridAfterPopupCancelClose
        {
            get { return _reloadGridAfterPopupCancelClose; }
        }

        public string Url
        {
            get { return _url; }
        }

        public bool UsePopup
        {
            get { return _usePopup; }
        }

        internal AjaxCallOptions AjaxCallOptionsValue
        {
            get { return _ajaxCallOptions; }
            set { _ajaxCallOptions = value; }
        }

        #endregion

        #region IColumnCommand<TRow>

        public IColumnCommand<TRow> ActionLink(
            [AspMvcAction] string actionName,
            Action<IParameterRowBuilder<TRow>> parameterBuilder)
        {
            _actionName = actionName;
            var builder = new ParameterRowBuilder<TRow>(_viewContext, _parameters);
            parameterBuilder(builder);
            _linkType = EnumLinkType.Link;
            return this;
        }

        public IColumnCommand<TRow> ActionLink(
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

        public IColumnCommand<TRow> ActionLink(
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
            Action<IParameterRowBuilder<TRow>> parameterBuilder,
            bool reloadGridAfterExecution = false)
        {
            _actionName = actionName;
            var builder = new ParameterRowBuilder<TRow>(_viewContext, _parameters);
            parameterBuilder(builder);
            //ochrana proti negaci - reload gridu muze byt nastaven uz z display popupu
            if (!_reloadGridAfterExecution)
                _reloadGridAfterExecution = reloadGridAfterExecution;
            _linkType = EnumLinkType.Ajax;
            return AjaxCallOptionsValue;
        }

        public IAjaxCallOptions AjaxCall(
            [AspMvcAction] string actionName,
            [AspMvcController] string controllerName,
            Action<IParameterRowBuilder<TRow>> parameterBuilder,
            bool reloadGridAfterExecution = false)
        {
            _actionName = actionName;
            _controllerName = controllerName;
            var builder = new ParameterRowBuilder<TRow>(_viewContext, _parameters);
            parameterBuilder(builder);
            //ochrana proti negaci - reload gridu muze byt nastaven uz z display popupu
            if (!_reloadGridAfterExecution)
                _reloadGridAfterExecution = reloadGridAfterExecution;
            _linkType = EnumLinkType.Ajax;
            return AjaxCallOptionsValue;
        }

        public IAjaxCallOptions AjaxCall(
            [AspMvcAction] string actionName,
            [AspMvcController] string controllerName,
            bool reloadGridAfterExecution = false)
        {
            _actionName = actionName;
            _controllerName = controllerName;
            //ochrana proti negaci - reload gridu muze byt nastaven uz z display popupu
            if (!_reloadGridAfterExecution)
                _reloadGridAfterExecution = reloadGridAfterExecution;
            _linkType = EnumLinkType.Ajax;
            return AjaxCallOptionsValue;
        }

        public IColumnCommand<TRow> DisabledIf<TProperty>(Expression<Func<TRow, TProperty>> propertyExpression)
        {
            string expressionText = ExpressionHelper.GetExpressionText(propertyExpression);
            if (propertyExpression.ReturnType != typeof (bool) || String.IsNullOrEmpty(expressionText))
            {
                throw new Exception(String.Format("Grid - ColumnCommand{0} has invalid Expression for DisabledIf", !string.IsNullOrEmpty(_options.Title) ? " with title " + _options.Title : null));
            }
            _options.DisabledIfProperty = expressionText;
            return this;
        }

        public IColumnCommand<TRow> DisabledIf(bool value)
        {
            _options.DisabledIfValue = value;
            return this;
        }

        public IColumnCommand<TRow> IconIf<TProperty>(Expression<Func<TRow, TProperty>> propertyExpression)
        {
            string expressionText = ExpressionHelper.GetExpressionText(propertyExpression);
            if (propertyExpression.ReturnType != typeof(bool) || String.IsNullOrEmpty(expressionText))
            {
                throw new Exception(String.Format("Grid - ColumnCommand{0} has invalid Expression for HiddenIf", !string.IsNullOrEmpty(_options.Title) ? " with title " + _options.Title : null));
            }
            _options.IconIfProperty = expressionText;
            return this;
        }

        public IColumnCommand<TRow> IconIf(bool value)
        {
            _options.IconIfValue = value;
            return this;
        }

        public IColumnCommand<TRow> DisabledIfPopupNotification<TProperty>(Expression<Func<TRow, TProperty>> propertyExpression, string title, string text)
        {
            _disabledIfPopupNotificationTitle = title;
            _disabledIfPopupNotificationText = text;
            return DisabledIf(propertyExpression);
        }

        public IColumnCommand<TRow> DisabledIfPopupNotification(bool value, string title, string text)
        {
            _disabledIfPopupNotificationTitle = title;
            _disabledIfPopupNotificationText = text;
            return DisabledIf(value);
        }

        public IColumnCommand<TRow> DisplayPopup(
            [AspMvcAction] string popupActionName,
            [AspMvcController] string popupControllerName,
            Action<IParameterRowBuilder<TRow>> popupParameters,
            [AspMvcAction] string popupSubmitActionName,
            [AspMvcController] string popupSubmitControllerName,
            string title,
            ModalSize modalSize = ModalSize.Small,
            ModalButtons modalButtons = ModalButtons.OkCancel,
            string popupId = null,
            bool reloadOnSuccess = true,
            bool reloadOnCancelClose = false,
            string javascriptOnClose = "")
        {
            _popupOptions.DisplayActionName = popupActionName;
            _popupOptions.DisplayControllerName = popupControllerName;
            var builder = new ParameterRowBuilder<TRow>(_viewContext, _popupOptions.DisplayParameters);
            popupParameters(builder);
            _popupOptions.Id = popupId;
            _popupOptions.SubmitActionName = popupSubmitActionName;
            _popupOptions.SubmitControllerName = popupSubmitControllerName;
            _popupOptions.Title = title;
            _popupOptions.ModalSize = modalSize;
            _popupOptions.ModalButtons = modalButtons;
            _reloadGridAfterExecution = reloadOnSuccess;
            _reloadGridAfterPopupCancelClose = reloadOnCancelClose;
            _javascriptOnPopupClose = javascriptOnClose;
            _javascriptOnPopupClose = javascriptOnClose;
            _usePopup = true;
            return this;
        }

        public IColumnCommand<TRow> DisplayPopupConfirmation(
            string text,
            string title,
            ModalSize modalSize = ModalSize.Small,
            ModalButtons modalButtons = ModalButtons.OkCancel,
            string popupId = null,
            bool reloadOnSuccess = true,
            bool reloadOnCancelClose = false,
            string javascriptOnClose = "")
        {
            _popupOptions.Id = popupId;
            _popupOptions.Title = title;
            _popupOptions.Text = text;
            _popupOptions.ModalSize = modalSize;
            _popupOptions.ModalButtons = modalButtons;
            _reloadGridAfterExecution = reloadOnSuccess;
            _reloadGridAfterPopupCancelClose = reloadOnCancelClose;
            _javascriptOnPopupClose = javascriptOnClose;
            _usePopup = true;
            return this;
        }

        public IColumnCommand<TRow> ExternalLink(string url, bool openInCurrentWindow = false)
        {
            _url = url;
            _newWindow = !openInCurrentWindow;
            _linkType = EnumLinkType.ExternalLink;
            return this;
        }

        public IColumnCommand<TRow> ExternalLink(string url, Action<IParameterRowBuilder<TRow>> parameterBuilder, bool openInCurrentWindow = false)
        {
            _url = url;
            _newWindow = !openInCurrentWindow;
            var builder = new ParameterRowBuilder<TRow>(_viewContext, _parameters);
            parameterBuilder(builder);
            _linkType = EnumLinkType.ExternalLink;
            return this;
        }

        public IColumnCommand<TRow> Icon(string cssIcon, string disabledCssIcon = "")
        {
            _options.IconCssClass = cssIcon;
            _options.IconDisabledCssClass = disabledCssIcon;
            return this;
        }

        public IColumnCommand<TRow> JavascriptCall(string callback)
        {
            _javascriptCallValue = callback;
            _linkType = EnumLinkType.JsAction;
            return this;
        }

        public IColumnCommand<TRow> JavascriptCall(string callback, Action<IParameterRowBuilder<TRow>> parameterBuilder)
        {
            _javascriptCallValue = callback;
            var builder = new ParameterRowBuilder<TRow>(_viewContext, _parameters);
            _linkType = EnumLinkType.JsActionParam;
            parameterBuilder(builder);
            return this;
        }

        public IColumnCommand<TRow> Title(string title)
        {
            _options.Title = title;
            return this;
        }

        #endregion
    }
}