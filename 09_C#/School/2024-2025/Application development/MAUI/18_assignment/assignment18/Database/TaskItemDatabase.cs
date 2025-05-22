using assignment18.Model;
using SQLite;

namespace TodoApp;
public class TaskItemDatabase
{
    readonly SQLiteConnection _database;

    public TaskItemDatabase(string dbPath)
    {
        _database = new SQLiteConnection(dbPath);
        _database.CreateTable<TaskItem>();
    }
    
    public List<TaskItem> GetTasks()
    {
        return _database.Table<TaskItem>().ToList();
    }

    public int Add(TaskItem task)
    {
        if (task.Id == 0)
        {
            return _database.Insert(task);
        }
        else
        {
            return _database.Update(task);
        }
    }
    
    public int Delete(TaskItem task)
    {
        return _database.Delete(task);
    }
    
    public int ClearTasks()
    {
        return _database.DeleteAll<TaskItem>();
    }
}