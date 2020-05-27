using System;
using System.Windows.Input;
using VisualSorts.Core.ViewModels;

namespace VisualSorts.Core.Commands
{
    internal class SortCommand : ICommand
    {
        private readonly SortViewModel _viewModel;

        public event EventHandler CanExecuteChanged;

        public SortCommand(SortViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        void ICommand.Execute(object parameter)
        {
            _viewModel.SortData();
        }

        bool ICommand.CanExecute(object parameter)
        {
            return true;
        }
    }
}
