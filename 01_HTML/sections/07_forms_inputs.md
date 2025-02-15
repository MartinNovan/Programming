# Forms and User Input in HTML

Forms are essential for collecting user input on web pages. In HTML, you can create forms that allow users to enter data, which can then be processed by a server or used in client-side applications. Let's explore how to work with forms and user input in HTML.

## Creating Forms

### 1. Basic Form Structure
To create a form, use the `<form>` tag. The `action` attribute specifies the URL where the form data will be sent, and the `method` attribute defines how the data will be sent (GET or POST).

**Example:**

```html
<form action="submit_form.php" method="post">
    <!-- Form elements will go here -->
</form>
```

### 2. Input Fields
You can create various types of input fields using the `<input>` tag. The `type` attribute specifies the type of input.

**Common Input Types:**

- **Text Input**: For single-line text input.
  
  ```html
  <input type="text" name="username" placeholder="Enter your username">
  ```

- **Password Input**: For password input, which hides the text.
  
  ```html
  <input type="password" name="password" placeholder="Enter your password">
  ```

- **Email Input**: For email addresses, with built-in validation.
  
  ```html
  <input type="email" name="email" placeholder="Enter your email">
  ```

- **Checkbox**: For selecting multiple options.
  
  ```html
  <input type="checkbox" name="subscribe" value="yes"> Subscribe to newsletter
  ```

- **Radio Buttons**: For selecting one option from a group.
  
  ```html
  <input type="radio" name="gender" value="male"> Male
  <input type="radio" name="gender" value="female"> Female
  ```

- **Select Dropdown**: For selecting one option from a dropdown list.
  
  ```html
  <select name="country">
      <option value="us">United States</option>
      <option value="ca">Canada</option>
      <option value="uk">United Kingdom</option>
  </select>
  ```

### 3. Textarea
For multi-line text input, use the `<textarea>` tag.

**Example:**

```html
<textarea name="message" rows="4" cols="50" placeholder="Enter your message"></textarea>
```

### 4. Submit Button
To submit the form, use the `<button>` or `<input>` tag with `type="submit"`.

**Example:**

```html
<button type="submit">Submit</button>
```

## Input Validation
HTML5 provides several attributes for input validation:

- **`required`**: Ensures that the field must be filled out before submitting the form.
  
  ```html
  <input type="text" name="username" required>
  ```

- **`min` and `max`**: Specify minimum and maximum values for numeric inputs.
  
  ```html
  <input type="number" name="age" min="1" max="100">
  ```

- **`pattern`**: Defines a regular expression that the input must match.
  
  ```html
  <input type="text" name="zipcode" pattern="\d{5}" placeholder="Enter ZIP code">
  ```

## Accessibility Considerations
When creating forms, it's important to consider accessibility:

- **Labeling Input Fields**: Use the `<label>` tag to associate labels with input fields, improving accessibility for screen readers.

**Example:**

```html
<label for="username">Username:</label>
<input type="text" id="username" name="username">
```

- **Fieldset and Legend**: Use `<fieldset>` to group related fields and `<legend>` to provide a caption for the group.

**Example:**

```html
<fieldset>
    <legend>Personal Information</legend>
    <label for="name">Name:</label>
    <input type="text" id="name" name="name">
</fieldset>
```

## Tips
- Always test your forms to ensure they work correctly and handle user input as expected.
- Consider using client-side validation with JavaScript for a better user experience.

Now that you know how to create forms and handle user input, let's explore the [next topic](08_semantic_html.md) in the course!
