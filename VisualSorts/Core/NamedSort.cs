using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace VisualSorts.Core
{
    public class NamedSort
    {
        public string Name { get; set; }

        private Sorter.Sorter sorter;
        public NamedSort(string name, Sorter.Sorter sorter)
        {
            Name = name;
            this.sorter = sorter;
        }

        public void Sort(IList list, int low, int high)
        {
            sorter.Sort(list, low, high);
        }
    }
}
