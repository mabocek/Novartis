namespace BocekMatous.Component.Grid.Columns
{
    public class CommandOptions
    {
        #region Properties

        public string IconCssClass { get; set; }
        public string IconDisabledCssClass { get; set; }
        public string DisabledIfProperty { get; set; }
        public bool? DisabledIfValue { get; set; }
        public string IconIfProperty { get; set; }
        public bool? IconIfValue { get; set; }
        public bool RenderUnderGrid { get; set; }
        public string Title { get; set; }

        /// <summary>
        /// attribute Id of HTML element, not database indentificator
        /// </summary>
        public string HtmlId { get; set; }
        /// <summary>
        /// attribute Name of HTML element, not title or display name
        /// </summary>
        public string HtmlName { get; set; }

        #endregion
    }
}