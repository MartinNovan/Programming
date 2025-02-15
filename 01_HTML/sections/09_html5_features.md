# HTML5 Features

HTML5 is the latest version of the HyperText Markup Language, which brings new features and improvements to enhance the functionality and usability of web applications. This section explores some of the key features introduced in HTML5 and how they can be utilized in web development.

## New Semantic Elements

HTML5 introduced several new semantic elements that provide better structure and meaning to web content. These elements help improve accessibility and SEO.

### 1. `<article>`
Represents a self-contained piece of content that could be distributed independently, such as a blog post or news article.

**Example:**

```html
<article>
    <h2>Breaking News</h2>
    <p>This is a news article that can stand alone.</p>
</article>
```

### 2. `<section>`
Defines a thematic grouping of content, typically with a heading. It is used to break up content into logical sections.

**Example:**

```html
<section>
    <h2>Features</h2>
    <p>Details about the features of the product.</p>
</section>
```

### 3. `<nav>`
Used to define a set of navigation links, helping search engines and assistive technologies identify the navigation structure of the site.

**Example:**

```html
<nav>
    <ul>
        <li><a href="home.html">Home</a></li>
        <li><a href="about.html">About</a></li>
    </ul>
</nav>
```

### 4. `<header>` and `<footer>`
The `<header>` element represents introductory content or a group of navigational links, while the `<footer>` element represents the footer of a document or section.

**Example:**

```html
<header>
    <h1>Website Title</h1>
</header>

<footer>
    <p>&copy; 2023 Your Company. All rights reserved.</p>
</footer>
```

## Multimedia Support

HTML5 provides native support for audio and video, allowing developers to embed multimedia content without relying on third-party plugins.

### 1. `<audio>` Tag
The `<audio>` tag is used to embed sound content in documents. It supports various audio formats and provides built-in controls.

**Example:**

```html
<audio controls>
    <source src="audio.mp3" type="audio/mpeg">
    Your browser does not support the audio tag.
</audio>
```

### 2. `<video>` Tag
The `<video>` tag is used to embed video content. It also supports multiple video formats and provides built-in controls.

**Example:**

```html
<video controls>
    <source src="video.mp4" type="video/mp4">
    Your browser does not support the video tag.
</video>
```

## Form Enhancements

HTML5 introduced new input types and attributes that enhance form functionality and improve user experience.

### 1. New Input Types
HTML5 includes several new input types, such as:

- **`email`**: For email addresses, with built-in validation.
  
  ```html
  <input type="email" name="user_email" placeholder="Enter your email">
  ```

- **`date`**: For selecting dates, with a date picker interface.
  
  ```html
  <input type="date" name="event_date">
  ```

- **`range`**: For selecting a value from a range using a slider.
  
  ```html
  <input type="range" name="volume" min="0" max="100">
  ```

### 2. Placeholder Attribute
The `placeholder` attribute provides a hint to the user about what to enter in the input field.

**Example:**

```html
<input type="text" name="username" placeholder="Enter your username">
```

## Canvas and SVG

HTML5 introduced the `<canvas>` element, which allows for dynamic, scriptable rendering of 2D shapes and bitmap images. It is commonly used for graphics, animations, and game development.

### 1. `<canvas>` Tag
The `<canvas>` tag is used to draw graphics on the fly via JavaScript.

**Example:**

```html
<canvas id="myCanvas" width="200" height="100"></canvas>
<script>
    var canvas = document.getElementById("myCanvas");
    var ctx = canvas.getContext("2d");
    ctx.fillStyle = "red";
    ctx.fillRect(20, 20, 150, 50);
</script>
```

## Conclusion

HTML5 brings significant improvements and new features that enhance the way we create and interact with web content. By utilizing these features, developers can create more engaging, accessible, and user-friendly web applications.

Now that you understand the key features of HTML5, let's explore the [last topic](10_best_practices.md) in the course!
