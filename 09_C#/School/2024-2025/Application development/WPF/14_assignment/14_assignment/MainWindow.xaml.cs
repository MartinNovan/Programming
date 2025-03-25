using System.Windows;
using System.Windows.Controls;

namespace _14_assignment;

public partial class MainWindow
{
    public MainWindow()
    {
        InitializeComponent();
        MainFrame.Navigate(new Pages.LoginPage());
    }
    public static void NavigateToPage(Page page)
    {
        var mainWindow = (MainWindow?)Application.Current.MainWindow;
        mainWindow?.MainFrame.Navigate(page);
    }
}