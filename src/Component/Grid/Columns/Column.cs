using System.Collections.Generic;
using System.Linq;
using BocekMatous.Component.Grid.Columns.Bounds;
using BocekMatous.Component.Grid.Columns.Commands;

namespace BocekMatous.Component.Grid.Columns
{
    public class Column<TRow> : IColumn<TRow> where TRow : class
    {
        #region Fields

        private readonly IColumnBound<TRow> _columnBound;
        private readonly IEnumerable<IColumnCommand<TRow>> _columnCommands;
        private ColumnOptions _options;

        #endregion

        #region Constructors and Destructors

        public Column(IColumnBound<TRow> columnBound, ColumnOptions options)
        {
            _columnBound = columnBound;
            _options = options;
        }

        public Column(IColumnCommand<TRow> columnCommand, ColumnOptions options)
        {
            _columnCommands = new List<IColumnCommand<TRow>>
                              {
                                  columnCommand
                              };
            _options = options;
        }

        public Column(IEnumerable<IColumnCommand<TRow>> columnCommands, ColumnOptions options)
        {
            _columnCommands = columnCommands.ToList();
            _options = options;
        }

        #endregion

        #region Properties

        public IColumnBound<TRow> ColumnBound
        {
            get { return _columnBound; }
        }

        public IEnumerable<IColumnCommand<TRow>> ColumnCommands { get { return _columnCommands; } }
        public ColumnOptions Options { get { return _options; }}

        #endregion
    }
}