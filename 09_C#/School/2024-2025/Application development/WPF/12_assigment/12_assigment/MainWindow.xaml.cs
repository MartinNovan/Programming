using System.Windows;

namespace _12_assigment;

public partial class MainWindow
{
    public MainWindow()
    {
        InitializeComponent();
    }
    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        var number = int.Parse(Counter.Content.ToString() ?? "0");
        number++;
        Counter.Content = number.ToString();
    }
}