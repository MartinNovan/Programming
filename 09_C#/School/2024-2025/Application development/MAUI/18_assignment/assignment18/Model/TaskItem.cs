using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;

namespace assignment18.Model;

public partial class TaskItem : ObservableObject
{
    [PrimaryKey, AutoIncrement] public int Id { get; set; }
    [ObservableProperty]
    private string title;
    [ObservableProperty]
    private string description;
    [ObservableProperty]
    private bool isCompleted;
}