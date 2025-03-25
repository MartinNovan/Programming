# WPF Image Stretching Application

This README provides an overview of a WPF application that demonstrates how to manipulate image stretching using different modes. The application allows users to select different stretching options for an image displayed in the window, showcasing how the `Stretch` property of the `Image` control works in WPF.

## Overview of Image Stretching in WPF

In WPF, the `Image` control has a `Stretch` property that determines how the image is resized to fit its container. The available options for the `Stretch` property are:

- **None**: The image is displayed at its original size. If the image is larger than the container, it will be clipped.
- **Fill**: The image is stretched to completely fill the container, which may distort the image's aspect ratio.
- **Uniform**: The image is scaled to fit within the container while maintaining its original aspect ratio. This means that the entire image will be visible, but there may be empty space in the container.
- **UniformToFill**: The image is scaled to fill the container while maintaining its aspect ratio. Parts of the image may be clipped if the aspect ratios of the image and container differ.

## Application Structure

The application consists of the following key components:

1. **XAML File**: Defines the layout and UI elements, including the `Image` control and radio buttons for selecting the stretching mode.
2. **Code-Behind File**: Contains the logic needed to change the image stretching mode based on user selection.

### Setting Up the Resources

To use images and other resources in your WPF application, it is recommended to create a dedicated folder structure. Here’s how to organize your resources:

1. **Create a Folder Named `Resources`**: This folder will contain all your resource files.
2. **Organize Further if Necessary**: If you have multiple types of resources, such as images, styles, or other assets, consider creating subfolders within the `Resources` folder. For example:
   - `Resources/Images` for image files.
   - `Resources/Styles` for XAML style files or resource dictionaries.

This organization helps keep your project tidy and makes it easier to manage resources as your application grows.

### Adding Images to Resources

#### In JetBrains Rider

1. **Add Image to Project**:
   - Right-click on your project in the Solution Explorer.
   - Select **Add** > **New Folder** and name it `Resources` (or any name you prefer).
   - Right-click on the `Resources` folder and select **Add** > **Existing Item**.
   - Browse to your image file and add it.

2. **Set Image as Resource**:
   - Select the image file in the Solution Explorer.
   - In the Properties window, set the **Build Action** to `Resource`.

#### In Visual Studio 2022

1. **Add Image to Project**:
   - Right-click on your project in the Solution Explorer.
   - Select **Add** > **New Folder** and name it `Resources`.
   - Right-click on the `Resources` folder and select **Add** > **Existing Item**.
   - Browse to your image file and add it.

2. **Set Image as Resource**:
   - Select the image file in the Solution Explorer.
   - In the Properties window, set the **Build Action** to `Resource`.

#### Manual Method

If you prefer to add the image manually without using the IDE:

1. Place your image file in the project directory (e.g., in a folder named `Resources`).
2. Open the `.csproj` file of your project in a text editor.
3. Add the following line within the `<ItemGroup>` section:

   ```xml
   <Resource Include="Resources\your_image_file.png" />
   ```

   Replace `your_image_file.png` with the actual name of your image file.

### Example XAML Code

Here’s the XAML code for the main window of the application:

