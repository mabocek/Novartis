using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace BocekMatous.Component.Grid
{
    /// <summary>
    ///     trida sloupce gridu
    /// </summary>
    /// <typeparam name="TRow"></typeparam>
    public class Column<TRow> where TRow : class
    {
        #region Constants

        private const string TABLE_COL_TAG = "th";
        private const string TABLE_CONTENT_COL_TAG = "td";

        #endregion

        #region Fields

        protected readonly Grid<TRow> _grid;
        protected readonly Option _option;
        protected readonly ViewContext _viewContext;
        private bool _initializedValueFormat;

        #endregion

        #region Constructors and Destructors

        public Column(ViewContext viewContext, Grid<TRow> grid)
        {
            _viewContext = viewContext;
            _grid = grid;
            _option = new Option();
        }

        public Column(ViewContext viewContext, string name, Grid<TRow> grid)
            : this(viewContext, grid)
        {
            _option.Name = _option.SortName = PropertyName = name;
        }

        #endregion

        #region Properties

        public string PropertyName { get; private set; }

        internal bool IsFrozen
        {
            get { return _option.Frozen; }
        }

        internal string TitleText { get; private set; }

        #endregion

        #region Public Methods

        public Column<TRow> Alignment(GridColumnAlignment alignment)
        {
            _option.Alignment = alignment;
            return this;
        }

        public Column<TRow> CheckBox()
        {
            _option.Stype = "select";
            _option.SearchOptions = new { value = String.Join(";", new[] { ":-", "1:" + "Ano", "0:" + "Ne" }) };
            _option.Alignment = GridColumnAlignment.Center;
            return this;
        }

        public Column<TRow> Date()
        {
            _option.PredefinedFormatter = "date";
            return this;
        }

        public Column<TRow> DateTime()
        {
            _option.PredefinedFormatter = "date";
            _option.Formatoptions = new { newformat = "d.m.Y H:i" };
            return this;
        }

        public Column<TRow> Enum<TEnum>(params TEnum[] excludes)
        {
            return Enum<TEnum>(excludes.Contains);
        }

        public Column<TRow> Enum<TEnum>(Func<TEnum, bool> excludes)
        {
            _option.PredefinedFormatter = "select";
            _option.EditType = "select";

            var enumValues = new List<string>();
            enumValues.Add(":-");
            //enumValues.AddRange(System.Enum.GetValues(typeof(TEnum))
            //                .Cast<TEnum>()
            //                .Where(m => !excludes(m))
            //                .Select(m => string.Format("{0}:{1}", (int)(object)m, ((Enum)(object)m).ToDescription())));

            _option.EditOptions = new { value = string.Join(";", enumValues) };
            _option.SearchOptions = new { value = string.Join(";", enumValues) };

            return this;
        }

        public Column<TRow> Frozen(bool frozen = true)
        {
            _option.Frozen = frozen;
            return this;
        }

        public Column<TRow> Hide(bool hide = true)
        {
            _option.Hidden = hide;
            return this;
        }

        public Column<TRow> Search(bool search = true)
        {
            _option.Search = search;
            return this;
        }

        public Column<TRow> Sort(bool sort = true)
        {
            _option.Sortable = sort;
            return this;
        }

        public Column<TRow> Template(string template)
        {
            template = HttpUtility.UrlDecode(template);
            template = Regex.Replace(template, "(#)(\\w+)(#)", "'+rowObject.$2+'");

            string pattern = "function (cellvalue, options, rowObject) {{ return '{0}'; }}";

            _option.Search = false;
            _option.Sortable = false;
            return this;
        }

        public Column<TRow> Title(string title)
        {
            TitleText = title;
            return this;
        }

        public override string ToString()
        {
            var tableCellTagBuilder = new TagBuilder(TABLE_COL_TAG)
            {
                InnerHtml = TitleText
            };
            if (_option.Sortable)
                tableCellTagBuilder.AddCssClass("sortable");

            return tableCellTagBuilder.ToString();
        }

        public Column<TRow> Width(int width)
        {
            _option.Width = width;
            return this;
        }

        public string RenderValue(object value)
        {
            if (!_initializedValueFormat)
                InitRender(value);

            var tableCellTagBuilder = new TagBuilder(TABLE_CONTENT_COL_TAG);

            tableCellTagBuilder.SetInnerText(value.ToString());


            return tableCellTagBuilder.ToString();
        }

        private void InitRender(object value)
        {
            if (_option.Formatter != null)
            {

            }
            else if (value is long || value is int || value is short)
            {
                if (!_option.Alignment.HasValue)
                    _option.Alignment = GridColumnAlignment.Right;
            }
        }


        #endregion

        #region Nested classes

        protected class Option
        {
            #region Constructors and Destructors

            public Option()
            {
                Search = true;
                Sortable = true;
                Width = 50;
            }

            #endregion

            #region Properties

            public GridColumnAlignment? Alignment { get; set; }
            public object EditOptions { get; set; }
            public string EditType { get; set; }
            public object Formatoptions { get; set; }
            public object Formatter { get; private set; }
            public bool Frozen { get; set; }
            public bool Hidden { get; set; }
            public string Name { get; set; }

            public string PredefinedFormatter
            {
                set { Formatter = value; }
            }

            public bool Search { get; set; }

            public object SearchOptions { get; set; }
            public string SortName { get; set; }
            public bool Sortable { get; set; }
            public string Stype { get; set; }
            public int Width { get; set; }

            #endregion
        }

        #endregion
    }

    public class Column<TRow, TProperty> : Column<TRow> where TRow : class
    {
        #region Constructors and Destructors

        public Column(ViewContext viewContext, Expression<Func<TRow, TProperty>> propertyExpression, Grid<TRow> grid)
            : base(viewContext, ExpressionHelper.GetExpressionText(propertyExpression), grid)
        {
            if (typeof(TProperty) == typeof(bool))
            {
                CheckBox();
            }
            else if (typeof(TProperty).IsEnum)
            {
                Enum<TProperty>();
            }
            else if (typeof(TProperty) == typeof(DateTime) || typeof(TProperty) == typeof(DateTime?))
            {
                Date();
            }
        }

        #endregion
    }

    public enum GridColumnAlignment
    {
        Left,

        Center,

        Right
    }
}