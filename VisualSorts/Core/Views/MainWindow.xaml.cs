using System.Windows;
using VisualSorts.Core.ViewModels;

namespace VisualSorts.Core.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new SortViewModel(ColPlot);
        }
    }
}
