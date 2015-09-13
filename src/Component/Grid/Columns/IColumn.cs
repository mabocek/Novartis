using System.Collections.Generic;
using BocekMatous.Component.Grid.Columns.Bounds;
using BocekMatous.Component.Grid.Columns.Commands;

namespace BocekMatous.Component.Grid.Columns
{
    public interface IColumn<TRow> where TRow : class
    {
        #region Properties

        IColumnBound<TRow> ColumnBound { get; }
        IEnumerable<IColumnCommand<TRow>> ColumnCommands { get; }
        ColumnOptions Options { get; }

        #endregion
    }
}