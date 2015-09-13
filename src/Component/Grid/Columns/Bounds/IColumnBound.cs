using System;
using System.Collections.Generic;
using System.Web.Mvc;
using BocekMatous.Component.Data;
using BocekMatous.Component.Parameters;
using JetBrains.Annotations;

namespace BocekMatous.Component.Grid.Columns.Bounds
{
    /// <summary>
    ///     Column with assigned property from row
    /// </summary>
    /// <typeparam name="TRow"></typeparam>
    public interface IColumnBound<TRow> where TRow : class
    {
        #region Properties

        string ActionName { get; }
        IAjaxCallOptions AjaxCallOptions { get; }
        ColumnBoundOptions BoundOptions { get; }

        ColumnOptions ColumnOptions { get; }
        string ControllerName { get; }
        bool IsIdentificator { get; }

        string JavascriptCallValue { get; }
        EnumLinkType LinkType { get; }

        bool OpenInNewWindow { get; }
        IEnumerable<IParameter> Parameters { get; }
        string Url { get; }
        ViewContext ViewContext { get; }

        #endregion

        #region Public Methods

        IColumnBound<TRow> ActionLink(
            [AspMvcAction] string actionName,
            Action<IParameterRowBuilder<TRow>> parameterBuilder);

        IColumnBound<TRow> ActionLink(
            [AspMvcAction] string actionName,
            [AspMvcController] string controllerName,
            Action<IParameterRowBuilder<TRow>> parameterBuilder);

        IColumnBound<TRow> ActionLink(string actionName, string controllerName);

        IAjaxCallOptions AjaxCall(
            [AspMvcAction] string actionName,
            Action<IParameterRowBuilder<TRow>> parameterBuilder);

        IAjaxCallOptions AjaxCall(
            [AspMvcAction] string actionName,
            [AspMvcController] string controllerName,
            Action<IParameterRowBuilder<TRow>> parameterBuilder);

        IAjaxCallOptions AjaxCall(
            [AspMvcAction] string actionName,
            [AspMvcController] string controllerName);

        IColumnBound<TRow> AlignCenter();

        IColumnBound<TRow> AlignJustify();
        IColumnBound<TRow> AlignLeft();

        IColumnBound<TRow> AlignRight();

        IColumnBound<TRow> CheckBox();
        IColumnBound<TRow> ColumnCssClass(string cssClass);

        IColumnBound<TRow> Date();

        IColumnBound<TRow> DateTime();

        IColumnBound<TRow> DateTimeSeconds();

        IColumnBound<TRow> ExternalLink(
            string url,
            bool openInCurrentWindow = false);

        IColumnBound<TRow> ExternalLink(
            string url,
            Action<IParameterRowBuilder<TRow>> parameterBuilder,
            bool openInCurrentWindow = false);

        IColumnBound<TRow> Frozen(bool frozen = true);

        IColumnBound<TRow> Hide(bool hide = true);
        IColumnBound<TRow> Id();
        IColumnBound<TRow> JavascriptCall(string callback);

        IColumnBound<TRow> JavascriptCall(string callback, Action<IParameterRowBuilder<TRow>> parameterBuilder);
        IColumnBound<TRow> Sortable(bool sort = true);
        IColumnBound<TRow> Time();
        IColumnBound<TRow> TimeSeconds();

        IColumnBound<TRow> Title(string title);
        IColumnBound<TRow> Width(int width);
        IColumnBound<TRow> WidthMin(int widthMin);

        #endregion
    }

    /// <summary>
    ///     zarovnani textu ve sloupcich
    /// </summary>
    public enum EnumGridColumnAlignment
    {
        Left,
        Center,
        Right,
        Justify
    }
}