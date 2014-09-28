using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace App.Common
{
    /// <summary>
    /// The main view model for the app.
    /// </summary>
    public class MainViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Private backing field for <see cref="Name"/>
        /// </summary>
        private string name;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        public MainViewModel()
        {
            this.MyCommand = new DelegateCommand(this.MyAction, this.CanExecuteMyCommand);
        }

        /// <summary>
        /// Event for property change notifications.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets a basic command.
        /// </summary>
        public DelegateCommand MyCommand { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name
        {
            get 
            { 
                return this.name; 
            }

            set
            { 
                this.SetProperty(ref this.name, value);
                this.MyCommand.RaiseCanExecuteChanged();
            }
        }

        /// <summary>
        /// Does something
        /// </summary>
        /// <param name="param">A parameter</param>
        public void MyMethod(string param)
        {
            if (param == null) throw new ArgumentNullException("param");

            // Custom actions
        }

        /// <summary>
        /// Checks if a property already matches a desired value.  Sets the property and
        /// notifies listeners only when necessary.
        /// </summary>
        /// <typeparam name="T">Type of the property.</typeparam>
        /// <param name="storage">Reference to a property with both getter and setter.</param>
        /// <param name="value">Desired value for the property.</param>
        /// <param name="propertyName">Name of the property used to notify listeners.  This
        /// value is optional and can be provided automatically when invoked from compilers that
        /// support CallerMemberName.</param>
        /// <returns>True if the value was changed, false if the existing value matched the
        /// desired value.</returns>
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(storage, value))
            {
                return false;
            }

            storage = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }

        /// <summary>
        /// Notifies listeners that a property value has changed.
        /// </summary>
        /// <param name="propertyName">Name of the property used to notify listeners.  This
        /// value is optional and can be provided automatically when invoked from compilers
        /// that support <see cref="CallerMemberNameAttribute"/>.</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var eventHandler = this.PropertyChanged;
            if (eventHandler != null)
            {
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Returns whether the <see cref="MyCommand"/> can be executed.
        /// </summary>
        /// <param name="obj">Parameter object</param>
        /// <returns>True when the command can be executed</returns>
        private bool CanExecuteMyCommand(object obj)
        {
            return !string.IsNullOrEmpty(this.Name);
        }

        /// <summary>
        /// Action for the <see cref="MyCommand"/>.
        /// </summary>
        /// <param name="obj">Parameter object</param>
        private void MyAction(object obj)
        {
            // Custom actions
        }
    }
}
