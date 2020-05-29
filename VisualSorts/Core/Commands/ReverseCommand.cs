using System;
using System.Windows.Input;
using VisualSorts.Core.ViewModels;

namespace VisualSorts.Core.Commands
{
    internal class ReverseCommand : ICommand
    {
        private readonly SortViewModel _viewModel;

        public event EventHandler CanExecuteChanged;

        public ReverseCommand(SortViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        void ICommand.Execute(object parameter)
        {
            _viewModel.ReverseData();
        }

        bool ICommand.CanExecute(object parameter)
        {
            return true;
        }
    }
}