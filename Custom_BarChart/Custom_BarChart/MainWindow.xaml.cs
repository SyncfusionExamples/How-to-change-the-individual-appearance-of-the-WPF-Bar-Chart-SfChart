using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using Syncfusion.UI.Xaml.Charts;

namespace Custom_BarChart
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }

    public class InteriorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var ydata = (value as ColumnSegment).YData;
            Brush interior;

            interior = ydata > 0 ?
                new SolidColorBrush(Colors.Green) :
                new SolidColorBrush(Colors.Red);

            return interior;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
