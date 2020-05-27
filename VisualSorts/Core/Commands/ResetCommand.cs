using System;
using System.Windows.Input;
using VisualSorts.Core.ViewModels;

namespace VisualSorts.Core.Commands
{
    internal class ResetCommand : ICommand
    {
        private readonly SortViewModel _viewModel;

        public event EventHandler CanExecuteChanged;

        public ResetCommand(SortViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        void ICommand.Execute(object parameter)
        {
            _viewModel.ResetData();
        }

        bool ICommand.CanExecute(object parameter)
        {
            return true;
        }
    }
}
