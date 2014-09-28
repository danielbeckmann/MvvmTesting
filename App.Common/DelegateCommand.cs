using System;
using System.Windows.Input;

namespace App.Common
{
    /// <summary>
    /// This class implements the ICommand interface for command-bindings.
    /// </summary>
    public class DelegateCommand : ICommand
    {
        /// <summary>
        /// The function to determine whether the command can be executed.
        /// </summary>
        private readonly Func<object, bool> canExecute;

        /// <summary>
        /// The function to execute with the command.
        /// </summary>
        private readonly Action<object> execute;

        /// <summary>
        /// Initializes a new instance of the <see cref="DelegateCommand" /> class.
        /// </summary>
        /// <param name="execute">Action to execute with the command</param>
        /// <param name="canExecute">Function to determine whether the command can be executed</param>
        public DelegateCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            this.canExecute = canExecute;
            this.execute = execute;
        }

        /// <summary>
        /// This event is invoked when the can execute indicator has changed.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Checks whether the command can be executed.
        /// </summary>
        /// <param name="parameter">Parameter for command execution</param>
        /// <returns>True when the command can be executed</returns>
        public bool CanExecute(object parameter)
        {
            if (this.canExecute == null)
            {
                return true;
            }

            return this.canExecute(parameter);
        }

        /// <summary>
        /// Executes the commands action.
        /// </summary>
        /// <param name="parameter">Parameter for command execution</param>
        public void Execute(object parameter)
        {
            if (this.execute != null)
            {
                this.execute(parameter);
            }
        }

        /// <summary>
        /// Raises the CanExecuteChanged event.
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            if (this.CanExecuteChanged != null)
            {
                this.CanExecuteChanged(this, EventArgs.Empty);
            }
        }
    }
}
