using OxyPlot.Wpf;
using System.Collections.ObjectModel;
using System.Windows.Input;
using VisualSorts.Core.Commands;
using VisualSorts.Core.Factories;
using VisualSorts.Core.Models;

namespace VisualSorts.Core.ViewModels
{
    public class SortViewModel
    {
        private readonly Plot _colPlot;
        private const int NumElements = 200;

        // XAML Bindings
        public ObservableCollection<IntegerModel> ListOfItems { get; set; }
        public ObservableCollection<NamedSort> Sorters { get; set;  }
        public NamedSort SelectedSort { get; set;  }

        public SortViewModel(Plot colPlot)
        {
            _colPlot = colPlot;

            /* Set axes maximums here instead of binding them because binding them in XAML
             * causes an issue where the plot auto-resizes based on the height of the currently
             * visible data (ie. a column of max height gets picked up in the algorithm temporarily
             * and the axis height shrinks until it's re-drawn)
             */
            foreach (var axes in _colPlot.Axes) axes.Maximum = NumElements;

            Sorters = SortFactory.GetSorters();
            SelectedSort = Sorters[0];
            ResetData();
        }

        // Command Bindings
        public ICommand Sort => new SortCommand(this);

        public ICommand Reset => new ResetCommand(this);

        // Command Functions
        public void SortData()
        {
            SelectedSort.Sort(ListOfItems, 0, ListOfItems.Count - 1);
        }

        public void ResetData()
        {
            ListOfItems = IntegerModelFactory.GetRandom(NumElements);
            _colPlot.Series[0].ItemsSource = ListOfItems;
        }
    }
}