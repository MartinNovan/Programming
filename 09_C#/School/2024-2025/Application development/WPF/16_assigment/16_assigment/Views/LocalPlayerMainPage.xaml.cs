using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using _16_assigment.Models;

namespace _16_assigment.Views;

public partial class LocalPlayerMainPage
{
    public static SongModel? PlayingSong { get; set; } = new();
    private static ObservableCollection<string?> PlayLists { get; set; } = new();
    public static string? CurrentPlayList { get; private set; } = "All Songs";
    private readonly DispatcherTimer _timer;
    private bool PlayRandomMode { get; set; }

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
        PlayerListView.SelectionChanged += PlayerListView_OnSelectionChanged;
        AlbumsPanel.ItemsSource = PlayLists;
        MediaElement.MediaEnded += MediaElementOnMediaEnded;
        _timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(0.5) };
        _timer.Tick += Timer_Tick;
        _timer.Start();
        DataContext = PlayLists;
    }


    private void MediaElementOnMediaEnded(object sender, RoutedEventArgs e)
    {
        if (RepeatMode == RepeatModes.RepeatOne)
        {
            PlaySong();
            return;
        }

        if (RepeatMode == RepeatModes.RepeatAll)
        {
            if (CurrentPlayList == "All Songs" && PlayRandomMode)
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
            else if (PlayRandomMode)
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


    private void Timer_Tick(object? sender, EventArgs e)
    {
        if (MediaElement.NaturalDuration.HasTimeSpan)
        {
            ProgressBar.Maximum = MediaElement.NaturalDuration.TimeSpan.TotalSeconds;
            ProgressBar.Value = MediaElement.Position.TotalSeconds;
            TimeLabel.Text = MediaElement.Position.ToString(@"m\:ss");
        }
    }

    public static void LoadPlaylists()
    {
        PlayLists.Clear();
        foreach (var album in GlobalSettings.Albums)
        {
            PlayLists.Add(album.Key);
        }
    }

    private void HomeButtonOnClick(object sender, RoutedEventArgs e)
    {
        PlayerListView.ItemsSource = GlobalSettings.AllSongs;
        SearchBox.Visibility = Visibility.Collapsed;
        CurrentPlayList = "All Songs";
        UpdateUi();
    }

    private void SearchButtonOnClick(object sender, RoutedEventArgs e)
    {
        PlayerListView.ItemsSource = GlobalSettings.AllSongs;
        SearchBox.Visibility = Visibility.Visible;
        CurrentPlayList = "Search all songs";
        UpdateUi();
    }

    private void PlayerListView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        UpdateUi();
        PlaySong();
    }


    private void CreateAlbumButtonOnClick(object sender, RoutedEventArgs e)
    {
        new AddPage("Album").Show();
    }

    private void UpdateUi()
    {
        if(PlayerListView.SelectedItem != null) PlayingSong = (SongModel)PlayerListView.SelectedItem;
        if(CurrentPlayList != null) PlaylistName.Text = CurrentPlayList;
        TimeLabel.Text = "0:00";
        ProgressBar.Value = 0;
        if(PlayingSong != null) FinishTimeLabel.Text = PlayingSong.Duration;
        PlayButton.Content = "\uf8ae";
        if(PlayingSong != null) SideBarSongName.Text = PlayingSong.Title;
        if(PlayingSong != null) SongName.Text = PlayingSong.Title;
        if(PlayingSong != null) SideBarAuthors.Text = PlayingSong.Artist;
        if(PlayingSong != null) Authors.Text = PlayingSong.Artist;
        if(PlayingSong != null) Image.Source = PlayingSong.AlbumArt;
        if(PlayingSong != null) SideBarImage.Source = PlayingSong.AlbumArt;
        if (CurrentPlayList != "All Songs" && CurrentPlayList != "Liked")
        {
            AddSongToPlaylistButton.Visibility = Visibility.Visible;
            RemovePlaylist.Visibility = Visibility.Visible;
        }
        else if(CurrentPlayList == "Liked")
        {
            AddSongToPlaylistButton.Visibility = Visibility.Visible;
            RemovePlaylist.Visibility = Visibility.Collapsed;
        }
        else
        {
            AddSongToPlaylistButton.Visibility = Visibility.Collapsed;
            RemovePlaylist.Visibility = Visibility.Collapsed;
        }
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

            PlayerListView.ItemsSource = GlobalSettings.AllSongs
                .Where(s => !string.IsNullOrEmpty(s?.Title) && s.Title.ToLower().Contains(searchText)).ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error when searching for songs: {ex}");
        }
    }

    private void VolumeChanged(object sender, RoutedPropertyChangedEventArgs<double> routedPropertyChangedEventArgs)
    {
        MediaElement.Volume = VolumeSlider.Value / 10;
        Console.WriteLine(MediaElement.Volume);
    }

    private void PlaySong()
    {
        if (PlayingSong != null) MediaElement.Source = new Uri(PlayingSong.Path!);
        MediaElement.Position = TimeSpan.Zero;
        MediaElement.Play();
    }

    private void ProgressSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        if (MediaElement.NaturalDuration.HasTimeSpan &&
            Math.Abs(MediaElement.Position.TotalSeconds - ProgressBar.Value) > 1)
        {
            MediaElement.Position = TimeSpan.FromSeconds(ProgressBar.Value);
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

    private void SkipForward_OnClick(object sender, RoutedEventArgs e)
    {
        if (CurrentPlayList == "All Songs")
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
        if (PlayRandomMode)
        {
            RandomPlay.SetResourceReference(Control.BackgroundProperty, "Transparent");
            PlayRandomMode = false;
        }
        else
        {
            RandomPlay.SetResourceReference(Control.BackgroundProperty, "AccentFillColorSelectedTextBackgroundBrush");
            PlayRandomMode = true;
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

    private void AlbumsPanel_OnSelectionChanged(object sender, RoutedEventArgs routedEventArgs)
    {
        CurrentPlayList = AlbumsPanel.SelectedItem.ToString();
        PlayerListView.ItemsSource = GlobalSettings.Albums[CurrentPlayList];
        SearchBox.Visibility = Visibility.Collapsed;
        AlbumsPanel.SelectionChanged -= AlbumsPanel_OnSelectionChanged;
        AlbumsPanel.SelectedItem = null;
        AlbumsPanel.SelectionChanged += AlbumsPanel_OnSelectionChanged;
        UpdateUi();
    }

    private void RemovePlaylist_OnClick(object sender, RoutedEventArgs e)
    {
        _ = FileHelpers.RemoveAlbum(CurrentPlayList);
        GlobalSettings.Albums.Remove(CurrentPlayList);
        LoadPlaylists();
        CurrentPlayList = "All Songs";
        PlayerListView.ItemsSource = GlobalSettings.AllSongs;
        UpdateUi();
    }

    private void AddSongToPlaylistButton_OnClick(object sender, RoutedEventArgs e)
    {
        new AddPage("AlbumAdd").Show();
    }
}