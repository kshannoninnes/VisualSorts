using Sorter;

namespace VisualSorts.Core.Models
{
    internal class IntegerModelOrder : AbstractOrder
    {
        public override bool Equal(object x, object y)
        {
            var first = (IntegerModel)x;
            var second = (IntegerModel)y;

            return first.Value == second.Value;
        }

        public override bool LessThan(object x, object y)
        {
            var first = (IntegerModel)x;
            var second = (IntegerModel)y;

            return first.Value < second.Value;
        }
    }
}
