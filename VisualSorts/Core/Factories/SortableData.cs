using System;
using System.Collections.ObjectModel;
using System.Linq;
using VisualSorts.Core.Models;

namespace VisualSorts.Core.Factories
{
    public class SortableData
    {
        private readonly ObservableCollection<IntegerModel> _orderedData;

        public SortableData(int length)
        {
            var rawData = Enumerable.Range(0, length).Select(x => new IntegerModel(x + 1));
            _orderedData = new ObservableCollection<IntegerModel>(rawData);
        }

        public ObservableCollection<IntegerModel> GetOrdered()
        {
            return new ObservableCollection<IntegerModel>(_orderedData);
        }

        public ObservableCollection<IntegerModel> GetRandom()
        {
            var rand = new Random();
            var randomized = _orderedData.OrderBy(x => rand.Next());
            return new ObservableCollection<IntegerModel>(randomized);
        }

        public ObservableCollection<IntegerModel> GetReversed()
        {
            return new ObservableCollection<IntegerModel>(_orderedData.Reverse());
        }
    }
}
