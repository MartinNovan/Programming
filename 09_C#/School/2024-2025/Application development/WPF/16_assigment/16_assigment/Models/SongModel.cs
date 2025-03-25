using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media.Imaging;

namespace _16_assigment.Models;

public class SongModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private void NotifyPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private readonly string? _title;
    public string? Title
    {
        get => _title;
        init
        {
            if (_title != value)
            {
                _title = value;
                NotifyPropertyChanged();
            }
        }
    }

    private readonly string? _artist;
    public string? Artist
    {
        get => _artist;
        init
        {
            if (_artist != value)
            {
                _artist = value;
                NotifyPropertyChanged();
            }
        }
    }

    private readonly string? _album;
    public string? Album
    {
        get => _album;
        init
        {
            if (_album != value)
            {
                _album = value;
                NotifyPropertyChanged();
            }
        }
    }

    private readonly string? _path;
    public string? Path
    {
        get => _path;
        init
        {
            if (_path != value)
            {
                _path = value;
                NotifyPropertyChanged();
            }
        }
    }

    private readonly string? _duration;
    public string? Duration
    {
        get => _duration;
        init
        {
            if (_duration != value)
            {
                _duration = value;
                NotifyPropertyChanged();
            }
        }
    }

    private string? _genre;
    public string? Genre
    {
        get => _genre;
        set
        {
            if (_genre != value)
            {
                _genre = value;
                NotifyPropertyChanged();
            }
        }
    }

    private string? _year;
    public string? Year
    {
        get => _year;
        set
        {
            if (_year != value)
            {
                _year = value;
                NotifyPropertyChanged();
            }
        }
    }

    private bool _liked;
    public bool Liked
    {
        get => _liked;
        set
        {
            if (_liked != value)
            {
                _liked = value;
                NotifyPropertyChanged();
            }
        }
    }

    private BitmapImage? _albumArt;
    public BitmapImage? AlbumArt
    {
        get => _albumArt;
        set
        {
            if (_albumArt != value)
            {
                _albumArt = value;
                NotifyPropertyChanged();
            }
        }
    }
}
