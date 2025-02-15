# To-Do List Application

## Overview

This To-Do List application allows users to add, check off, and remove tasks from their list. It is built using HTML, CSS, and JavaScript, providing a simple and interactive user interface.

## How It Works

### HTML Structure

The HTML file (`index.html`) contains the basic structure of the application:

- A header section with a title and an input field for entering tasks.
- A button to add tasks to the list.
- An unordered list (`<ul>`) to display the tasks.

### JavaScript Functionality

The JavaScript file (`app.js`) contains the logic for adding and managing tasks:

1. **Adding a Task**:
   - The `addTodo` function retrieves the value from the input field.
   - If the input is empty, an alert prompts the user to enter a task.
   - If a task is entered, a new list item (`<li>`) is created, containing the task text and a close button (×).
   - The new task is appended to the list, and the input field is cleared.

2. **Removing a Task**:
   - The close button is set up to remove the task from the list when clicked. It hides the parent list item.

3. **Checking Off a Task**:
   - An event listener is added to the list that toggles the 'checked' class on a task when it is clicked. This visually indicates that the task is completed.

### CSS Styling

The CSS file (`style.css`) styles the application, providing a clean and user-friendly interface:

- The body has a background color and margin settings.
- The header and input fields are styled for better visibility and usability.
- List items change appearance when checked, providing visual feedback to the user.

## Conclusion

This To-Do List application demonstrates basic web development concepts, including DOM manipulation, event handling, and styling. It serves as a practical example of how to create interactive web applications using HTML, CSS, and JavaScript. Users can easily add, check off, and remove tasks, making it a useful tool for managing daily activities.