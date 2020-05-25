using OxyPlot.Wpf;
using Sorter.Implemented_Sorts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using VisualSorts.Commands;

namespace VisualSorts.Core
{
    internal class OxyChart
    {
        private Plot colPlot;
        public ObservableCollection<NamedSort> Sorters { get; set; }
        public NamedSort SelectedSort { get; set; }
        public ObservableCollection<IntegerModel> ListOfItems { get; set; }
        public ObservableCollection<IntegerModel> PreSortedList { get; set; }

        public OxyChart(Plot colPlot)
        {
            this.colPlot = colPlot;
            InitData();
            InitSorts();
        }

        private void InitData()
        {
            List<IntegerModel> PreRandomList = new List<IntegerModel>();

            for (int ii = 100; ii > 0; ii--)
            {
                var iModel = new IntegerModel(ii);
                PreRandomList.Add(iModel);
            }

            var rand = new Random();
            var PostRandomList = PreRandomList.OrderBy(x => rand.Next()).ToList();
            ListOfItems = new ObservableCollection<IntegerModel>(PostRandomList);
            PreSortedList = new ObservableCollection<IntegerModel>(ListOfItems);
        }

        private void InitSorts()
        {
            Sorters = new ObservableCollection<NamedSort>();

            var ordering = new IntegerModelOrder();
            Sorters.Add(new NamedSort("Insertion Sort", new InsertionSort(ordering)));
            Sorters.Add(new NamedSort("Bubble Sort", new BubbleSort(ordering)));
            Sorters.Add(new NamedSort("Merge Sort", new MergeSort(ordering)));
            Sorters.Add(new NamedSort("Quick Sort", new QuickSort(ordering)));
            Sorters.Add(new NamedSort("Heap Sort", new HeapSort(ordering)));

            SelectedSort = Sorters[0];
        }

        public ICommand SortCommand
        {
            get
            {
                return new SortCommand(this);
            }
        }

        public ICommand ResetCommand
        {
            get
            {
                return new ResetCommand(this);
            }
        }

        public void Sort()
        {
            SelectedSort.Sort(ListOfItems, 0, ListOfItems.Count - 1);
        }

        public void Reset()
        {
            ListOfItems = new ObservableCollection<IntegerModel>(PreSortedList);
            colPlot.Series[0].ItemsSource = ListOfItems;
        }
    }
}