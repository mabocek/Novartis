using System;
using System.Collections.Generic;
using System.Web.Mvc;
using BocekMatous.Component.Data;
using BocekMatous.Component.Grid.Columns;
using BocekMatous.Component.Parameters;
using BocekMatous.Component.Popup;
using JetBrains.Annotations;

namespace BocekMatous.Component.Grid.OuterCommands
{
    public class OuterCommand<TRow> : IOuterCommand<TRow> where TRow : class
    {
        #region Fields

        private readonly EnumCommandType _commandType;
        private readonly IGrid<TRow> _grid;
        private readonly CommandOptions _options;
        private readonly List<IParameter> _parameters;
        private readonly PopupOptions _popupOptions;
        private readonly ViewContext _viewContext;
        private string _actionName;
        private AjaxCallOptions _ajaxCallOptions;
        private string _controllerName;
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

        public OuterCommand(ViewContext viewContext, IGrid<TRow> grid)
        {
            _viewContext = viewContext;
            _grid = grid;
            _options = new CommandOptions();
            _ajaxCallOptions = new AjaxCallOptions();
            _parameters = new List<IParameter>();
            _popupOptions = new PopupOptions
                            {
                                DisplayParameters = new List<IParameter>()
                            };
        }

        public OuterCommand(ViewContext viewContext, IGrid<TRow> grid, EnumLinkType linkType) : this(viewContext, grid)
        {
            _linkType = linkType;
        }

        public OuterCommand(ViewContext viewContext, string name)
        {
            _viewContext = viewContext;
            _options = new CommandOptions();
            _options.Title = name;
            _parameters = new List<IParameter>();
            _popupOptions = new PopupOptions
                            {
                                DisplayParameters = new List<IParameter>()
                            };
        }

        public OuterCommand(ViewContext viewContext, string name, EnumLinkType linkType) : this(viewContext, name)
        {
            _linkType = linkType;
        }

        public OuterCommand(ViewContext viewContext, IGrid<TRow> grid, EnumCommandType commandType) : this(viewContext, grid)
        {
            _options = new CommandOptions();
            _commandType = commandType;
        }

        public OuterCommand(ViewContext viewContext, IGrid<TRow> grid, string htmlId, string htmlName)
            : this(viewContext, grid)
        {
            _options.HtmlName = htmlName;
            _options.HtmlId = htmlId;
        }

        public OuterCommand(ViewContext viewContext, IGrid<TRow> grid, string name, string htmlId, string htmlName)
            : this(viewContext, grid, htmlId, htmlName)
        {
            _options.Title = name;
        }

        public OuterCommand(ViewContext viewContext, IGrid<TRow> grid, EnumCommandType commandType, EnumLinkType linkType) :
            this(viewContext, grid, commandType)
        {
            _linkType = linkType;
        }

        public OuterCommand(ViewContext viewContext, IGrid<TRow> grid, EnumLinkType linkType, string htmlId, string htmlName)
            : this(viewContext, grid, linkType)
        {
            _options.HtmlName = htmlName;
            _options.HtmlId = htmlId;
        }

        public OuterCommand(ViewContext viewContext, string name, IGrid<TRow> grid, EnumCommandType commandType)
            : this(viewContext, grid, commandType)
        {
            _options.Title = name;
        }

        public OuterCommand(ViewContext viewContext, string name, IGrid<TRow> grid, EnumLinkType linkType)
            : this(viewContext, grid)
        {
            _options.Title = name;
            _linkType = linkType;
        }

        public OuterCommand(ViewContext viewContext, string name, IGrid<TRow> grid, EnumLinkType linkType, string htmlId, string htmlName)
            : this(viewContext, grid, linkType)
        {
            _options.Title = name;
            _options.HtmlName = htmlName;
            _options.HtmlId = htmlId;
        }

        public OuterCommand(ViewContext viewContext, string name, IGrid<TRow> grid, EnumCommandType commandType, string htmlId, string htmlName) :
            this(viewContext, grid, commandType)
        {
            _options.Title = name;
            _options.HtmlName = htmlName;
            _options.HtmlId = htmlId;
        }

        public OuterCommand(ViewContext viewContext, string name, IGrid<TRow> grid, EnumCommandType commandType, EnumLinkType linkType) : this(viewContext, grid, commandType, linkType)
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

