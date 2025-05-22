using System.Collections.ObjectModel;
using assignment18.Model;

namespace assignment18.Repository;

public static class TaskRepository
{
    public static TaskItemCollection Tasks { get; } = new();
    
}