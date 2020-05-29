using VisualSorts.Core.Factories;
using VisualSorts.Core.ViewModels;

namespace VisualSorts.Core.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainView
    {
        public MainView()
        {
            InitializeComponent();
            var sortHandler = new SortHandler();
            var sortableData = new SortableData(length: 100);
            DataContext = new SortViewModel(ColPlot, sortHandler, sortableData);
        }
    }
}
