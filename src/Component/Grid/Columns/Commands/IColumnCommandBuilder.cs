namespace BocekMatous.Component.Grid.Columns.Commands
{
    /// <summary>
    ///     columnCommand builder for actions in grid
    /// </summary>
    /// <typeparam name="TRow"></typeparam>
    public interface IColumnCommandBuilder<TRow> where TRow : class
    {
        #region Public Methods

        /// <summary>
        ///     Create columnCommand
        /// </summary>
        IColumnCommand<TRow> Create(string title = "");

        /// <summary>
        ///     Delete columnCommand
        /// </summary>
        IColumnCommand<TRow> Delete(string title = "");

        /// <summary>
        ///     Detail columnCommand
        /// </summary>
        IColumnCommand<TRow> Detail(string title = "");

        /// <summary>
        ///     Edit columnCommand
        /// </summary>
        IColumnCommand<TRow> Edit(string title = "");

        /// <summary>
        ///     Link columnCommand
        /// </summary>
        IColumnCommand<TRow> Link(string title = "");

        #endregion
    }
}