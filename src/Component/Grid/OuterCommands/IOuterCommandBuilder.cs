using System;
using System.Linq.Expressions;

namespace BocekMatous.Component.Grid.OuterCommands
{
    /// <summary>
    ///     columnCommand builder for actions in grid
    /// </summary>
    /// <typeparam name="TRow"></typeparam>
    public interface IOuterCommandBuilder<TRow> where TRow : class
    {
        #region Public Methods

        /// <summary>
        ///     Create columnCommand
        /// </summary>
        IOuterCommand<TRow> Create(string title = "");

        /// <summary>
        ///     Link columnCommand
        /// </summary>
        IOuterCommand<TRow> Link(string title = "");

        /// <summary>
        ///     Creates search with model search filter and optionally by custom search text.
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="propertyExpression"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        IOuterCommand<TRow> SearchFor<TProperty>(Expression<Func<TRow, TProperty>> propertyExpression, string text = "");

        #endregion
    }
}