# WPF Custom User Controls: Placeholder TextBox

This README provides an overview of a WPF (Windows Presentation Foundation) application that demonstrates how to create custom user controls when the framework lacks specific functionality. In this case, we will focus on a custom `PlaceholderTextBox` control that displays placeholder text when the text box is empty. This project illustrates the importance of creating reusable components to enhance the user interface and improve user experience.

## Overview of the Application

The application features a custom user control called `PlaceholderTextBox`, which combines a `TextBox` with a `TextBlock` to display placeholder text. This control is useful for guiding users on what to input in the text box, especially when the field is empty. The project showcases how to define custom properties, handle events, and create a visually appealing user interface.

## Importance of Custom User Controls in WPF

Creating custom user controls in WPF is essential for several reasons:

1. **Reusability**: Custom controls can be reused across different parts of an application or even in multiple applications, reducing code duplication and improving maintainability.
2. **Encapsulation**: User controls encapsulate functionality and presentation, allowing developers to create complex UI elements without exposing their internal workings.
3. **Customization**: Custom controls can be tailored to meet specific design requirements that may not be achievable with standard controls.
4. **Enhanced User Experience**: By creating controls that better fit the application's needs, developers can improve the overall user experience.

## Creating Custom User Controls

### Steps to Create a Custom User Control

1. **Define the User Control**:
   - Create a new UserControl file in your project. In this case, we created `PlaceholderTextBox.xaml` under the `UserControls` folder.
   - Define the layout and visual elements in the XAML file. For example, the `PlaceholderTextBox` combines a `TextBlock` for the placeholder and a `TextBox` for user input.

2. **Add Dependency Properties**:
   - In the code-behind file (e.g., `PlaceholderTextBox.xaml.cs`), define dependency properties for the control. This allows for data binding and customization.
   - Example:
     ```csharp
     public static readonly DependencyProperty PlaceholderProperty = DependencyProperty.Register(nameof(Placeholder), typeof(string), typeof(PlaceholderTextBox), new PropertyMetadata(""));
     public string Placeholder
     { 
         get => (string)GetValue(PlaceholderProperty);
         set => SetValue(PlaceholderProperty, value);
     }
     ```

3. **Handle Events**:
   - Implement event handlers to manage user interactions. For instance, the `TextBox_TextChanged` event updates the visibility of the placeholder text based on whether the `TextBox` is empty.
   - Example:
     ```csharp
     private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
     {
         var textbox = (TextBox)sender;
         PLaceholderElement.Visibility = !string.IsNullOrEmpty(textbox.Text) ? Visibility.Collapsed : Visibility.Visible;
     }
     ```

4. **Define Styles and Templates**:
   - Use styles and control templates to customize the appearance of the user control. This can include setting properties like `CornerRadius` for rounded corners.
   - Example:
     ```xml
     <UserControl.Resources>
         <Style TargetType="Border">
             <Setter Property="CornerRadius" Value="{Binding CornerRadius, ElementName=MyControl}"/>
         </Style>
     </UserControl.Resources>
     ```

5. **Organize User Controls**:
   - It is recommended to keep all user controls in a dedicated folder, such as `UserControls`, to maintain a clean project structure. This makes it easier to manage and locate custom controls.

### Example User Control Code

Here is the XAML code for the `PlaceholderTextBox` user control:

```xml
<UserControl x:Class="_13_assignment.UserControls.PlaceholderTextBox"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006" 
             xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
             mc:Ignorable="d" 
             d:DesignHeight="50" d:DesignWidth="200"  x:Name="MyControl" Background="White">
    <UserControl.Resources>
        <Style TargetType="Border" >
            <Setter Property="CornerRadius" Value="{Binding CornerRadius, ElementName=MyControl}"/>
        </Style>
    </UserControl.Resources>
    <Grid>
        <TextBlock Margin="2,0,0,0" Name="PLaceholderElement" Text="{Binding Placeholder, ElementName=MyControl}"/>
        <TextBox BorderThickness="0" Background="Transparent" TextChanged="TextBox_TextChanged" Text="{Binding Text, ElementName=MyControl, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"/>
    </Grid>
</UserControl>
```

### Detailed Explanation of the User Control Code

1. **User Control Definition**:
   - `<UserControl x:Class="_13_assignment.UserControls.PlaceholderTextBox"`: This line defines the user control and specifies its class name and namespace.
   - `xmlns` attributes: These define the XML namespaces used in the XAML file, including the standard WPF namespaces and design-time support.

2. **User Control Resources**:
   - `<UserControl.Resources>`: This section is used to define resources that can be reused within the user control.
   - `<Style TargetType="Border">`: This style targets `Border` elements, allowing customization of their properties.
   - `<Setter Property="CornerRadius" Value="{Binding CornerRadius, ElementName=MyControl}"/>`: This binds the `CornerRadius` property of the `Border` to the `CornerRadius` property of the user control, allowing for rounded corners.

3. **Grid Layout**:
   - `<Grid>`: This layout container organizes the UI elements within the user control.
   - **Placeholder TextBlock**:
     - `<TextBlock Margin="2,0,0,0" Name="PLaceholderElement" Text="{Binding Placeholder, ElementName=MyControl}"/>`: This `TextBlock` displays the placeholder text. It binds its `Text` property to the `Placeholder` property of the user control, allowing dynamic updates.
   - **TextBox**:
     - `<TextBox BorderThickness="0" Background="Transparent"`: This `TextBox` is styled to have no border and a transparent background, allowing the placeholder text to be visible.
     - `TextChanged="TextBox_TextChanged"`: This event handler is triggered whenever the text in the `TextBox` changes, allowing for visibility control of the placeholder text.
     - `Text="{Binding Text, ElementName=MyControl, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"`: This binds the `Text` property of the `TextBox` to the `Text` property of the user control, enabling two-way data binding.

