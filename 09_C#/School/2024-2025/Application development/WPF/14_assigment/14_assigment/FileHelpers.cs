using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Windows;

namespace _14_assigment;

public class FileHelper
{
    private static string FilePath => "./users.json";

    public async Task<bool> Login(string username, string password)
    {
        CreateJsonFileIfNotExists();
        var users = new List<Models.User>();
        try
        {
            if (File.Exists(FilePath))
            {
                string json = await File.ReadAllTextAsync(FilePath);
                if (!string.IsNullOrEmpty(json))
                {
                    users = JsonSerializer.Deserialize<List<Models.User>>(json) ?? new();
                }
            }
            var user = users.FirstOrDefault(u => u.Username == username);
            if (user is { Password: not null } && VerifyPasswordHash(password, user.Password))
            {
                user.LastLogin = DateTime.Now;
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(users, options);
                await File.WriteAllTextAsync(FilePath, jsonString);
                return true;
            }

            MessageBox.Show("Incorrect username or password!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error while logging in: {ex.Message}", "Error", MessageBoxButton.OK);
            return false;
        }
    }

    public async void Register(Models.User user)
    {
        try
        {
            CreateJsonFileIfNotExists();
            var users = new List<Models.User>();
            if (File.Exists(FilePath))
            {
                string json = await File.ReadAllTextAsync(FilePath);
                if (!string.IsNullOrEmpty(json))
                {
                    users = JsonSerializer.Deserialize<List<Models.User>>(json) ?? new();
                }
            }

            if (users.Any(u => u.Username == user.Username))
            {
                MessageBox.Show("Username already exists!", "Error", MessageBoxButton.OK);
                return;
            }
            if (user.Password != null) user.Password = GeneratePasswordHash(user.Password);
            user.Id = users.Count + 1;
            user.CreatedAt = DateTime.Now;
            users.Add(user);

            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(users, options);
            await File.WriteAllTextAsync(FilePath, jsonString);
            MessageBox.Show("User registered successfully", "Success", MessageBoxButton.OK);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error while saving user: {ex.Message}", "Error", MessageBoxButton.OK);
        }
    }

    private void CreateJsonFileIfNotExists()
    {
        if (!File.Exists(FilePath))
        {
            try
            {
                var emptyUsers = new List<Models.User>();
                string emptyJson = JsonSerializer.Serialize(emptyUsers,
                    new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(FilePath, emptyJson);
                MessageBox.Show("File with users created successfully", "Success", MessageBoxButton.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while creating file with connections: {ex.Message}", "Error", MessageBoxButton.OK);
            }
        }
    }

    private string GeneratePasswordHash(string password)
    {
        using var sha256 = SHA256.Create();
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
        byte[] hashBytes = sha256.ComputeHash(passwordBytes);
        return Convert.ToBase64String(hashBytes);
    }

    private bool VerifyPasswordHash(string password, string storedHash)
    {
        string hashOfInput = GeneratePasswordHash(password);
        return hashOfInput == storedHash;
    }
}