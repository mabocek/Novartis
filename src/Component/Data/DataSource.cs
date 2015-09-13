using System.Collections.Generic;
using System.Web.Routing;
using JetBrains.Annotations;

namespace BocekMatous.Component.Data
{
    public class DataSource<TRow> where TRow : class
    {
        #region Properties

        internal string CreateActionName { get; set; }
        internal string CreateControllerName { get; set; }
        internal string DeleteActionName { get; set; }
        internal string DeleteControllerName { get; set; }
        internal string ListActionName { get; set; }
        internal string ListControllerName { get; set; }
        internal string ListFilterDataFunction { get; set; }
        internal RouteValueDictionary ListRouteValueDictionary { get; set; }
        internal IEnumerable<TRow> Rows { get; set; }
        internal string EditActionName { get; set; }
        internal string EditControllerName { get; set; }
        internal string UpdateActionName { get; set; }
        internal string UpdateControllerName { get; set; }
        internal RouteValueDictionary RouteValues { get; set; }
        

        #endregion

        #region Public Methods

        public DataSource<TRow> Create(
            [AspMvcAction]
            string actionName,
            [AspMvcController]
            string controllerName = "")
        {
            CreateActionName = actionName;
            CreateControllerName = controllerName;
            return this;
        }

        public DataSource<TRow> Delete(
            [AspMvcAction]
            string actionName,
            [AspMvcController]
            string controllerName = "")
        {
            DeleteActionName = actionName;
            DeleteControllerName = controllerName;
            return this;
        }

        public DataSource<TRow> Edit(
            [AspMvcAction]
            string actionName,
            [AspMvcController]
            string controllerName = "")
        {
            EditActionName = actionName;
            EditControllerName = controllerName;
            return this;
        }

        public DataSource<TRow> Update(
            [AspMvcAction]
            string actionName,
            [AspMvcController]
            string controllerName = "")
        {
            UpdateActionName = actionName;
            UpdateControllerName = controllerName;
            return this;
        }

        #endregion
    }
}