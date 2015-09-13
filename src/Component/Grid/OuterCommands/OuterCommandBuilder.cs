using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using BocekMatous.Component.Grid.Columns;

namespace BocekMatous.Component.Grid.OuterCommands
{
    public class OuterCommandBuilder<TRow> : IOuterCommandBuilder<TRow> where TRow : class
    {
        private const string CREATE_ICON = "fa fa-plus-square-o";

        #region Fields

        private readonly List<IOuterCommand<TRow>> _commands;
        private readonly IGrid<TRow> _grid;
        private readonly ViewContext _viewContext;

        #endregion

        #region Constructors and Destructors

        public OuterCommandBuilder(ViewContext viewContext, IGrid<TRow> grid, List<IOuterCommand<TRow>> commands)
        {
            _viewContext = viewContext;
            _grid = grid;
            _commands = commands;
        }

        #endregion

        #region IOuterCommandBuilder<TRow>

        public IOuterCommand<TRow> Create(string title = "")
        {
            IOuterCommand<TRow> columnCommand = new OuterCommand<TRow>(_viewContext, title, _grid, EnumCommandType.Create);
            columnCommand.Icon(CREATE_ICON);
            _commands.Add(columnCommand);
            return columnCommand;
        }

        public IOuterCommand<TRow> Link(string title = "")
        {
            IOuterCommand<TRow> columnCommand = new OuterCommand<TRow>(_viewContext, title, _grid, EnumLinkType.Link);
            _commands.Add(columnCommand);
            return columnCommand;
        }

        public IOuterCommand<TRow> SearchFor<TProperty>(Expression<Func<TRow, TProperty>> propertyExpression, string text = "")
        {
            var htmlId = _viewContext.ClientIdFor(propertyExpression).ToString();
            var htmlName = ExpressionHelper.GetExpressionText(propertyExpression);
            IOuterCommand<TRow> columnCommand = new OuterCommand<TRow>(_viewContext, text, _grid, EnumCommandType.Search, htmlId, htmlName);
            _commands.Add(columnCommand);
            return columnCommand;
        }

        #endregion
    }
}