### Example Code-Behind for User Control

Here is the code-behind for the `PlaceholderTextBox` user control:

```csharp
using System.Windows;
using System.Windows.Controls;

namespace _13_assignment.UserControls
{
    public partial class PlaceholderTextBox
    {
        public static readonly DependencyProperty PlaceholderProperty = DependencyProperty.Register(nameof(Placeholder), typeof(string), typeof(PlaceholderTextBox), new PropertyMetadata(""));
        public string Placeholder
        { 
            get => (string)GetValue(PlaceholderProperty);
            set => SetValue(PlaceholderProperty, value);
        }
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(nameof(Text), typeof(string), typeof(PlaceholderTextBox), new PropertyMetadata(""));
        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }
        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(PlaceholderTextBox), new PropertyMetadata(new CornerRadius(0)));
        public string CornerRadius
        {
            get => (string)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }
        public PlaceholderTextBox()
        {
            InitializeComponent();
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textbox = (TextBox)sender;
            PLaceholderElement.Visibility = !string.IsNullOrEmpty(textbox.Text) ? Visibility.Collapsed : Visibility.Visible;
        }
    }
}
```

### Detailed Explanation of the Code-Behind

1. **Dependency Properties**:
   - **Placeholder Property**:
     - `public static readonly DependencyProperty PlaceholderProperty`: This line defines a dependency property for the placeholder text. Dependency properties are used in WPF to enable data binding, styling, and animation.
     - `public string Placeholder`: This property provides access to the placeholder text, allowing it to be set and retrieved.
   - **Text Property**:
     - Similar to the `Placeholder` property, this defines a dependency property for the text entered in the `TextBox`.
   - **CornerRadius Property**:
     - This property allows customization of the corner radius of the `Border` in the user control, enabling rounded corners.

2. **Constructor**:
   - `public PlaceholderTextBox()`: This constructor initializes the user control and calls `InitializeComponent()`, which loads the XAML-defined UI.

3. **TextChanged Event Handler**:
   - `private void TextBox_TextChanged(object sender, TextChangedEventArgs e)`: This method is triggered when the text in the `TextBox` changes.
   - `var textbox = (TextBox)sender;`: This line retrieves the `TextBox` that triggered the event.
   - `PLaceholderElement.Visibility = !string.IsNullOrEmpty(textbox.Text) ? Visibility.Collapsed : Visibility.Visible;`: This line controls the visibility of the placeholder text. If the `TextBox` contains text, the placeholder is hidden; otherwise, it is displayed.

### Example Main Window Code

Here is the XAML code for the main window that demonstrates the use of the `PlaceholderTextBox` user control:

```xml
<Window x:Class="_13_assignment.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:userControls="clr-namespace:_13_assignment.UserControls"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800">
    <Grid>
        <StackPanel Orientation="vertical" >
            <userControls:PlaceholderTextBox CornerRadius="20" Placeholder="Start writing here" Width="200" Padding="10" Margin="20" Background="green" Foreground="LightGray"/>
            <userControls:PlaceholderTextBox CornerRadius="10" Placeholder="Do not write here" Width="200" Padding="10" Margin="20" Background="red" Foreground="LightBlue"/>
        </StackPanel>
    </Grid>
</Window>
```

### Detailed Explanation of the Main Window Code

1. **Window Definition**:
   - `<Window x:Class="_13_assignment.MainWindow"`: This line defines the main window of the application and specifies its class name.
   - `xmlns` attributes: These define the XML namespaces used in the XAML file, including the user controls namespace.

2. **Grid Layout**:
   - `<Grid>`: This layout container organizes the UI elements within the main window.

3. **StackPanel**:
   - `<StackPanel Orientation="vertical">`: This panel arranges its child elements in a vertical stack.

4. **PlaceholderTextBox Instances**:
   - `<userControls:PlaceholderTextBox CornerRadius="20" Placeholder="Start writing here" Width="200" Padding="10" Margin="20" Background="green" Foreground="LightGray"/>`: This instance of the `PlaceholderTextBox` control has a corner radius of 20, a placeholder text, and specific dimensions and colors.
   - `<userControls:PlaceholderTextBox CornerRadius="10" Placeholder="Do not write here" Width="200" Padding="10" Margin="20" Background="red" Foreground="LightBlue"/>`: This instance has a different corner radius and colors, demonstrating the flexibility of the custom control.

## Conclusion

This WPF Custom User Controls project demonstrates how to create reusable components when the framework lacks specific functionality. The `PlaceholderTextBox` control enhances user experience by providing placeholder text, guiding users on what to input. Understanding how to create and utilize custom user controls is essential for building flexible and maintainable WPF applications.

### Best Practices for Creating Custom User Controls

- **Organize User Controls**: Keep all user controls in a dedicated folder, such as `UserControls`, to maintain a clean project structure. This makes it easier to manage and locate custom controls.
- **Use Dependency Properties**: Define dependency properties for any properties that need to be bindable or customizable. This allows for better integration with WPF's data binding system.
- **Implement Event Handlers**: Handle relevant events to manage user interactions effectively. This enhances the functionality of the user control.
- **Utilize Styles and Templates**: Define styles and control templates to customize the appearance of the user control, ensuring it fits seamlessly into the overall application design.
