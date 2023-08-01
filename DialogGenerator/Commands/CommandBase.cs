using System;
using System.Windows.Input;

namespace DialogGenerator.Commands
{
    public abstract class CommandBase : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public virtual bool CanExecute(object? parameter) => true;

        public abstract void Execute(object? parameter);

        protected void OnCanExecute()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}