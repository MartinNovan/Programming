# Node.js MySQL User Management Application

This project is a simple Node.js application that connects to a MySQL database to manage user data. It allows users to submit their first and last names via a form, which are then stored in the database. The application also provides functionality to display all users stored in the database.

## Project Structure

- **`app.js`**: The main server file that sets up the Express application, connects to the MySQL database, and defines routes for handling user data.
- **`index.html`**: The HTML file that provides the user interface for submitting and displaying user data.

## Code Explanation

### `app.js`

- **MySQL Connection**:
  - Uses `mysql2` to connect to a MySQL database with specified credentials.
  - Inserts a sample user into the `users` table and retrieves all users upon successful connection.

- **Express Setup**:
  - Creates an Express application and listens on port 5500.
  - Serves static files and parses JSON and URL-encoded data.

- **Routes**:
  - **`GET /`**: Serves the `index.html` file.
  - **`POST /save-user`**: Inserts user data into the database and redirects to the home page.
  - **`GET /show-all-users`**: Queries the database for all users and returns them as JSON.

### `index.html`

- **HTML Structure**:
  - Provides a form for users to submit their first and last names.
  - Includes buttons to submit the form via JavaScript and to display all users in the database.

- **JavaScript Functions**:
  - `submitViaJS()`: Submits the form data as JSON to the server and clears the input fields upon successful submission.
  - `showUsers()`: Fetches and displays all users from the database.

### Form Submission Buttons

The application provides two different methods for submitting form data:

1. **Standard Submit Button**:
   - **Functionality**: Uses the standard HTML form submission method, which sends data as URL-encoded to the server.
   - **Advantages**:
     - Simplicity: Easy to implement and understand.
     - Compatibility: Works in all browsers without additional JavaScript.
   - **Disadvantages**:
     - Page Reload: Causes a full page reload, which can be less efficient and disrupts the user experience.
     - Less Control: Limited control over the submission process and response handling.

2. **Submit via JavaScript Button**:
   - **Functionality**: Uses JavaScript's `fetch` API to send data as JSON to the server asynchronously.
   - **Advantages**:
     - No Page Reload: Allows for data submission without reloading the page, providing a smoother user experience.
     - More Control: Offers greater control over the request and response, allowing for custom handling of success and error states.
   - **Disadvantages**:
     - Requires JavaScript: Relies on JavaScript being enabled in the user's browser.
     - Complexity: Slightly more complex to implement compared to standard form submission.

## Installation and Setup

1. **Install Node.js**: Ensure Node.js is installed on your system.
2. **Install Dependencies**: Run the following command in the project directory to install the required modules:
   ```bash
   npm install express mysql2
   ```
3. **Set Up MySQL Database**:
   - Ensure MySQL is installed and running on your system.
   - Create a database named `my_db` using the following query:
     ```sql
     CREATE DATABASE my_db;
     ```
   - Switch to the `my_db` database:
     ```sql
     USE my_db;
     ```
   - Create a table named `users` with columns `firstName` and `lastName` using the following query:
     ```sql
     CREATE TABLE users (
         id INT AUTO_INCREMENT PRIMARY KEY,
         firstName VARCHAR(50),
         lastName VARCHAR(50)
     );
     ```
   - Update the database connection details in `app.js` if necessary.

4. **Run the Server**: Execute `node app.js` in the terminal to start the server.
5. **Access the Application**: Open a web browser and navigate to `http://localhost:5500` to view the page.

## Notes

- This project demonstrates basic CRUD operations with a MySQL database using Node.js and Express.
- Ensure that the MySQL server is running and accessible before starting the application.
- The application uses a simple form and JavaScript to interact with the server and database.
