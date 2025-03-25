using System.Collections.Immutable;
using System.Windows;

namespace _16_assignment.Views;

public partial class AddPage
{
    private readonly string _mode;
    public AddPage(string mode)
    {
        _mode = mode;
        InitializeComponent();
        switch (mode)
        {
            case "Album":
                AddAlbum.Visibility = Visibility.Visible;
                AddProfile.Visibility = Visibility.Collapsed;
                AddCustomPath.Visibility = Visibility.Collapsed;
                AddSong.Visibility = Visibility.Collapsed;
                break;
            case "Profile":
                AddAlbum.Visibility = Visibility.Collapsed;
                AddProfile.Visibility = Visibility.Visible;
                AddCustomPath.Visibility = Visibility.Collapsed;
                AddSong.Visibility = Visibility.Collapsed;
                break;
            case "Path":
                AddAlbum.Visibility = Visibility.Collapsed;
                AddProfile.Visibility = Visibility.Collapsed;
                AddCustomPath.Visibility = Visibility.Visible;
                AddSong.Visibility = Visibility.Collapsed;
                break;
            case "AlbumAdd":
                AddAlbum.Visibility = Visibility.Collapsed;
                AddProfile.Visibility = Visibility.Collapsed;
                AddCustomPath.Visibility = Visibility.Collapsed;
                AddSong.Visibility = Visibility.Visible;
                ListView.ItemsSource = GlobalSettings.AllSongs;
                ListView.SelectedItems.Clear();
                foreach (var song in GlobalSettings.Albums[LocalPlayerMainPage.CurrentPlayList])
                {
                    ListView.SelectedItems.Add(song);
                }
                break;
        }
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        switch (_mode)
        {
            case "Album":
                _ = FileHelpers.AddAlbum(AlbumName.Text);
                Application.Current.Dispatcher.Invoke(LocalPlayerMainPage.LoadPlaylists);
                Close();
                break;
            case "Profile":
                _ = FileHelpers.AddProfile(Profile.Text);
                Close();
                break;
            case "Path":
                _ = FileHelpers.AddCustomPath(Path.Text);
                Close();
                break;
            case "AlbumAdd":
                foreach (var song in GlobalSettings.AllSongs)
                {
                    if (ListView.SelectedItems.Contains(song) &&
                        !GlobalSettings.Albums[LocalPlayerMainPage.CurrentPlayList].Contains(song))
                    {
                        FileHelpers.AddSongToAlbum(LocalPlayerMainPage.CurrentPlayList, song);
                    }
                    else if (!ListView.SelectedItems.Contains(song) &&
                             GlobalSettings.Albums[LocalPlayerMainPage.CurrentPlayList].Contains(song))
                    {
                        FileHelpers.RemoveSongFromAlbum(LocalPlayerMainPage.CurrentPlayList, song);
                    }
                }
                Close();
                break;
        }
    }
}