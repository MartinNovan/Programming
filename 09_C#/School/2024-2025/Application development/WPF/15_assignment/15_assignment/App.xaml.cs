using System.Windows;
using Microsoft.Win32;

namespace _15_assignment;
public partial class App
{
    public App()
    {
        InitializeComponent();
        ApplyTheme(); // Call the method to apply the theme when the application starts
        UserRepository.CreateDatabeseFileIfNotExists(); // Call the method to create the database file if it doesn't exist
    }

    private void ApplyTheme()
    {
        // Determine if dark mode is enabled
        bool isDarkMode = IsDarkModeEnabled();

        // Select the appropriate ResourceDictionary
        string theme = isDarkMode ? "Themes/Dark.xaml" : "Themes/Light.xaml";
        var dictionary = new ResourceDictionary
        {
            Source = new Uri(theme, UriKind.Relative)
        };

        // Update the application's resources
        Current.Resources.MergedDictionaries.Clear();
        Current.Resources.MergedDictionaries.Add(dictionary);
    }

    private bool IsDarkModeEnabled()
    {
        const string registryKeyPath = @"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize";
        const string registryValueName = "AppsUseLightTheme";

        using var key = Registry.CurrentUser.OpenSubKey(registryKeyPath);
        if (key != null && key.GetValue(registryValueName) is int value)
        {
            return value == 0; // 0 = Dark Mode, 1 = Light Mode
        }

        return false; // Default to light mode
    }
}