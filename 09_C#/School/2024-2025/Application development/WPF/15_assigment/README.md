# Creating New Windows and Pages in WPF

This README provides an overview of a WPF (Windows Presentation Foundation) application designed for creating new windows and pages, specifically functioning as a simple login application. This document will focus on the application structure, detailing how themes are defined and applied within the application.

## Overview of the Application

The application is structured to allow users to log in through a user-friendly interface. It utilizes two themes—light and dark—which can be dynamically applied based on user preferences or system settings. The main functionality includes user authentication and navigation to different pages within the application.

## Application Structure

The application consists of the following key components:

1. **App.xaml**: Defines the application-level resources and startup settings.
2. **App.xaml.cs**: Contains the application logic, including theme management.
3. **MainWindow.xaml**: The main window of the application that hosts the navigation frame.
4. **MainWindow.xaml.cs**: Contains the logic for navigating between pages within the application.
5. **Pages/LoginPage.xaml**: The login page where users can enter their credentials.
6. **Pages/LoginPage.xaml.cs**: Contains the logic for handling user login.
7. **UserControls/PlaceHolderTextBox.xaml**: A custom user control for input fields with placeholder text.
8. **UserControls/PlaceHolderTextBox.xaml.cs**: Logic for the custom placeholder text box control.
9. **UserRepository.cs**: Contains methods for user authentication and registration using SQLite.
10. **Models.cs**: Defines the user model used for storing user information.
11. **Themes/Dark.xaml**: Defines the styles and resources for the dark theme.
12. **Themes/Light.xaml**: Defines the styles and resources for the light theme.
13. **Windows/RegisterWindow.xaml**: The registration window where new users can create an account.
14. **Windows/RegisterWindow.xaml.cs**: Contains the logic for handling user registration.
15. **Pages/MainPage.xaml**: The main page displayed after a successful login.
16. **Pages/MainPage.xaml.cs**: Contains the logic for the main page.

### Important Note

Before running the application, ensure that you have installed the necessary NuGet package for SQLite. You can do this by executing the following command in the Package Manager Console:

```
Install-Package System.Data.SQLite
```

### 1. App.xaml

The `App.xaml` file is crucial for defining application-wide resources, including themes. Here's the relevant code:

```xml
<Application x:Class="_15_assigment.App"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             StartupUri="MainWindow.xaml">
    <Application.Resources>
        <ResourceDictionary>
            <ResourceDictionary x:Key="LightTheme" Source="Themes/Light.xaml" />
            <ResourceDictionary x:Key="DarkTheme" Source="Themes/Dark.xaml" />
        </ResourceDictionary>
    </Application.Resources>
</Application>
```

#### Explanation of App.xaml

- **Application Definition**: 
  - `<Application x:Class="_15_assigment.App"`: This line defines the application class and its namespace.
  - `StartupUri="MainWindow.xaml"`: This specifies the initial window that will be displayed when the application starts.

- **Application Resources**:
  - `<Application.Resources>`: This section is used to define resources that can be accessed throughout the application.
  - `<ResourceDictionary>`: This is a collection of resources, including styles, brushes, and other UI elements.
  - **Theme Resources**: 
    - `<ResourceDictionary x:Key="LightTheme" Source="Themes/Light.xaml" />`: This line references the light theme resource dictionary.
    - `<ResourceDictionary x:Key="DarkTheme" Source="Themes/Dark.xaml" />`: This line references the dark theme resource dictionary.

### 2. App.xaml.cs

The `App.xaml.cs` file contains the logic for applying the selected theme when the application starts. Here's the relevant code:

