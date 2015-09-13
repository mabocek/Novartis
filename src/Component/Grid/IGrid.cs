using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using BocekMatous.Component.Data;
using BocekMatous.Component.Grid.Columns;
using BocekMatous.Component.Grid.Data;
using BocekMatous.Component.Grid.JsEvents;
using BocekMatous.Component.Grid.OuterCommands;

namespace BocekMatous.Component.Grid
{
    public interface IGrid<TRow> : IHtmlString where TRow : class
    {
        #region Properties

        IEnumerable<IColumn<TRow>> ColumnDefinitions { get; }
        DataSource<TRow> DataSourceValue { get; }
        IEnumerable<IGridJsEvent> GridEventDefinitions { get; }
        GridOptions Options { get; }
        IEnumerable<IOuterCommand<TRow>> OuterCommandDefinitions { get; }
        ViewContext ViewContext { get; }

        #endregion

        #region Public Methods

        IGrid<TRow> Columns(Action<IColumnBuilder<TRow>> columnBuilder);

        /// <summary>
        ///     Set's common settings for Grid
        ///     Can ovveride some your settings, so use it before defining your own settings
        /// </summary>
        IGrid<TRow> CommonSettings();

        ///// Neni mozne priradit container, protoze se grid obaluje
        ///// <summary>
        /////     Set container of grid
        ///// </summary>
        ///// <param name="id"></param>
        //IGrid<TRow> Container(string id);

        IGrid<TRow> DataSource(Action<GridDataSourceBuilder<TRow>> action);

        ///// <summary>
        ///// name of element to be rendered
        ///// </summary>bh
        //string ContainerName { get; }

        IGrid<TRow> DefaultSorting<TProperty>(Expression<Func<TRow, TProperty>> defaultSortingColumn, bool descending = false);
        IGrid<TRow> JavascriptEvents(Action<IGridJsEventBuilder> gridEventBuilder);
        IGrid<TRow> OuterActions(Action<IOuterCommandBuilder<TRow>> outerCommandBuilder);
        IGrid<TRow> Paging(bool paging);
        IGrid<TRow> PagingSize(int pagingSize);
        IGrid<TRow> SelectableOnRowClick();

        void SetDataSource(DataSource<TRow> dataSource);
        //IGrid<TRow> TableCssClass(string cssClass);
        IGrid<TRow> TableTitle(string title);

        IGrid<TRow> Name(string name);

        #endregion

        //IGrid<TRow> Selectable();
        //IGrid<TRow> MultiSelectable();
        //IGrid<TRow> SelectableCheckboxes();
    }
}