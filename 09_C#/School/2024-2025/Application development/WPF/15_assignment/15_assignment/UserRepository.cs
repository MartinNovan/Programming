using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Data.SQLite;

namespace _15_assignment;

public class UserRepository
{
    private static string FilePath => "./users.db";
    private static SQLiteConnection connection = new SQLiteConnection($"Data Source={FilePath}");
    public async Task<bool> Login(string username, string password)
    {
        try
        {
            connection.Open();
            string sql = $"SELECT * FROM users WHERE Username = '{username}'";
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            SQLiteDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                string storedHash = reader.GetString(reader.GetOrdinal("Password"));
                if (VerifyPasswordHash(password, storedHash))
                {
                    sql = $"UPDATE users SET last_login = '{DateTime.Now}' WHERE Username = '{username}'";
                    command = new SQLiteCommand(sql, connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                    return true;
                }
                MessageBox.Show("Incorrect username or password!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                connection.Close();
                return false;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error while logging in: " + ex.Message, "Error", MessageBoxButton.OK);
            return false;
        }

        return false;
    }

    public async void Register(Models.User user)
    {
        try
        {
            connection.Open();
            string sql = $"INSERT INTO users (Username, Password, Email, CreatedAt) VALUES ('{user.Username}', '{GeneratePasswordHash(user.Password)}', '{user.Email}', '{DateTime.Now}')";
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("User registered successfully", "Success", MessageBoxButton.OK);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error while saving user: {ex.Message}", "Error", MessageBoxButton.OK);
        }
    }

    public static void CreateDatabeseFileIfNotExists()
    {
        if (!File.Exists(FilePath))
        {
            try
            {
                SQLiteConnection.CreateFile(FilePath);
                connection.Open();
                string sql = "CREATE TABLE users (Id INTEGER PRIMARY KEY, Username TEXT, Password TEXT, Email TEXT, CreatedAt TEXT , last_login TEXT)";
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("File with users created successfully", "Success", MessageBoxButton.OK);
                connection.Close();
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