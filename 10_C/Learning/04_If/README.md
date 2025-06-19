# If Statements in C

## Introduction
This project demonstrates the use of `if` statements in C, which allow the program to make decisions based on certain conditions.

## Code Explanation

### `main.c`
```c
#include <stdio.h>

int main() {
    int number = 10;

    if (number > 0) {
        printf("The number is positive.\n");
    } else if (number < 0) {
        printf("The number is negative.\n");
    } else {
        printf("The number is zero.\n");
    }

    return 0;
}
```

- **`if (number > 0)`**: Checks if `number` is greater than `0` and prints "The number is positive." if true.
- **`else if (number < 0)`**: Checks if `number` is less than `0` and prints "The number is negative." if true.
- **`else`**: If neither of the above conditions is true, prints "The number is zero."
