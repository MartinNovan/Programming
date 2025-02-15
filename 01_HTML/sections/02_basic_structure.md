# Basic HTML Structure

Every HTML document has a basic structure that is necessary for proper rendering in the browser. Let's break down the essential components of an HTML document.

### Basic HTML Document Structure

A simple HTML document structure looks like this:

```html
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document Title</title>
</head>
<body>
    <h1>Hello, World!</h1>
    <p>Welcome to your first HTML page.</p>
</body>
</html>
```
### Explanation of the Structure:
- `<!DOCTYPE html>`: This declaration tells the browser that the document is an HTML5 document. It should always be the very first line in an HTML document.

- `<html>`: The root element of the HTML document that contains all the content.

- `<head>`: The head section contains metadata (data about the document), such as the character encoding, the document's title, and links to stylesheets or scripts. It does not display content on the page.

    - `<meta charset="UTF-8">`: This meta tag specifies the character encoding for the document, which ensures that special characters are displayed correctly.

    - `<meta name="viewport" content="width=device-width, initial-scale=1.0">`: This meta tag ensures the page is responsive on mobile devices, setting the width of the page to the device's screen size.

    - `<title>`: The title tag specifies the title of the document, which appears in the browser tab.

- `<body>`: This section contains all the visible content on the webpage, such as text, images, and links. Everything inside the <body> tag is displayed on the page.

## Key Elements in HTML:
Headings: Used for titles and subheadings, e.g., `<h1>` to `<h6>`.
Paragraphs: Used to structure text content, e.g., `<p>`.
Links: Used to create clickable hyperlinks, e.g., `<a href="https://example.com">Example</a>`.
Images: Used to display images, e.g., `<img src="image.jpg" alt="Image description">`.
Lists: Used for ordered and unordered lists, e.g., `<ul>`, `<ol>`, and `<li>`.
## Tips:
- Always structure your HTML document with a `<!DOCTYPE html>` declaration at the top to ensure compatibility with modern browsers.
- Use semantic HTML whenever possible to improve accessibility and SEO.
---
Now that you understand the basic structure, let's dive deeper into text formatting in the [next section](03_text_formatting.md)!