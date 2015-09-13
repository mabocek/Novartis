using System.Collections.Generic;
using BocekMatous.Component.Grid.Columns.Bounds;

namespace BocekMatous.Component.Grid.Columns
{
    public interface IColumnOptions
    {
        #region Properties

        EnumGridColumnAlignment? AlignmentType { get; }
        IEnumerable<string> ColumnCssClasses { get; }
        bool FrozenValue { get; }
        bool Hidden { get; }
        bool SortableValue { get; }
        string SortNameValue { get; }
        string TitleName { get; }
        int WidthSize { get; }
        int WidthMinSize { get; }

        #endregion

        #region Public Methods

        IColumnOptions Alignment(EnumGridColumnAlignment alignment);
        IColumnOptions ColumnCssClass(string ccsClass);

        IColumnOptions Hide(bool hide = true);
        IColumnOptions Title(string title);
        IColumnOptions Width(int width);
        IColumnOptions WidthMin(int widthMin);
        IColumnOptions Frozen(bool frozen = true);
        IColumnOptions Sortable(bool sortable = true);

        #endregion
    }
}