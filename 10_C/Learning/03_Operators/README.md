# Operators in C

## Introduction
This project demonstrates the use of various operators in C, including arithmetic, relational, and logical operators.

## Code Explanation

### `main.c`
```c
#include <stdio.h>

int main() {
    int a = 10, b = 20;
    int sum = a + b;
    int difference = a - b;
    int product = a * b;
    float quotient = (float)a / b;

    printf("Sum: %d\n", sum);
    printf("Difference: %d\n", difference);
    printf("Product: %d\n", product);
    printf("Quotient: %.2f\n", quotient);

    if (a > b) {
        printf("a is greater than b\n");
    } else {
        printf("a is not greater than b\n");
    }

    return 0;
}
```

- **`int sum = a + b;`**: Adds the values of `a` and `b` and stores the result in `sum`.
- **`int difference = a - b;`**: Subtracts `b` from `a` and stores the result in `difference`.
- **`int product = a * b;`**: Multiplies `a` and `b` and stores the result in `product`.
- **`float quotient = (float)a / b;`**: Divides `a` by `b` and stores the result in `quotient`. The `(float)` cast ensures floating-point division.
- **`if (a > b)`**: Checks if `a` is greater than `b` and prints the appropriate message.
