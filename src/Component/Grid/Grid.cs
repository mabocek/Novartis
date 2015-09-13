using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using BocekMatous.Component.Data;
using BocekMatous.Component.Grid.Columns;
using BocekMatous.Component.Grid.Columns.Commands;
using BocekMatous.Component.Grid.Data;
using BocekMatous.Component.Grid.JsEvents;
using BocekMatous.Component.Grid.OuterCommands;

namespace BocekMatous.Component.Grid
{
    /// <summary>
    ///     Generic Grid
    /// </summary>
    /// <typeparam name="TRow"></typeparam>
    public class Grid<TRow> : IGrid<TRow> where TRow : class
    {
        #region Fields

        private readonly List<IColumn<TRow>> _column;
        private readonly List<IColumnCommand<TRow>> _commands;
        private readonly List<IGridJsEvent> _jsEvents;
        private readonly GridOptions _options;
        private readonly List<IOuterCommand<TRow>> _outerCommands;
        private readonly ViewContext _viewContext;
        private DataSource<TRow> _dataSource;

        #endregion

        #region Constructors and Destructors

        public Grid(ViewContext viewContext)
        {
            _viewContext = viewContext;
            _column = new List<IColumn<TRow>>();
            _options = new GridOptions();
            _dataSource = new DataSource<TRow>();
            _commands = new List<IColumnCommand<TRow>>();
            _outerCommands = new List<IOuterCommand<TRow>>();
            _jsEvents = new List<IGridJsEvent>();
        }

        #endregion

        #region Properties

        public IEnumerable<IColumn<TRow>> ColumnDefinitions
        {
            get { return _column; }
        }

        public DataSource<TRow> DataSourceValue
        {
            get { return _dataSource; }
        }

        public IEnumerable<IGridJsEvent> GridEventDefinitions
        {
            get { return _jsEvents; }
        }

        public GridOptions Options
        {
            get { return _options; }
        }

        public IEnumerable<IOuterCommand<TRow>> OuterCommandDefinitions
        {
            get { return _outerCommands; }
        }

        public ViewContext ViewContext
        {
            get { return _viewContext; }
        }

        #endregion

        #region Public Methods

        public IGrid<TRow> Name(string name)
        {
            _options.ContainerAssigned = true;
            _options.ContainerName = name;
            return this;
        }

        public IGrid<TRow> MultiSelectable()
        {
            _options.MultiselectableRow = true;
            return this;
        }

        public IGrid<TRow> OuterActions(Action<IColumnCommandBuilder<TRow>> commandBuilder)
        {
            var builder = new ColumnCommandBuilder<TRow>(_viewContext, this, _commands);
            commandBuilder(builder);
            return this;
        }

        public IGrid<TRow> Selectable()
        {
            _options.SelectableRow = true;
            return this;
        }

        public IGrid<TRow> SelectableCheckboxes()
        {
            _options.SelectableCheckboxRow = true;
            return this;
        }

        public IGrid<TRow> TableCssClass(string cssClass)
        {
            if (!_options.TableCssClasses.Contains(cssClass))
                _options.TableCssClasses.Add(cssClass);
            return this;
        }

        public override string ToString()
        {
            return ToHtmlString();
        }

        #endregion

        #region IGrid<TRow>

        public IGrid<TRow> Columns(Action<IColumnBuilder<TRow>> columnBuilder)
        {
            var builder = new ColumnBuilder<TRow>(_viewContext, this, _column);
            columnBuilder(builder);
            return this;
        }

        public IGrid<TRow> CommonSettings()
        {
            _options.CommonSettings();
            return this;
        }

        public IGrid<TRow> DataSource(Action<GridDataSourceBuilder<TRow>> action)
        {
            var builder = new GridDataSourceBuilder<TRow>(_viewContext, this);
            action(builder);
            return this;
        }

        public IGrid<TRow> DefaultSorting<TProperty>(Expression<Func<TRow, TProperty>> defaultSortingColumn, bool descending = false)
        {
            var member = defaultSortingColumn.Body as MemberExpression;
            if (member != null)
            {
                _options.DefaultSortingColumnName = member.Member.Name;
            }

            _options.DefaultSorting = descending ? GridOptions.EnumSorting.Descending : GridOptions.EnumSorting.Ascending;
            _options.Sorting = true;
            return this;
        }

        public IGrid<TRow> JavascriptEvents(Action<IGridJsEventBuilder> gridEventBuilder)
        {
            var builder = new GridJsEventBuilder(_viewContext, _jsEvents);
            gridEventBuilder(builder);
            return this;
        }
        
        public IGrid<TRow> OuterActions(Action<IOuterCommandBuilder<TRow>> columnBuilder)
        {
            var builder = new OuterCommandBuilder<TRow>(_viewContext, this, _outerCommands);
            columnBuilder(builder);
            return this;
        }

        public IGrid<TRow> Paging(bool paging)
        {
            _options.Paging = paging;
            return this;
        }

        public IGrid<TRow> PagingSize(int pagingSize)
        {
            _options.PagingSize = pagingSize;
            return this;
        }

        public IGrid<TRow> SelectableOnRowClick()
        {
            _options.SelectableOnRowClick = true;
            return this;
        }

        public void SetDataSource(DataSource<TRow> dataSource)
        {
            _dataSource = dataSource;
        }

        public IGrid<TRow> TableTitle(string title)
        {
            _options.TableTitle = title;
            return this;
        }

        #endregion

        #region IHtmlString

        public string ToHtmlString()
        {
            //if (DataSourceValue.Rows != null)
            //    return new PageGridRenderer<TRow>().Render(this);
            //if (!String.IsNullOrEmpty(DataSourceValue.ListActionName))
            //    return new AjaxGridRenderer<TRow>().Render(this);
            //throw new NullReferenceException("No datasource provided in Grid.");
#warning Renderers removed
            return null;
        }

        #endregion
    }
}