using System.Windows;
using _15_assignment.Windows;
using static _15_assignment.MainWindow;

namespace _15_assignment.Pages;

public partial class LoginPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private void Hyperlink_OnClick(object sender, RoutedEventArgs e)
    {
        new RegisterWindow().Show();
    }

    private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            if (UsernameEntry.Text.Length == 0 || PasswordEntry.Text.Length == 0)
            {
                MessageBox.Show("Please fill in all fields!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            bool correctLogin = await new UserRepository().Login(UsernameEntry.Text, PasswordEntry.Text);
            if (correctLogin)
            {
                NavigateToPage(new MainPage());
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

}