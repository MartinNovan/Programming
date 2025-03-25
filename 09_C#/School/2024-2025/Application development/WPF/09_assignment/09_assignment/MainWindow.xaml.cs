using System.Windows;
using System.Windows.Media;

namespace _09_assignment;
public partial class MainWindow
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void UniformButtonOnChecked(object sender, RoutedEventArgs e)
    {
        Image.Stretch = Stretch.Uniform;
    }

    private void UniformToFillButtonOnChecked(object sender, RoutedEventArgs e)
    {
        Image.Stretch = Stretch.UniformToFill;
    }

    private void FillButtonOnChecked(object sender, RoutedEventArgs e)
    {
        Image.Stretch = Stretch.Fill;
    }

    private void NoneButtonOnChecked(object sender, RoutedEventArgs e)
    {
        Image.Stretch = Stretch.None;
    }
}