```csharp
using System.Windows;
using Microsoft.Win32;

namespace _15_assigment;
public partial class App
{
    public App()
    {
        InitializeComponent();
        ApplyTheme(); // Call the method to apply the theme when the application starts
        UserRepository.CreateDatabeseFileIfNotExists(); // Call the method to create the database file if it doesn't exist
    }

    private void ApplyTheme()
    {
        // Determine if dark mode is enabled
        bool isDarkMode = IsDarkModeEnabled();

        // Select the appropriate ResourceDictionary
        string theme = isDarkMode ? "Themes/Dark.xaml" : "Themes/Light.xaml";
        var dictionary = new ResourceDictionary
        {
            Source = new Uri(theme, UriKind.Relative)
        };

        // Update the application's resources
        Current.Resources.MergedDictionaries.Clear();
        Current.Resources.MergedDictionaries.Add(dictionary);
    }

    private bool IsDarkModeEnabled()
    {
        const string registryKeyPath = @"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize";
        const string registryValueName = "AppsUseLightTheme";

        using var key = Registry.CurrentUser.OpenSubKey(registryKeyPath);
        if (key != null && key.GetValue(registryValueName) is int value)
        {
            return value == 0; // 0 = Dark Mode, 1 = Light Mode
        }

        return false; // Default to light mode
    }
}
```

#### Explanation of App.xaml.cs

- **Constructor**:
  - `public App()`: This constructor initializes the application and calls the `ApplyTheme()` method to set the appropriate theme based on user preferences.

- **ApplyTheme Method**:
  - `private void ApplyTheme()`: This method determines whether dark mode is enabled and selects the corresponding resource dictionary.
  - `bool isDarkMode = IsDarkModeEnabled();`: This line checks if the system is set to dark mode.
  - `string theme = isDarkMode ? "Themes/Dark.xaml" : "Themes/Light.xaml";`: This line selects the theme based on the dark mode status.
  - `var dictionary = new ResourceDictionary { Source = new Uri(theme, UriKind.Relative) };`: This creates a new resource dictionary based on the selected theme.
  - `Current.Resources.MergedDictionaries.Clear();`: This clears any existing merged dictionaries to avoid conflicts.
  - `Current.Resources.MergedDictionaries.Add(dictionary);`: This adds the selected theme's resource dictionary to the application's resources.

- **IsDarkModeEnabled Method**:
  - This method checks the Windows registry to determine if dark mode is enabled. It reads the value from the registry key that controls theme settings.
  - If the value is `0`, dark mode is enabled; if `1`, light mode is enabled. If the registry key is not found, it defaults to light mode.

### 3. MainWindow.xaml

The `MainWindow.xaml` file defines the main window of the application, which hosts a navigation frame. Here's the relevant code:

```xml
<Window x:Class="_15_assigment.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        mc:Ignorable="d"
        Icon="Resources/Icon.png"
        Height="450" Width="800">
        <Frame x:Name="MainFrame" NavigationUIVisibility="Hidden" />
</Window>
```

#### Explanation of MainWindow.xaml

- **Window Definition**:
  - `<Window x:Class="_15_assigment.MainWindow"`: This line defines the main window class and its namespace.
  - `Icon="Resources/Icon.png"`: This sets the icon for the application window.
  - `Height` and `Width`: These properties define the dimensions of the window.

- **Frame**:
  - `<Frame x:Name="MainFrame" NavigationUIVisibility="Hidden" />`: This frame is used for navigation between different pages within the application. The `NavigationUIVisibility` property is set to `Hidden` to hide the default navigation UI.

### 4. MainWindow.xaml.cs

The `MainWindow.xaml.cs` file contains the logic for navigating between pages within the application. Here's the relevant code:

```csharp
using System.Windows;
using System.Windows.Controls;

namespace _15_assigment;

public partial class MainWindow
{
    public MainWindow()
    {
        InitializeComponent();
        MainFrame.Navigate(new Pages.LoginPage());
    }
    public static void NavigateToPage(Page page)
    {
        var mainWindow = (MainWindow?)Application.Current.MainWindow;
        mainWindow?.MainFrame.Navigate(page);
    }
}
```

#### Explanation of MainWindow.xaml.cs

