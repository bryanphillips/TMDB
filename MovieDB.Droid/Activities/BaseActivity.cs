using System;
using Android.App;
using MovieDB.Core;
using MovieDB.Droid.Utilities;

namespace MovieDB.Droid
{
    public class BaseActivity : Activity
    {
        protected readonly ILogger _logger = ServiceContainer.Resolve<ILogger>();
        private ProgressSpinner _spinner;

        public void ShowSpinner()
        {
            if ((_spinner == null || !_spinner.IsShowing) && !this.IsFinishing)
                _spinner = ProgressSpinner.Show(this, null, null, true, false);
        }

        public void HideSpinner()
        {
            if (_spinner != null && _spinner.IsShowing)
                _spinner.Dismiss();
        }

        /// <summary>
        /// Generic exception handling.  Will show the system default alert dialog.
        /// </summary>
        /// <param name="exc">exception to show</param>
        public virtual void OnError(Exception exc)
        {
            _logger.Log("Error", exc);
            if (!IsFinishing)
                this.ShowError(exc);
        }
    }
}