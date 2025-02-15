using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Interactivity;
using MsBox.Avalonia;

namespace LogApp_Avalonia;

public partial class MainWindow : Window
{
    private string FilePath { get; set; } = "./log.json";
        public class Log
        {
            public string? Name { get; set; }
            public string? Message { get; set; }
            public string? Date { get; set; } = DateTime.Now.ToString("yyyy-MM-dd");
            public string? Time { get; set; } = DateTime.Now.ToString("HH:mm:ss");
        }

        public ObservableCollection<Log>? Logs { get; set; } = new();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            CreateJsonFileIfNotExists();
            _ = LoadLogs();

        }

        private async Task LoadLogs()
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    string json = await File.ReadAllTextAsync(FilePath);
                    if (!string.IsNullOrEmpty(json))
                    {
                        var logs = JsonSerializer.Deserialize<List<Log>>(json) ?? new();
                        Logs!.Clear();
                        logs.ForEach(Logs.Add);
                    }
                    Counter.Text = $"Total: {Logs!.Count}";
                }
            }
            catch (Exception ex)
            {
                await MessageBoxManager.GetMessageBoxStandard("Error", $"Error while loading logs: {ex.Message}").ShowAsync();
            }
        }
        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(NameBox.Text))
                {
                    await MessageBoxManager.GetMessageBoxStandard("Error", "Name must be filled").ShowAsync();
                    return;
                }
                var log = new Log
                {
                    Name = NameBox.Text,
                    Message = NoteBox.Text
                };
                Logs!.Add(log);
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(Logs, options);
                await File.WriteAllTextAsync(FilePath, jsonString);
                await LoadLogs();
                NameBox.Clear();
                NoteBox.Clear();
            }
            catch (Exception ex)
            {
                await MessageBoxManager.GetMessageBoxStandard("Error", $"Error while saving log: {ex.Message}").ShowAsync();
            }
        }
        private void CreateJsonFileIfNotExists()
        {
            if (!File.Exists(FilePath))
            {
                try
                {
                    var emptyLogs = new List<Log>();
                    string emptyJson = JsonSerializer.Serialize(emptyLogs,
                        new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(FilePath, emptyJson);
                    MessageBoxManager.GetMessageBoxStandard("Success", "File for logs created successfully").ShowAsync();
                }
                catch (Exception ex)
                {
                    MessageBoxManager.GetMessageBoxStandard("Error", $"Error while creating file with connections: {ex.Message}").ShowAsync();
                }
            }
        }
}