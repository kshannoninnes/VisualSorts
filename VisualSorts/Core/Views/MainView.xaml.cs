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
            DataContext = new SortViewModel(ColPlot, new DataHandler(), new SortHandler());
        }
    }
}