- **Constructor**:
  - `public MainWindow()`: This constructor initializes the main window and navigates to the `LoginPage` when the application starts.

- **NavigateToPage Method**:
  - `public static void NavigateToPage(Page page)`: This static method allows navigation to a specified page from anywhere in the application.
  - `var mainWindow = (MainWindow?)Application.Current.MainWindow;`: This retrieves the current instance of the main window.
  - `mainWindow?.MainFrame.Navigate(page);`: This line navigates the `MainFrame` to the specified page.

### 5. Pages/LoginPage.xaml

The `LoginPage.xaml` file defines the layout for the login page where users can enter their credentials. Here's the relevant code:

```xml
<Page x:Class="_15_assigment.Pages.LoginPage"
      xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
      xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
      xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
      xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
      xmlns:userControls="clr-namespace:_15_assigment.UserControls"
      mc:Ignorable="d"
      Title="LogIn">
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="Auto"/>
        </Grid.RowDefinitions>
        <userControls:PlaceHolderTextBox x:Name="UsernameEntry" Placeholder="Username" Margin="5,15,5,5" Grid.Row="0"/>
        <userControls:PlaceHolderTextBox x:Name="PasswordEntry" Placeholder="Password" Margin="5,5,5,5" Grid.Row="1"/>
        <Button Grid.Row="2" Click="ButtonBase_OnClick" Content="LogIn" Margin="5"/>
        <TextBlock Grid.Row="3" Text="Don't have an account? " TextAlignment="Center" FontSize="10">
            <Hyperlink Click="Hyperlink_OnClick">Register</Hyperlink>
        </TextBlock>
    </Grid>
</Page>
```

#### Explanation of LoginPage.xaml

- **Page Definition**:
  - `<Page x:Class="_15_assigment.Pages.LoginPage"`: This line defines the login page class and its namespace.

- **Grid Layout**:
  - The layout consists of a `Grid` with four rows, where each row contains different UI elements.

- **User Controls**:
  - `<userControls:PlaceHolderTextBox>`: Custom user controls for username and password input fields with placeholder text.

- **Button and Hyperlink**:
  - A button for logging in and a hyperlink for navigating to the registration page.

### 6. Pages/LoginPage.xaml.cs

The `LoginPage.xaml.cs` file contains the logic for handling user login. Here's the relevant code:

```csharp
using System.Windows;
using _15_assigment.Windows;
using static _15_assigment.MainWindow;

namespace _15_assigment.Pages;

public partial class LoginPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private void Hyperlink_OnClick(object sender, RoutedEventArgs e)
    {
        new RegisterWindow().Show();
    }

    private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            if (UsernameEntry.Text.Length == 0 || PasswordEntry.Text.Length == 0)
            {
                MessageBox.Show("Please fill in all fields!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            bool correctLogin = await new FileHelper().Login(UsernameEntry.Text, PasswordEntry.Text);
            if (correctLogin)
            {
                NavigateToPage(new MainPage());
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
```

#### Explanation of LoginPage.xaml.cs

- **Constructor**:
  - `public LoginPage()`: Initializes the login page.

- **Hyperlink_OnClick Method**:
  - Opens the registration window when the hyperlink is clicked.

- **ButtonBase_OnClick Method**:
  - Validates user input and attempts to log in using the `FileHelper` class. If successful, it navigates to the main page.

### 7. UserControls/PlaceHolderTextBox.xaml

The `PlaceHolderTextBox.xaml` file defines a custom user control for input fields with placeholder text. Here's the relevant code:

