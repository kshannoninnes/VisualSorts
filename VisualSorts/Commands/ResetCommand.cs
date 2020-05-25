using System;
using System.Windows.Input;
using VisualSorts.Core;

namespace VisualSorts.Commands
{
    class ResetCommand : ICommand
    {
        private readonly OxyChart viewModel;

        public event EventHandler CanExecuteChanged;

        public ResetCommand(OxyChart viewModel)
        {
            this.viewModel = viewModel;
        }

        void ICommand.Execute(object parameter)
        {
            viewModel.Reset();
        }

        bool ICommand.CanExecute(object parameter)
        {
            return true;
        }
    }
}
