using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.Core.ViewModels
{
    /// <summary>
    /// Base class for all view models.
    /// </summary>
    public class ViewModelBase
    {
        public event EventHandler IsBusyChanged;
        public event EventHandler IsValidChanged;

        private readonly List<string> _errors = new List<string>();
        internal readonly IWebService _service = ServiceContainer.Resolve<IWebService>();
        protected readonly ISettings _settings = ServiceContainer.Resolve<ISettings>();
        private bool _isBusy = false;

        /// <summary>
        /// IsValid property for checking any input information from UI
        /// </summary>
        public bool IsValid
        {
            get { return _errors.Count == 0; }
        }

        /// <summary>
        /// Internal list of errors to display to user.
        /// </summary>
        protected List<string> Errors
        {
            get { return _errors; }
        }

        /// <summary>
        /// Error message to display
        /// </summary>
        public virtual string Error
        {
            get
            {
                return _errors.Aggregate(new StringBuilder(), (b, s) => b.AppendLine(s)).ToString().Trim();
            }
        }

        /// <summary>
        /// Validate method for the view model to check if UI input information is valid.
        /// </summary>
        protected virtual void Validate()
        {
            IsValidChanged?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Method to check the validation of a property of the view model.
        /// </summary>
        /// <param name="validate">validation function</param>
        /// <param name="error">error message to display</param>
        protected virtual void ValidateProperty(Func<bool> validate, string error)
        {
            if (validate())
            {
                if (!Errors.Contains(error))
                {
                    Errors.Add(error);
                }
            }
            else
            {
                Errors.Remove(error);
            }
        }        

        /// <summary>
        /// A way for the view model to tell the UI if it is busy and should show a spinner.
        /// </summary>
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnIsBusyChanged();
            }
        }

        /// <summary>
        /// Event for the view model is doing work and needs the UI to show a spinner.
        /// </summary>
        protected virtual void OnIsBusyChanged()
        {
            IsBusyChanged?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Clears any data in the ViewModel
        /// </summary>
        public virtual void Clear()
        {

        }
    }
}
