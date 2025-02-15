# LogApp - WPF vs AvaloniaUI

LogApp is a simple desktop application for managing and storing logs. It is available in two versions: one built with **WPF (Windows Presentation Foundation)** and another with **AvaloniaUI**. This document compares the two implementations, highlighting their differences, advantages, and use cases.

---

## Overview

### **WPF Version**
- Built using **WPF**, a UI framework for Windows desktop applications.
- Uses **XAML** for defining the user interface and **C#** for the logic.
- Supports **dark and light modes** by detecting the system theme via the Windows Registry.
- Logs are stored in a `log.json` file and displayed in a `ListView`.

### **AvaloniaUI Version**
- Built using **AvaloniaUI**, a cross-platform UI framework.
- Uses **Avalonia XAML (AXAML)** for defining the user interface and **C#** for the logic.
- Supports **dark and light modes** using the `SemiTheme` library, which adapts to the system theme.
- Logs are stored in a `log.json` file and displayed in a `ListBox`.

---

## Feature Comparison

| Feature                  | WPF Version                          | AvaloniaUI Version                     |
|--------------------------|--------------------------------------|----------------------------------------|
| **Platform Support**     | Windows only                        | Cross-platform (Windows, macOS, Linux)|
| **Theme Support**        | Custom dark/light mode detection    | Built-in theme support via `SemiTheme` |
| **UI Framework**         | WPF (Windows Presentation Foundation)| AvaloniaUI                             |
| **Log Display**          | `ListView` with `GridView`          | `ListBox` with custom `DataTemplate`   |
| **Error Handling**       | `MessageBox` (WPF)                  | `MsBox.Avalonia` (Avalonia)            |
| **File Handling**        | `System.IO`                         | `System.IO`                            |
| **JSON Serialization**   | `System.Text.Json`                  | `System.Text.Json`                     |

---

## Key Differences

### 1. **Platform Support**
   - **WPF**: Only runs on Windows, as it is a Windows-specific framework.
   - **AvaloniaUI**: Cross-platform, supporting Windows, macOS, and Linux.

### 2. **Theme Support**
   - **WPF**: Implements custom dark/light mode detection using the Windows Registry.
   - **AvaloniaUI**: Uses the `SemiTheme` library, which provides built-in theme support and automatically adapts to the system theme.

### 3. **UI Framework**
   - **WPF**: Uses WPF, which is mature and well-suited for Windows applications but lacks cross-platform capabilities.
   - **AvaloniaUI**: Uses AvaloniaUI, which is modern, cross-platform, and provides a similar development experience to WPF.

### 4. **Log Display**
   - **WPF**: Uses a `ListView` with a `GridView` to display logs in a tabular format.
   - **AvaloniaUI**: Uses a `ListBox` with a custom `DataTemplate` to display logs in a more flexible layout.

### 5. **Error Handling**
   - **WPF**: Uses the built-in `MessageBox` for displaying error messages.
   - **AvaloniaUI**: Uses the `MsBox.Avalonia` library, which provides a more modern and customizable message box.

---

## Why Choose One Over the Other?

### **Choose WPF if:**
- You are developing a **Windows-only application**.
- You prefer a **mature and stable framework** with extensive documentation and community support.
- You need to integrate with **Windows-specific features** (e.g., Registry, Windows APIs).

### **Choose AvaloniaUI if:**
- You need a **cross-platform application** that runs on Windows, macOS, and Linux.
- You want to use a **modern UI framework** with built-in theme support and a more flexible layout system.
- You are targeting **future-proof development** with a framework that is actively maintained and evolving.

---

## Code Comparison

### **Theme Detection**
- **WPF**:
  ```csharp
  private bool IsDarkModeEnabled()
  {
      const string registryKeyPath = @"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize";
      const string registryValueName = "AppsUseLightTheme";

      using (var key = Registry.CurrentUser.OpenSubKey(registryKeyPath))
      {
          if (key != null && key.GetValue(registryValueName) is int value)
          {
              return value == 0;
          }
      }
      return false;
  }
  ```

- **AvaloniaUI**:
  ```xml
  <Application xmlns="https://github.com/avaloniaui"
               xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
               x:Class="LogApp_Avalonia.App"
               RequestedThemeVariant="Default">
  ```

### **Log Display**
- **WPF**:
  ```xml
  <ListView ItemsSource="{Binding Logs}">
      <ListView.View>
          <GridView>
              <GridViewColumn Header="Name" DisplayMemberBinding="{Binding Name}" />
              <GridViewColumn Header="Message" DisplayMemberBinding="{Binding Message}" />
              <GridViewColumn Header="Time" DisplayMemberBinding="{Binding Time}" />
          </GridView>
      </ListView.View>
  </ListView>
  ```

- **AvaloniaUI**:
  ```xml
  <ListBox ItemsSource="{Binding Logs}">
      <ListBox.ItemTemplate>
          <DataTemplate>
              <Grid ColumnDefinitions="Auto, *, Auto">
                  <TextBlock Grid.Column="0" Text="{Binding Name}" />
                  <TextBlock Grid.Column="1" Text="{Binding Message}" />
                  <TextBlock Grid.Column="2" Text="{Binding Time}" />
              </Grid>
          </DataTemplate>
      </ListBox.ItemTemplate>
  </ListBox>
  ```

---

## Conclusion

Both versions of LogApp provide the same core functionality but are built using different frameworks, each with its own strengths. The **WPF version** is ideal for Windows-only applications, while the **AvaloniaUI version** is better suited for cross-platform development. Choose the one that best fits your project requirements and target platforms.
