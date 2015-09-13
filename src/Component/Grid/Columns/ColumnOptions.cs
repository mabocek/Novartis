using System.Collections.Generic;
using System.Linq;
using BocekMatous.Component.Grid.Columns.Bounds;

namespace BocekMatous.Component.Grid.Columns
{
    public class ColumnOptions : IColumnOptions
    {
        #region Constants

        private const string CSS_CLASS_TEXT_ALIGN_CENTER = "text-align-center";
        private const string CSS_CLASS_TEXT_ALIGN_JUSTIFY = "text-align-justify";
        private const string CSS_CLASS_TEXT_ALIGN_LEFT = "text-align-left";
        private const string CSS_CLASS_TEXT_ALIGN_RIGHT = "text-align-right";

        #endregion

        #region Constructors and Destructors

        public ColumnOptions()
        {
            WidthSize = 10;
            WidthMinSize = 10;
            ColumnCssClasses = new List<string>();
            SortableValue = false;
        }

        #endregion

        #region Properties

        public EnumGridColumnAlignment? AlignmentType { get; private set; }

        public IEnumerable<string> ColumnCssClasses { get; private set; }
        public bool FrozenValue { get; private set; }
        public bool Hidden { get; private set; }
        public string SortNameValue { get; private set; }
        public bool SortableValue { get; private set; }
        public string TitleName { get; private set; }
        public int WidthSize { get; private set; }
        public int WidthMinSize { get; private set; }

        #endregion

        #region Public Methods

        public IColumnOptions SortName(string sortName)
        {
            SortNameValue = sortName;
            return this;
        }

        #endregion

        #region IColumnOptions

        public IColumnOptions Alignment(EnumGridColumnAlignment alignment)
        {
            AlignmentType = alignment;
            switch (alignment)
            {
                case (EnumGridColumnAlignment.Left):
                    ColumnCssClass(CSS_CLASS_TEXT_ALIGN_LEFT);
                    break;
                case (EnumGridColumnAlignment.Center):
                    ColumnCssClass(CSS_CLASS_TEXT_ALIGN_CENTER);
                    break;
                case (EnumGridColumnAlignment.Right):
                    ColumnCssClass(CSS_CLASS_TEXT_ALIGN_RIGHT);
                    break;
                case (EnumGridColumnAlignment.Justify):
                    ColumnCssClass(CSS_CLASS_TEXT_ALIGN_JUSTIFY);
                    break;
            }
            return this;
        }

        public IColumnOptions ColumnCssClass(string ccsClass)
        {
            if (!ColumnCssClasses.Contains(ccsClass))
            {
                ((List<string>) ColumnCssClasses).Add(ccsClass);
            }
            return this;
        }

        public IColumnOptions Frozen(bool frozen)
        {
            FrozenValue = frozen;
            return this;
        }

        public IColumnOptions Hide(bool hide = true)
        {
            Hidden = hide;
            return this;
        }

        public IColumnOptions Sortable(bool sortable = true)
        {
            SortableValue = sortable;
            return this;
        }

        public IColumnOptions Title(string title)
        {
            TitleName = title;
            return this;
        }

        public IColumnOptions Width(int width)
        {
            WidthSize = width;
            return this;
        }

        public IColumnOptions WidthMin(int widthMin)
        {
            WidthMinSize = widthMin;
            return this;
        }
        

        #endregion
    }
}