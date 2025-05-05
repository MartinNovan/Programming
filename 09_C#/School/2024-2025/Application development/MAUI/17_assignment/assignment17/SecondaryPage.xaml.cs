namespace _17_assignment;

public partial class SecondaryPage
{
    public SecondaryPage()
    {
        InitializeComponent();
    }

    private async void Button_OnClicked(object? sender, EventArgs e)
    {
        try
        {
            await Shell.Current.GoToAsync("//main");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Error when navigating to MainPage: {ex.Message}", "OK");
        }
    }
}