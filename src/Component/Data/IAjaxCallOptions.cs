namespace BocekMatous.Component.Data
{
    public interface IAjaxCallOptions
    {
        #region Properties

        string AlwaysCallback { get; }
        string DoneCallback { get; }
        string FailCallback { get; }

        #endregion

        #region Public Methods

        IAjaxCallOptions Always(string callback);
        IAjaxCallOptions Done(string callback);
        IAjaxCallOptions Fail(string callback);

        #endregion
    }
}