# WPF Application Example

This README provides an overview of a simple WPF (Windows Presentation Foundation) application, explaining its structure, functionality, and how the various components interact. WPF is a UI framework for building desktop applications on Windows, allowing developers to create rich user interfaces with a clear separation between the UI and the business logic.

## Overview of WPF

WPF uses a markup language called XAML (Extensible Application Markup Language) to define the user interface. XAML allows developers to create UI elements declaratively, making it easier to design and maintain complex interfaces. The code-behind files (with a `.xaml.cs` extension) contain the logic that interacts with the UI defined in XAML.

### Key Concepts

1. **XAML**: A markup language used to define the layout and appearance of the UI.
2. **Code-Behind**: C# code that handles events and contains the logic for the application.
3. **Data Binding**: A powerful feature in WPF that allows UI elements to be bound to data sources, enabling automatic updates of the UI when the data changes.
4. **Styles and Resources**: WPF allows the definition of styles and resources that can be reused across the application, promoting consistency and reducing redundancy.

## Application Structure

The application consists of several key files:

### 1. `App.xaml` and `App.xaml.cs`

- **`App.xaml`**: This file defines the application-level resources and the startup URI, which specifies the initial window to display when the application starts.

  ```xml
  <Application x:Class="_08_assigment.App"
               xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
               xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
               StartupUri="MainWindow.xaml">
      <Application.Resources>
      </Application.Resources>
  </Application>
  ```

  - **`x:Class`**: Specifies the name of the class that will represent this application.
  - **`StartupUri`**: Indicates which XAML page should be loaded when the application starts. In this case, it is `MainWindow.xaml`.

- **`App.xaml.cs`**: This is the code-behind for `App.xaml`. It contains the application logic, but in this case, it is empty as no specific logic is required at the application level.

  ```csharp
  namespace _08_assigment;

  public partial class App
  {
  }
  ```

  - **`partial class`**: Allows the definition of a class to be split across multiple files. This class is partial because its definition is spread between `App.xaml` and `App.xaml.cs`.

### 2. `MainWindow.xaml` and `MainWindow.xaml.cs`

- **`MainWindow.xaml`**: This file defines the layout and UI elements of the main window. It uses a `DockPanel` to arrange buttons and a `TextBlock` for displaying messages.

  ```xml
  <Window x:Class="_08_assigment.MainWindow"
          xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
          xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
          Title="MainWindow" Height="600" Width="900">
      
      <Window.Resources>
          <Style x:Key="ButtonStyle" TargetType="Button">
              <Setter Property="Background" Value="LightGray"/>
              <Setter Property="Foreground" Value="Black"/>
              <Setter Property="Height" Value="200"/>
              <Setter Property="Width" Value="200"/>
              <Setter Property="FontSize" Value="50"/>
          </Style>
      </Window.Resources>
      
      <DockPanel Margin="10,10,10,10" x:Name="DockPanel">
          <Grid DockPanel.Dock="Left">
              <Grid.RowDefinitions>
                  <RowDefinition Height="*"/>
                  <RowDefinition Height="*"/>
              </Grid.RowDefinitions>
              <Button Style="{DynamicResource ButtonStyle}" Grid.Row="0" Click="ButtonBase_OnClick">Black</Button>
              <Button Style="{DynamicResource ButtonStyle}" Grid.Row="1" Click="ButtonBase_OnClick">Blue</Button>
          </Grid>
          <Grid DockPanel.Dock="Right">
              <Grid.RowDefinitions>
                  <RowDefinition Height="*"/>
                  <RowDefinition Height="*"/>
              </Grid.RowDefinitions>
              <Button Style="{DynamicResource ButtonStyle}" Grid.Row="0" Click="ButtonBase_OnClick">Red</Button>
              <Button Style="{DynamicResource ButtonStyle}" Grid.Row="1" Click="ButtonBase_OnClick">Green</Button>
          </Grid>
          
          <Grid Background="Yellow">
              <TextBlock x:Name="Text" Text="Not clicked" HorizontalAlignment="Center" VerticalAlignment="Center" FontSize="50" Foreground="Black"/>
          </Grid>
      </DockPanel>
  </Window>
  ```

  - **`<Window>`**: The main container for the application that contains all UI elements.
  - **`<Window.Resources>`**: Defines styles and resources that can be used within the window. In this case, a style for buttons is defined.
  - **`<DockPanel>`**: Allows arranging elements in the window. In this case, buttons are placed on the left and right sides.
  - **`<Button>`**: Buttons that trigger the `ButtonBase_OnClick` event when clicked. Each button has assigned text that indicates the color it represents.
  - **`<TextBlock>`**: A text element that displays the current click state.

