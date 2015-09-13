namespace BocekMatous.Component.Data
{
    public class AjaxCallOptions : IAjaxCallOptions
    {
        #region Fields

        private string _alwaysValue;
        private string _doneValue;
        private string _failValue;

        #endregion

        #region Properties

        public string AlwaysCallback
        {
            get { return _alwaysValue; }
        }

        public string DoneCallback
        {
            get { return _doneValue; }
        }

        public string FailCallback
        {
            get { return _failValue; }
        }

        #endregion

        #region IAjaxCallOptions

        public IAjaxCallOptions Always(string callback)
        {
            if (!string.IsNullOrEmpty(_alwaysValue))
            {
                _alwaysValue += "; ";
            }
            _alwaysValue += callback;
            return this;
        }

        public IAjaxCallOptions Done(string callback)
        {
            if (!string.IsNullOrEmpty(_doneValue))
            {
                _doneValue += "; ";
            }
            _doneValue += callback;
            return this;
        }

        public IAjaxCallOptions Fail(string callback)
        {
            if (!string.IsNullOrEmpty(_failValue))
            {
                _failValue += "; ";
            }
            _failValue += callback;
            return this;
        }

        #endregion
    }
}