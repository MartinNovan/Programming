using System.Windows;
using System.Windows.Data;

namespace _16_assigment.Views;

public partial class SettingPage
{
    public SettingPage()
    {
        InitializeComponent();
        DefaultProfilePicker.ItemsSource = GlobalSettings.Profiles;
        DefaultProfilePicker.SelectedItem = GlobalSettings.DefaultProfileAtStart;
        ProfileList.ItemsSource = GlobalSettings.Profiles;
        CustomPathsList.ItemsSource = GlobalSettings.CustomPaths;
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        if ((string?)DefaultProfilePicker.SelectedItem != GlobalSettings.DefaultProfileAtStart)
            _ = FileHelpers.SetDefaultProfileAtStart((string?)DefaultProfilePicker.SelectedItem);
    }

    private void CreateProfileClicked(object sender, RoutedEventArgs e)
    {
        new AddPage("Profile").Show();
    }

    private void AddPathButtonOnClick(object sender, RoutedEventArgs e)
    {
        new AddPage("Path").Show();
    }

    private void RemovePathOnSelected(object sender, RoutedEventArgs e)
    {
        if (CustomPathsList.SelectedItem is string path)
        {
            _ = FileHelpers.RemoveCustomPath(path);
        }
        CustomPathsList.ItemsSource = null;
        CustomPathsList.ItemsSource = GlobalSettings.CustomPaths;
    }

    private void RemoveProfileOnSelected(object sender, RoutedEventArgs e)
    {
        if (ProfileList.SelectedItem is string profile)
        {
            if(profile == GlobalSettings.DefaultProfileAtStart || profile == "Default") return;
            _ = FileHelpers.RemoveProfile(profile);
        }
        DefaultProfilePicker.ItemsSource = null;
        DefaultProfilePicker.ItemsSource = GlobalSettings.Profiles;
        DefaultProfilePicker.SelectedItem = null;
        DefaultProfilePicker.SelectedItem = GlobalSettings.DefaultProfileAtStart;
        ProfileList.ItemsSource = null;
        ProfileList.ItemsSource = GlobalSettings.Profiles;
    }
}