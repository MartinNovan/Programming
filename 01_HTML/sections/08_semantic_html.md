# Semantic HTML

Semantic HTML refers to the use of HTML markup that conveys meaning about the content contained within it. By using semantic elements, you can improve the accessibility, search engine optimization (SEO), and overall structure of your web pages. Let's explore the importance of semantic HTML and how to use it effectively.

## What is Semantic HTML?

Semantic HTML uses HTML tags that have clear meanings and describe the content they contain. This helps both browsers and developers understand the structure and purpose of the content. For example, using `<header>`, `<footer>`, `<article>`, and `<section>` tags provides context about the content, making it easier to read and maintain.

## Benefits of Semantic HTML

### 1. Improved Accessibility
Semantic HTML enhances accessibility for users with disabilities. Screen readers and other assistive technologies can better interpret the content when semantic elements are used, allowing for a more inclusive web experience.

### 2. Better SEO
Search engines use semantic HTML to understand the context of the content on a page. By using appropriate semantic tags, you can improve your site's visibility in search engine results.

### 3. Enhanced Maintainability
Using semantic elements makes your HTML code more readable and easier to maintain. Developers can quickly understand the structure and purpose of the content, which is especially beneficial in collaborative projects.

## Common Semantic HTML Elements

### 1. `<header>`
The `<header>` element represents introductory content or a group of navigational links. It typically contains the site logo, title, and navigation menu.

**Example:**

```html
<header>
    <h1>Website Title</h1>
    <nav>
        <ul>
            <li><a href="index.html">Home</a></li>
            <li><a href="about.html">About</a></li>
        </ul>
    </nav>
</header>
```

### 2. `<nav>`
The `<nav>` element is used to define a set of navigation links. It helps search engines and assistive technologies identify the navigation structure of the site.

**Example:**

```html
<nav>
    <ul>
        <li><a href="services.html">Services</a></li>
        <li><a href="contact.html">Contact</a></li>
    </ul>
</nav>
```

### 3. `<main>`
The `<main>` element represents the main content of the document. It should contain content that is unique to the page and not repeated across other pages.

**Example:**

```html
<main>
    <h2>Welcome to Our Website</h2>
    <p>This is the main content area.</p>
</main>
```

### 4. `<section>`
The `<section>` element defines a thematic grouping of content, typically with a heading. It is used to break up content into logical sections.

**Example:**

```html
<section>
    <h2>About Us</h2>
    <p>Information about the company.</p>
</section>
```

### 5. `<article>`
The `<article>` element represents a self-contained piece of content that could be distributed independently, such as a blog post or news article.

**Example:**

```html
<article>
    <h2>Latest News</h2>
    <p>This is a news article.</p>
</article>
```

### 6. `<footer>`
The `<footer>` element represents the footer of a document or section, typically containing author information, copyright notices, or related links.

**Example:**

```html
<footer>
    <p>&copy; 2023 Your Company. All rights reserved.</p>
</footer>
```

## Tips for Using Semantic HTML
- Use semantic elements whenever possible to enhance the meaning of your content.
- Avoid using generic elements like `<div>` and `<span>` when a semantic element is more appropriate.
- Ensure that your HTML structure is logical and reflects the hierarchy of your content.

Now that you understand the importance of semantic HTML, let's explore the [next topic](09_html5_features.md) in the course!
