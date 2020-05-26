using Sorter;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace VisualSorts.Core
{
    public class NamedSort
    {
        public string Name { get; set; }

        private AbstractSort sorter;
        public NamedSort(string name, AbstractSort sorter)
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
