# Clean Code Principles

This document outlines essential clean code principles to improve code readability, maintainability, and overall quality. These principles are crucial for writing code that is easy to understand and modify, especially in collaborative environments.

## 1: Meaningful Naming

Use clear and descriptive names:
- Variable and function names should accurately reflect their purpose.
- **Variables**: Use nouns (e.g., `customerList`).
- **Functions**: Use verbs (e.g., `getSum`) to indicate what is being done with the data.

Naming Rules:
- Length should be between 3-20 characters.
- Avoid abbreviations unless they are widely accepted (e.g., URL, ID).
- Consistent use of case (e.g., camelCase for variables and functions).

## 2: Comment "Why," Not "How"

Explain the purpose:
- Comments should clarify why the code exists, not how it works.
- Assume the code is self-explanatory.

Commenting Rules:
- Start with an imperative verb (e.g., "Read file, so we can...").
- Limit comments to 80 characters per line.
- Place comments above all non-trivial functions and classes, complex lines, and in larger (team) projects, also in the header files.
- Comments are necessary where it is not clear what the code does even after 10 seconds.

## 3: Magic Constants

Use named constants:
- Replace hard-coded values with clearly named constants or variables.
- Improves code readability and maintainability.

Implementation Guidelines:
- Define constants at the beginning of the file or in configuration.
- Use uppercase with underscores for constant names (e.g., `MAX_ATTEMPTS`).
- Some values are better expressed as equations (e.g., `DAY = 24 * 60 * 60 * 1000`).
- Constants should truly be constant and not change.

## 4: Side Effects of Functions

Ensure purity:
- Functions should perform their task without unexpected changes to external states or variables.
- Do not modify global variables or input parameters without expectation.

Best Practices:
- Return new values instead of changing existing ones.
- If side effects are necessary, document them clearly.
- Keep functions focused on a single task.

## 5: Keep Functions Short and Simple

Function Length:
- Aim for short functions, ideally between 5-20 lines.

Simplify Logic:
- Avoid deep nesting; limit to a maximum of 3 levels.
- Break down complex functions into smaller, reusable parts.

## 6: DRY (Don't Repeat Yourself)

Eliminate duplication:
- Do not repeat yourself.
- Do not repeat yourself.
- Do not repeat yourself.

Implementation Tips:
- Can it be written as a function? Then it should be a function.
- Doing something twice is okay, three times is a waste of time.
- Repeated method calls with different arguments can often be abstracted.

## 7: Consistent Code Formatting

Uniform Style:
- If it looks nice, it will read nicely.
- If it reads nicely, you will make fewer mistakes.

Formatting Rules:
- Line length: Limit to 80 characters per line.
- Naming conventions: Follow agreed styles (e.g., camelCase, snake_case).

Tip:
- Use linters for automatic style rule enforcement. ESLint, Prettier, Black...
- VS Code has many options.