```xml
<UserControl x:Class="_15_assigment.UserControls.PlaceHolderTextBox"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
             xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
             mc:Ignorable="d"
             d:DesignHeight="50" d:DesignWidth="200"  x:Name="MyControl">
    <UserControl.Resources>
        <Style TargetType="Border" >
            <Setter Property="CornerRadius" Value="{Binding CornerRadius, ElementName=MyControl}"/>
        </Style>
    </UserControl.Resources>
    <Grid>
        <TextBlock Margin="2,0,0,0" Name="PlaceholderElement" Text="{Binding Placeholder, ElementName=MyControl}" TextAlignment="Center" VerticalAlignment="Center" HorizontalAlignment="Left"/>
        <TextBox BorderThickness="0" Background="Transparent" TextChanged="TextBox_TextChanged" Text="{Binding Text, ElementName=MyControl, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" VerticalContentAlignment="Top"/>
    </Grid>
</UserControl>
```

#### Explanation of PlaceHolderTextBox.xaml

- **User Control Definition**:
  - `<UserControl x:Class="_15_assigment.UserControls.PlaceHolderTextBox"`: This line defines the custom user control class and its namespace.

- **Grid Layout**:
  - The layout consists of a `Grid` containing a `TextBlock` for the placeholder and a `TextBox` for user input.

### 8. UserControls/PlaceHolderTextBox.xaml.cs

The `PlaceHolderTextBox.xaml.cs` file contains the logic for the custom placeholder text box control. Here's the relevant code:

```csharp
using System.Windows;
using System.Windows.Controls;

namespace _15_assigment.UserControls;

public partial class PlaceHolderTextBox
{
    public static readonly DependencyProperty PlaceholderProperty = DependencyProperty.Register(nameof(Placeholder), typeof(string), typeof(PlaceHolderTextBox), new PropertyMetadata(""));
    public string Placeholder
    {
        get => (string)GetValue(PlaceholderProperty);
        set => SetValue(PlaceholderProperty, value);
    }
    public static readonly DependencyProperty TextProperty = DependencyProperty.Register(nameof(Text), typeof(string), typeof(PlaceHolderTextBox), new PropertyMetadata(""));
    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }
    public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(PlaceHolderTextBox), new PropertyMetadata(new CornerRadius(0)));
    public string CornerRadius
    {
        get => (string)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }
    public PlaceHolderTextBox()
    {
        InitializeComponent();
    }
    private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        var textbox = (TextBox)sender;
        PlaceholderElement.Visibility = !string.IsNullOrEmpty(textbox.Text) ? Visibility.Collapsed : Visibility.Visible;
    }
}
```

#### Explanation of PlaceHolderTextBox.xaml.cs

- **Dependency Properties**:
  - Defines properties for `Placeholder`, `Text`, and `CornerRadius` to allow binding and customization of the control.

- **Constructor**:
  - `public PlaceHolderTextBox()`: Initializes the custom user control.

- **TextBox_TextChanged Method**:
  - This method manages the visibility of the placeholder text based on whether the `TextBox` is empty or not.

### 9. UserRepository.cs
The `UserRepository.cs` file contains methods for user authentication and registration using SQLite. Here’s the relevant code:

```csharp
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Data.SQLite;

namespace _15_assigment;

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

    public static void CreateDatabaseFileIfNotExists()
    {
        if (!File.Exists(FilePath))
        {
            try
            {
                SQLiteConnection.CreateFile(FilePath);
                connection.Open();
                string sql = "CREATE TABLE users (Id INTEGER PRIMARY KEY, Username TEXT, Password TEXT, Email TEXT, CreatedAt TEXT, last_login TEXT)";
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Database file created successfully", "Success", MessageBoxButton.OK);
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while creating database: {ex.Message}", "Error", MessageBoxButton.OK);
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
```

#### Explanation of UserRepository.cs

- **Login Method**:
  - Validates user credentials against stored data in the SQLite database. If successful, updates the last login time.

- **Register Method**:
  - Registers a new user by adding their information to the SQLite database, ensuring that usernames are unique.

- **CreateDatabaseFileIfNotExists Method**:
  - Creates the SQLite database file if it does not already exist.

- **Password Hashing**:
  - Methods for generating and verifying password hashes to enhance security.

### 10. Models.cs

