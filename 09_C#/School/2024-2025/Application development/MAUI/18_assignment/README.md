# .NET MAUI MVVM & Collection Example

## Introduction
This project demonstrates the use of the MVVM (Model-View-ViewModel) architecture in .NET MAUI and how to display and manage a collection of tasks. Users can add new tasks, mark them as completed, and delete them – all through a collection bound to the UI using data binding.

## Differences Between Classic Approach and MVVM in .NET MAUI

### 1. **Architecture**
- **Classic Approach**: Logic is often placed directly in code-behind files (e.g., `MainPage.xaml.cs`).
- **MVVM**: Separates logic (ViewModel) from the UI (View) and data (Model), improving code clarity, testability, and reusability.

### 2. **Working with Collections**
- **Classic**: The collection is managed directly in code-behind, and UI does not automatically reflect changes.
- **MVVM**: The collection (e.g., `ObservableCollection`) is managed in the ViewModel, and the UI updates automatically via data binding.

### 3. **Data Binding**
- **Classic**: Values are often set manually in code.
- **MVVM**: Everything is connected through bindings in XAML, reducing repetitive code.

---

## MVVM in .NET MAUI

### What is MVVM?
MVVM (Model-View-ViewModel) is an architectural pattern that separates the user interface (View), data (Model), and logic (ViewModel). .NET MAUI natively supports this pattern, enabling efficient data and UI management.

---

## Using CommunityToolkit.Mvvm

This project uses the [CommunityToolkit.Mvvm](https://learn.microsoft.com/en-us/dotnet/communitytoolkit/mvvm/) NuGet package to simplify MVVM development. It provides attributes and base classes that reduce boilerplate code.

### Key Features Used

#### 1. `[ObservableProperty]` Attribute

- **Purpose:** Automatically generates a property with change notification (INotifyPropertyChanged).
- **How it works:** You declare a private field and decorate it with `[ObservableProperty]`. The toolkit generates the public property and the code to notify the UI when the value changes.

**Example:**

```csharp
using CommunityToolkit.Mvvm.ComponentModel;

public partial class TaskItem : ObservableObject
{
    [ObservableProperty]
    private string title;

    [ObservableProperty]
    private string description;

    [ObservableProperty]
    private bool isCompleted;
}
```
*In this example, `TaskItem` inherits from `ObservableObject` (from the toolkit), and each field marked with `[ObservableProperty]` will have a public property generated for it. When you set, for example, `Title`, the UI is automatically notified and updates any bindings.*

#### 2. `ObservableCollection<T>`

- **Purpose:** A collection that notifies the UI when items are added, removed, or the whole list is refreshed.
- **Usage:** Used for the list of tasks so that the UI updates automatically when tasks are added or deleted.

**Example:**

```csharp
public static class TaskRepository
{
    public static ObservableCollection<TaskItem> Tasks { get; } = new();
}
```

---

## Example: Working with Collection and MVVM

### Displaying the Collection in MainPage

```xml
<CollectionView ItemsSource="{Binding Tasks}">
    <CollectionView.ItemTemplate>
        <DataTemplate>
            <Frame>
                <StackLayout>
                    <Label Text="{Binding Title}" />
                    <Label Text="{Binding Description}" />
                    <Switch IsToggled="{Binding IsCompleted, Mode=TwoWay}"/>
                    <Button Text="Delete"
                            Command="{Binding DeleteCommand, Source={x:Reference MyPage}}"
                            CommandParameter="{Binding .}" />
                </StackLayout>
            </Frame>
        </DataTemplate>
    </CollectionView.ItemTemplate>
</CollectionView>
```
*The `CollectionView` binds to the `Tasks` collection. Each item displays its properties, and changes (like toggling completion or deleting) are reflected in the UI automatically.*

### Adding a New Task

```csharp
private void Button_OnClicked(object? sender, EventArgs e)
{
    var newTask = new Model.TaskItem
    {
        Title = titleEntry.Text,
        Description = descriptionEditor.Text,
        IsCompleted = false
    };
    Repository.TaskRepository.Tasks.Add(newTask);
    // Clear fields and notify the user
}
```
*When a new task is added to the `Tasks` collection, the UI updates instantly because of the `ObservableCollection`.*

---

## Project Structure
- **Model/TaskItem.cs**: Defines the task data model using `[ObservableProperty]` and `ObservableObject`.
- **Repository/TaskRepository.cs**: Static collection of tasks.
- **MainPage.xaml / .cs**: Displays and manages the task collection.
- **NewTaskPage.xaml / .cs**: Form for adding new tasks.
- **AppShell.xaml**: Defines navigation between pages.
