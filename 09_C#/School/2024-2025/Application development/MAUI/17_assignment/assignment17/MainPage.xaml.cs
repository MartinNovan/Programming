namespace _17_assignment;

public partial class MainPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void Button_OnClicked(object? sender, EventArgs e)
    {
        try
        {
            await Shell.Current.GoToAsync("//second");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Error when navigating to the secondary page: {ex.Message}", "OK");
        }
    }
}