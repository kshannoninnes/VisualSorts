using System.Collections.Generic;
using OxyPlot.Wpf;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using VisualSorts.Core.Commands;
using VisualSorts.Core.Factories;
using VisualSorts.Core.Models;

namespace VisualSorts.Core.ViewModels
{
    public class SortViewModel
    {
        private readonly Plot _colPlot;
        private readonly SortableData _sortableData;
        private readonly SortHandler _sortHandler;

        private ObservableCollection<IntegerModel> InitialData; 

        // XAML Bindings
        public ObservableCollection<IntegerModel> ListOfItems { get; set; }
        public ObservableCollection<NamedSort> Sorters { get; set;  }
        public NamedSort SelectedSort { get; set; }

        public SortViewModel(Plot colPlot, SortHandler sortHandler, SortableData sortableData)
        {
            _colPlot = colPlot;
            _sortableData = sortableData;
            _sortHandler = sortHandler;

            InitialData = _sortableData.GetRandom();
            UpdateAxesLength(InitialData.Count);
            SetPlotData(InitialData);

            Sorters = _sortHandler.GetSorters();
            SelectedSort = Sorters[0];
        }

        // Command Bindings
        public ICommand Sort => new SortCommand(this);
        public ICommand Reset => new ResetCommand(this);
        public ICommand Randomize => new RandomizeCommand(this);
        public ICommand Reverse => new ReverseCommand(this);

        // Command Functions
        public void SortData()
        {
            SelectedSort.Sort(ListOfItems, 0, ListOfItems.Count - 1);
        }

        public void ResetData()
        {
            SetPlotData(InitialData);
        }

        public void RandomizeData()
        {
            var randomData = _sortableData.GetRandom();
            SetPlotData(randomData);
        }

        public void ReverseData()
        {
            var reversedData = ListOfItems.Reverse();
            SetPlotData(reversedData);
        }

        // Private helpers
        private void SetPlotData(IEnumerable<IntegerModel> data)
        {
            ListOfItems = new ObservableCollection<IntegerModel>(data);
            _colPlot.Series[0].ItemsSource = ListOfItems;
        }

        private void UpdateAxesLength(int length)
        {
            /* Set axes maximums here instead of binding them because binding them in XAML
             * causes an issue where the plot auto-resizes based on the height of the currently
             * visible data (ie. a column of max height gets picked up in the algorithm temporarily
             * and the axis height shrinks until it's re-drawn)
             */
            foreach (var axis in _colPlot.Axes) axis.Maximum = length;
        }
    }
}