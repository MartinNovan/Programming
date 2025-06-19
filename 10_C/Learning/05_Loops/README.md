# Loops in C

## Introduction
This project demonstrates the use of loops in C, including `for`, `while`, and `do-while` loops.

## Code Explanation

### `main.c`
```c
#include <stdio.h>

int main() {
    int i;

    // For loop
    printf("For loop:\n");
    for (i = 0; i < 5; i++) {
        printf("%d\n", i);
    }

    // While loop
    printf("While loop:\n");
    i = 0;
    while (i < 5) {
        printf("%d\n", i);
        i++;
    }

    // Do-while loop
    printf("Do-while loop:\n");
    i = 0;
    do {
        printf("%d\n", i);
        i++;
    } while (i < 5);

    return 0;
}
```

- **`for (i = 0; i < 5; i++)`**: A `for` loop that initializes `i` to `0`, checks if `i` is less than `5`, and increments `i` after each iteration.
- **`while (i < 5)`**: A `while` loop that continues to execute as long as `i` is less than `5`.
- **`do { ... } while (i < 5);`**: A `do-while` loop that executes the block of code at least once and continues as long as `i` is less than `5`.
