using System.Collections.ObjectModel;
using System.IO;
using _16_assignment.Models;

namespace _16_assignment;

public static class GlobalSettings
{
    public static readonly string DataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MartinNovan", "MusicPlayer");
    public static readonly string AppData = Path.Combine(DataPath, "settings.json");

    public static readonly string MyMusicDataPath = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
    public static readonly string CommonMusicDataPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonMusic);

    public static readonly string DefaultProfileDataPath = Path.Combine(DataPath, "Default");
    public static readonly string DefaultProfileDataFile = Path.Combine(DefaultProfileDataPath, "profile.json");

    public static string? DefaultProfileAtStart = "Default";

    public static List<string> Profiles { get; } = new();

    public static List<string> CustomPaths { get; } = new();

    public static ObservableCollection<SongModel?> AllSongs { get; } = new();
    public static Dictionary<string, ObservableCollection<SongModel?>> Albums { get; } = new();

}