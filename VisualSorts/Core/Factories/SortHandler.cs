using Sorter.Implemented_Sorts;
using System.Collections.ObjectModel;
using VisualSorts.Core.Models;

namespace VisualSorts.Core.Factories
{
    public class SortHandler
    {
        private ObservableCollection<NamedSort> _sorters;

        private void InitSorts()
        {
            _sorters = new ObservableCollection<NamedSort>();

            var ordering = new IntegerModelOrder();
            _sorters.Add(new NamedSort("Insertion Sort", new InsertionSort(ordering)));
            _sorters.Add(new NamedSort("Bubble Sort", new BubbleSort(ordering)));
            _sorters.Add(new NamedSort("Merge Sort", new MergeSort(ordering)));
            _sorters.Add(new NamedSort("Quick Sort", new QuickSort(ordering)));
            _sorters.Add(new NamedSort("Heap Sort", new HeapSort(ordering)));
        }

        public ObservableCollection<NamedSort> GetSorters()
        {
            if (_sorters == null) InitSorts();

            return new ObservableCollection<NamedSort>(_sorters);
        }
    }
}
