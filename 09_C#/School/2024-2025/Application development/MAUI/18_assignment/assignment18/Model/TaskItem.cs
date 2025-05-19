using CommunityToolkit.Mvvm.ComponentModel;
namespace assignment18.Model;

public partial class TaskItem : ObservableObject
{
    [ObservableProperty]
    private string title;
    [ObservableProperty]
    private string description;
    [ObservableProperty]
    private bool isCompleted;
}