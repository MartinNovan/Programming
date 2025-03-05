using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using _16_assigment.Models;

namespace _16_assigment.Views;

public partial class LocalPlayerMainPage
{
    private SongModel PlayingSong { get; set; } = new ();
    private List<string> PlayLists { get; set; } = new();
    private string CurrentPlayList { get; set; } = "All Songs";
    private readonly DispatcherTimer _timer;
    private bool randomPlay { get; set; } = false;
    private enum RepeatModes
    {
        RepeatAll,
        RepeatOne,
        RepeatNone
    }
    private RepeatModes RepeatMode { get; set; } = RepeatModes.RepeatAll;

    public LocalPlayerMainPage()
    {
        InitializeComponent();

        PlayerListView.ItemsSource = GlobalSettings.AllSongs;
        PlayerListView.SelectedItem = GlobalSettings.AllSongs[0];
        UpdateUi();
        LoadPlaylists();
        MediaElement.MediaEnded += MediaElementOnMediaEnded;
        _timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(0.5) };
        _timer.Tick += Timer_Tick;
        _timer.Start();
    }



    private void MediaElementOnMediaEnded(object sender, RoutedEventArgs e)
    {
        MediaElement.Stop();
        MediaElement.Position = TimeSpan.Zero;
        _timer.Stop();
        MediaElement.Clock = null;
        MediaElement.Source = null;

        if (RepeatMode == RepeatModes.RepeatOne)
        {
            PlaySong();
            return;
        }

        if (RepeatMode == RepeatModes.RepeatAll)
        {
            if (CurrentPlayList == "All Songs" && randomPlay)
            {
                var random = new Random();
                var index = random.Next(0, GlobalSettings.AllSongs.Count);
                PlayerListView.SelectedItem = GlobalSettings.AllSongs[index];
            }
            else if (CurrentPlayList == "All Songs")
            {
                var index = GlobalSettings.AllSongs.IndexOf(PlayingSong);
                if (index + 1 < GlobalSettings.AllSongs.Count)
                {
                    PlayerListView.SelectedItem = GlobalSettings.AllSongs[index + 1];
                }
            }
            else if (randomPlay)
            {
                var random = new Random();
                var index = random.Next(0, GlobalSettings.Albums[CurrentPlayList].Count);
                PlayerListView.SelectedItem = GlobalSettings.Albums[CurrentPlayList][index];
            }
            else
            {
                var index = GlobalSettings.Albums[CurrentPlayList].IndexOf(PlayingSong);
                if (index + 1 < GlobalSettings.Albums[CurrentPlayList].Count)
                {
                    PlayerListView.SelectedItem = GlobalSettings.Albums[CurrentPlayList][index + 1];
                }
            }
            UpdateUi();
            PlaySong();
        }
    }


    private void Timer_Tick(object sender, EventArgs e)
    {
        if (MediaElement.NaturalDuration.HasTimeSpan)
        {
            ProgressSlider.Maximum = MediaElement.NaturalDuration.TimeSpan.TotalSeconds;
            ProgressSlider.Value = MediaElement.Position.TotalSeconds;
            TimeLabel.Text = MediaElement.Position.ToString(@"m\:ss");
        }
    }

    private void LoadPlaylists()
    {

        foreach (var album in GlobalSettings.Albums)
        {
            Button albumButton = new Button
            {
                Content = album.Key,
                Margin = new Thickness(5),
                Width = 50,
                Height = 50,
                VerticalAlignment = VerticalAlignment.Top,
                ClickMode = ClickMode.Press,
                ToolTip = album.Key
            };
            if (album.Key == "Liked")
            {
                albumButton.Content = "\ueb52";
                albumButton.SetResourceReference(Control.FontFamilyProperty, "SymbolThemeFontFamily");
                albumButton.FontSize = 25;
                albumButton.Click += LikedButtonOnClick;
            }
            else
            {
                albumButton.Click += AlbumButtonOnClick;
            }
            AlbumsPanel.Children.Add(albumButton);
            PlayLists.Add(album.Key);
        }
    }

    private void AlbumButtonOnClick(object sender, RoutedEventArgs e)
    {
        var button = (Button)sender;
        PlayerListView.ItemsSource = GlobalSettings.Albums[button.Content.ToString()!];
        SearchBox.Visibility = Visibility.Collapsed;
    }

    private void HomeButtonOnClick(object sender, RoutedEventArgs e)
    {
        PlayerListView.ItemsSource = GlobalSettings.AllSongs;
        SearchBox.Visibility = Visibility.Collapsed;
    }

    private void SearchButtonOnClick(object sender, RoutedEventArgs e)
    {
        PlayerListView.ItemsSource = GlobalSettings.AllSongs;
        SearchBox.Visibility = Visibility.Visible;
    }

    private void LikedButtonOnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            PlayerListView.ItemsSource = GlobalSettings.Albums["Liked"];
            SearchBox.Visibility = Visibility.Collapsed;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error when searching for songs: {ex}");
        }
    }

    private void PlayerListView_OnSelected(object sender, RoutedEventArgs e)
    {
        UpdateUi();
        PlaySong();
    }

    private void CreateAlbumButtonOnClick(object sender, RoutedEventArgs e)
    {

    }

    private void UpdateUi()
    {
        PlayingSong = (SongModel)PlayerListView.SelectedItem;
        TimeLabel.Text = "0:00";
        FinishTimeLabel.Text = PlayingSong.Duration;
        PlayButton.Content = "\uf8ae";
        SideBarSongName.Text = PlayingSong.Title;
        SongName.Text = PlayingSong.Title;
        SideBarAuthors.Text = PlayingSong.Artist;
        Authors.Text = PlayingSong.Artist;
        Image.Source = PlayingSong.AlbumArt;
        SideBarImage.Source = PlayingSong.AlbumArt;
    }

    private void SearchBox_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
            var searchText = (sender as TextBox)?.Text.ToLower() ?? "";

            if (string.IsNullOrWhiteSpace(searchText))
            {
                PlayerListView.ItemsSource = GlobalSettings.AllSongs;
                return;
            }

            PlayerListView.ItemsSource = GlobalSettings.AllSongs.Where(s => !string.IsNullOrEmpty(s.Title) && s.Title.ToLower().Contains(searchText)).ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error when searching for songs: {ex}");
        }
    }

    private void AddToPlaylistButton_Click(object sender, RoutedEventArgs e)
    {
        var song = (sender as Button)?.DataContext as SongModel;

        if (song != null)
        {
            var contextMenu = sender as Button;
            if (contextMenu != null)
            {
                Console.WriteLine("SUCCESS");
            }
        }
    }

    private void VolumeChanged(object sender, RoutedPropertyChangedEventArgs<double> routedPropertyChangedEventArgs)
    {
        MediaElement.Volume = VolumeSlider.Value/10;
        Console.WriteLine(MediaElement.Volume);
    }

    private void PlaySong()
    {
        MediaElement.Source = new Uri(PlayingSong.Path!);
        _timer.Start();
        MediaElement.Position = TimeSpan.Zero;
        MediaElement.Play();
    }

    private void ProgressSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        if (MediaElement.NaturalDuration.HasTimeSpan && Math.Abs(MediaElement.Position.TotalSeconds - ProgressSlider.Value) > 1)
        {
            MediaElement.Position = TimeSpan.FromSeconds(ProgressSlider.Value);
        }
    }

    private void PlayButton_OnClick(object sender, RoutedEventArgs e)
    {
        if (PlayButton.Content.ToString() == "\uf8ae")
        {
            MediaElement.Pause();
            PlayButton.Content = "\uf5b0";
        }
        else
        {
            MediaElement.Play();
            PlayButton.Content = "\uf8ae";
        }
    }

    private void SkipFoward_OnClick(object sender, RoutedEventArgs e)
    {
        if(CurrentPlayList == "All Songs")
        {
            var index = GlobalSettings.AllSongs.IndexOf(PlayingSong);
            if (index + 1 < GlobalSettings.AllSongs.Count)
            {
                PlayerListView.SelectedItem = GlobalSettings.AllSongs[index + 1];
                UpdateUi();
                PlaySong();
            }
        }
        else
        {
            var index = GlobalSettings.Albums[CurrentPlayList].IndexOf(PlayingSong);
            if (index + 1 < GlobalSettings.Albums[CurrentPlayList].Count)
            {
                PlayerListView.SelectedItem = GlobalSettings.Albums[CurrentPlayList][index + 1];
                UpdateUi();
                PlaySong();
            }
        }
    }



    private void SkipBack_OnClick(object sender, RoutedEventArgs e)
    {
        if (CurrentPlayList == "All Songs")
        {
            var index = GlobalSettings.AllSongs.IndexOf(PlayingSong);
            if (index - 1 >= 0)
            {
                PlayerListView.SelectedItem = GlobalSettings.AllSongs[index - 1];
                UpdateUi();
                PlaySong();
            }
        }
        else
        {
            var index = GlobalSettings.Albums[CurrentPlayList].IndexOf(PlayingSong);
            if (index - 1 >= 0)
            {
                PlayerListView.SelectedItem = GlobalSettings.Albums[CurrentPlayList][index - 1];
                UpdateUi();
                PlaySong();
            }
        }
    }

    private void RandomPlay_OnClick(object sender, RoutedEventArgs e)
    {
        if (randomPlay)
        {
            RandomPlay.SetResourceReference(Control.BackgroundProperty, "Transparent");
            randomPlay = false;
        }
        else
        {
            RandomPlay.SetResourceReference(Control.BackgroundProperty, "AccentFillColorSelectedTextBackgroundBrush");
            randomPlay = true;
        }
    }

    private void Repeat_OnClick(object sender, RoutedEventArgs e)
    {
        switch (RepeatMode)
        {
            case RepeatModes.RepeatAll:
                Repeat.SetResourceReference(Control.BackgroundProperty, "AccentFillColorSelectedTextBackgroundBrush");
                Repeat.Content = "\ue8ee";
                RepeatMode = RepeatModes.RepeatOne;
                break;
            case RepeatModes.RepeatOne:
                Repeat.SetResourceReference(Control.BackgroundProperty, "AccentFillColorSelectedTextBackgroundBrush");
                Repeat.Content = "\ue8ed";
                RepeatMode = RepeatModes.RepeatNone;
                break;
            case RepeatModes.RepeatNone:
                Repeat.SetResourceReference(Control.BackgroundProperty, "Transparent");
                Repeat.Content = "\uf5e7";
                RepeatMode = RepeatModes.RepeatAll;
                break;
        }
    }
}