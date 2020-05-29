using System.Windows.Media;

namespace VisualSorts.Core.Models
{
    public class NamedColor
    {
        public Color MediaColor { get; set; }
        public string Name { get; set; }

        public NamedColor(Color mediaColor, string name)
        {
            MediaColor = mediaColor;
            Name = name;
        }
    }
}