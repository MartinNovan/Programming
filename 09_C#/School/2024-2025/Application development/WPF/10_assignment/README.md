# WPF Text Decoration Application

This README provides an overview of a WPF (Windows Presentation Foundation) application that demonstrates how to manipulate text decorations using checkboxes. The application allows users to apply different text decorations (underline, overline, strikethrough) to a text displayed in a `TextBox`, showcasing how the `TextDecorations` property of the `TextBox` control works in WPF.

## Overview of WPF

WPF is a UI framework for building desktop applications on Windows, allowing developers to create rich user interfaces with a clear separation between the UI and the business logic. This application utilizes WPF's capabilities to manipulate text decorations effectively.

## Key Concepts

1. **XAML**: A markup language used to define the layout and appearance of the UI. The application uses XAML to create the user interface elements.
2. **Code-Behind**: C# code that handles events and contains the logic for the application. The code-behind file manages the text decoration functionality based on user input.
3. **Text Decorations**: The `TextDecorations` property of the `TextBox` control determines how the text is displayed. The available options include:
   - **Underline**: Draws a line beneath the text.
   - **Overline**: Draws a line above the text.
   - **Strikethrough**: Draws a line through the text.

## Application Structure

The application consists of the following key components:

1. **XAML File**: Defines the layout and UI elements, including the `TextBox` control and checkboxes for selecting the text decoration mode.
2. **Code-Behind File**: Contains the logic needed to change the text decoration based on user selection.

### Setting Up the Resources

To use this application, ensure that you have the necessary resources and dependencies set up in your WPF project.

### Example XAML Code

Here’s the XAML code for the main window of the application:

```xml
<Window x:Class="_10_assignment.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800">
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="*"/>
        </Grid.RowDefinitions>
        <TextBox Text="Decoration" FontSize="30" Grid.Row="0" TextAlignment="Center"/>
        <Grid Grid.Row="1">
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="*"/>
                <ColumnDefinition Width="*"/>
                <ColumnDefinition Width="*"/>
            </Grid.ColumnDefinitions>
            <CheckBox x:Name="UnderlineCheckBox" Checked="UnderlineOnChecked" Unchecked="CheckBoxUnchecked" Grid.Column="0" VerticalAlignment="Center"/>
            <TextBlock Text="Underline" TextDecorations="Underline" Grid.Column="0" Margin="20,0,0,0" FontSize="15"/>
            <CheckBox x:Name="OverlineCheckBox" Checked="OverlineOnChecked" Unchecked="CheckBoxUnchecked" Grid.Column="1" VerticalAlignment="Center"/>
            <TextBlock Text="Overline" TextDecorations="Overline" Grid.Column="1" Margin="20,0,0,0" FontSize="15"/>
            <CheckBox x:Name="StrikethroughCheckBox" Checked="StrikethroughOnChecked" Unchecked="CheckBoxUnchecked" Grid.Column="2" VerticalAlignment="Center" />
            <TextBlock Text="Strikethrough" TextDecorations="Strikethrough" Grid.Column="2" Margin="20,0,0,0" FontSize="15"/>
        </Grid>
        <TextBox x:Name="TextBox" Grid.Row="2" TextDecorations="None" 
                 AcceptsReturn="True" SpellCheck.IsEnabled="True" TextWrapping="Wrap"/>
    </Grid>
</Window>
```

### Example Code-Behind

Here’s the code-behind for the main window, which handles the logic for changing the text decoration based on user selection:

```csharp
using System.Windows;

namespace _10_assignment;

public partial class MainWindow
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void UnderlineOnChecked(object sender, RoutedEventArgs e)
    {
        SetTextDecoration(TextDecorations.Underline);
    }

    private void OverlineOnChecked(object sender, RoutedEventArgs e)
    {
        SetTextDecoration(TextDecorations.OverLine);
    }

    private void StrikethroughOnChecked(object sender, RoutedEventArgs e)
    {
        SetTextDecoration(TextDecorations.Strikethrough);
    }

    private void CheckBoxUnchecked(object sender, RoutedEventArgs e)
    {
        if (UnderlineCheckBox.IsChecked != null && !UnderlineCheckBox.IsChecked.Value 
            && OverlineCheckBox.IsChecked != null && !OverlineCheckBox.IsChecked.Value 
            && StrikethroughCheckBox.IsChecked != null && !StrikethroughCheckBox.IsChecked.Value)
        {
            TextBox.TextDecorations = null;
        }
    }

    private void SetTextDecoration(TextDecorationCollection decoration)
    {
        TextBox.TextDecorations = decoration;

        if (decoration == TextDecorations.Underline)
        {
            OverlineCheckBox.IsChecked = false;
            StrikethroughCheckBox.IsChecked = false;
        }
        else if (decoration == TextDecorations.OverLine)
        {
            UnderlineCheckBox.IsChecked = false;
            StrikethroughCheckBox.IsChecked = false;
        }
        else if (decoration == TextDecorations.Strikethrough)
        {
            UnderlineCheckBox.IsChecked = false;
            OverlineCheckBox.IsChecked = false;
        }
    }
}
```

### Explanation of the Code-Behind

- **`public MainWindow()`**: The constructor for the `MainWindow` class, which initializes the components defined in XAML.
- **Event Handlers**: Each method corresponds to a checkbox's `Checked` or `Unchecked` event. When a checkbox is checked or unchecked, the corresponding method is called, and the `TextDecorations` property of the `TextBox` control is updated accordingly.

## Conclusion

This WPF Text Decoration Application demonstrates how to work with text decorations in a WPF application, allowing users to apply various styles to text dynamically. The text input field now supports line breaks, spell checking, and text wrapping, enhancing the user experience.

Feel free to expand upon this example by adding more text decoration options, experimenting with different layouts, or incorporating additional user interactions to change the text properties at runtime. Remember to organize your resources effectively to maintain a clean project structure.