        public PopupOptions PopupOptions
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

        #region Public Methods

        public IOuterCommand<TRow> UnderGrid(bool renderUnderGrid = true)
        {
            _options.RenderUnderGrid = renderUnderGrid;
            return this;
        }

        #endregion

        #region IOuterCommand<TRow>

        public IOuterCommand<TRow> ActionLink(
            [AspMvcAction] string actionName,
            Action<IParameterBuilder<TRow>> parameterBuilder)
        {
            _actionName = actionName;
            var builder = new ParameterBuilder<TRow>(_viewContext, _parameters);
            parameterBuilder(builder);
            _linkType = EnumLinkType.Link;
            return this;
        }

        public IOuterCommand<TRow> ActionLink(
            [AspMvcAction] string actionName,
            [AspMvcController] string controllerName,
            Action<IParameterBuilder<TRow>> parameterBuilder)
        {
            _actionName = actionName;
            _controllerName = controllerName;
            var builder = new ParameterBuilder<TRow>(_viewContext, _parameters);
            parameterBuilder(builder);
            _linkType = EnumLinkType.Link;
            return this;
        }

        public IOuterCommand<TRow> ActionLink(
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
            Action<IParameterBuilder<TRow>> parameterBuilder,
            bool reloadGridAfterExecution = false)
        {
            _actionName = actionName;
            var builder = new ParameterBuilder<TRow>(_viewContext, _parameters);
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
            Action<IParameterBuilder<TRow>> parameterBuilder,
            bool reloadGridAfterExecution = false)
        {
            _actionName = actionName;
            _controllerName = controllerName;
            var builder = new ParameterBuilder<TRow>(_viewContext, _parameters);
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

        public IOuterCommand<TRow> DisabledIf(bool value)
        {
            _options.DisabledIfValue = value;
            return this;
        }

        public IOuterCommand<TRow> DisplayPopup(
            [AspMvcAction] string popupActionName,
            [AspMvcController] string popupControllerName,
            Action<IParameterBuilder<TRow>> popupParameters,
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
            var builder = new ParameterBuilder<TRow>(_viewContext, _popupOptions.DisplayParameters);
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
            _usePopup = true;
            return this;
        }

        public IOuterCommand<TRow> DisplayPopupConfirmation(
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
            _popupOptions.ModalButtons = modalButtons;
            _popupOptions.ModalSize = modalSize;
            _reloadGridAfterExecution = reloadOnSuccess;
            _reloadGridAfterPopupCancelClose = reloadOnCancelClose;
            _javascriptOnPopupClose = javascriptOnClose;
            _usePopup = true;
            return this;
        }

        public IOuterCommand<TRow> ExternalLink(string url, bool openInCurrentWindow = false)
        {
            _url = url;
            _newWindow = !openInCurrentWindow;
            _linkType = EnumLinkType.ExternalLink;
            return this;
        }

        public IOuterCommand<TRow> ExternalLink(string url, Action<IParameterBuilder<TRow>> parameterBuilder, bool openInCurrentWindow = false)
        {
            _url = url;
            _newWindow = !openInCurrentWindow;
            var builder = new ParameterBuilder<TRow>(_viewContext, _parameters);
            parameterBuilder(builder);
            _linkType = EnumLinkType.ExternalLink;
            return this;
        }

        public IOuterCommand<TRow> Icon(string cssIcon, string disabledCssIcon = "")
        {
            _options.IconCssClass = cssIcon;
            _options.IconDisabledCssClass = disabledCssIcon;
            return this;
        }

        public IOuterCommand<TRow> JavascriptCall(string callback)
        {
            _javascriptCallValue = callback;
            _linkType = EnumLinkType.JsAction;
            return this;
        }

        public IOuterCommand<TRow> JavascriptCall(string callback, Action<IParameterBuilder<TRow>> parameterBuilder)
        {
            _javascriptCallValue = callback;
            var builder = new ParameterBuilder<TRow>(_viewContext, _parameters);
            _linkType = EnumLinkType.JsActionParam;
            parameterBuilder(builder);
            return this;
        }

        public IOuterCommand<TRow> Text(string title)
        {
            _options.Title = title;
            return this;
        }

        #endregion
    }
}