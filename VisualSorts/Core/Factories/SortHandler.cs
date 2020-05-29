using Sorter.Implemented_Sorts;
using System.Collections.ObjectModel;
using VisualSorts.Core.Models;

namespace VisualSorts.Core.Factories
{
    public class SortHandler
    {
        private readonly ObservableCollection<NamedSort> _sorters;

        public SortHandler()
        {
            var ordering = new IntegerModelOrder();
            _sorters = new ObservableCollection<NamedSort>
            {
                new NamedSort("Insertion Sort", new InsertionSort(ordering)),
                new NamedSort("Bubble Sort", new BubbleSort(ordering)),
                new NamedSort("Merge Sort", new MergeSort(ordering)),
                new NamedSort("Quick Sort", new QuickSort(ordering)),
                new NamedSort("Heap Sort", new HeapSort(ordering))
            };
        }

        public ObservableCollection<NamedSort> GetSorters()
        {
            return new ObservableCollection<NamedSort>(_sorters);
        }
    }
}
