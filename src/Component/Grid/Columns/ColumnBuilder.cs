using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using BocekMatous.Component.Grid.Columns.Bounds;
using BocekMatous.Component.Grid.Columns.Commands;

namespace BocekMatous.Component.Grid.Columns
{
    /// <summary>
    ///     builder pro sestaveni sloupcu gridu
    /// </summary>
    /// <typeparam name="TRow"></typeparam>
    public class ColumnBuilder<TRow> : IColumnBuilder<TRow> where TRow : class
    {
        #region Fields

        private readonly List<IColumn<TRow>> _columns;
        private readonly IGrid<TRow> _grid;
        private readonly ViewContext _viewContext;

        #endregion

        #region Constructors and Destructors

        public ColumnBuilder(ViewContext viewContext, IGrid<TRow> grid, List<IColumn<TRow>> columns)
        {
            _viewContext = viewContext;
            _grid = grid;
            _columns = columns;
        }

        #endregion

        #region IColumnBuilder<TRow>

        public IColumnOptions Commands(Action<IColumnCommandBuilder<TRow>> columnBuilder)
        {
            var columnCommands = new List<IColumnCommand<TRow>>();
            var builder = new ColumnCommandBuilder<TRow>(_viewContext, _grid, columnCommands);
            columnBuilder(builder);
            var column = new Column<TRow>(columnCommands, new ColumnOptions());
            _columns.Add(column);
            return column.Options;
        }
        
        public IColumnBound<TRow> For(string name)
        {
            IColumnBound<TRow> columnBound = new ColumnBound<TRow>(_viewContext, name, _grid);
            var column = new Column<TRow>(columnBound, columnBound.ColumnOptions);
            _columns.Add(column);
            return column.ColumnBound;
        }

        public IColumnBound<TRow> For<TProperty>(Expression<Func<TRow, TProperty>> propertyExpression)
        {
            ColumnBound<TRow> columnBound = new ColumnBound<TRow, TProperty>(_viewContext, propertyExpression, _grid);
            var column = new Column<TRow>(columnBound, columnBound.ColumnOptions);
            _columns.Add(column);
            return column.ColumnBound;
        }

        #endregion
    }
}