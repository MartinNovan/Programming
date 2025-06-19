# Variables in C

## Introduction
This project demonstrates the use of variables in C. Variables are used to store data that can be manipulated and retrieved throughout the program.

## Code Explanation

### `main.c`
```c
#include <stdio.h>

int main() {
    int number = 10;
    float pi = 3.14;
    char letter = 'A';

    printf("Number: %d\n", number);
    printf("Pi: %.2f\n", pi);
    printf("Letter: %c\n", letter);

    return 0;
}
```

- **`int number = 10;`**: Declares an integer variable `number` and initializes it with the value `10`.
- **`float pi = 3.14;`**: Declares a floating-point variable `pi` and initializes it with the value `3.14`.
- **`char letter = 'A';`**: Declares a character variable `letter` and initializes it with the value `'A'`.
- **`printf("Number: %d\n", number);`**: Prints the value of `number` using the `%d` format specifier.
- **`printf("Pi: %.2f\n", pi);`**: Prints the value of `pi` using the `%f` format specifier, with 2 decimal places.
- **`printf("Letter: %c\n", letter);`**: Prints the value of `letter` using the `%c` format specifier.