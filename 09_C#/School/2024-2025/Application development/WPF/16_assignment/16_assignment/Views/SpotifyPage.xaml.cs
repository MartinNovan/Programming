using System.Windows.Controls;

namespace _16_assignment.Views;

public partial class SpotifyPage : Page
{
    public SpotifyPage()
    {
        InitializeComponent();
        SpotifyWebView.Source = new Uri("https://open.spotify.com");

    }
}