- **`MainWindow.xaml.cs`**: This is the code-behind for `MainWindow.xaml`. It contains the logic for handling button clicks and updating the UI.

  ```csharp
  using System.Windows;
  using System.Windows.Controls;
  using System.Windows.Media;

  namespace _08_assigment
  {
      public partial class MainWindow
      {
          public MainWindow()
          {
              InitializeComponent();
          }

          private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
          {
              var clickedButton = (Button)sender;
              string? clickedText = clickedButton.Content.ToString();

              Brush newBackground;
              Brush newForeground;

              switch (clickedText)
              {
                  case "Black":
                      newBackground = Brushes.Black;
                      newForeground = Brushes.White;
                      break;
                  case "Blue":
                      newBackground = Brushes.Blue;
                      newForeground = Brushes.White;
                      break;
                  case "Red":
                      newBackground = Brushes.Red;
                      newForeground = Brushes.Yellow;
                      break;
                  case "Green":
                      newBackground = Brushes.Green;
                      newForeground = Brushes.Black;
                      break;
                  default:
                      newBackground = Brushes.Gray;
                      newForeground = Brushes.Black;
                      break;
              }

              var buttons = DockPanel.Children.OfType<Grid>()
                  .SelectMany(grid => grid.Children.OfType<Button>());

              foreach (var button in buttons)
              {
                  button.Background = newBackground;
                  button.Foreground = newForeground;
              }

              Text.Text = clickedText;
          }
      }
  }
  ```

  - **`public MainWindow()`**: The constructor for the `MainWindow` class, which initializes the components defined in XAML.
  - **`ButtonBase_OnClick`**: A method that is triggered when a button is clicked. It retrieves the text of the clicked button and changes the background and foreground colors of all buttons based on the clicked button's color. It also updates the `TextBlock` to display which button was clicked.
  - **`DockPanel.Children.OfType<Grid>()`**: Retrieves all `Grid` elements in the `DockPanel`.
  - **`SelectMany`**: Used to get all buttons from each `Grid`, allowing iteration over all buttons.

### 3. `AssemblyInfo.cs`

- **`AssemblyInfo.cs`**: This file contains metadata about the assembly, such as theme information. It is used by WPF to manage resources and themes.

  ```csharp
  using System.Windows;

  [assembly: ThemeInfo(
      ResourceDictionaryLocation.None, //where theme specific resource dictionaries are located
      ResourceDictionaryLocation.SourceAssembly //where the generic resource dictionary is located
  )]
  ```

  - **`ThemeInfo`**: An attribute that specifies where theme-specific resources are located. In this case, it indicates that there are no specific resources for themes and that the generic resources are located in the current assembly.

## How It Works

1. **Application Startup**: When the application starts, `App.xaml` specifies that `MainWindow.xaml` should be loaded. The `MainWindow` class is instantiated, and the `InitializeComponent()` method is called to load the XAML-defined UI.

2. **Button Click Handling**: Each button in the `MainWindow.xaml` has an event handler (`ButtonBase_OnClick`) defined in the code-behind. When a button is clicked, the event handler is triggered, and the application logic is executed.

3. **Changing UI Elements**: The `ButtonBase_OnClick` method retrieves the text of the clicked button and changes the background and foreground colors of all buttons based on the clicked button's color. It also updates the `TextBlock` to display which button was clicked.

4. **Dynamic Resources**: The button styles are defined in the `Window.Resources` section, allowing for easy updates and consistent styling across the application.

## Conclusion

This WPF application demonstrates the basic structure and functionality of a WPF application, including the use of XAML for UI design and C# for application logic. By separating the UI definition from the logic, WPF allows for a clean and maintainable codebase. This example serves as a foundation for building more complex WPF applications, utilizing data binding, styles, and resources to create rich user interfaces.