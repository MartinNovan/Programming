# Strings in C

## Introduction
This project demonstrates the use of strings in C, which are arrays of characters terminated by a null character (`\0`).

## Code Explanation

### `main.c`
```c
#include <stdio.h>

int main() {
    char greeting[] = "Hello, World!";

    printf("Greeting: %s\n", greeting);

    return 0;
}
```

- **`char greeting[] = "Hello, World!";`**: Declares a character array `greeting` and initializes it with the string "Hello, World!".
- **`printf("Greeting: %s\n", greeting);`**: Prints the string stored in `greeting` using the `%s` format specifier.
