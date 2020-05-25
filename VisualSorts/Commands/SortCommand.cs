using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using VisualSorts.Core;

namespace VisualSorts.Commands
{
    class SortCommand : ICommand
    {
        private readonly OxyChart viewModel;

        public event EventHandler CanExecuteChanged;

        public SortCommand(OxyChart viewModel)
        {
            this.viewModel = viewModel;
        }

        void ICommand.Execute(object parameter)
        {
            viewModel.Sort();
        }

        bool ICommand.CanExecute(object parameter)
        {
            return true;
        }
    }
}
