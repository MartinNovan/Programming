using System.Windows;

namespace _14_assigment.Windows;

public partial class RegisterWindow
{
    public RegisterWindow()
    {
        InitializeComponent();
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        if(UsernameEntry.Text.Length == 0 || EmailEntry.Text.Length == 0 || PasswordEntry.Text.Length == 0 || PasswordConfirmationEntry.Text.Length == 0)
        {
            MessageBox.Show("Please fill in all fields!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }
        if (PasswordEntry.Text != PasswordConfirmationEntry.Text)
        {
            MessageBox.Show("Passwords do not match", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }
        var user = new Models.User
        {
            Username = UsernameEntry.Text,
            Email = EmailEntry.Text,
            Password = PasswordEntry.Text,
        };
        new FileHelper().Register(user);
        Close();
    }
}