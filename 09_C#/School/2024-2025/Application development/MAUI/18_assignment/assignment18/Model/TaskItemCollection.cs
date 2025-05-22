using System.Collections.ObjectModel;
using System.ComponentModel;
using SQLite;
using TodoApp;

namespace assignment18.Model;

public class TaskItemCollection : ObservableCollection<TaskItem>
{
    
    public TaskItemCollection()
    {
        foreach (var task in Database.GetTasks())
        {
            AddTask(task);
        }
    }

    public new void Add(TaskItem item)
    {
        Database.Add(item);
        base.Add(item);
    }
    
    public new bool Remove(TaskItem item)
    {
        Database.Delete(item);
        return base.Remove(item);
    }
    
    public static TaskItemDatabase _database;
    public static TaskItemDatabase Database
    {
        get
        {
            if (_database == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TaskItem.db3");
                _database = new TaskItemDatabase(dbPath);
            }  
            return _database;
        }
    }

    private void AddTask(TaskItem item)
    {
        if (!Contains(item))
        {
            item.PropertyChanged += (s, e) =>
            {
                Database.Add(item);
            };
        }
        Add(item);
    }
}