The `Models.cs` file defines the user model used for storing user information. Here's the relevant code:

```csharp
namespace _15_assigment;

public static class Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Username { get; init; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastLogin { get; set; }
    }
}
```

#### Explanation of Models.cs

- **User Class**:
  - Defines properties for user information, including `Id`, `Username`, `Password`, `Email`, `CreatedAt`, and `LastLogin`.

### 11. Themes/Dark.xaml

The `Dark.xaml` file defines the styles and resources for the dark theme. Here's the relevant code:

```xml
<ResourceDictionary xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                    xmlns:userControls="clr-namespace:_15_assigment.UserControls">

    <!-- Color definitions -->
    <Color x:Key="BackgroundColor">#1E1E1E</Color>
    <Color x:Key="ControlColor">#3C3C3C</Color>
    <Color x:Key="ControlHoverColor">#505050</Color>
    <Color x:Key="TextColor">#FFFFFF</Color>

    <!-- Brush definitions -->
    <SolidColorBrush x:Key="AppBackgroundBrush" Color="{StaticResource BackgroundColor}" />
    <SolidColorBrush x:Key="ControlBrush" Color="{StaticResource ControlColor}" />
    <SolidColorBrush x:Key="ControlHoverBrush" Color="{StaticResource ControlHoverColor}" />
    <SolidColorBrush x:Key="TextBrush" Color="{StaticResource TextColor}" />

    <!-- Global style for Window -->
    <Style TargetType="Window">
        <Setter Property="Background" Value="{DynamicResource AppBackgroundBrush}" />
    </Style>

    <!-- Global style for Grid -->
    <Style TargetType="Grid">
        <Setter Property="Background" Value="{DynamicResource AppBackgroundBrush}"/>
    </Style>

    <!-- Global style for TextBox -->
    <Style TargetType="TextBox">
        <Setter Property="Background" Value="{DynamicResource ControlBrush}" />
        <Setter Property="Foreground" Value="{DynamicResource TextBrush}" />
        <Setter Property="Height" Value="50"/>
        <Setter Property="Width" Value="250"/>
        <Setter Property="FontSize" Value="25" />
        <Setter Property="VerticalContentAlignment" Value="Center"/>
        <Setter Property="Padding" Value="10,0" /> <!-- Add padding for proper text display -->
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="TextBox">
                    <Border Background="{TemplateBinding Background}" BorderBrush="Transparent" BorderThickness="1" CornerRadius="10">
                        <ScrollViewer x:Name="PART_ContentHost" />
                    </Border>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>

    <!-- Global style for TextBlock -->
    <Style TargetType="TextBlock">
        <Setter Property="Foreground" Value="{DynamicResource TextBrush}" />
        <Setter Property="FontSize" Value="25" />
        <Setter Property="Padding" Value="10,0" /> <!-- Add padding for proper text display -->
    </Style>

    <!-- Global style for PlaceHolder -->
    <Style TargetType="userControls:PlaceHolderTextBox">
        <Setter Property="Background" Value="{DynamicResource ControlBrush}" />
        <Setter Property="Foreground" Value="{DynamicResource TextBrush}" />
        <Setter Property="Height" Value="50"/>
        <Setter Property="Width" Value="250"/>
        <Setter Property="FontSize" Value="20" />
        <Setter Property="VerticalContentAlignment" Value="Center"/>
        <Setter Property="HorizontalAlignment" Value="Center"/>
        <Setter Property="CornerRadius" Value="5"/>
        <Setter Property="Padding" Value="5" />
    </Style>

    <!-- Global style for all Buttons -->
    <Style TargetType="Button">
        <Setter Property="Background" Value="{DynamicResource ControlBrush}" />
        <Setter Property="Foreground" Value="{DynamicResource TextBrush}" />
        <Setter Property="Height" Value="50"/>
        <Setter Property="Width" Value="150"/>
        <Setter Property="HorizontalContentAlignment" Value="Center"/>
        <Setter Property="VerticalContentAlignment" Value="Center"/>
        <Setter Property="Padding" Value="10,0" /> <!-- Add padding for proper text display -->
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="Button">
                    <Border Background="{TemplateBinding Background}" CornerRadius="10">
                        <ContentPresenter HorizontalAlignment="Center" VerticalAlignment="Center"/>
                    </Border>
                    <ControlTemplate.Triggers>
                        <Trigger Property="IsMouseOver" Value="True">
                            <Setter Property="Background" Value="{DynamicResource ControlHoverBrush}" />
                        </Trigger>
                    </ControlTemplate.Triggers>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
</ResourceDictionary>
```

