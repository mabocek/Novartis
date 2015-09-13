using System;
using System.Linq.Expressions;
using BocekMatous.Component.Grid.Columns.Bounds;
using BocekMatous.Component.Grid.Columns.Commands;

namespace BocekMatous.Component.Grid.Columns
{
    /// <summary>
    ///     Column builder for Grid
    /// </summary>
    /// <typeparam name="TRow"></typeparam>
    public interface IColumnBuilder<TRow> where TRow : class
    {
        #region Public Methods

        /// <summary>
        ///     Builder for commands (actions)
        /// </summary>
        /// <param name="columnBuilder"></param>
        /// <returns></returns>
        IColumnOptions Commands(Action<IColumnCommandBuilder<TRow>> columnBuilder);

        /// <summary>
        ///     Builder for column property by name
        /// </summary>
        /// <param name="name">nazev sloupce</param>
        /// <returns></returns>
        IColumnBound<TRow> For(string name);

        /// <summary>
        ///     Builder for column property by expression
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="propertyExpression"></param>
        /// <returns></returns>
        IColumnBound<TRow> For<TProperty>(Expression<Func<TRow, TProperty>> propertyExpression);

        #endregion
    }
}