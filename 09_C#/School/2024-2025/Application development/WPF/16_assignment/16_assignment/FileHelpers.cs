using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using _16_assignment.Models;
using _16_assignment.Views;
using Newtonsoft.Json.Linq;

namespace _16_assignment;

public abstract class FileHelpers
{
    public static async Task CreateAppFileIfNotExist()
    {
        try
        {
            Directory.CreateDirectory(GlobalSettings.DataPath);
            Directory.CreateDirectory(GlobalSettings.DefaultProfileDataPath);

            if (!File.Exists(GlobalSettings.AppData))
            {
                await File.WriteAllTextAsync(GlobalSettings.AppData, "{ \"DefaultProfileAtStart\" : \"Default\" }").ConfigureAwait(false);
            }

            if (!File.Exists(GlobalSettings.DefaultProfileDataFile))
            {
                await File.WriteAllTextAsync(GlobalSettings.DefaultProfileDataFile, "{\"CustomPaths\": [], \"Liked\" : [] }").ConfigureAwait(false);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error: " + ex.Message);
        }
    }

    public static void LoadAllProfiles()
    {
        try
        {
            GlobalSettings.Profiles.Clear();
            if (Directory.Exists(GlobalSettings.DataPath))
            {
                foreach (var directory in Directory.GetDirectories(GlobalSettings.DataPath).Select(Path.GetFileName))
                {
                    if (directory != null) GlobalSettings.Profiles.Add(directory);
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error: " + ex.Message);
        }
    }

        public static void GetDefaultProfile()
        {
            try
            {
                if (File.Exists(GlobalSettings.AppData))
                {
                    var appData = JObject.Parse(File.ReadAllText(GlobalSettings.AppData));
                    GlobalSettings.DefaultProfileAtStart = appData["DefaultProfileAtStart"]?.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


    public static async Task LoadProfile()
    {
        try
        {
            if (GlobalSettings.DefaultProfileAtStart == null) return;

            string profilePath = Path.Combine(GlobalSettings.DataPath, GlobalSettings.DefaultProfileAtStart, "profile.json");
            if (!File.Exists(profilePath)) return;

            var profileData = JObject.Parse(await File.ReadAllTextAsync(profilePath).ConfigureAwait(false));
            GlobalSettings.CustomPaths.Clear();

            if (profileData["CustomPaths"] is JArray paths)
            {
                foreach (var path in paths)
                {
                    GlobalSettings.CustomPaths.Add(path.ToString());
                }
            }

            await LoadAllSongs();
            GlobalSettings.Albums.Clear();

            foreach (var property in profileData.Properties())
            {
                if (property.Name != "CustomPaths" && property.Value is JArray songsPaths)
                {
                    var songList = new ObservableCollection<SongModel?>();
                    foreach (var songPath in songsPaths)
                    {
                        var song = GlobalSettings.AllSongs.FirstOrDefault(x => x?.Path == songPath.ToString());
                        if (song != null)
                        {
                            songList.Add(song);
                        }
                    }
                    GlobalSettings.Albums[property.Name] = songList;
                }
            }

            foreach (var song in GlobalSettings.AllSongs)
            {
                if (GlobalSettings.Albums["Liked"].Contains(song))
                {
                    if (song != null) song.Liked = true;
                }
            }

            Application.Current.Dispatcher.Invoke(LocalPlayerMainPage.LoadPlaylists);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error: " + ex.Message);
        }
    }

    private static async Task LoadAllSongs()
    {
        try
        {

            Application.Current.Dispatcher.Invoke(() => LocalPlayerMainPage.PlayingSong = null);
            Application.Current.Dispatcher.Invoke(() => GlobalSettings.AllSongs.Clear());
            var allPaths = new List<string> { GlobalSettings.MyMusicDataPath, GlobalSettings.CommonMusicDataPath };
            allPaths.AddRange(GlobalSettings.CustomPaths);

            await Task.Run(() =>
            {
                foreach (var path in allPaths)
                {
                    if (!Directory.Exists(path)) continue;

                    foreach (var file in Directory.GetFiles(path, "*.mp3", SearchOption.AllDirectories))
                    {
                        using var tagFile = TagLib.File.Create(file);
                        var song = new SongModel
                        {
                            Path = file,
                            Title = string.IsNullOrWhiteSpace(tagFile.Tag.Title) ? Path.GetFileNameWithoutExtension(file) : tagFile.Tag.Title,
                            Artist = tagFile.Tag.Performers?.FirstOrDefault() ?? "Unknown Artist",
                            Album = tagFile.Tag.Album ?? "Unknown Album",
                            Genre = tagFile.Tag.Genres?.FirstOrDefault() ?? "Unknown Genre",
                            Year = tagFile.Tag.Year > 0 ? tagFile.Tag.Year.ToString() : "Unknown Year",
                            Duration = tagFile.Properties.Duration.ToString(@"mm\:ss"),
                        };
                        Application.Current.Dispatcher.Invoke(() => GlobalSettings.AllSongs.Add(song));
                    }
                }
            }).ConfigureAwait(false);

            await LoadSongImage();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error: " + ex.Message);
        }
    }

    private static async Task LoadSongImage()
    {
        await Task.Run(() =>
        {
            foreach (var song in GlobalSettings.AllSongs)
            {
                try
                {
                    using var file = TagLib.File.Create(song?.Path);
                    BitmapImage? albumArt;

                    if (file.Tag.Pictures.Length > 0 && file.Tag.Pictures != null && file.Tag.Pictures[0].Data.Data.Length > 0 && file.Tag.Pictures[0].Data.Data != null && file.Tag.Pictures[0].Data.IsEmpty == false && file.Tag.Pictures[0].Data.IsReadOnly == false)
                    {
                        using var stream = new MemoryStream(file.Tag.Pictures[0].Data.Data);
                        albumArt = new BitmapImage();
                        albumArt.BeginInit();
                        albumArt.StreamSource = stream;
                        albumArt.CacheOption = BitmapCacheOption.OnLoad;
                        albumArt.EndInit();
                        albumArt.Freeze();
                    }
                    else
                    {
                        albumArt = new BitmapImage(new Uri("pack://application:,,,/Resources/Images/music-logo.jpg"));
                        albumArt.Freeze();
                    }

                    Application.Current.Dispatcher.Invoke(() => song!.AlbumArt = albumArt);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading album art for {song?.Path}: {ex}");
                }
                if (song?.AlbumArt == null)
                {
                    song!.AlbumArt = new BitmapImage(new Uri("pack://application:,,,/Resources/Images/music-logo.jpg"));
                    song.AlbumArt.Freeze();
                }
            }
        }).ConfigureAwait(false);
    }

    public static async Task SetDefaultProfileAtStart(string profile)
    {
        try
        {
            if (File.Exists(GlobalSettings.AppData))
            {
                var appData = JObject.Parse(await File.ReadAllTextAsync(GlobalSettings.AppData));
                appData["DefaultProfileAtStart"] = profile;

                await File.WriteAllTextAsync(GlobalSettings.AppData, appData.ToString(Newtonsoft.Json.Formatting.Indented));

                GlobalSettings.DefaultProfileAtStart = profile;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error: " + ex.Message);
        }
    }

    public static async Task AddProfile(string profile)
    {
        try
        {
            if(string.IsNullOrWhiteSpace(profile))return;
            var profilePath = Path.Combine(GlobalSettings.DataPath, profile);
            if(!Directory.Exists(profilePath))
            {
                Directory.CreateDirectory(profilePath);
                await File.WriteAllTextAsync(Path.Combine(profilePath, "profile.json"), "{\"CustomPaths\": [], \"Liked\" : [] }").ConfigureAwait(false);
            }
            GlobalSettings.Profiles.Add(profile);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error: " + ex.Message);
        }
    }

    public static async Task AddSongToAlbum(string? album, SongModel song)
{
    try
    {
        if (!GlobalSettings.Albums.ContainsKey(album))
        {
            GlobalSettings.Albums[album] = new ObservableCollection<SongModel?>();
        }

        if (!GlobalSettings.Albums[album].Contains(song))
        {
            GlobalSettings.Albums[album].Add(song);
            await SaveProfile();
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show("Error: " + ex.Message);
    }
}

    public static async Task RemoveSongFromAlbum(string? album, SongModel song)
    {
        try
        {
            if (GlobalSettings.Albums.ContainsKey(album) && GlobalSettings.Albums[album].Contains(song))
            {
                GlobalSettings.Albums[album].Remove(song);
                await SaveProfile();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error: " + ex.Message);
        }
    }

    public static async Task AddCustomPath(string path)
    {
        try
        {
            if (!GlobalSettings.CustomPaths.Contains(path) && Directory.Exists(path))
            {
                GlobalSettings.CustomPaths.Add(path);
                await SaveProfile();
                await LoadAllSongs();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error: " + ex.Message);
        }
    }

    public static async Task RemoveCustomPath(string path)
    {
        try
        {
            if (GlobalSettings.CustomPaths.Contains(path))
            {
                GlobalSettings.CustomPaths.Remove(path);
                await SaveProfile();
                await LoadAllSongs();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error: " + ex.Message);
        }
    }

    public static Task RemoveProfile(string profile)
    {
        try
        {
            if (GlobalSettings.Profiles.Contains(profile))
            {
                if (profile == GlobalSettings.DefaultProfileAtStart || profile == "Default") return Task.CompletedTask;

                var profilePath = Path.Combine(GlobalSettings.DataPath, profile);
                if (Directory.Exists(profilePath))
                {
                    Directory.Delete(profilePath, true);
                }

                GlobalSettings.Profiles.Remove(profile);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error: " + ex.Message);
        }

        return Task.CompletedTask;
    }

    public static async Task AddAlbum(string? albumName)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(albumName) || GlobalSettings.Albums.ContainsKey(albumName))
                return;

            GlobalSettings.Albums[albumName] = new ObservableCollection<SongModel?>();

            await SaveProfile();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error: " + ex.Message);
        }
    }

    public static async Task RemoveAlbum(string? albumName)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(albumName) || !GlobalSettings.Albums.ContainsKey(albumName))
                return;

            GlobalSettings.Albums.Remove(albumName);

            await SaveProfile();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error: " + ex.Message);
        }
    }

    private static async Task SaveProfile()
    {
        try
        {
            if (GlobalSettings.DefaultProfileAtStart == null) return;

            string profilePath = Path.Combine(GlobalSettings.DataPath, GlobalSettings.DefaultProfileAtStart, "profile.json");

            var profileData = new JObject
            {
                ["CustomPaths"] = new JArray(GlobalSettings.CustomPaths)
            };

            foreach (var album in GlobalSettings.Albums)
            {
                var songsArray = new JArray(album.Value.Select(song => song?.Path));
                if (album.Key != null) profileData[album.Key] = songsArray;
            }

            await File.WriteAllTextAsync(profilePath, profileData.ToString(Newtonsoft.Json.Formatting.Indented));
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error: " + ex.Message);
        }
    }
}
