# .NET MAUI Navigation and Shell Example

## Introduction
This project demonstrates the basics of navigation and Shell in .NET MAUI (Multi-platform App UI). The application consists of two pages: `MainPage` and `SecondaryPage`, which allow users to navigate between them using the Shell navigation system.

## Differences Between WPF and .NET MAUI

### 1. **Platform Support**
- **WPF**: Windows-only framework for building desktop applications.
- **.NET MAUI**: Cross-platform framework for building applications that run on Android, iOS, macOS, and Windows.

### 2. **UI Framework**
- **WPF**: Uses XAML for UI design and C# for logic, but is limited to Windows.
- **.NET MAUI**: Also uses XAML and C#, but provides a unified API for multiple platforms, allowing developers to write once and deploy everywhere.

### 3. **Navigation**
- **WPF**: Navigation is typically handled using `Frame` or `NavigationWindow`.
- **.NET MAUI**: Uses `Shell` for navigation, which provides a more modern and flexible approach, including support for flyout menus, tabs, and deep linking.

### 4. **Development Experience**
- **WPF**: Requires Visual Studio and is tightly integrated with Windows.
- **.NET MAUI**: Can be developed using Visual Studio or Visual Studio Code, and supports hot reload for faster development cycles.

## Shell in .NET MAUI

### What is Shell?
Shell in .NET MAUI is a container that provides a way to define the structure of an application, including navigation, flyout menus, and tabs. It simplifies the navigation process and provides a consistent user experience across different platforms.

### Key Features of Shell
1. **Flyout Menu**: A side menu that can be accessed by swiping or clicking a button.
2. **Tabs**: A tab bar for switching between different sections of the app.
3. **Navigation**: Simplified navigation with support for deep linking and route-based navigation.
4. **Customization**: Ability to customize the appearance and behavior of the Shell.

### How Shell Works in This Project
In this project, the `AppShell.xaml` file defines the structure of the application using `FlyoutItem` and `ShellContent`. The `MainPage` and `SecondaryPage` are registered as routes, allowing users to navigate between them using the `GoToAsync` method.

```xaml:09_C#/School/2024-2025/Application development/MAUI/17_assignment/assignment17/AppShell.xaml
<FlyoutItem FlyoutDisplayOptions="AsMultipleItems">
    <ShellContent Route="main" Title="Žák" ContentTemplate="{DataTemplate local:MainPage}"/>
    <ShellContent Route="second" Title="Ročníková práce" ContentTemplate="{DataTemplate local:SecondaryPage}"/>
</FlyoutItem>
```

### Navigation Example
Navigation between pages is handled in the code-behind files (`MainPage.xaml.cs` and `SecondaryPage.xaml.cs`) using the `Shell.Current.GoToAsync` method.

```csharp:09_C#/School/2024-2025/Application development/MAUI/17_assignment/assignment17/MainPage.xaml.cs
private async void Button_OnClicked(object? sender, EventArgs e)
{
    try
    {
        await Shell.Current.GoToAsync("//second");
    }
    catch (Exception ex)
    {
        await DisplayAlert("Error", $"Error when navigating to the secondary page: {ex.Message}", "OK");
    }
}
```

## Project Structure
- **App.xaml**: Defines the application resources and startup behavior.
- **AppShell.xaml**: Defines the Shell structure and navigation routes.
- **MainPage.xaml**: The main page of the application with a button to navigate to the secondary page.
- **SecondaryPage.xaml**: The secondary page with a button to navigate back to the main page.