using System.Collections.Generic;
using System.Web.Mvc;

namespace BocekMatous.Component.Grid.Columns.Commands
{
    public class ColumnCommandBuilder<TRow> : IColumnCommandBuilder<TRow> where TRow : class
    {
        #region Fields

        private readonly List<IColumnCommand<TRow>> _commands;
        private readonly IGrid<TRow> _grid;
        private readonly ViewContext _viewContext;

        #endregion

        #region Constructors and Destructors

        public ColumnCommandBuilder(ViewContext viewContext, IGrid<TRow> grid, List<IColumnCommand<TRow>> commands)
        {
            _viewContext = viewContext;
            _grid = grid;
            _commands = commands;
        }

        #endregion

        #region IColumnCommandBuilder<TRow>

        public IColumnCommand<TRow> Create(string title = "")
        {
            IColumnCommand<TRow> columnCommand = new ColumnCommand<TRow>(_viewContext, title, _grid, EnumCommandType.Create);
            columnCommand.Icon("fa fa-plus create");
            _commands.Add(columnCommand);
            return columnCommand;
        }

        public IColumnCommand<TRow> Delete(string title = "")
        {
            IColumnCommand<TRow> columnCommand = new ColumnCommand<TRow>(_viewContext, title, _grid, EnumCommandType.Delete);
            columnCommand.Icon("fa fa-trash-o delete");
            _commands.Add(columnCommand);
            return columnCommand;
        }

        public IColumnCommand<TRow> Detail(string title = "")
        {
            IColumnCommand<TRow> columnCommand = new ColumnCommand<TRow>(_viewContext, title, _grid, EnumCommandType.Detail);
            columnCommand.Icon("fa fa-search detail");
            _commands.Add(columnCommand);
            return columnCommand;
        }

        public IColumnCommand<TRow> Edit(string title = "")
        {
            IColumnCommand<TRow> columnCommand = new ColumnCommand<TRow>(_viewContext, title, _grid, EnumCommandType.Edit);
            columnCommand.Icon("fa fa-pencil edit");
            _commands.Add(columnCommand);
            return columnCommand;
        }

        public IColumnCommand<TRow> Link(string title = "")
        {
            IColumnCommand<TRow> columnCommand = new ColumnCommand<TRow>(_viewContext, title, _grid, EnumLinkType.Link);
            columnCommand.Icon("fa fa-external-link external");
            _commands.Add(columnCommand);
            return columnCommand;
        }

        #endregion
    }
}