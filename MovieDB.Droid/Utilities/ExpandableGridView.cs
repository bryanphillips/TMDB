using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Util;

namespace MovieDB.Droid.Utilities
{
    public class ExpandableGridView : GridView
    {
        public ExpandableGridView(Context context) : base(context)
        { }

        public ExpandableGridView(Context context, IAttributeSet attrs) : base(context, attrs)
        { }

        public ExpandableGridView(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle)
        { }

        public ExpandableGridView(Context context, IAttributeSet attrs, int defStyle, int defStyleRes) : base(context, attrs, defStyle, defStyleRes)
        { }

        public bool IsExpanded
        {
            get;
            set;
        }

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            if (IsExpanded)
            {
                int expandSpec = MeasureSpec.MakeMeasureSpec(MeasuredSizeMask, MeasureSpecMode.AtMost);
                base.OnMeasure(widthMeasureSpec, expandSpec);
                var layoutParams = LayoutParameters;
                layoutParams.Height = MeasuredHeight;
            }
            else
            {
                base.OnMeasure(widthMeasureSpec, heightMeasureSpec);
            }
        }
    }
}