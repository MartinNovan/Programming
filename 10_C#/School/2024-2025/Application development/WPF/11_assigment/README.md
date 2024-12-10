# WPF Product Management Application

This README provides an overview of a WPF (Windows Presentation Foundation) application designed for managing products. The application displays a list of products in a data grid and allows users to add, remove, and track the total price and count of expired products.

## Overview of the Application

The application utilizes WPF to create a user interface that enables interaction with product data. Users can add new products, modify existing ones, and monitor the total price of all products as well as the number of expired products.

## Key Concepts

1. **XAML**: A markup language used to define the layout and appearance of the user interface. The application employs XAML to create user interface elements.
2. **Code-Behind**: C# code that handles events and contains the application logic. The code-behind file manages the functionality of the application based on user input.
3. **ObservableCollection**: A special collection that automatically notifies the user interface of changes, such as adding or removing items. This is crucial for data binding in WPF applications.

## Application Structure

The application consists of the following key components:

1. **XAML File**: Defines the layout and user interface elements, including the data grid for displaying products.
2. **Code-Behind File**: Contains the logic needed to manipulate products and update the user interface.

### Example XAML Code

Here is the XAML code for the main window of the application:

```xml
<Window x:Class="_11_assigment.MainWindow"
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
        </Grid.RowDefinitions>
            <DataGrid Grid.Row="0" CurrentCellChanged="DataGrid_OnCurrentCellChanged"
                 HorizontalScrollBarVisibility="Auto"
                 VerticalScrollBarVisibility="Auto"
                 ItemsSource="{Binding Products}"
                 AutoGenerateColumns="False"
                 CanUserAddRows="True" 
                 CanUserDeleteRows="True"
                 Margin="10">
                <DataGrid.Columns>
                    <DataGridTextColumn Header="Product Name" Binding="{Binding ProductName}" Width="*"/>
                    <DataGridTextColumn Header="Price" Binding="{Binding Price}" Width="*"/>
                    <DataGridTextColumn Header="Expiration Date" Binding="{Binding ExpirationDate}" Width="*" />
                </DataGrid.Columns>
            </DataGrid>
        <StackPanel Grid.Row="1" Margin="10">
            <TextBlock x:Name="TotalPrice" Text="Total price: -"/>
            <TextBlock x:Name="ExpiredProducts" Text="Expired products: -"/>
        </StackPanel>
    </Grid>
</Window>
```

### Explanation of the XAML Code

- **`<Window>`**: The main container for the application that holds all UI elements.
- **`<Grid>`**: A layout container that organizes the UI elements in rows and columns.
- **`<DataGrid>`**: Displays the list of products. It is bound to the `Products` collection, allowing for dynamic updates as products are added or removed. The `CurrentCellChanged` event is handled to update the total price and count of expired products.
- **`<StackPanel>`**: Contains text blocks that display the total price and the number of expired products. This panel is placed below the data grid.

### Example Code-Behind

Here is the code-behind for the main window, which handles the logic for managing products:

```csharp
using System.Collections.ObjectModel;

namespace _11_assigment
{
    public partial class MainWindow
    {
        // ObservableCollection to hold the list of products
        public ObservableCollection<Product> Products { get; set; }
        
        // Constructor for MainWindow
        public MainWindow()
        {
            InitializeComponent(); // Initializes the components defined in XAML
            Products = new ObservableCollection<Product>(); // Initializes the Products collection
            DataContext = this; // Sets the data context for data binding
        }

        // Event handler for when the current cell in the DataGrid changes
        private void DataGrid_OnCurrentCellChanged(object? sender, EventArgs e)
        {
            // Updates the TotalPrice text block with the sum of all product prices
            TotalPrice.Text = $"Total price: {Products.Sum(product => product.Price)}";
            // Updates the ExpiredProducts text block with the count of expired products
            ExpiredProducts.Text = $"Expired products: { Products.Count(product => product.ExpirationDate < DateTime.Now)}";
        }

        // Product class representing a product with its properties
        public class Product
        {
            public string ProductName { get; set; } = "Default Name"; // Default product name
            public decimal Price { get; set; } = 0; // Default price
            public DateTime ExpirationDate { get; set; } = DateTime.Now; // Default expiration date
        }
    }
}
```

### Detailed Explanation of the Code-Behind

- **Namespaces**: 
  - `System.Collections.ObjectModel`: This namespace is used for the `ObservableCollection<T>` class, which provides a dynamic data collection that provides notifications when items get added, removed, or when the whole list is refreshed.
  - `System.Linq`: This namespace is included to use LINQ (Language Integrated Query) methods such as `Sum()` and `Count()`, which allow for concise and readable data manipulation.
  - `System.Windows`: This namespace is essential for WPF applications, providing classes for the user interface.

- **`public ObservableCollection<Product> Products { get; set; }`**: 
  - This property holds the collection of products. It is of type `ObservableCollection<Product>`, which means that any changes to this collection (like adding or removing products) will automatically update the UI due to data binding.

- **`public MainWindow()`**: 
  - This is the constructor for the `MainWindow` class. It initializes the components defined in the XAML file and sets up the data context for data binding.
  - `Products = new ObservableCollection<Product>();`: Initializes the `Products` collection, which will hold the product data.
  - `DataContext = this;`: Sets the data context of the window to itself, allowing the UI to bind to the `Products` property.

- **`private void DataGrid_OnCurrentCellChanged(object? sender, EventArgs e)`**: 
  - This method is an event handler that is triggered whenever the current cell in the `DataGrid` changes. 
  - `TotalPrice.Text = $"Total price: {Products.Sum(product => product.Price)}";`: This line calculates the total price of all products in the `Products` collection using the `Sum()` method and updates the `TotalPrice` text block.
  - `ExpiredProducts.Text = $"Expired products: { Products.Count(product => product.ExpirationDate < DateTime.Now)}";`: This line counts how many products have expired by checking if their `ExpirationDate` is less than the current date and updates the `ExpiredProducts` text block.

- **`public class Product`**: 
  - This nested class represents a product with three properties: 
    - `ProductName`: A string representing the name of the product, initialized to "Default Name".
    - `Price`: A decimal representing the price of the product, initialized to 0.
    - `ExpirationDate`: A `DateTime` representing the expiration date of the product, initialized to the current date and time.

## Conclusion

This WPF Product Management Application demonstrates how to work with data collections and user interfaces in WPF. Users can easily manage products and track their total price and expiration status. 

Feel free to expand upon this example by adding features such as editing and deleting products, or experimenting with different layouts to enhance the user experience. Remember to maintain a clean project structure by organizing your resources effectively.