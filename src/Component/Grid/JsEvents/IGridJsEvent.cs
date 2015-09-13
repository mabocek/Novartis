namespace BocekMatous.Component.Grid.JsEvents
{
    public interface IGridJsEvent
    {
        #region Properties

        string EventName { get; }

        string EventCall { get; }

        bool IncludeSelectedRows { get; }

        #endregion
    }
}