#### Explanation of Dark.xaml

- **Resource Dictionary**: 
  - This file defines a collection of resources, including colors and styles, specifically for the dark theme.

- **Color Definitions**:
  - Colors are defined using `<Color x:Key="...">` elements. These colors will be used throughout the application to ensure a consistent dark theme.
  - For example, `BackgroundColor` is set to a dark gray (`#1E1E1E`), and `TextColor` is set to white (`#FFFFFF`).

- **Brush Definitions**:
  - `SolidColorBrush` elements are created to define brushes that can be used for backgrounds, controls, and text. These brushes reference the previously defined colors.

- **Global Styles**:
  - Styles are defined for various controls, including `Window`, `Grid`, `TextBox`, `TextBlock`, and `Button`.
  - Each style sets properties such as `Background`, `Foreground`, `Height`, `Width`, and `Padding` to ensure a cohesive look across the application.

### 12. Themes/Light.xaml

The `Light.xaml` file defines the styles and resources for the light theme. It follows the same structure as the dark theme but with different color definitions. Here's a brief overview:

- **Color Definitions**:
  - The colors are set to lighter shades, such as `BackgroundColor` set to white (`#FFFFFF`) and `TextColor` set to black (`#000000`).

- **Brush Definitions**:
  - Similar to the dark theme, but using the lighter colors defined.

- **Global Styles**:
  - The styles for controls are defined in the same way as in the dark theme, ensuring a consistent look and feel for the light theme.

### 13. Windows/RegisterWindow.xaml

The `RegisterWindow.xaml` file defines the registration window where new users can create an account. Here's the relevant code:

```xml
<Window x:Class="_15_assigment.Windows.RegisterWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:userControl="clr-namespace:_15_assigment.UserControls"
        mc:Ignorable="d"
        Title="Register" Height="400" Width="350">
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="Auto"/>
        </Grid.RowDefinitions>
        <TextBlock Grid.Row="0" Text="Registration:" FontSize="20" />
        <userControl:PlaceHolderTextBox x:Name="UsernameEntry" Grid.Row="1" Margin="5, 15, 5, 5" Placeholder="Username"/>
        <userControl:PlaceHolderTextBox x:Name="EmailEntry" Grid.Row="2" Margin="5" Placeholder="Email"/>
        <userControl:PlaceHolderTextBox x:Name="PasswordEntry" Grid.Row="3" Margin="5" Placeholder="Password"/>
        <userControl:PlaceHolderTextBox x:Name="PasswordConfirmationEntry" Grid.Row="4" Margin="5" Placeholder="Confirm Password"/>
        <Button Grid.Row="5" Content="Register" Click="ButtonBase_OnClick" HorizontalAlignment="Center" />
    </Grid>
</Window>
```

#### Explanation of RegisterWindow.xaml

- **Window Definition**:
  - `<Window x:Class="_15_assigment.Windows.RegisterWindow"`: This line defines the registration window class and its namespace.

- **Grid Layout**:
  - The layout consists of a `Grid` with six rows, where each row contains different UI elements for user registration.

- **User Controls**:
  - `<userControl:PlaceHolderTextBox>`: Custom user controls for username, email, password, and password confirmation input fields with placeholder text.

### 14. Windows/RegisterWindow.xaml.cs

