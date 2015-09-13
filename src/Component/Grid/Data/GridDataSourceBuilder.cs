using System.Web.Mvc;
using System.Web.Routing;
using BocekMatous.Component.Data;
using JetBrains.Annotations;

namespace BocekMatous.Component.Grid.Data
{
    public class GridDataSourceBuilder<TRow> where TRow : class
    {
        #region Fields

        private readonly IGrid<TRow> _grid;
        private readonly ViewContext _viewContext;

        #endregion

        #region Constructors and Destructors

        public GridDataSourceBuilder(ViewContext viewContext, IGrid<TRow> grid)
        {
            _viewContext = viewContext;
            _grid = grid;
        }

        #endregion

        #region Public Methods

        public DataSource<TRow> Ajax(
            [AspMvcAction] string actionName,
            [AspMvcController] string controllerName,
            RouteValueDictionary routeValueDictionary,
            string filterDataFunction = "")
        {
            DataSource<TRow> dataSource = _grid.DataSourceValue;
            dataSource.ListActionName = actionName;
            dataSource.ListControllerName = controllerName;
            dataSource.RouteValues = routeValueDictionary;
            dataSource.ListFilterDataFunction = filterDataFunction;
            _grid.SetDataSource(dataSource);
            return dataSource;
        }

        public DataSource<TRow> Ajax(
            [AspMvcAction] string actionName,
            [AspMvcController] string controllerName,
            object routeValueDictionary,
            string filterDataFunction = "")
        {
            return Ajax(actionName, controllerName, new RouteValueDictionary(routeValueDictionary), filterDataFunction);
        }

        public DataSource<TRow> Ajax(
            [AspMvcAction] string actionName,
            [AspMvcController] string controllerName,
            string filterDataFunction = "")
        {
            return Ajax(actionName, controllerName, null, filterDataFunction);
        }

        public DataSource<TRow> Ajax(
            [AspMvcAction] string actionName,
            RouteValueDictionary routeValueDictionary = null,
            string filterDataFunction = "")
        {
            return Ajax(actionName, null, routeValueDictionary, filterDataFunction);
        }

        #endregion
    }
}