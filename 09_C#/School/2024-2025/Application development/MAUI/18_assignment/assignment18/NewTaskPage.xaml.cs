using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment18;

public partial class NewTaskPage : ContentPage
{
    public NewTaskPage()
    {
        InitializeComponent();
    }

    private void Button_OnClicked(object? sender, EventArgs e)
    {
        var newTask = new Model.TaskItem
        {
            Title = titleEntry.Text,
            Description = descriptionEditor.Text,
            IsCompleted = false
        };
        Repository.TaskRepository.Tasks.Add(newTask);
        
        titleEntry.Text = string.Empty;
        descriptionEditor.Text = string.Empty;

        DisplayAlert("Success", "Task added successfully!", "OK");
    }
}