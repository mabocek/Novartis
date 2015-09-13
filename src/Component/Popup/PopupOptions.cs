using System.Collections.Generic;
using BocekMatous.Component.Parameters;

namespace BocekMatous.Component.Popup
{
    public class PopupOptions
    {
        #region Properties

        public string DisplayActionName { get; set; }
        public string DisplayControllerName { get; set; }
        public List<IParameter> DisplayParameters { get; set; }
        public string Id { get; set; }
        public ModalButtons ModalButtons { get; set; }
        public ModalSize ModalSize { get; set; }
        public string SubmitActionName { get; set; }
        public string SubmitControllerName { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }

        #endregion
    }

    public class PopupOptions<TRow> : PopupOptions where TRow : class
    {
    }
}