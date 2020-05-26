using System.Windows;
using VisualSorts.Core;

namespace VisualSorts
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new OxyChart(colPlot);
        }
    }
}
