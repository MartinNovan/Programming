# Lists and Tables in HTML

Lists and tables are essential for organizing and presenting data in a structured manner on web pages. In HTML, you can create ordered and unordered lists, as well as tables to display information clearly. Let's explore how to work with lists and tables in HTML.

## Creating Lists

### 1. Unordered Lists
An unordered list is created using the `<ul>` tag, with each list item defined by the `<li>` tag. This type of list is typically displayed with bullet points.

**Example:**

```html
<ul>
    <li>Item 1</li>
    <li>Item 2</li>
    <li>Item 3</li>
</ul>
```

### 2. Ordered Lists
An ordered list is created using the `<ol>` tag, with each list item also defined by the `<li>` tag. This type of list is typically displayed with numbers.

**Example:**

```html
<ol>
    <li>First item</li>
    <li>Second item</li>
    <li>Third item</li>
</ol>
```

### 3. Nested Lists
You can create nested lists by placing one list inside another. This can be done with either ordered or unordered lists.

**Example:**

```html
<ul>
    <li>Fruits
        <ul>
            <li>Apple</li>
            <li>Banana</li>
        </ul>
    </li>
    <li>Vegetables
        <ul>
            <li>Carrot</li>
            <li>Broccoli</li>
        </ul>
    </li>
</ul>
```

## Creating Tables

### 1. Basic Table Structure
To create a table, use the `<table>` tag. The table consists of rows defined by the `<tr>` tag, header cells defined by the `<th>` tag, and standard cells defined by the `<td>` tag.

**Example:**

```html
<table>
    <tr>
        <th>Name</th>
        <th>Age</th>
    </tr>
    <tr>
        <td>Alice</td>
        <td>30</td>
    </tr>
    <tr>
        <td>Bob</td>
        <td>25</td>
    </tr>
</table>
```

### 2. Table Attributes
You can use various attributes to enhance your tables:
- **`border`**: Adds a border to the table.
- **`cellpadding`**: Adds space between the cell content and the cell border.
- **`cellspacing`**: Adds space between table cells.

**Example:**

```html
<table border="1" cellpadding="5" cellspacing="0">
    <tr>
        <th>Name</th>
        <th>Age</th>
    </tr>
    <tr>
        <td>Alice</td>
        <td>30</td>
    </tr>
    <tr>
        <td>Bob</td>
        <td>25</td>
    </tr>
</table>
```

### 3. Caption for Tables
You can add a caption to your table using the `<caption>` tag, which provides a title or explanation for the table.

**Example:**

```html
<table>
    <caption>People and Their Ages</caption>
    <tr>
        <th>Name</th>
        <th>Age</th>
    </tr>
    <tr>
        <td>Alice</td>
        <td>30</td>
    </tr>
    <tr>
        <td>Bob</td>
        <td>25</td>
    </tr>
</table>
```

## Accessibility Considerations
When creating lists and tables, it's important to consider accessibility:

- **Descriptive List Items**: Ensure that list items are clear and descriptive to aid understanding.
- **Table Headers**: Use `<th>` for header cells to help screen readers identify the structure of the table.

## Tips
- Use lists for grouping related items and tables for displaying structured data.
- Keep your lists and tables organized and easy to read for better user experience.

Now that you know how to work with lists and tables, let's explore forms and user input in the [next section](07_forms_inputs.md)!
