using System;
using System.Windows.Input;
using VisualSorts.Core.ViewModels;

namespace VisualSorts.Core.Commands
{
    internal class RandomizeCommand : ICommand
    {
        private readonly SortViewModel _viewModel;

        public event EventHandler CanExecuteChanged;

        public RandomizeCommand(SortViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        void ICommand.Execute(object parameter)
        {
            _viewModel.RandomizeData();
        }

        bool ICommand.CanExecute(object parameter)
        {
            return true;
        }
    }
}