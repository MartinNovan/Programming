# Text Formatting in HTML

In HTML, text formatting is essential for creating structured, readable content. You can use various tags to apply different styles and formatting to text. Let's explore some of the most commonly used text formatting tags in HTML.

## Basic Text Formatting Tags

### 1. Bold Text
To make text bold, use the `<b>` tag or the more semantically correct `<strong>` tag, which also indicates importance.

### 2. Italic Text
To italicize text, use the `<i>` tag or the more semantic `<em>` tag, which stands for "emphasis."

### 3. Underlined Text
You can underline text using the `<u>` tag, but note that this tag is generally used for non-semantic purposes. It's often better to use CSS for underlining in most cases.

### 4. Strikethrough Text
The `<s>` tag can be used to create strikethrough text, indicating that the text is no longer relevant or has been removed.

### 5. Superscript and Subscript
Superscript and subscript text are used for mathematical expressions or footnotes.

- **Superscript**: `<sup>`
- **Subscript**: `<sub>`

**Example:**

```html
H<sup>2</sup>O (Water)
E=mc<sup>2</sup>
CO<sub>2</sub> (Carbon Dioxide)
```

## Text Alignment
To align text, you can use the `align` attribute (although it's now considered obsolete and better handled by CSS):

```html
<h1 align="center">Centered Heading</h1>
<p align="right">This text is aligned to the right</p>
```

However, it's recommended to use CSS for text alignment:

```css
h1 {
    text-align: center;
}
p {
    text-align: right;
}
```

## Line Breaks and Spacing

### Line Breaks
Use the `<br>` tag to insert a line break.

### Paragraphs
The `<p>` tag is used to define paragraphs. By default, browsers add space between paragraphs.

### Non-breaking Space
The `&nbsp;` entity creates a space that won't break into a new line.

## Preformatted Text
The `<pre>` tag preserves whitespace and line breaks, displaying text exactly as it is written in the HTML file.

## Tips
- Use semantic tags like `<strong>` and `<em>` instead of `<b>` and `<i>` when you want to convey meaning or emphasize the importance of text.
- CSS is the recommended method for styling text, such as changing colors, fonts, and alignments.

Now that you know how to format text, let's explore links and navigation in the [next section](04_links_navigation.md)!
