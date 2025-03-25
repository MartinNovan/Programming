# README for Word Navigation Application

## Overview

This Word Navigation Application is a console-based program that allows users to manage a list of words. Users can add words to the list and navigate through them using commands. The application demonstrates basic command handling and list management in C#.

## How It Works

### Main Functionality

1. **User Input**:
   - The program continuously reads user input from the console.

2. **Command Structure**:
   - The user can enter commands in the format `command: argument`. The application recognizes the following commands:
     - **Add**: Adds a word to the list.
     - **Back**: Navigates to the previous word in the list.
     - **Forward**: Navigates to the next word in the list.

3. **Adding Words**:
   - When the user enters the command `add: <word>`, the application adds the specified word to the list and updates the current index to the last added word. If the command format is incorrect, an error message is displayed.

4. **Navigating Words**:
   - The `back` command allows the user to move to the previous word in the list. If the user is at the beginning of the list, it will display the first word.
   - The `forward` command allows the user to move to the next word in the list. If the user is at the end of the list, no action is taken.

5. **Output**:
   - The application displays the current word based on the user's navigation commands or provides feedback for invalid commands.

## Conclusion

This Word Navigation Application serves as a practical example of how to manage a list of items and navigate through them in a console application using C#. It demonstrates fundamental programming concepts such as user input handling, list management, and command processing. Users can easily add and navigate through words, making it a useful tool for simple word management tasks.