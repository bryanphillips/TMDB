
using Android.App;
using Android.Content;
using Android.Views;
using Android.Widget;

namespace MovieDB.Droid.Utilities
{
    public class ProgressSpinner : Dialog
    {
        public static ProgressSpinner Show(Context context, string title, string message)
        {
            return Show(context, title, message);
        }

        public static ProgressSpinner Show(Context context, string title, string message, bool indeterminate)
        {
            return Show(context, title, message, indeterminate);
        }

        public static ProgressSpinner Show(Context context, string title, string message, bool indeterminate, bool cancelable)
        {
            return Show(context, title, message, indeterminate, cancelable, null);
        }

        public static ProgressSpinner Show(Context context, string title = null, string message = null, bool indeterminate = false,
            bool cancelable = false, IDialogInterfaceOnCancelListener cancelListener = null)
        {
            var dialog = new ProgressSpinner(context);
            dialog.SetCancelable(cancelable);
            dialog.SetOnCancelListener(cancelListener);
            /* The next line will add the ProgressBar to the dialog. */
            dialog.AddContentView(new ProgressBar(context), new LinearLayout.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent));
            dialog.Show();

            return dialog;
        }

        public ProgressSpinner(Context context)
            : base(context, Resource.Style.SpinnerStyle) { }
    }
}