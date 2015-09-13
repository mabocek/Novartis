using System.Collections.Generic;
using System.Web.Mvc;

namespace BocekMatous.Component.Grid.JsEvents
{
    public class GridJsEventBuilder : IGridJsEventBuilder
    {
        #region Constants

        private const string GRID_EVENT_LOADING_RECORDS = "loadingRecords";
        private const string GRID_EVENT_RECORDS_LOADED = "recordsLoaded";
        private const string GRID_EVENT_SELECTION_CHANGED = "selectionChanged";

        #endregion

        #region Fields

        private readonly List<IGridJsEvent> _gridEvents;

        #endregion

        #region Constructors and Destructors

        public GridJsEventBuilder(ViewContext viewContext, List<IGridJsEvent> gridEvents)
        {
            _gridEvents = gridEvents;
        }

        #endregion

        #region Public Methods

        public IGridJsEventBuilder SelectionChanged(string value)
        {
            IGridJsEvent gridEvent = new GridJsEvent(GRID_EVENT_SELECTION_CHANGED, value);
            _gridEvents.Add(gridEvent);
            return this;
        }

        public IGridJsEventBuilder SelectionChangedSelectedRow(string value)
        {
            IGridJsEvent gridEvent = new GridJsEvent(GRID_EVENT_SELECTION_CHANGED, value, true);
            _gridEvents.Add(gridEvent);
            return this;
        }

        #endregion

        #region IGridJsEventBuilder

        public IGridJsEventBuilder LoadingRecords(string value)
        {
            IGridJsEvent gridEvent = new GridJsEvent(GRID_EVENT_LOADING_RECORDS, value);
            _gridEvents.Add(gridEvent);
            return this;
        }

        public IGridJsEventBuilder RecordsLoaded(string value)
        {
            IGridJsEvent gridEvent = new GridJsEvent(GRID_EVENT_RECORDS_LOADED, value);
            _gridEvents.Add(gridEvent);
            return this;
        }

        #endregion
    }
}