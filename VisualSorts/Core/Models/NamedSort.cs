using Sorter;
using System.Collections;

namespace VisualSorts.Core.Models
{
    public class NamedSort
    {
        public string Name { get; }

        private readonly AbstractSort _sorter;
        public NamedSort(string name, AbstractSort sorter)
        {
            Name = name;
            _sorter = sorter;
        }

        public void Sort(IList list, int low, int high)
        {
            _sorter.Sort(list, low, high);
        }
    }
}
