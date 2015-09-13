namespace BocekMatous.Component.Grid.JsEvents
{
    public class GridJsEvent : IGridJsEvent
    {
        #region Fields

        private readonly string _eventName;
        private readonly string _eventcall;
        private readonly bool _includeSelectedRows;

        #endregion

        #region Constructors and Destructors

        public GridJsEvent(string eventName, string eventcall, bool includeSelectedRows = false)
        {
            _eventName = eventName;
            _eventcall = eventcall;
            _includeSelectedRows = includeSelectedRows;
        }

        #endregion

        #region Properties

        public string EventCall
        {
            get { return _eventcall; }
        }

        public string EventName
        {
            get { return _eventName; }
        }

        public bool IncludeSelectedRows
        {
            get { return _includeSelectedRows; }
        }

        #endregion
    }
}