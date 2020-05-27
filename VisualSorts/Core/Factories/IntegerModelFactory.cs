using System;
using System.Collections.ObjectModel;
using System.Linq;
using VisualSorts.Core.Models;

namespace VisualSorts.Core.Factories
{
    public static class IntegerModelFactory
    {
        private static ObservableCollection<IntegerModel> _orderedData;

        private static void InitData(int length)
        {
            var rawData = Enumerable.Range(0, length).Select(x => new IntegerModel(x));
            _orderedData = new ObservableCollection<IntegerModel>(rawData);
        }

        public static ObservableCollection<IntegerModel> GetOrdered(int length = 100)
        {
            if (_orderedData == null) InitData(length);

            return new ObservableCollection<IntegerModel>(_orderedData);
        }

        public static ObservableCollection<IntegerModel> GetRandom(int length = 100)
        {
            if (_orderedData == null) InitData(length);

            var rand = new Random();
            var randomized = _orderedData.OrderBy(x => rand.Next());
            return new ObservableCollection<IntegerModel>(randomized);
        }

        public static ObservableCollection<IntegerModel> GetReversed(int length = 100)
        {
            if (_orderedData == null) InitData(length);

            return new ObservableCollection<IntegerModel>(_orderedData.Reverse());
        }
    }
}
