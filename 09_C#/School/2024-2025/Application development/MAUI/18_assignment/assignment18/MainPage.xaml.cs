using System.Collections.ObjectModel;
using System.Globalization;
using assignment18.Model;
using assignment18.Repository;

namespace assignment18;

public partial class MainPage : ContentPage
{
    public ObservableCollection<TaskItem> Tasks => TaskRepository.Tasks;
    public Command DeleteCommand { get; set; }
    public MainPage()
    {
        DeleteCommand = new Command(DeleteTask);
        InitializeComponent();
        BindingContext = this;
    }
    
    private void DeleteTask(object task)
    {
        Tasks.Remove(task as TaskItem);
    }
}

public class BoolToStatusConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if ((bool)value == true)
        {
            return "Hotovo";
        }
        return "Zbývá";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return ((string)value) == "Hotovo";
    }
}