using System;
using System.Collections.Generic;

namespace BocekMatous.Component.Grid
{
    public class GridOptions
    {
        private const string ASCENDING = "ASC";
        private const string DESCENDING = "DESC";

        #region Constructors and Destructors

        public GridOptions()
        {
            TableCssClasses = new List<string>();
        }

        #endregion

        #region Enums

        public enum EnumSorting
        {
            Ascending,
            Descending
        }

        #endregion

        #region Properties

        public bool ContainerAssigned { get; set; }
        public string ContainerName { get; set; }
        public EnumSorting DefaultSorting { get; set; }
        public String DefaultSortingColumnName { get; set; }
        public bool Paging { get; set; }
        public int PagingSize { get; set; }
        public bool Sorting { get; set; }
        public List<string> TableCssClasses { get; set; }
        public string TableTitle { get; set; }
        public bool UseJQueryUITheme { get; set; }
        public bool SelectableRow { get; set; }
        public bool MultiselectableRow { get; set; }
        public bool SelectableCheckboxRow { get; set; }
        public bool SelectableOnRowClick { get; set; }
        #endregion

        #region Public Methods

        public void CommonSettings()
        {
            Paging = false;
            DefaultSorting = EnumSorting.Ascending;
        }

        #endregion

        #region Protected and private methods

        internal string GetSortingString()
        {
            switch (DefaultSorting)
            {
                case (EnumSorting.Ascending):
                    return ASCENDING;
                case (EnumSorting.Descending):
                    return DESCENDING;
                default:
                    return null;
            }
        }

        #endregion
    }
}