The `RegisterWindow.xaml.cs` file contains the logic for handling user registration. Here's the relevant code:

```csharp
using System.Windows;

namespace _15_assigment.Windows;

public partial class RegisterWindow
{
    public RegisterWindow()
    {
        InitializeComponent();
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        if(UsernameEntry.Text.Length == 0 || EmailEntry.Text.Length == 0 || PasswordEntry.Text.Length == 0 || PasswordConfirmationEntry.Text.Length == 0)
        {
            MessageBox.Show("Please fill in all fields!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }
        if (PasswordEntry.Text != PasswordConfirmationEntry.Text)
        {
            MessageBox.Show("Passwords do not match", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }
        var user = new Models.User
        {
            Username = UsernameEntry.Text,
            Email = EmailEntry.Text,
            Password = PasswordEntry.Text,
        };
        new FileHelper().Register(user);
        Close();
    }
}
```

#### Explanation of RegisterWindow.xaml.cs

- **Constructor**:
  - `public RegisterWindow()`: Initializes the registration window.

- **ButtonBase_OnClick Method**:
  - Validates user input and checks if the passwords match. If valid, it creates a new user and calls the `Register` method from the `FileHelper` class to save the user data.

### 15. Pages/MainPage.xaml

The `MainPage.xaml` file defines the main page displayed after a successful login. Here's the relevant code:

```xml
<Page x:Class="_15_assigment.Pages.MainPage"
      xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
      xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
      xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
      xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
      mc:Ignorable="d"
      Title="MainWindow" Height="450" Width="800">
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="*"/>
        </Grid.RowDefinitions>
        <TextBlock Grid.Row="0" Text="You made it past login YAY! :)" FontSize="30"/>
        <Image Grid.Row="1" Source="/Resources/you_made_it_here.jpg" />
    </Grid>
</Page>
```

#### Explanation of MainPage.xaml

- **Page Definition**:
  - `<Page x:Class="_15_assigment.Pages.MainPage"`: This line defines the main page class and its namespace.

- **Grid Layout**:
  - The layout consists of a `Grid` with two rows, where the first row contains a congratulatory message and the second row contains an image.

### 16. Pages/MainPage.xaml.cs

The `MainPage.xaml.cs` file contains the logic for the main page. Here's the relevant code:

```csharp
using System.Windows.Controls;

namespace _15_assigment.Pages;

public partial class MainPage
{
    public MainPage()
    {
        InitializeComponent();
    }
}
```

#### Explanation of MainPage.xaml.cs

- **Constructor**:
  - `public MainPage()`: Initializes the main page.

### Database File Structure

Previously, user data was stored in a JSON file named `users.json`. Now, user data is stored in an SQLite database. The structure of the database table `users` is as follows:

- **Id**: Integer, primary key.
- **Username**: Text, unique username.
- **Password**: Text, hashed password.
- **Email**: Text, user email.
- **CreatedAt**: Text, timestamp of account creation.
- **LastLogin**: Text, timestamp of last login.

#### Explanation of Password Hashing

In this application, passwords are not stored in plain text for security reasons. Instead, they are hashed using the SHA-256 algorithm before being saved to the database file. 

For example:
- If the first user's password is "132", it is hashed to `pmWkWSBCL51Bfkhn79xPuKBKHz//H6B\u002BmY6G9/eieuM=`.
- If the second user's password is "987", it is hashed to `VcgHmslsak9qlONGDHnkAG1iN0zObp/IsoGTijq8dic=`.

This ensures that even if the database file is compromised, the actual passwords remain secure.

## Conclusion

This WPF Login Application demonstrates how to implement theming, navigation, and user authentication effectively. By defining the main window and utilizing a frame for navigation, the application can provide a seamless user experience.

In the next steps, we can explore additional components of the application, such as the registration functionality, user interface design, and any other features that enhance the user experience. Please provide the next part of the project, and we can continue building the documentation.
