namespace BocekMatous.Component.Grid.JsEvents
{
    public interface IGridJsEventBuilder
    {
        #region Public Methods

        /// <summary>
        /// Javascriptova eventa pro grid - LoadingRecords
        /// </summary>
        /// <param name="value">javascriptova fce pro grid ve formatu: function (event, data) { return OBSAH_FUNKCE; }</param>
        IGridJsEventBuilder LoadingRecords(string value);

        /// <summary>
        /// Javascriptova eventa pro grid - RecordsLoaded
        /// </summary>
        /// <param name="value">javascriptova fce  pro grid ve formatu: function (event, data) { return OBSAH_FUNKCE; }</param>
        IGridJsEventBuilder RecordsLoaded(string value);

        /// <summary>
        /// Javascriptova eventa pro grid - SelectionChanged
        /// </summary>
        /// <param name="value">javascriptova fce  pro grid ve formatu: function (event, data) { return OBSAH_FUNKCE; }</param>
        IGridJsEventBuilder SelectionChanged(string value);

        /// <summary>
        /// Javascriptova eventa pro grid - SelectionChangedSelectedRow
        /// </summary>
        /// <param name="value">nazev javascriptove fce s parametrem data, ktery obsahuje radky, ktere byly vybrany</param>
        IGridJsEventBuilder SelectionChangedSelectedRow(string value);

        #endregion
    }
}