```xml
<Window x:Class="_09_assignment.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800">
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/> 
            <RowDefinition Height="*"/>    
            <RowDefinition Height="Auto"/>
        </Grid.RowDefinitions>
        <Viewbox Grid.Row="0"> 
            <TextBlock Text="App with stretching image" HorizontalAlignment="Center" VerticalAlignment="Center"/>
        </Viewbox>
        <Image x:Name="Image" Source="/Resources/downloaded_image.png" Grid.Row="1" HorizontalAlignment="Center" VerticalAlignment="Center" Stretch="None"/>
        <Grid Grid.Row="2">
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="*"/>
                <ColumnDefinition Width="*"/>
                <ColumnDefinition Width="*"/>
                <ColumnDefinition Width="*"/>
            </Grid.ColumnDefinitions>
            <RadioButton Grid.Column="0" GroupName="ImageMode" VerticalAlignment="Center" Checked="UniformButtonOnChecked"/>
            <TextBlock Text="Uniform" Grid.Column="0" HorizontalAlignment="Center" VerticalAlignment="Center"/>
            <RadioButton Grid.Column="1" GroupName="ImageMode" VerticalAlignment="Center" Checked="UniformToFillButtonOnChecked"/>
            <TextBlock Text="UniformToFill" Grid.Column="1" HorizontalAlignment="Center" VerticalAlignment="Center"/>
            <RadioButton Grid.Column="2" GroupName="ImageMode" VerticalAlignment="Center" Checked="FillButtonOnChecked"/>
            <TextBlock Text="Fill" Grid.Column="2" HorizontalAlignment="Center" VerticalAlignment="Center"/>
            <RadioButton Grid.Column="3" GroupName="ImageMode" VerticalAlignment="Center" IsChecked="True" Checked="NoneButtonOnChecked"/>
            <TextBlock Text="None" Grid.Column="3" HorizontalAlignment="Center" VerticalAlignment="Center"/>
        </Grid>
    </Grid>
</Window>
```

### Explanation of the XAML Code

- **`<Window>`**: The main container for the application that contains all UI elements.
- **`<Grid>`**: The layout container that organizes the UI elements in rows and columns.
- **`<Viewbox>`**: Used to scale the `TextBlock` that displays the title of the application, ensuring it remains centered and appropriately sized.
- **`<Image>`**: Displays the image specified in the `Source` property. The initial `Stretch` property is set to `None`, meaning the image will be displayed at its original size.
- **`<Grid>`**: Contains radio buttons for selecting the image stretching mode. Each radio button is associated with a different stretching option, allowing users to change how the image is displayed.

### Example Code-Behind

Here’s the code-behind for the main window, which handles the logic for changing the image stretching mode based on user selection:

```csharp
using System.Windows;
using System.Windows.Media;

namespace _09_assignment
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent(); // Initializes the components defined in XAML
        }

        // Event handler for the Uniform radio button
        private void UniformButtonOnChecked(object sender, RoutedEventArgs e)
        {
            Image.Stretch = Stretch.Uniform; // Sets the image to stretch uniformly, maintaining its aspect ratio
        }

        // Event handler for the UniformToFill radio button
        private void UniformToFillButtonOnChecked(object sender, RoutedEventArgs e)
        {
            Image.Stretch = Stretch.UniformToFill; // Sets the image to stretch uniformly to fill the container
        }

        // Event handler for the Fill radio button
        private void FillButtonOnChecked(object sender, RoutedEventArgs e)
        {
            Image.Stretch = Stretch.Fill; // Sets the image to fill the container, potentially distorting its aspect ratio
        }

        // Event handler for the None radio button
        private void NoneButtonOnChecked(object sender, RoutedEventArgs e)
        {
            Image.Stretch = Stretch.None; // Resets the image to its original size, displaying it without any stretching
        }
    }
}
```

### Explanation of the Code-Behind

- **`public MainWindow()`**: The constructor for the `MainWindow` class, which initializes the components defined in XAML.
- **Event Handlers**: Each method corresponds to a radio button's `Checked` event. When a radio button is checked, the corresponding method is called, and the `Stretch` property of the `Image` control is updated accordingly:
  - **`UniformButtonOnChecked`**: Sets the image to stretch uniformly, maintaining its aspect ratio.
  - **`UniformToFillButtonOnChecked`**: Sets the image to stretch uniformly to fill the container while maintaining its aspect ratio.
  - **`FillButtonOnChecked`**: Sets the image to fill the container, which may distort its aspect ratio.
  - **`NoneButtonOnChecked`**: Resets the image to its original size, displaying it without any stretching.

## Conclusion

This WPF Image Stretching Application demonstrates how to work with images in a WPF application, including how to change the image stretching mode using radio buttons. By understanding these concepts, you can create more dynamic and visually appealing applications that effectively utilize images.

Feel free to expand upon this example by adding more images, experimenting with different layouts, or incorporating additional user interactions to change the image properties at runtime. Remember to organize your resources effectively to maintain a clean project structure.