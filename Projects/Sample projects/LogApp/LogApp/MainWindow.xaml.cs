using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Windows;

namespace LogApp
{
    public partial class MainWindow
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
                MessageBox.Show($"Error while loading logs: {ex.Message}", "Error", MessageBoxButton.OK);
            }
        }

        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(NameBox.Text))
                {
                    MessageBox.Show("Name must be filled", "Error", MessageBoxButton.OK);
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
                MessageBox.Show($"Error while saving log: {ex.Message}", "Error", MessageBoxButton.OK);
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
                    MessageBox.Show("File with connections created successfully", "Success", MessageBoxButton.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error while creating file with connections: {ex.Message}", "Error", MessageBoxButton.OK);
                }
            }
        }
    }
}
