using System.Windows;
using Microsoft.Win32; 

namespace LogApp;

public partial class App
{
    public App()
    {
        InitializeComponent();
        ApplyTheme();
    }

    private void ApplyTheme()
    {
        bool isDarkMode = IsDarkModeEnabled();
        string theme = isDarkMode ? "Themes/Dark.xaml" : "Themes/Light.xaml";
        var dictionary = new ResourceDictionary
        {
            Source = new Uri(theme, UriKind.Relative)
        };
        Current.Resources.MergedDictionaries.Clear();
        Current.Resources.MergedDictionaries.Add(dictionary);
    }

    private bool IsDarkModeEnabled()
    {
        const string registryKeyPath = @"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize";
        const string registryValueName = "AppsUseLightTheme";

        using (var key = Registry.CurrentUser.OpenSubKey(registryKeyPath))
        {
            if (key != null && key.GetValue(registryValueName) is int value)
            {
                return value == 0; 
            }
        }
        return false;
    }
}